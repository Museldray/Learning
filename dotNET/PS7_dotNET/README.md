# Utwórz własny middleware (0.5pkt dla IApplicationBuilder lub  0.25pkt dla postaci zanonimizowanej), który:

## Wariant 1: 0.25pkt
wypisuje na stronie WWW zawartość zmiennej User-Agent zapisanej w nagłówkach żądania (zmienna Request.Headers w kontekście)

lub

## Wariant 2: 0.5pkt
sprawdza nazwę przeglądarki. Dla przeglądarek: Edge, EdgeChromium i IE middleware zwraca komunikat "Przeglądarka nie jest obsługiwana". W przypadku innych przeglądarek użytkownik powinien otrzymać  żądaną stronę. 

W celu sprawdzanie nazwy przeglądarki z której wysłane jest żądanie możesz użyć zewnętrznego pakietu.

 Max: 1 pkt
