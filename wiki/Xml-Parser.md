# 1 Aufgaben des Parsers
Der Parser liest eine XML-Datei `word/document.xml` aus dem OOXML-Verzeichnis. Er liest iterativ jedes XML-Element aus und trägt es, sofern es von Relevanz ist, in eine Instanz von fString ein. Zu letzt vereint er die fString Instanzen in einer Paragraph-Klasse.

Eine gute Quelle zum Office Open XML Standard finden Sie [hier](http://officeopenxml.com/WPcontentOverview.php).

# 2 Ablauf beim Parsen

![Aktivitätsdiagramm Parser](https://i.imgur.com/USkU4tk.png)

An diesem Bild soll veranschaulicht werden, wie der Parser einen Absatz des Xml-Dokuments durchläuft:

 <ul>
  <li>Orange : Der Parser liest Elemente, bis er auf den Beginn eines Absatzes stößt. Eventuell sollte ein Abbruch erfolgen, wenn er das Ende des Dokuments erreicht</li>
  <li>Grün : Der Parser liest, bis ein Run beginnt. Bemerkt er in dieser Zeit, dass eine List deklariert wird, erklärt er den Paragraphen zu einer Liste</li>
  <li>Pink : Der Parser liest, bis er das Ende eines Runs erreicht. Trifft er auf Text, wird dieser dem Rückgabewert hinzugefügt. Ansonsten wird versucht, eine Property aus dem Element zu lesen</li>
</ul> 

# 3 Parser und Speicherklassen

![Parser Klassendiagramm](https://i.imgur.com/O4lo1kz.png)

In dem Klassendiagramm wird dargestellt, wie der Parser lesen soll und wohin er speichert.
fString beinhaltet hierbei alle nötigen Informationen zum Text in einem BitFlag Enumerator, sowie in den Variablen `Size` für Schriftgröße und `Highlight` beziehungsweise `Color` für Farben. 
Sollen diese Informationen für QTI ausgegeben werden, wird eine `PrintQTI()` Methode aufgerufen. 

Zusammengefasst werden die fStrings in einem Array in der Klasse Paragraph. Die Nutzung einer zusätzlichen Klasse List wurde verworfen, da jede Liste aus speziellen Paragraphen besteht. Daher gibt es eine Variable `isList`, die diese Information speichert.
Über `GetEnumerator()` soll über das fString Array iteriert werden, wodurch man für die Ausgabe alle fStrings erhält.

Der Parser selbst wird konstruiert, indem ein String mit dem Pfad des Dokuments übergeben wird. Daraufhin wird ein ZipArchive erstellt und die Datei `word/document.xml` mit dem Textkörper wird an den XmlReader reader übergeben.
Über diesen wird nun, wie oben beschrieben, gelesen und in eine Paragraph-Klasse übergeben. Eventuell sollte der zu beschreibende Paragraph als Referenz übergeben werden, so kann der Rückgabewert bool darüber Auskunft geben, ob bereits das Ende des Dokuments erreicht wurde.

Oft ist es nötig, auf einen bestimmten Tag zu warten. Dafür gibt es die Methode `ScanWhile()`, welche eine Aufgabe erfüllt bis der Parser auf einen bestimmten Tag trifft. Man könnte zum Beispiel eine `Func<bool>` Funktion übergeben, welche die Bedingung für die Beendigung der Schleife angibt, sowie einen Delegaten, der die auszuführende Funktion in der Schleife beeinhaltet.