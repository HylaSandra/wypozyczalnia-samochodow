# Wypo�yczalnia samochod�w

Aplikacja wypo�yczalni samochod�w to program umo�liwiaj�cy zarz�dzanie flot� pojazd�w, klientami oraz procesem wypo�ycze�. Aplikacja sk�ada si� z interfejsu u�ytkownika wykonanego z u�yciem silnika **WPF** oraz backendu opartego na **ASP.NET Core** z pod��czeniem do bazy danych **SQL Server**.


**Autorzy**: Karolina Ciszowska, Daniel Jurczyk, Sandra Hyla

## Funkcjonalno�ci
### Zarz�dzanie flot� samochod�w:
- dodawanie i usuwanie samochod�w
- przechowywanie danych (marka, model, paliwo, moc, rocznik, klimatyzacja, nawigacja)
### Zarz�dzanie klientami:
- dodawanie, usuwanie i edytowanie klient�w
- przechowywanie danych (imi�, nazwisko, PESEL, NIP, telefon)
### Obs�uga wypo�ycze�:
- wyb�r samochodu i klienta
- wyb�r daty i godziny wynajmu
- wyliczanie koszt�w wypo�yczenia
### Po��czenie z baz� danych SQL:
- przechowywanie danych w Entity Framework Core
### Interfejs u�ytkownika WPF:
- aplikacja okienkowa z g��wnym oknem wyboru i osobnymi widokami klient�w, samochod�w i wypo�ycze�

## Technologie
- **Frontend:** WPF (C#)
- **Backend:** ASP.NET Core
- **Baza danych:** SQL Server, Entity Framework
- **System kontroli wersji:** GitHub
### Backend (ASP.NET Core):
Aplikacja backendowa diza�a jako REST API i udost�pnia kontrolery:
- `SamochodController.cs` -> zarz�dzenie samochodami (GET/api/Samochod)
- `KlientController.cs` -> zarz�dzanie klientami (GET/api/Klient)
- `WypozyczenieController.cs` -> zarz�dzanie wypo�yczeniami (POST/api/Wypozyczenie)
#### Obs�uga bazy danych:
Wykorzystano Entity Framework Core, kt�ry mapuje modele na tabel� w bazie SQL Server.

### Frontend (WPF)
Interfejs u�ytkownika zosta� utworzony w technologii Windows Presentation Foundation (WPF).
- `MainWindow.xaml` �> ekran g��wny z nawigacj�
- `SamochodyWindow.xaml` �> lista samochod�w, dodawanie i usuwanie
- `KlienciWindow.xaml` �> lista klient�w, dodawanie, usuwanie i edycja
- `WypozyczeniaWindow.xaml` �> panel wypo�ycze�
- `DateTimePicker.xaml.cs` �> niestandardowy komponent do wyboru daty i godziny
- `BoolToYesNoConverter.cs` -> konwerter true/false na tak/nie

Komunikacja z API odbywa si� za pomoc� `ApiClient.cs`, kt�ra wysy�a zapytania HTTP do backendu.

W aplikacji zastosowano specialne style zmieniaj�ce wygl�d przycisk�w w zale�no�ci od interakcji u�ytkownika (najazd myszki, klikni�cie) z u�yciem `Trigger` i `ControlTemplate`.

W ka�dym z okien znajduje si� pogl�d rekord�w z bazy danych na �ywo:
- ![Samochody](images/db-samochody.png)
- ![Klienci](images/db-klienci.png)
- ![Wypozyczenia](images/db-wypozyczenia.png)


## Instalacja i uruchamianie
### Wymagania:
- .NET 6.0 (lub wy�sza wersja)
- SQL Server
- Visual Studio 2022 (lub wy�sza wersja) z odpowiednimi rozszerzeniami do obs�ugi WPF i ASP.NET Core
### Uruchamianie:
1. Sklonowanie repozytorium.
2. Stworzenie bazy danych SQL Server Managment Studio u�ywaj�s polece� z pliku `BazaDanych.sql`.
3. Zmiana w pliku **appsettings.json** nazwy serwera na w�asny w `ConnectionStrings`.
4. Uruchomienie backendu: `wypozyczalnia_backend.sln`.
5. Uruchomienie frontendu: `wpf_app.sln`.
### Korzystanie:
- Po uruchomieniu aplikacji pojawi si� ekran g��wny, z kt�rego mo�na przej�� do innych sekcji (Samochody, Klienci, Wypo�yczenia).
- W sekcji Samochody usuni�cie samochodu znajduje si� poni�ej wy�wietlanej listy samochod�w. Nale�y wybra� samoch�d z listy i klikn�� przycisk usu�.
- W poszczeg�lnych oknach mo�na przewija� za pomoc� rolki myszy.
- Przycisk `X` s�u�y do zamkni�cia danego okna.

## Elementy obiektowo�ci
### Dziedziczenie:
Klasy **Samochod**, **Klient**. **Wypozyczenie** dziedzicz� po **BaseModel**.
### Hermetyzacja:
Pola klas s� prywatne, dost�pne przez metody.
### Polimorfizm:
Klasa **ApiClient** obs�uguje modele **Samochod**, **Klient**, **Wypozyczenie**.
### Interfejsy:
Obs�uga konwersji **BoolToYesNoConverter.cs**.
## Diagram klas

### Opis klas:

- **Klient**
    - `Id`: Unikalny identyfikator klienta.
    - `Imie`: Imi� klienta.
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
    - `Id`: Unikalny identyfikator wypo�yczenia.
    - `IdKlient`: Identyfikator klienta, kt�ry wypo�yczy� samoch�d.
    - `IdSamochod`: Identyfikator samochodu, kt�ry zosta� wypo�yczony.
    - `DataOd`: Data rozpocz�cia wypo�yczenia.
    - `DataDo`: Data zako�czenia wypo�yczenia.

Wszystkie powy�sze klasy dziedzicz� po klasie `BaseModel`, kt�ra zawiera:
- `Id`: Unikalny identyfikator obiektu.

## Dodatkowe informacje
### Logowanie:
Pr�bowano zaimplementowa� logowanie u�ytkownika z loginem i has�em, ale zosta�o to porzucone w p�niejszym etapie tworzenia aplikacji.
### Styl tabel:
Pr�bowano w ca�o�ci zmodyfikowa� wszystkie kontrolki typu ComboBox, DateTimePicker, ale czynno�� by�a czasoch�onna i cz�� zmian porzucono.



