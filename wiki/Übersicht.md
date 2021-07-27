# 1 Einleitung

Ziel des Projektes ist es, die Erstellung von ONYX Tests zu erleichtern, indem die Bearbeitung der Tests in Microsoft Word (bzw. vergleichbaren Open XML-fähigen Programmen) ermöglicht wird.

## 2 Grundlegende Funktionsweise
### 2.1 Bestehende Software und Bibliotheken
Informationen zu bestehenden Ansätzen ist [hier](https://github.com/gelbeforelle/SWE-SS21/wiki/Bestehender-Code-und-Software) zu finden.
### 2.2 Verbesserungsansätze
Die Intension hinter der Erstellung eines neuen Tools zur Generierug von ONYX Lerninhalten ist die Integration bestehender Lerninhalte in eine digitale Umgebung.  
In einem idealen Szenario könnten Inhalte über Test-Features in OPAL bereits vor Live-Übungen vermittelt werden. Somit wäre es den Lehrenden möglich, aktiver auf Fehlerschwerpunkte einzugehen. Studierende hätten ein sofortiges Feedback zu ihrer Lösung und könnten, sollte diese falsch sein, bereits selbstständig Missverständnisse ermitteln.  
Die eigentliche Art der Optimierung der Online-Lehrangebote soll jedoch nicht Kern dieser Argumentation sein.  
Beleuchtet werden soll die Frage, was Lehrende davon abhält, interaktive Tests in ihren Veranstaltungen zu nutzen. Nach eigener Recherche zu Möglichkeiten der Erstellung ist uns besonders der Aufwand aufgefallen, Fragen manuell digitalisieren zu müssen. Es existieren zwar sowohl Tools wie ONYX Suite und Standards wie IMS QTI, welche den Import in OPAL ermöglichen, jedoch ist ihre Verbreitung sehr begrenzt und die Bedinung oft mit der Hürde zusätzlicher Programme verbunden.

### 2.3 Ansätze zur Vereinfachung der Testentwicklung
Um diese Hürde zu überwinden möchten wir den Hauptteil der Erstellung von Testfragen in bekannte Software auslagern.
Ein Standard-Anwendungsszenario könnte wie folgt verlaufen:

1. Öffnen des Aufgabentextes in einem geeigneten (Office Open XML-fähigen) Programm  

2. Markierung signifikanter Inhalte (z.B. Antwortfelder, Antwortmöglichkeiten) mittels "Texthervorhebung"  

3. Öffnen in einem in C# geschriebenen Konvertierungsprogramm  

4. Ausgabe als IMS QTI-konforme XML-Datei und Upload in ONYX
![Anwendungsszenario](http://www.plantuml.com/plantuml/png/TLBRQXin47tNLmmkbCHWGvkx2IOb3JHGjxHEQ0fvcKgJjR0qMgHPPvFIVwzMTfqr9GzZ2yxikHpc8Wb6QRnJQMcvneWUK4k8Stbo1FX8ANXIgacaCH7Spjy19XXyhOdXRlOPziOcw7PVZKPgEBngXJZPm507op8SmYTRBLmU0VF4wAs6h25fq6TyNnXd69SGaKtmzfaC52z2CQazEwOnw2P9yA3HwSQXT2A2QPdsTxWENhYGqoD5onMG8qyi_vXyuyJMZa0lWjK4lq9BXIQI5kGg8uFBDr37e2brQGRmkoTnM2I-4nhOjf2hQsJGMpegIvU1LnHB8Gyn-9Tz2V3jvhfxlbRS1xD2rcJWXfB0rIO1_B3F64tsUhkLEjv4Rgr7y2WB8AuiKz_EoSQEpx5R44hRCZv6hE1j_WirO4vRSL7QRVLqBK768kZ0Gfp3_b7QXSPa-6nz4bz-tjqpySh6m1t7FUzTp-Obw4E87Wlf91kF4nXDoocfxcSydfOhcC3vENL5cEcq1npy3vIl3rMUzVD8vTci7--izu2Jru3JNQ0WXVPCNH2Rnhk_)
### 2.4 Entwicklungsschwerpunkte
Folgende Probleme sollen bei der Entwicklung gelöst werden: 

* Dekomprimierung und einlesen von .docx Dateien (Office Open XML)
* Erkennung von XML-Strukturen und Umsetzung in Klassen  
* Verarbeitung in Abhängigkeit der Formatierung zu QTI-konformen XML Dateien
* Behandlung von "besonderen Strukturen" in Dokumenten (Bilder, Tabellen, ...)
* Interpretation verschiedener Fragetypen in IMS QTI
* Integration von [Maxima](https://github.com/gelbeforelle/SWE-SS21/wiki/Maxima) zur Auswertung von Formeln

Folgender Erstentwurf soll das Prinzip verdeutlichen. Als Grundlage des XML Parsers dient die [XMLReader Klasse](https://github.com/gelbeforelle/SWE-SS21/wiki/Bestehender-Code-und-Software)
![Erstentwurf Klassen](https://i.imgur.com/FRNUVbw.png)





