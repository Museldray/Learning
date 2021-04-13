# Wykonaj aplikację FizzBuzz jak aplikację webową.

Założenia:
- FizzBuzz jest aplikacją webową składającą się z 2 stron: strony głównej oraz
strony “Ostatnio Szukane”.
- Na głównej stronie użytkownik odwiedzający aplikację widzi formularz
przyjmujący jedną liczbę całkowitą z zakresu 1-1000. Jeśli użytkownik poda
liczbę spoza zakresu lub poda inny typ danych np. znaki, powinien zostać
Programowanie aplikacji WWW w technologii .NET, Politechnika Białostocka 2020/2021, IKS
wyświetlony komunikat o błędzie. Błędy oznaczone są na czerwono,
pogrubioną czcionką.
- Na stronie głównej użytkownik otrzymuje informację o wyniku
sprawdzania:
  - 'Otrzymano: Fizz' jeśli podana liczba jest podzielna przez 3
  - 'Otrzymano: Buzz' jeśli podana liczba jest podzielną przez 5
  - 'Otrzymano: FizzBuzz' jeśli liczba jest podzielna przez 3 i 5
  - ‘Liczba: <podana przez użytkownika liczba> nie spełnia kryteriów
Fizz/Buzz’ w pozostałych przypadkach
- Wynik ostatniego sprawdzania (np. Fizz), szukana liczba oraz data
ostatniego szukania powinna zostać zapisana w sesji.
- Na stronie “Ostatnio szukane” wyświetlane jest ostatnie wyszukiwania
użytkownika .
- Wszystkie zmiany powinny zostać zapisane w repozytorium Git.
- Link do repozytorium proszę umieścić na platformie CEZ.

# Zmodyfikuj aplikację FizzBuzz webową z poprzednich zajęć w taki sposób, aby:

- każde zwalidowane wyszukanie (liczba, czas oraz wynik) zostało zapisane w
bazie danych (0.5pkt)
- na stronie “Ostatnio szukane” była dostępna lista 10 ostatnich wyszukiwań
posortowanych malejąco według czasu (0.5pkt)
- aplikacja powinna udostępnić możliwość usunięcia wpisu z historii
(0.25pkt)
- edycja historycznych wpisów nie powinna być dostępna (0.25pkt)

Ponadto:

- Aplikacja nadal powinna realizować zapis danych do sesji. Odczyt z sesji
powinien być dostępny na stronie “Zapisane w sesji” (0.25pkt)
- Wszystkie zmiany powinny zostać zapisane na oddzielnej gałęzi w
istniejącym repozytorium dla aplikacji Fizzbuzz (0.25pkt). Link do
repozytorium proszę umieścić na platformie CEZ.
