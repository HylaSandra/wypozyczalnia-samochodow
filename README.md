# Aplikacja wypożyczalni samochodów

Autorzy: Karolina Ciszowska, Daniel Jurczyk, Sandra Hyla
Aplikacja wypożyczalni samochodów od strony firmy wypożyczającej.

Funkcjonalności aplikacji: 
- Wypożyczenie samochodu
- Dodanie klienta
- Dodanie/usunięcie samochodu

Struktura bazy danych:
- Samochod: Id, marka, model, rok, moc, ile osob, typ, czy usunięty, udogodnienia*
- Klient: Id, Imie, Nazwisko, Nazwa, PESEL, NIP, NrTelefonu, DowodOsobisty
- Wypozyczenie: Id, IdKlient, IdSamochod, DataOd, DataDo, Ilosc, TypIlosci, Stawka, Kwota
- Slownik: Id, SlownikId





