# task-manager / praktyka-project

Internetowy system zarządzania zadaniami. Projekt realizowany podczas praktyk zawodowych (INF.03).

## Opis

Aplikacja „Moje Zadania" pozwala użytkownikowi:

- rejestrować się i logować,
- dodawać, edytować i usuwać zadania,
- filtrować zadania po statusie (`do zrobienia` / `w trakcie` / `wykonane`),
- dodawać komentarze do zadań.

## Struktura katalogów

```text
task-manager/
├── frontend/           # HTML, CSS, JS (prototyp UI)
├── backend/            # miejsce na PHP lub ASP.NET Core Web API
├── database/           # skrypty SQL (PostgreSQL 18), kopie zapasowe
├── docs/               # wymagania, projekt wyglądu, ERD, notatki Markdown
├── tests/              # przypadki testowe
├── .github/workflows/  # CI (walidacja Markdown + SQL)
├── .gitignore
└── README.md
```

Git nie zapisuje pustych folderów — w każdym pustym katalogu znajduje się plik `.gitkeep`.

## Szybki start (frontend — prototyp)

Otwórz plik `frontend/index.html` w przeglądarce. Nie wymaga serwera.

## Baza danych (PostgreSQL 18)

```sql
-- utworzenie bazy:
-- CREATE DATABASE taskmanager;
-- \c taskmanager
-- \i database/schema.sql
-- \i database/seed.sql
```

Szczegóły: `database/schema.sql`, `docs/erd.md`.

## Dokumentacja

- `docs/wymagania.md` — wymagania funkcjonalne i niefunkcjonalne,
- `docs/design.md` — makiety, paleta kolorów, czcionki, logo,
- `docs/erd.md` — diagram ERD + opis tabel `USERS`, `TASKS`, `COMMENTS`,
- `docs/notatki-markdown.md` — notatki ze składni Markdown (zadanie zdalne).

## Testy

Przypadki testowe: `tests/test-cases.md`.

## CI

Workflow `.github/workflows/ci.yml` sprawdza obecność kluczowych plików i poprawność składni SQL (jeśli dostępny `psql` / `sqlfluff`).
