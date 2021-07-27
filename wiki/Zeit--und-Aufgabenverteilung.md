-> [Aufgabenverteilung](https://github.com/gelbeforelle/SWE-SS21/wiki/Aufgabenverteilung)

# Inhalt
... geht das automatisch? <br>
* Extrahieren der xml-Datei <br>
* Einlesen der xml-Datei und Erfassen der Texte und Formatierungen <br>
* Auswertung der Formatierung <br>
  -> Auswertung in C# <br>
  -> Erstellen eines Tutorials für den Nutzer <br>
* Umwandlung in Onyx-Code <br>
* Ausgabe/Speichern als Onyx-Dokument zum Hochladen auf Opal <br>
* ggf. Integrierung von Maxima <br>

## Programmablauf

![Programmablauf](https://i.imgur.com/r2E846D.png)

* Xml Parser liest formatierte Strings ein und speichert sie in Klassen des Ixml Interface (vorerst Paragraph)
* Paragraphs werden zur "Auswertung der Formatierung" weitergegeben
* Markierte Fragen werden hier erkannt und zusammen mit dem Fragentext an eine Output Klasse gegeben
* Diese generiert in einer Datei das QTI XML Dokument

# Extrahieren der xml-Datei
Zunächst muss die xml-Datei zum Word-Dokument extrahiert werden, um den Inhalt und Formatierungen auslesen zu können.

**Zuständigkeit**: @gelbeforelle <br>
**Zeitaufwand**: gering <br>
**Aktueller Stand der Bearbeitung**: <br>
abgeschlossen ✔️

# Einlesen der xml-Datei und Erfassen der Texte und Formatierungen
Die xml-Datei muss zunächst Schritt für Schritt nach Befehlen abgesucht werden.
Die Befehle sollen vom Programm erkannt werden und in eine Klassenhierarchie eingeordnet werden.
(siehe [Xml-Parser](https://github.com/gelbeforelle/SWE-SS21/wiki/Xml-Parser))

**Zuständigkeit**: @gelbeforelle <br>
**Zeitaufwand**: hoch <br>
**Aktueller Stand der Bearbeitung**: <br>
abgeschlossen ✔️

# Auswertung der Formatierung
## Auswertung in C#
Der Inhalt und die Formatierung einzelner Abschnitte sind separiert und zueinander zugeordnet.
Nun soll das Programm den Formatierungen konkrete _Funktionen_ (Text, Aufgabe, Frage, Antwort, Lücke, ...) zuordnen.

**Zuständigkeit**: @hannah-knst <br>
**Zeitaufwand**: mittel <br>
**Aktueller Stand der Bearbeitung**: <br>
noch nicht begonnen

## Erstellen eines Tutorials für den Nutzer
Der Ersteller der Word-Dokumente, die für Opal nutzbar sein sollen, muss wissen, wie welcher Inhalt dargestellt werden muss, damit er von unserem Programm als Text, Frage, Antwort, Lücke, Formel, ... erkannt wird.
Dazu soll ein Tutorial.md erstellt werden, indem sämtliche Funktionen genannt und beschrieben werden, und zusätzlich ein beispielhaftes Word-Dokument, welches dem Nutzer als Vorlage dienen kann.

**Zuständigkeit**: @hannah-knst <br>
**Zeitaufwand**: gering <br>
**Aktueller Stand der Bearbeitung**: <br>
noch nicht begonnen

# Umwandlung in Onyx-Code

Die nun erkannten Funktionen einzelner Abschnitte müssen in Onyx-Code umgewandelt werden.

**Zuständigkeit**: @hannah-knst <br>
**Zeitaufwand**: hoch <br>
**Aktueller Stand der Bearbeitung**: <br>
einlesen zu Onyx-Code

## Methoden zur Erstellung Qti-formatierter strings
**Zuständigkeit**: @gelbeforelle <br>
**Zeitaufwand**: mittel <br>
**Aktueller Stand der Bearbeitung**: <br>
Vorabversion im qti-output branch 🟡
 

# ~~Ausgabe/Speichern als Onyx-Dokument zum Hochladen auf Opal ???~~
~~Der Onyx-Code der einzelnen Abschnitte wird nun zusammengefasst, strukturiert und soll letztendlich als eine Code-Datei ausgegeben/gespeichert werden.~~

**Zuständigkeit**: @gelbeforelle <br>
**Zeitaufwand**: mittel? <br>
**Aktueller Stand der Bearbeitung**: <br>
abgebrochen und in "Umwandlung zu ONYX-Code" vereint 

# Optionale Features

## ~~Integration Maxima~~
~~siehe [Maxima](https://github.com/gelbeforelle/SWE-SS21/wiki/Maxima#welche-funktionen-sind-f%C3%BCr-uns-relevant)~~

**Zuständigkeit**: @hannah-knst <br>
**Zeitaufwand**: mittel <br>
**Aktueller Stand der Bearbeitung**: <br>
einlesen zur Funktionsweise von Maxima (in Onyx)
auf unbestimmte Zeit ausgesetzt

## GUI

**Zuständigkeit**: @gelbeforelle <br>
**Zeitaufwand**: mittel <br>
**Aktueller Stand der Bearbeitung**: <br>
Proof of concept in gui branch