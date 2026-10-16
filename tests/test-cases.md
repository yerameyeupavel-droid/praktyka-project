# Przypadki testowe — „Moje Zadania"

| ID | Tytuł | Kroki | Oczekiwany rezultat |
|---|---|---|---|
| TC-01 | Dodanie zadania z tytułem | 1. Kliknij „Dodaj zadanie" 2. Wpisz tytuł 3. Zapisz | Zadanie na liście ze statusem „Do zrobienia" |
| TC-02 | Walidacja pustego tytułu | 1. Otwórz formularz 2. Zostaw pusty tytuł 3. Zapisz | Komunikat „Wpisz tytuł zadania.", brak zapisu |
| TC-03 | Edycja statusu | 1. „Edytuj" 2. Zmień status na „Wykonane" 3. Zapisz | Badge „Wykonane", zielone tło + tekst |
| TC-04 | Usuwanie z potwierdzeniem | 1. „Usuń" 2. Potwierdź | Zadanie znika; komentarze usuwane (CASCADE) |
| TC-05 | Filtrowanie | 1. Wybierz filtr „W trakcie" | Tylko zadania `in_progress` |
| TC-06 | Błędne logowanie | 1. Zły e-mail/hasło 2. „Zaloguj" | „Nie udało się zalogować…" |
| TC-07 | Kontrast | Sprawdź pary z `design.md` w Contrast Checker | Wszystkie ≥ 4,5:1 |
| TC-08 | SQL seed | `schema.sql` + `seed.sql` na czystej bazie | Brak błędów, 3 zadania + 1 komentarz |
