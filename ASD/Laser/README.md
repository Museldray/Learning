# Problem 3 – Misja
Ziemia weszła w konflikt z obcą cywilizacją, która posiada wyjątkowo niebezpieczną broń mogącą
zniszczyć naszą planetę. Kapitan kosmicznego statku „Enterprise” ma za zadanie unieszkodliwić
wroga. Posiada on rozmieszczenie baz nieprzyjaciela i planuje im przeszkodzić. W tym celu
zostanie użyta nowatorska broń nadprzestrzenna, która niszczy wszystkie obiekty położone w
zasięgu jej wiązki (jej szerokość kątowa to 90 stopni). Mając do dyspozycji współrzędne kątowe
baz nieprzyjaciela należy wyznaczyć optymalny punkt ulokowania broni, by unieszkodliwić jak
najwięcej baz za jednym wystrzałem. Dzięki swoim nadzwyczajnym umiejętnościom
algorytmicznym możesz uratować ziemię!
## Wejście:
W jedynej linii wejścia podana jest liczba n baz nieprzyjaciela (1<=n<=106). W kolejnych n liniach
podane są po dwie liczby całkowite oznaczające współrzędne kątowe kolejnych baz (stopnie od 0
do 359, minuty od 0 do 59) w stosunku do miejsca przetrzymywania broni (mogą się one
powtarzać). Możemy założyć, że kąt 0 stopni to północ, 45 stopni to północny-wschód, 90 stopni to
wschód itd.

## Wyjście:
W pierwszym wierszu wyjścia podana jest maksymalna możliwa liczba zniszczonych baz, jeśli
broń będzie ustawiona pod odpowiednim kątem 

### Przykład:
Wejście (in.txt):
```
7 //7 baz
170 0 //pierwsza baza ma wsp. kątową 170 stopni i 0 minut
95 15 //itd.
0 5
260 0
70 23
190 0
330 38
```
Wyjście (out.txt):
```
3 //przy odpowiednim ustawieniu broni można zniszczyć bazy o wsp. 170, 190 i 260 st
```
