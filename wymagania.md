# Wymagania — „Moje Zadania"

## Funkcjonalne

1. **Rejestracja / logowanie** — e-mail + hasło (hash bcrypt), walidacja, komunikat o błędzie.
2. **Lista zadań** — tytuł, opis, status, termin; wyszukiwarka + filtr statusu.
3. **Dodawanie zadania** — tytuł wymagany (max 200), status domyślnie `todo`.
4. **Edycja zadania** — zmiana tytułu / opisu / statusu / terminu.
5. **Usuwanie zadania** — z potwierdzeniem; usuwa też komentarze (CASCADE).
6. **Komentarze** — dodawanie komentarza do zadania, lista chronologiczna.
7. **Statusy** — `todo` (Do zrobienia), `in_progress` (W trakcie), `done` (Wykonane); zawsze z etykietą tekstową, nie samym kolorem.

## Niefunkcjonalne

- Dostępność: kontrast tekstu ≥ 4,5:1 (AA), focus klawiatury, etykiety formularzy.
- Responsywność: desktop + jedna kolumna ≤ 600 px.
- Baza: PostgreSQL 18, UTF-8, hasła tylko jako hash.
- Kod: `frontend/` bez frameworka (prototyp), `backend/` do rozbudowy (PHP lub ASP.NET Core).
- CI sprawdza strukturę repo na każdy PR do `main`.

## Kryteria akceptacji

- [ ] Pusta lista pokazuje komunikat + CTA „Dodaj zadanie".
- [ ] Pusty tytuł blokuje zapis z komunikatem „Wpisz tytuł zadania."
- [ ] Błędny login pokazuje „Nie udało się zalogować…".
- [ ] Kontrast par z `design.md` ≥ 4,5:1.
- [ ] `schema.sql` + `seed.sql` wykonują się bez błędów na czystej bazie.
