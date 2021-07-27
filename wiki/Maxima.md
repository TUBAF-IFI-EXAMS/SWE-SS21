## Was ist Maxima?
Maxima ist eine weiterentwickelte Version des in den 1960ern am MIT mit CommonLisp entwickelten Computeralgebrasystems "Macsyma". <br>
Es lassen sich primär algebraische Ausdrücke darstellen und ausführen, aber auch Dokumentation mithilfe von Textzeilen, Überschriften, Bildern, ... einfügen. <br>
Eine Befehlseingabe ist über die Konsole oder über die Benutzeroberfläche wxMaxima möglich. Zusätzlich lassen sich Funktionen mit gnuplot darstellen. <br>
Maxima ist frei zugänglich und plattformunabhängig und kann somit gut weiterentwickelt werden.

## Welche Funktionen sind für uns relevant?
In unserem Programm soll MAXIMA vorrangig zur Auswertung von eingegebenen Formeln dienen. <br>
...

## Aufbau und Syntax
Maxima besteht aus Input -und Output-Zeilen, welche mit %i._index_ bzw. %o._index_ bezeichnet werden.
Grundlegend gibt es nur Zahlentypen: ganze, rationale, reelle und komplexe Zahlen. Zusätzlich sind etliche Konstanten mit shortcuts aufrufbar (z. B. `%pi`).

### Operatoren
Es können übliche Operatoren wie +, -, *, /, ^, ... verwendet werden.

### Funktionen
* Wurzel `sqrt()`
* Exponentialfunktion `exp()`
* Logarithmus `log()`
* Betrag `abs()`
* Signum `signum()`
* Winkelfunktionen `sin()`, `cos()`, ...
<br>

* `solve()` -> z. B. zum Lösen von Gleichungen
* differenzieren `diff()`
* integrieren `integrate()`

Um eine Funktion auf die letzte Ausgabe anzuwenden, kann in die Klammern ein "%" gesetzt werden. Z. B.: <br>
`%i1 a: 3-5;` <br>
`%o1 -2` <br>
`%i2 abs(%);` <br>
`%o2 2` (?)

### Definition von Variablen und Funktionen
* Variablen: `Variablenname : Wert` (z. B. `a: 5`, `a: x=3`)
* Funktionen: `Funktionsname := Funktion` (z. B. `f(x) := x^2+3`, `f(x,y,z) := x+y+z`)

### if-else und Schleifen
...

## Integration von Maxima in C#
...