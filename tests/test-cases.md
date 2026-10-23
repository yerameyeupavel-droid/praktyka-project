# Co sprawdzałem ręcznie

| Nr | Co | Jak | Ma być |
|---|---|---|---|
| 1 | wczytanie danych | otwieram stronę przez Live Server | widać 5 zadań w kolumnach |
| 2 | dodawanie | wpisuję tytuł, zapisuję | karta w kolumnie Do zrobienia |
| 3 | pusty tytuł | zostawiam puste, zapisuję | pisze "Wpisz tytuł zadania", nie zapisuje |
| 4 | brak opisu | dodaję zadanie bez opisu | na karcie pisze "brak opisu" |
| 5 | edycja i przenoszenie | zmieniam status na Wykonane | karta przechodzi do kolumny Wykonane |
| 6 | usuwanie | klikam Usuń, potwierdzam | karta znika |
| 7 | szukanie | wpisuję fragment tytułu | zostają tylko pasujące karty |
| 8 | telefon | zwężam okno | kolumny układają się jedna pod drugą |
| 9 | logowanie | złe hasło | "Nie udało się zalogować" |
| 10 | baza | table-schema.sql + insert-data.sql na pustej bazie | bez błędów |
| 11 | select | select-training.sql | 4 zapytania zwracają wyniki |
| 12 | rejestracja API | POST /api/auth/register | 200 i token JWT |
| 13 | logowanie API | POST /api/auth/login na nowe konto | 200 i token JWT |
| 14 | lista zadań | GET /api/tasks z tokenem | tylko zadania zalogowanego użytkownika |
| 15 | dodanie zadania | POST /api/tasks | 201, zadanie w bazie |
| 16 | edycja zadania | PUT /api/tasks/{id} | 200, zmieniony status i opis |
| 17 | usuwanie zadania | DELETE /api/tasks/{id} | 204, zadania nie ma na liście |
| 18 | komentarz | POST /api/tasks/{id}/comments | 201, komentarz widoczny w GET |
| 19 | bez tokenu | GET /api/tasks bez nagłówka | 401 |
| 20 | cudze zadanie | drugi użytkownik pyta o zadanie pierwszego | 404 |
| 21 | walidacja | pusty tytuł albo zły status | 400 |
| 22 | duplikat konta | rejestracja na ten sam e-mail | 409 |
| 23 | konto z bazy | login `admin@example.com` / `admin123` | 200 i token JWT |
