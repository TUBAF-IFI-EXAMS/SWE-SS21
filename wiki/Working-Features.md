Dies ist eine Zusammenfassung, welche Features bisher funktionieren.

Genauere Funktionsweisen der Features sind in der [README.md](https://github.com/gelbeforelle/SWE-SS21/blob/main/README.md) bzw. dort verlinkten Seiten nachzulesen.

## XML Parser ✔️
* extrahieren der xml-Datei ✔️
* Einlesen und Erfassen von Inhalt & Formatierung ✔️

## Konverter für Markierungen ✔️
* Erstellung qti-formatierter Strings: ✔️

## QTI Output ❓
* responseDeclaration ✔️
* outcomeDeclarations ✔️
* itemBody ❓
* responseProcessing 🟡
(responseProcessing beispielhaft für SingleChoice implementiert)

## integrierte Tests ✔️
Für XmlParser vorhanden, Ausführung steht im Konflikt zur GUI und ist im gui Branch daher deaktiviert

## Dokumentation 🟡
* Beipsielcode (und Übersichten) -> Website: [githubPages](https://gelbeforelle.github.io/SWE-SS21/) ✔️

### GUI mit VisualStudio 🟡
* bisher implementiert zur Eingabe von Dateipfaden
* steht im Konflikt mit xUnit Tests und wird bis auf weiteres nicht mit main gemergt
