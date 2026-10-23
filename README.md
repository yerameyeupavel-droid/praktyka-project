# praktyka-project - Moje Zadania

Repo na praktyki, INF.03. Aplikacja do zapisywania zadań (tablica w 3
kolumnach) + API w .NET 10.

## Co to jest

Tablica zadań. Są 3 kolumny: Do zrobienia, W trakcie, Wykonane.
Można dodawać zadania, edytować i usuwać. Jak zmienić status w formularzu,
to karta sama przechodzi do właściwej kolumny. Jest też szukanie i logowanie
(na razie prototyp).

Frontend na razie wczytuje dane z pliku `frontend/data/tasks.json`. Backend
(`backend/TaskManager.Api`) jest osobną częścią i ma własne API + bazę
PostgreSQL. Frontend nie jest jeszcze podłączony do API.

## Gdzie co jest

```text
frontend/   - strona (index.html, css/style.css, js/app.js, data/tasks.json, assets)
backend/    - API ASP.NET Core (.NET 10) + Entity Framework Core
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

## Jak odpalić backend

1. Zainstaluj .NET 10 SDK. Sprawdzenie w CMD:

```cmd
dotnet -v
```

Ma pokazać `10.0.402` (albo inną wersję 10.x). Jak nie ma, to installer:

https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-10.0.402-windows-x64-installer

2. Baza `taskmanager` musi istnieć (patrz wyżej).
3. W folderze projektu:

```bash
cd backend/TaskManager.Api
dotnet restore
dotnet run
```

4. Swagger: `http://localhost:5024/swagger`

Konta testowe z bazy: `admin@example.com` / `admin123` (tak samo jan, anna,
piotr i kasia). Szczegóły są w `backend/README.md`.

## Docs

- `docs/design.md` - kolory, czcionki, logo, makiety
- `docs/erd.md` - baza, tabele USERS, TASKS, COMMENT
- `docs/kopia-zapasowa.docx` - backup i restore (z opisem kroków)
- `docs/uprawnienia-role.docx` - użytkownik tylko do SELECT
- `docs/notatki-markdown.md` - moje notatki z Markdown
- `backend/README.md` - jak uruchomić API i jakie są endpointy

## Testy

`tests/test-cases.md` - lista rzeczy, które sprawdzam ręcznie. API testowałem
przez Swaggera i plik `.http`.

## Uwagi

- Frontend to na razie prototyp i czyta dane z `tasks.json`.
- Logowanie na stronie zawsze pokazuje błąd, bo nie jest podłączone do API.
- Backend ma własne logowanie (JWT) i osobną bazę.
- W tabeli na komentarze nazwa jest `comment` (tak jak w zadaniu).
