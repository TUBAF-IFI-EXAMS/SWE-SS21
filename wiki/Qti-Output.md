# 1 Übersicht QTI
Zu beachten sind die [Kurzübersicht](http://www.imsglobal.org/spec/qti/v3p0/guide), [ausführliche Dokumentation](http://www.imsglobal.org/spec/qti/v3p0/impl) und die [OPAL-Teststruktur](https://github.com/gelbeforelle/SWE-SS21/wiki/Struktur-der-Tests-auf-OPAL).

# 2 Funktionsweise des Qti Output
Der Qti Output soll (vorläufig) eine Erweiterungsmethode für StreamWriter beinhalten. In dieser wird durch ein Array der Klasse `Question` iteriert und, je nach Typ der aktuellen Frage, Strings ausgegeben. Zuerst wird für jede Frage eine "Answer declaration" mit Informationen zu den korrekten Antworten erstellt. Folgendes Aktivitätsdiagramm stellt dar, welchen Prozess jede Frage durchläuft.

![Diagramm Deklaration](https://i.imgur.com/suDKqtF.png)

Danach wird für den Text der Frage sowie der Multiple Choice Antworten folgendes Diagramm abermals für jede Frage realisiert

![Diagramm Textausgabe](https://i.imgur.com/IRZfcnB.png)