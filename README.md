# Wypo¿yczalnia samochodów

Aplikacja wypo¿yczalni samochodów to program umo¿liwiaj¹cy zarz¹dzanie flot¹ pojazdów, klientami oraz procesem wypo¿yczeñ. Aplikacja sk³ada siê z interfejsu u¿ytkownika wykonanego z u¿yciem silnika **WPF** oraz backendu opartego na **ASP.NET Core** z pod³¹czeniem do bazy danych **SQL Server**.


**Autorzy**: Karolina Ciszowska, Daniel Jurczyk, Sandra Hyla

## Funkcjonalnoœci
### Zarz¹dzanie flot¹ samochodów:
- dodawanie i usuwanie samochodów
- przechowywanie danych (marka, model, paliwo, moc, rocznik, klimatyzacja, nawigacja)
### Zarz¹dzanie klientami:
- dodawanie, usuwanie i edytowanie klientów
- przechowywanie danych (imiê, nazwisko, PESEL, NIP, telefon)
### Obs³uga wypo¿yczeñ:
- wybór samochodu i klienta
- wybór daty i godziny wynajmu
- wyliczanie kosztów wypo¿yczenia
### Po³¹czenie z baz¹ danych SQL:
- przechowywanie danych w Entity Framework Core
### Interfejs u¿ytkownika WPF:
- aplikacja okienkowa z g³ównym oknem wyboru i osobnymi widokami klientów, samochodów i wypo¿yczeñ

## Technologie
- **Frontend:** WPF (C#)
- **Backend:** ASP.NET Core
- **Baza danych:** SQL Server, Entity Framework
- **System kontroli wersji:** GitHub
### Backend (ASP.NET Core):
Aplikacja backendowa diza³a jako REST API i udostêpnia kontrolery:
- `SamochodController.cs` -> zarz¹dzenie samochodami (GET/api/Samochod)
- `KlientController.cs` -> zarz¹dzanie klientami (GET/api/Klient)
- `WypozyczenieController.cs` -> zarz¹dzanie wypo¿yczeniami (POST/api/Wypozyczenie)
#### Obs³uga bazy danych:
Wykorzystano Entity Framework Core, który mapuje modele na tabelê w bazie SQL Server.

### Frontend (WPF)
Interfejs u¿ytkownika zosta³ utworzony w technologii Windows Presentation Foundation (WPF).
- `MainWindow.xaml` –> ekran g³ówny z nawigacj¹
- `SamochodyWindow.xaml` –> lista samochodów, dodawanie i usuwanie
- `KlienciWindow.xaml` –> lista klientów, dodawanie, usuwanie i edycja
- `WypozyczeniaWindow.xaml` –> panel wypo¿yczeñ
- `DateTimePicker.xaml.cs` –> niestandardowy komponent do wyboru daty i godziny
- `BoolToYesNoConverter.cs` -> konwerter true/false na tak/nie

Komunikacja z API odbywa siê za pomoc¹ `ApiClient.cs`, która wysy³a zapytania HTTP do backendu.

W aplikacji zastosowano specialne style zmieniaj¹ce wygl¹d przycisków w zale¿noœci od interakcji u¿ytkownika (najazd myszki, klikniêcie) z u¿yciem `Trigger` i `ControlTemplate`.

W ka¿dym z okien znajduje siê pogl¹d rekordów z bazy danych na ¿ywo:
- ![Samochody](images/db-samochody.png)
- ![Klienci](images/db-klienci.png)
- ![Wypozyczenia](images/db-wypozyczenia.png)


## Instalacja i uruchamianie
### Wymagania:
- .NET 6.0 (lub wy¿sza wersja)
- SQL Server
- Visual Studio 2022 (lub wy¿sza wersja) z odpowiednimi rozszerzeniami do obs³ugi WPF i ASP.NET Core
### Uruchamianie:
1. Sklonowanie repozytorium.
2. Stworzenie bazy danych SQL Server Managment Studio u¿ywaj¹s poleceñ z pliku `BazaDanych.sql`.
3. Zmiana w pliku **appsettings.json** nazwy serwera na w³asny w `ConnectionStrings`.
4. Uruchomienie backendu: `wypozyczalnia_backend.sln`.
5. Uruchomienie frontendu: `wpf_app.sln`.
### Korzystanie:
- Po uruchomieniu aplikacji pojawi siê ekran g³ówny, z którego mo¿na przejœæ do innych sekcji (Samochody, Klienci, Wypo¿yczenia).
- W sekcji Samochody usuniêcie samochodu znajduje siê poni¿ej wyœwietlanej listy samochodów. Nale¿y wybraæ samochód z listy i klikn¹æ przycisk usuñ.
- W poszczególnych oknach mo¿na przewijaæ za pomoc¹ rolki myszy.
- Przycisk `X` s³u¿y do zamkniêcia danego okna.

## Elementy obiektowoœci
### Dziedziczenie:
Klasy **Samochod**, **Klient**. **Wypozyczenie** dziedzicz¹ po **BaseModel**.
### Hermetyzacja:
Pola klas s¹ prywatne, dostêpne przez metody.
### Polimorfizm:
Klasa **ApiClient** obs³uguje modele **Samochod**, **Klient**, **Wypozyczenie**.
### Interfejsy:
Obs³uga konwersji **BoolToYesNoConverter.cs**.
## Diagram klas

### Opis klas:

- **Klient**
    - `Id`: Unikalny identyfikator klienta.
    - `Imie`: Imiê klienta.
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
    - `Id`: Unikalny identyfikator wypo¿yczenia.
    - `IdKlient`: Identyfikator klienta, który wypo¿yczy³ samochód.
    - `IdSamochod`: Identyfikator samochodu, który zosta³ wypo¿yczony.
    - `DataOd`: Data rozpoczêcia wypo¿yczenia.
    - `DataDo`: Data zakoñczenia wypo¿yczenia.

Wszystkie powy¿sze klasy dziedzicz¹ po klasie `BaseModel`, która zawiera:
- `Id`: Unikalny identyfikator obiektu.

## Dodatkowe informacje
### Logowanie:
Próbowano zaimplementowaæ logowanie u¿ytkownika z loginem i has³em, ale zosta³o to porzucone w póŸniejszym etapie tworzenia aplikacji.
### Styl tabel:
Próbowano w ca³oœci zmodyfikowaæ wszystkie kontrolki typu ComboBox, DateTimePicker, ale czynnoœæ by³a czasoch³onna i czêœæ zmian porzucono.



