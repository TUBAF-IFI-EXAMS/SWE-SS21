<br> Ein OPAL-Test besteht aus Parts, Sections und Items. <br><br>
![Beispielschema](http://www.imsglobal.org/sites/default/files/spec/qti/v3/guide/img/image7.png) <br>
_Besipielschema_

## Parts
_Parts_ unterteilen den OPAL-Tests in verschiedene Seiten. Dabei lässt sich mit _weiter_ und _zurück_ zwischen diesen Seiten navigieren. Man kann einstellen, dass nur weitergeklickt werden und man nicht auf eine abgeschlossene Seite zurück gelangen kann. <br>
Jeder OPAL-Test muss mindestens einen _Part_ beinhalten.

## Sections
_Sections_ unterteilen die Parts in Aufgabenbereiche. <br>
Jeder _Part_ muss mindestens eine _Section_ beinhalten. <br>
_Sections_ können weiter untergliedert sein, also wieder _Sections_ beinhalten.

## Items
Ein _Item_ ist grundlegend in Beschreibung (Text, Bilder, Tabellen, ...), konkrete Frage/Aufgabe und Interaktionsfeld zum Antworten unterteilt. <br>
Jede _(Unter-)Section_ muss mindestens ein _Item_ beinhalten.

### Quellcode OPAL
![GrobeStruktur_ItemQuellcode](http://www.imsglobal.org/sites/default/files/spec/qti/v3/guide/img/image5.png) <br>
_grobe Struktur des Quellcodes für ein Item_


Zunächst müssen allg. Informationen zum Dokument (-> in der Eröffnung von _qti-assessment-item_), die richtige Antwort (-> _qti-response-declaration_) und die Punktevergabe (-> _qti-outcome-declaration_) definiert/geklärt werden. <br>

Beipielcode: <br>
`<qti-assessment-item
xmlns="http://www.imsglobal.org/xsd/qti/imsqtiasi_v3p0" 
xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
xsi:schemaLocation="http://www.imsglobal.org/xsd/imsqtiasi_v3p0 
https://purl.imsglobal.org/spec/qti/v3p0/schema/xsd/imsqti_asiv3p0_v1p0.xsd"
identifier="firstexample"
time-dependent="false" 
xml:lang="en-US">` <br>
(`</qti-assessment-item>` kommt ganz am Ende des Quellcodes)

`<qti-response-declaration base-type="identifier" cardinality="single" identifier="RESPONSE">
   <qti-correct-response>
     <qti-value>A</qti-value>
   </qti-correct-response>
 </qti-response-declaration>`

 `<qti-outcome-declaration base-type="float" cardinality="single" identifier="SCORE">
   <qti-default-value>
     <qti-value>1</qti-value>
   </qti-default-value>
 </qti-outcome-declaration>` <br><br>

Jetzt kommt der eigentliche Inhalt (-> _qti-item-body_):

`<qti-item-body>` <br>
`<p>Of the following hormones, which is produced by the adrenal glands?</p>` <br>
  `<qti-choice-interaction max-choices="1" min-choices="1" ` <br>
  `response-identifier="RESPONSE">` <br>
    `<qti-simple-choice identifier="A">Epinephrine</qti-simple-choice>` <br>
    `<qti-simple-choice identifier="B">Glucagon</qti-simple-choice>` <br>
    `<qti-simple-choice identifier="C">Insulin</qti-simple-choice>` <br>
    `<qti-simple-choice identifier="D">Oxytocin</qti-simple-choice>` <br>
  `</qti-choice-interaction>` <br>
`</qti-item-body>` <br>

Schließlich muss noch die Auswertung der Antwort implementiert werden (-> _qti-response-processing_). <br>
In OPAL existieren hier bereits Standard-Prozesse, auf die einfach verlinkt werden kann.
(z.B.: `<qti-response-processing
template="https://purl.imsglobal.org/spec/qti/v3p0/rptemplates/match_correct"/>`) <br>
-> hier: _match-correct_ gibt 1 Punkt, wenn die Antwort mit der zuvor angegebenen korrekten Antwort übereinstimmt und ansonsten 0 Punkte. <br>
Nach der Struktur der Beispielcodes können natürlich auch eigene Auswertungscodes geschrieben werden.

## Quellen
http://www.imsglobal.org/spec/qti/v3p0/guide