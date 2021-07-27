
# Existierender Code

## 1 Bestandteile des Codes

<p>Zur Übersicht über bestehenden Code sollen die geplanten Elemente dienen. Diese sind</p>

* Parser von Office Open XML
* Einbindung von Maxima und Formatierung nach IMS QTI XML
* Export als XML Datei

### 1.1 Open Office XML Parser

Der Open Office XML Standard (.docx) wird vorrangig von Microsoft Word verwendet. Es handelt sich um ein komprimiertes ZIP-Archiv, welches verschiedene XML-Dateien zur Beschreibung von Text und Textstrukturen, sowie graphische Elemente enthält.  
Ein großer Vorteil ist die strikte Trennung von Text und Medien, was die Verarbeitung erleichtert.  
Um Open Office XML zu lesen gibt es eine Vielzahl an Möglichkeiten. Microsoft selbst stellt den [Open XML SDK](https://docs.microsoft.com/de-de/office/open-xml/open-xml-sdk) , auch andere Alternativen wie die [DocX Library](https://github.com/xceedsoftware/DocX) wären denkbar. Nachteil bei diesen Lösungen ist ihre Komplexität, die für das Parsen in diesem Projekt schlichtweg nicht benötigt wird. Stattdessen soll versucht werden, eine simple Klasse zur Speicherung von Text und zugehörige Attributen erstellt zu werden. Dazu wird die [ZipFile Klasse](https://docs.microsoft.com/de-de/dotnet/api/system.io.compression.zipfile?view=net-5.0) sowie die [XMLReader Klasse](https://docs.microsoft.com/de-de/dotnet/api/system.xml.xmlreader?view=net-5.0) genutzt.


### 1.2 IMS QTI Formatierung
Der IMS QTI Standard für XML Dokumente wird bereits von vielen Programmen genutzt. Dazu gehören die [QTI SDK](https://github.com/oat-sa/qti-sdk), [Moodle](https://github.com/moodle/moodle) oder eben ONYX. Aufgrund ihrer Komplexität lassen sie sich nur begrenzt als Referenz verwenden.
Eine ausgiebige Liste lässt sich auf [Wikipedia](https://en.wikipedia.org/wiki/QTI) finden.  
Die Dokumentation zu QTI ist [hier](http://www.imsglobal.org/spec/qti/v3p0/guide#h.vc15ylnm99k8) zu finden.

### 1.3 Maxima Math Engine

Die [Maxima Math Engine](https://github.com/gelbeforelle/SWE-SS21/wiki/Maxima) erlaubt, neben vielen weiteren CAS Features, die Auswertung von Formeln. Maxima erlaubt es, Ausdrücke auf Äquivalenz zu überprüfen und ermöglicht so die Eingabe von automatisch bewerteten Formeln.
Maxima wird von vielen Programmen für verschiedene mathematische Aufgaben genutzt. Praktischerweise lässt sich hierfür die Export Funktion der ONYX Suite für die sonst schlecht dokumentierte Einbindung in QTI als Referenz verwenden.
