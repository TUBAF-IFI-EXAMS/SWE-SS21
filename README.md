
# Willkommen beim WordToQti Parser
Dieser Parser erlaubt es, simple Test aus Office Open XML (.docx) Dateien zu erstellen und unter anderem in der Testplattform ONYX einzulesen.
***
In dieser README Datei wird erklärt, wie der Parser verwendet wird und wo weitere Informationen zu finden sind.

## 1 Praktisches Anwendungsziel

In der Praxis soll WordToQti ermöglichen, aus speziell formatierten Word-Dokumenten sogenannte QTI-Tests zu erstellen, welche Online-Testplattformen lesen können.
Dazu hinterlegt der Nutzer Stellen, welche als Fragen interpretiert werden sollen.
Eine Textbox kann also durch einen farbig hinterlegten Text dargestellt werden, eine Multiple Choice Frage durch eine farbig hinterlegte Liste.

Genauere Informationen zur Markierungssyntax finden Sie [hier](https://github.com/gelbeforelle/SWE-SS21/wiki/Festlegung-von-Markierungsstandards).

Neben den Markierungen zur Formatierung der Tests wird zudem eine GUI geplant.

## 2 Komponenten
### 2.1 Xml Parser
Dieses Tool dient dazu, OOXML Dateien einzulesen. Dazu wird lediglich ein Pfad benötigt, der über den Konstruktor `XmlParser(path)` initialisiert wird, danach kann mit `ReadSection(out Paragraph)` nacheinander jeder Abschnitt gelesen werden.
Der Text wird in der out Variable `Paragraph` gespeichert.

Weitere Informationen zum Parser und der Paragraph Klasse finden Sie [hier](https://github.com/gelbeforelle/SWE-SS21/wiki/Xml-Parser).
Sehen Sie sich dazu auch die Dokumentation zum Parser und den Paragraphs an TODO

### 2.2 Konverter für Markierungen
Im Konverter wird eine `Paragraph` Klasse nach Formatierungsschlüsseln untersucht und in eine `Question` Klasse zur Speicherung eines Tests umgewandelt.

Weitere Informationen zur Question Klasse finden Sie hier. TODO
Sehen Sie sich dazu auch die Dokumentation zu Questions an. TODO

### 2.3 Wizard
Nachdem der Konverter erkannt hat, welche Fragen erstellt werden sollen, übergibt er sie an einen Wizard. Hier wird in einer GUI unter anderem festgelegt, wieviele Antworten es auf eine Multiple Choice Frage geben soll, welche richtig sind, und so weiter.

Weiter Informationen zum Wizard finden Sie hier. TODO

### 2.4 Qti Output
Im letzten Schritt wird eine Output Methode aufgerufen. Diese Methode erweitert den `StreamWriter` um eine Methode, welche ein `Question` Array akzeptiert und daraus einen QTI-Test generiert.

Weiter Informationen zum Qti Output finden Sie [hier](https://github.com/gelbeforelle/SWE-SS21/wiki/Qti-Output).
Sehen Sie sich dazu auch die Dokumentation zum Qti Output an. TODO


