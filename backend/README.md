# Backend - TaskManager.Api

API w ASP.NET Core (.NET 10) + PostgreSQL. Tutaj jest obsługa użytkowników,
zadań i komentarzy.

## Co jest zrobione

- rejestracja i logowanie (hasło jest hashowane przez BCrypt, token JWT),
- lista zadań tylko dla zalogowanego użytkownika,
- dodawanie, edycja i usuwanie zadań,
- komentarze do zadań,
- Swagger do testowania API.

## Technologie

- .NET 10 (ASP.NET Core Web API)
- Entity Framework Core 10 + Npgsql
- PostgreSQL 18
- JWT Bearer
- BCrypt.Net-Next
- Swashbuckle (Swagger)

## Jak uruchomić

### 1. Baza

Musi być zainstalowany PostgreSQL i baza `taskmanager`. Skrypty są w
folderze `database/`:

```bash
psql -U postgres -d taskmanager -f database/table-schema.sql
psql -U postgres -d taskmanager -f database/insert-data.sql
```

### 2. Połączenie do bazy

W pliku `backend/TaskManager.Api/appsettings.json` jest connection string:

```json
"ConnectionStrings": {
  "Default": "Host=localhost;Port=5432;Database=taskmanager;Username=postgres;Password=postgres"
}
```

Jak masz inne hasło do użytkownika `postgres`, to zmień `Password=...`.

### 3. Uruchomienie

```bash
cd backend/TaskManager.Api
dotnet restore
dotnet run
```

API działa na `http://localhost:5024`, a Swagger na
`http://localhost:5024/swagger`.

Jak `dotnet` nie jest rozpoznawany, to znaczy że nie ma .NET 10 SDK. Wtedy
trzeba zainstalować:

https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-10.0.402-windows-x64-installer

Sprawdzenie w CMD:

```cmd
dotnet -v
```

Powinno pokazać `10.0.402` (albo inną wersję 10.x).

## Endpointy

| Metoda | Adres | Co robi | Token? |
|---|---|---|---|
| POST | `/api/auth/register` | rejestracja | nie |
| POST | `/api/auth/login` | logowanie | nie |
| GET | `/api/tasks` | lista zadań | tak |
| GET | `/api/tasks/{id}` | jedno zadanie | tak |
| POST | `/api/tasks` | dodanie zadania | tak |
| PUT | `/api/tasks/{id}` | edycja zadania | tak |
| DELETE | `/api/tasks/{id}` | usunięcie zadania | tak |
| GET | `/api/tasks/{id}/comments` | komentarze | tak |
| POST | `/api/tasks/{id}/comments` | dodanie komentarza | tak |

Statusy zadań: `todo`, `in_progress`, `done`.

## Przykład testu (curl)

Rejestracja:

```bash
curl -X POST http://localhost:5024/api/auth/register ^
  -H "Content-Type: application/json" ^
  -d "{\"username\":\"test\",\"email\":\"test@example.com\",\"password\":\"test1234\"}"
```

W odpowiedzi jest `token`. Potem lista zadań:

```bash
curl http://localhost:5024/api/tasks ^
  -H "Authorization: Bearer TU_WKLEJ_TOKEN"
```

Można też wszystko klikać w Swaggerze. W pliku `TaskManager.Api.http` są
gotowe przykłady requestów.

## Struktura

```text
Controllers/  - AuthController, TasksController, CommentsController
Models/       - User, TaskItem, Comment
Data/         - AppDbContext (Entity Framework Core)
Dtos/         - obiekty do requestów i odpowiedzi
Services/     - TokenService (JWT)
Program.cs    - konfiguracja API
```

## Konta testowe

Po odpaleniu `insert-data.sql` można się zalogować na:

- `admin@example.com` / `admin123`
- `jan@example.com` / `admin123`
- `anna@example.com` / `admin123`
- `piotr@example.com` / `admin123`
- `kasia@example.com` / `admin123`

Nowe konta można też tworzyć przez `/api/auth/register`.

## Uwagi

- Frontend na razie czyta `frontend/data/tasks.json` i nie jest podłączony do API.
- Hasło do bazy i klucz JWT są w `appsettings.json`, bo to projekt na praktyki.
- `appsettings.Development.json` jest w `.gitignore`.
- Token jest ważny 120 minut.
- Swagger jest włączony tylko w Development.
