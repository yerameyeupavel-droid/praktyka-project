# praktyka-project - Moje Zadania

Repo na praktyki, INF.03. Aplikacja do zapisywania zadań (tablica w 3 kolumnach).

## Co to jest

Tablica zadań. Są 3 kolumny: Do zrobienia, W trakcie, Wykonane.
Można dodawać zadania, edytować i usuwać. Jak zmienię status w formularzu,
to karta sama przechodzi do właściwej kolumny. Jest też szukanie i logowanie
(na razie prototyp, bez backendu).

Dane wczytują się z pliku `frontend/data/tasks.json`. Zmiany nie zapisują się
po odświeżeniu strony, bo nie ma jeszcze backendu.

## Gdzie co jest

```text
frontend/   - strona (index.html, css/style.css, js/app.js, data/tasks.json, assets)
backend/    - tu później będzie API
database/   - table-schema.sql, insert-data.sql, select-training.sql
docs/       - design, ERD, dokumenty (backup, role), notatki
tests/      - co sprawdzałem ręcznie
```

## Jak odpalić stronę

Nie otwieraj `index.html` bezpośrednio z dysku, bo wtedy `fetch` nie wczyta
`data/tasks.json` (przeglądarka blokuje pliki lokalne).

1. Otwórz folder w VS Code.
2. Zainstaluj rozszerzenie **Live Server**.
3. Kliknij prawym na `frontend/index.html` -> **Open with Live Server**.
4. Strona otworzy się na `http://127.0.0.1:5500/frontend/index.html`.

## Jak odpalić bazę

1. Instalujesz PostgreSQL 18 (hasło `postgres`).
2. Tworzysz bazę `taskmanager`.
3. Odpalasz skrypty:

```bash
psql -U postgres -d taskmanager -f database/table-schema.sql
psql -U postgres -d taskmanager -f database/insert-data.sql
psql -U postgres -d taskmanager -f database/select-training.sql
```

## Docs

- `docs/design.md` - kolory, czcionki, logo, makiety
- `docs/erd.md` - baza, tabele USERS, TASKS, COMMENT
- `docs/kopia-zapasowa.docx` - backup i restore (z opisem kroków)
- `docs/uprawnienia-role.docx` - użytkownik tylko do SELECT
- `docs/notatki-markdown.md` - moje notatki z Markdown

## Testy

`tests/test-cases.md` - lista rzeczy, które sprawdzam ręcznie.

## Uwagi

- Frontend to na razie prototyp (bez backendu).
- Logowanie zawsze pokazuje błąd, bo nie ma API.
- W tabeli na komentarze nazwa jest `comment` (tak jak w zadaniu).
