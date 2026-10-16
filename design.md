# Projekt wyglądu aplikacji „Moje Zadania"

> Branch: `design` → Pull Request do `main`. Katalog: `docs/`.

## 1. Założenia

Prosta, czytelna aplikacja do zarządzania zadaniami. Priorytet: szybkie dodawanie zadań, czytelna lista, dostępność (kontrast min. 4,5:1 dla zwykłego tekstu, status nigdy oznaczany samym kolorem — zawsze z etykietą tekstową).

Grupa docelowa: uczniowie / małe zespoły, głównie desktop, z responsywną wersją mobilną (jedna kolumna).

## 2. Paleta kolorów (HEX)

| Rola | HEX | Zastosowanie |
|---|---|---|
| Główny (primary) | `#1D4ED8` | Przyciski główne, linki, logo |
| Dodatkowy (secondary) | `#0F766E` | Akcenty, ikony, drugi typ akcji |
| Tło aplikacji | `#F8FAFC` | Tło strony |
| Tło kart / formularzy | `#FFFFFF` | Karty zadań, formularze |
| Tekst główny | `#0F172A` | Nagłówki, treść, etykiety |
| Tekst pomocniczy | `#475569` | Opisy, daty, placeholdery |
| Błąd / usuwanie | `#DC2626` | Walidacja, przycisk „Usuń" |
| Status „Do zrobienia" — tło | `#E2E8F0` | Badge |
| Status „Do zrobienia" — tekst | `#334155` | Napis na badge |
| Status „W trakcie" — tło | `#DBEAFE` | Badge |
| Status „W trakcie" — tekst | `#1E40AF` | Napis na badge |
| Status „Wykonane" — tło | `#DCFCE7` | Badge |
| Status „Wykonane" — tekst | `#166534` | Napis na badge |

