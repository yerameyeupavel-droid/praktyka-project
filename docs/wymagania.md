# Co ma robić apka

## Musi być

1. Logowanie - email + hasło, jak złe to błąd.
2. Tablica zadań - 3 kolumny według statusu (Do zrobienia, W trakcie, Wykonane).
3. Dodawanie - tytuł wymagany, bez tytułu nie zapisze.
4. Karta zadania - pokazuje tytuł i opis, jak nie ma opisu to pisze "brak opisu".
5. Edycja - można zmienić tytuł, opis i status. Po zapisie karta idzie do właściwej kolumny.
6. Usuwanie - pyta "czy na pewno", karta znika.
7. Szukanie po tytule i opisie.

Statusy: todo, in_progress, done.

## Backend

- API w .NET 10 (ASP.NET Core Web API) + PostgreSQL.
- Rejestracja i logowanie, hasło hashowane przez BCrypt, token JWT.
- CRUD zadań tylko dla zalogowanego użytkownika.
- Komentarze do zadań.
- Swagger do testowania.
- Tabele: users, tasks, comment.

## Inne

- Ma działać na telefonie (jedna kolumna).
- Kolory czytelne, kontrast powyżej 4,5.
- Baza PostgreSQL.
- Dane nie mogą być wstawiane przez `innerHTML` (bezpieczeństwo).

## Kiedy uznaję że działa

- [ ] pusta kolumna pokazuje "Brak zadań"
- [ ] bez tytułu nie da się dodać
- [ ] zmiana statusu przenosi kartę do innej kolumny
- [ ] usuwanie działa po potwierdzeniu
- [ ] `table-schema.sql` odpala się bez błędów
- [ ] `insert-data.sql` dodaje po 5 rekordów
- [ ] `dotnet -v` pokazuje wersję 10.x
- [ ] backend startuje przez `dotnet run` i otwiera się Swagger
- [ ] rejestracja i logowanie zwracają token
- [ ] zadania i komentarze działają na bazie `taskmanager`
