# Blog – posty z komentarzami i ręczną moderacją (ASP.NET Core)

Projekt przedstawia prostą aplikację typu blog z:
- listą postów,
- możliwością dodawania komentarzy,
- ręczną moderacją komentarzy (approve),
- publicznym widokiem pokazującym wyłącznie zatwierdzone komentarze.

Backend został zrealizowany w **ASP.NET Core Web API**, a frontend jako **minimalny HTML + JavaScript**.

---

## Funkcjonalności

### Posty
- Dodawanie postów (title, body)
- Lista postów
- Publiczny widok treści posta

### Komentarze
- Dodawanie komentarzy do posta (author, body)
- Nowe komentarze mają domyślnie status `approved = false`
- Publiczny widok pokazuje wyłącznie zatwierdzone komentarze

### Moderacja
- Lista komentarzy oczekujących na zatwierdzenie
- Ręczne zatwierdzanie komentarzy (approve)
- Zatwierdzony komentarz jest natychmiast widoczny publicznie

---

## Model danych

```sql
Posts(
  Id,
  Title,
  Body,
  CreatedAt
)

Comments(
  Id,
  PostId,
  Author,
  Body,
  CreatedAt,
  Approved
)
```
- Relacja: Comments.PostId → Posts.Id
- Approved domyślnie = 0 (false)

---

## Technologie

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- HTML + JavaScript (bez frameworków)

---

## Uruchomienie projektu

- Sklonuj repozytorium.
- Skonfiguruj połączenie do SQL Server w appsettings.json.
- Utwórz bazę danych i uruchom skrypt SQL.
- Uruchom aplikację:
```
dotnet run
```
- Aplikacja będzie dostępna pod adresem:
```
https://localhost:XXXX
```
- Swagger:
```
https://localhost:XXXX/swagger
```
- Publiczny UI:
```
https://localhost:XXXX/index.html
```
- Panel moderatora:
```
https://localhost:XXXX/moderator.html
```
XXXX odpowiada portowi, który może być różny w zależności od środowiska.

---

## UI

Minimalny interfejs użytkownika znajduje się w:
```
wwwroot/index.html
```
Umożliwia:
- przeglądanie postów,
- wyświetlanie treści posta,
- przeglądanie zatwierdzonych komentarzy,
- dodawanie nowych komentarzy.

Panel moderatora znajduje się w:
```
wwwroot/moderator.html
```
Umożliwia:
- przeglądanie komentarzy oczekujących,
- zatwierdzanie komentarzy.

---

## Testy API

Plik test.rest zawiera przykładowe wywołania API:
- tworzenie postów,
- dodawanie komentarzy,
- moderację komentarzy,
- weryfikację widoczności komentarzy przed i po zatwierdzeniu.
Testy przedstawiają poprawny scenariusz „happy path” oraz wybrane przypadki błędów.

---

## Uwagi końcowe

- Zastosowano DTO w postaci record dla spójności i niemutowalności
- Modele domenowe nie zawierają kolekcji (relacje realizowane przez ID)
- Walidacja nie jest powielana w kontrolerach
- Projekt ma charakter edukacyjny i demonstracyjny
