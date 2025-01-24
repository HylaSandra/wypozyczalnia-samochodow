# Wypożyczalnia samochodów

Aplikacja wypożyczalni samochodów to program umożliwiający zarządzanie flotą pojazdów, klientami oraz procesem wypożyczeń. Aplikacja składa się z interfejsu użytkownika wykonanego z użyciem silnika **WPF** oraz backendu opartego na **ASP.NET Core** z podłączeniem do bazy danych **SQL Server**.


**Autorzy**: Karolina Ciszowska, Daniel Jurczyk, Sandra Hyla

## Funkcjonalności
### Zarządzanie flotą samochodów:
- dodawanie i usuwanie samochodów
- przechowywanie danych (marka, model, paliwo, moc, rocznik, klimatyzacja, nawigacja)
### Zarządzanie klientami:
- dodawanie, usuwanie i edytowanie klientów
- przechowywanie danych (imię, nazwisko, PESEL, NIP, telefon)
### Obsługa wypożyczeń:
- wybór samochodu i klienta
- wybór daty i godziny wynajmu
- wyliczanie kosztów wypożyczenia
### Połączenie z bazą danych SQL:
- przechowywanie danych w Entity Framework Core
### Interfejs użytkownika WPF:
- aplikacja okienkowa z głównym oknem wyboru i osobnymi widokami klientów, samochodów i wypożyczeń

## Technologie
- **Frontend:** WPF (C#)
- **Backend:** ASP.NET Core
- **Baza danych:** SQL Server, Entity Framework
- **System kontroli wersji:** GitHub
### Backend (ASP.NET Core):
Aplikacja backendowa dizała jako REST API i udostępnia kontrolery:
- `SamochodController.cs` -> zarządzenie samochodami (GET/api/Samochod)
- `KlientController.cs` -> zarządzanie klientami (GET/api/Klient)
- `WypozyczenieController.cs` -> zarządzanie wypożyczeniami (POST/api/Wypozyczenie)
#### Obsługa bazy danych:
Wykorzystano Entity Framework Core, który mapuje modele na tabelę w bazie SQL Server.

### Frontend (WPF)
Interfejs użytkownika został utworzony w technologii Windows Presentation Foundation (WPF).
- `MainWindow.xaml` –> ekran główny z nawigacją
- `SamochodyWindow.xaml` –> lista samochodów, dodawanie i usuwanie
- `KlienciWindow.xaml` –> lista klientów, dodawanie, usuwanie i edycja
- `WypozyczeniaWindow.xaml` –> panel wypożyczeń
- `DateTimePicker.xaml.cs` –> niestandardowy komponent do wyboru daty i godziny
- `BoolToYesNoConverter.cs` -> konwerter true/false na tak/nie

Komunikacja z API odbywa się za pomocą `ApiClient.cs`, która wysyła zapytania HTTP do backendu.

W aplikacji zastosowano specialne style zmieniające wygląd przycisków w zależności od interakcji użytkownika (najazd myszki, kliknięcie) z użyciem `Trigger` i `ControlTemplate`.

W każdym z okien znajduje się pogląd rekordów z bazy danych na żywo:
- ![Samochody](master/images/db-samochody.png)
- ![Klienci](master/images/db-klienci.png)
- ![Wypozyczenia](master/images/db-wypozyczenia.png)


## Instalacja i uruchamianie
### Wymagania:
- .NET 6.0 (lub wyższa wersja)
- SQL Server
- Visual Studio 2022 (lub wyższa wersja) z odpowiednimi rozszerzeniami do obsługi WPF i ASP.NET Core
### Uruchamianie:
1. Sklonowanie repozytorium.
2. Stworzenie bazy danych SQL Server Managment Studio używająs poleceń z pliku `BazaDanych.sql`.
3. Zmiana w pliku **appsettings.json** nazwy serwera na własny w `ConnectionStrings`.
4. Uruchomienie backendu: `wypozyczalnia_backend.sln`.
5. Uruchomienie frontendu: `wpf_app.sln`.
### Korzystanie:
- Po uruchomieniu aplikacji pojawi się ekran główny, z którego można przejść do innych sekcji (Samochody, Klienci, Wypożyczenia).
- W sekcji Samochody usunięcie samochodu znajduje się poniżej wyświetlanej listy samochodów. Należy wybrać samochód z listy i kliknąć przycisk usuń.
- W poszczególnych oknach można przewijać za pomocą rolki myszy.
- Przycisk `X` służy do zamknięcia danego okna.

## Elementy obiektowości
### Dziedziczenie:
Klasy **Samochod**, **Klient**. **Wypozyczenie** dziedziczą po **BaseModel**.
### Hermetyzacja:
Pola klas są prywatne, dostępne przez metody.
### Polimorfizm:
Klasa **ApiClient** obsługuje modele **Samochod**, **Klient**, **Wypozyczenie**.
### Interfejsy:
Obsługa konwersji **BoolToYesNoConverter.cs**.
## Diagram klas

### Opis klas:

- **Klient**
    - `Id`: Unikalny identyfikator klienta.
    - `Imie`: Imię klienta.
    - `Nazwisko`: Nazwisko klienta.
    - `PESEL`: Numer PESEL klienta.
    - `NrTelefonu`: Numer telefonu klienta.

- **Samochod**
    - `Id`: Unikalny identyfikator samochodu.
    - `Marka`: Marka samochodu.
    - `Model`: Model samochodu.
    - `RokProdukcji`: Rok produkcji samochodu.
    - `Paliwo`: Typ paliwa samochodu.

- **Wypozyczenie**
    - `Id`: Unikalny identyfikator wypożyczenia.
    - `IdKlient`: Identyfikator klienta, który wypożyczył samochód.
    - `IdSamochod`: Identyfikator samochodu, który został wypożyczony.
    - `DataOd`: Data rozpoczęcia wypożyczenia.
    - `DataDo`: Data zakończenia wypożyczenia.

Wszystkie powyższe klasy dziedziczą po klasie `BaseModel`, która zawiera:
- `Id`: Unikalny identyfikator obiektu.

## Dodatkowe informacje
### Logowanie:
Próbowano zaimplementować logowanie użytkownika z loginem i hasłem, ale zostało to porzucone w późniejszym etapie tworzenia aplikacji.
### Styl tabel:
Próbowano w całości zmodyfikować wszystkie kontrolki typu ComboBox, DateTimePicker, ale czynność była czasochłonna i część zmian porzucono.