Podgląd: [coolors.co](https://coolors.co/1d4ed8-0f766e-f8fafc-0f172a-475569) (paleta odtworzona ręcznie).

### Kontrast (sprawdzone w WebAIM Contrast Checker)

Metoda: względna luminancja wg WCAG 2.1, minimum 4,5:1 dla zwykłego tekstu (AA).

| Tekst | Tło | Kontrast | AA (tekst zwykły) |
|---|---|---|---|
| `#0F172A` | `#F8FAFC` | 17,06:1 | Spełnia |
| `#0F172A` | `#FFFFFF` | 17,85:1 | Spełnia |
| `#475569` | `#FFFFFF` | 7,58:1 | Spełnia |
| `#475569` | `#F8FAFC` | 7,24:1 | Spełnia |
| `#FFFFFF` | `#1D4ED8` | 6,70:1 | Spełnia |
| `#FFFFFF` | `#0F766E` | 5,47:1 | Spełnia |
| `#FFFFFF` | `#DC2626` | 4,83:1 | Spełnia |
| `#334155` | `#E2E8F0` | 8,40:1 | Spełnia |
| `#1E40AF` | `#DBEAFE` | 7,15:1 | Spełnia |
| `#166534` | `#DCFCE7` | 6,49:1 | Spełnia |

Uwaga: jaśniejszy odcień teal `#0D9488` (3,74:1 z bielą) odrzuciłem do tekstu na przyciskach — dlatego dodatkowy to ciemniejszy `#0F766E`. Wyniki dotyczą podanych par, sprawdź ponownie na [webaim.org/resources/contrastchecker](https://webaim.org/resources/contrastchecker/).

## 3. Czcionki (Google Fonts)

- **Nagłówki: [Poppins](https://fonts.google.com/specimen/Poppins)** — 600/700, 24–32 px (H1 30 px, H2 22 px). Geometryczna, dobrze wygląda w logo i nagłówkach, pełne wsparcie polskich znaków (latin-ext).
- **Treść / UI: [Inter](https://fonts.google.com/specimen/Inter)** — 400 (treść 16 px, pomocniczy 14 px), 500 (przyciski, etykiety). Zaprojektowana do UI, wysoka czytelność małych rozmiarów, polskie znaki.

Dlaczego dwie rodziny: Poppins daje charakter nagłówkom, Inter zapewnia czytelność długich opisów i formularzy. Ograniczenie do 2 rodzin = szybsze ładowanie i spójność. Import:

```html
<link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;700&family=Poppins:wght@600;700&display=swap" rel="stylesheet" />
```

## 4. Logo

`images/logo.svg` — niebieski kwadrat z zaokrągleniem + biała „fajka" na liście (3 linie zadań, jedna odhaczona). Obok napis „Moje Zadania" (Poppins 700). Działa też samo (favicon / nagłówek mobilny).

![Logo — Moje Zadania](images/logo.svg)

## 5. Makiety ekranów

Makiety poglądowe (SVG w `images/`). Prototyp klikalny: `frontend/index.html`.

### 5.1 Lista zadań

Góra: logo + nazwa + „Wyloguj". Poniżej H1 „Moje zadania", pasek: [+ Dodaj zadanie] + wyszukiwarka + filtr statusu. Karty zadań: tytuł, opis, badge statusu, „Edytuj" / „Usuń". Pusta lista → komunikat + CTA. Usunięcie z potwierdzeniem `confirm()`.

```text
+--------------------------------------------------+
| [logo] Moje Zadania                [Wyloguj]     |
+--------------------------------------------------+
| Moje zadania                                     |
| [+ Dodaj zadanie] [Szukaj...] [Status: Wszystkie]|
+--------------------------------------------------+
| Zadanie: Przygotować ERD                         |
| Tabele USERS, TASKS, COMMENTS  [W trakcie]       |
| [Edytuj] [Usuń]                                  |
+--------------------------------------------------+
| Zadanie: Zrobić makiety                          |
| Lista, formularz, logowanie    [Wykonane]        |
| [Edytuj] [Usuń]                                  |
+--------------------------------------------------+
```

![Makieta listy zadań](images/lista-zadan.svg)

### 5.2 Formularz dodawania zadania

Pola: Tytuł* (max 200), Opis, Status (select), Termin (date, opcjonalnie). Akcje: [Dodaj zadanie] (primary) + [Anuluj] (ghost). Błąd przy pustym tytule: „Wpisz tytuł zadania."

```text
+----------------------------------+
| Dodaj zadanie                    |
| Tytuł* [________________]        |
| Opis   [________________]        |
| Status [Do zrobienia v]          |
| Termin [____-__-__]              |
| [Dodaj zadanie] [Anuluj]         |
+----------------------------------+
```

![Makieta formularza dodawania](images/dodawanie-zadania.svg)

### 5.3 Formularz edycji zadania

Ten sam układ, pola wypełnione („Przygotować ERD" + status „W trakcie"), przycisk [Zapisz zmiany], link „← Wróć do listy".

![Makieta formularza edycji](images/edycja-zadania.svg)

### 5.4 Ekran logowania

Wyśrodkowana karta 380 px: logo, H1 „Zaloguj się", E-mail + Hasło (z „Pokaż"), [Zaloguj się], błąd: „Nie udało się zalogować. Sprawdź adres e-mail i hasło." Bez linku rejestracji w prototypie (do dodania z backendem).

```text
+----------------------------------+
|        [logo]                    |
|        Zaloguj się               |
| E-mail [jan@example.com]         |
| Hasło  [••••••••] [Pokaż]        |
| [      Zaloguj się      ]        |
+----------------------------------+
```

![Makieta logowania](images/logowanie.svg)

## 6. Mobile (600 px i mniej)

Jedna kolumna, toolbar układa się pionowo (przycisk / wyszukiwarka / filtr na 100% szerokości), karty zadań pełna szerokość, formularze bez kolumn bocznych, topbar zwarty. Focus klawiatury widoczny (outline 2 px `#1D4ED8`).

## 7. Pliki

```text
docs/
├── design.md
└── images/
    ├── logo.svg
    ├── lista-zadan.svg
    ├── dodawanie-zadania.svg
    ├── edycja-zadania.svg
    └── logowanie.svg
frontend/
├── index.html   # prototyp zgodny z makietami
├── style.css    # zmienne z palety powyżej
└── app.js
```
