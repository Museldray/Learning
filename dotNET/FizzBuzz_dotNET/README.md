# Zarządzanie sesją w ASP.NET Core

### Programowanie aplikacji WWW w technologii .NET, 2020/

### Przygotowała: I. Kartowicz-Stolarska

## WYMAGANIA

1. Zainstalowany pakiet NuGet Microsoft.AspNetCore.Session .NET Core 3.
2. Włączone SessionState w Startup.cs
3. Przestrzeń nazw: Microsoft.AspNetCore.Http

## TUTORIAL

1. Zainstaluj pakiet Nuget Microsoft.AspNetCore.Session .NET Core 3.1 oraz
    Newtonsoft.Json (Projekt->Zarządzaj pakietami NuGet)
2. Włącz obsługę sesji w Startup.cs:

```
public void ​ ConfigureServices ​(IServiceCollection services){
...
services.AddMemoryCache();
services.AddSession();
}
```
```
public void ​ Configure ​(IApplicationBuilder app,
IWebHostEnvironment env){
...
```

```
app.useSession();
...
}
```
3. Zamiast AddMemoryCache możesz użyć
    services.AddDistributedMemoryCache();
4. W service.AddSession() możesz ustawić dodatkowe parametry np.

```
services.AddSession(options =>
{
options.IdleTimeout = TimeSpan.FromSeconds(10);
options.Cookie.HttpOnly = true;
options.Cookie.IsEssential = true;
});
```
5. Dodaj nową stronę Razor do projektu (Pages, menu kontekstowe
    Dodaj->Strona Razor) np. o nazwie Address.cshtml.
6. Dodaj nowy element nawigacji do pliku _Layout.cshtml
    <li class="nav-item">
    <a class="nav-link text-dark" asp-area=""
    asp-page="/Address">Session Address</a>
    </li>
7. W pliku Pages/Index.cshtml/Index.cshtml.cs dodaj przestrzeń nazw:
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
8. W pliku Pages/Index.cshtml/Index.cshtml.cs zmodyfikuj funkcję​ _onPost()_
    public IActionResult OnPost() {
       if (ModelState.IsValid){
          **HttpContext.Session.SetString("SessionAddress",**
       **JsonConvert.SerializeObject(Address));**
      **return RedirectToPage("./AddressList");**
    }
    return Page();
    }
9. W pliku Address.cshtml.cs dodaj nowy atrybut Address oraz uzupełnij
    metodę onGet():
    ....
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    ....
    public void OnGet() {
       var SessionAddress =
    HttpContext.Session.GetString("SessionAddress");


```
if (SessionAddress != null ) {
Address =
JsonConvert.DeserializeObject<Address>(sessionAddress);
}
```
10.Zmodyfikuj szablon strony Address.cshtml o wyświetlanie danych
pobranych z sesji:
<p>Dane w zapisane w sesji</p>
@if (Model.Address != null)
{
<p>@Html.DisplayNameFor(model => Model.Address.Street):
@Model.Address.Street </p>
<p>@Html.DisplayNameFor(model => Model.Address.City):
@Model.Address.City </p>
<p>@Html.DisplayNameFor(model => Model.Address.Number):
@Model.Address.Number </p>
<p>@Html.DisplayNameFor(model => Model.Address.ZipCode):
@Model.Address.ZipCode </p>
}

11.Bazując na dokumentacji
https://docs.microsoft.com/pl-pl/aspnet/core/fundamentals/app-state?vie
w=aspnetcore-5.
● sprawdź jak działa HttpContext.Session.SetInt32() i
HttpContext.Session.GetInt32()
● spróbuj zserializować listę obiektów np. listę ostatnio podanych
adresów.

## ZADANIE DOMOWE

Wykonaj aplikację FizzBuzz jak aplikację webową.
Założenia:
- FizzBuzz jest aplikacją webową składającą się z 2 stron: strony głównej oraz
strony “Ostatnio Szukane”.
- Na głównej stronie użytkownik odwiedzający aplikację widzi formularz
przyjmujący jedną liczbę całkowitą z zakresu 1-1000. Jeśli użytkownik poda
liczbę spoza zakresu lub poda inny typ danych np. znaki, powinien zostać
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
użytkownika.
- Wszystkie zmiany powinny zostać zapisane w repozytorium Git.
- Link do repozytorium proszę umieścić na platformie CEZ.


