using System;
using System.Text.Json;
using System.Windows;

namespace wpf_app;

public partial class KlienciWindow : Window
{
    private readonly ApiClient _apiClient;

    public KlienciWindow()
    {
        InitializeComponent();
        _apiClient = new ApiClient();
        LoadKlienci();
    }

    // Wczytanie listy klientów z API
    private async void LoadKlienci()
    {
        try
        {
            var klienci = await _apiClient.GetKlienciAsync();
            KlienciListView.ItemsSource = klienci;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas ładowania klientów: {ex.Message}");
        }
    }

    // Dodanie nowego klienta
    private async void DodajKlienta_Click(object sender, RoutedEventArgs e)
    {
        // Walidacja danych wejściowych
        if (string.IsNullOrWhiteSpace(ImieTextBox.Text))
        {
            MessageBox.Show("Pole 'Imię' nie może być puste.");
            return;
        }

        if (string.IsNullOrWhiteSpace(NazwiskoTextBox.Text))
        {
            MessageBox.Show("Pole 'Nazwisko' nie może być puste.");
            return;
        }

        long pesel = 0; // Domyślna wartość numeru PESEL
        if (string.IsNullOrWhiteSpace(PESELTextBox.Text))
        {
            MessageBox.Show("PESEL nie może być pusty. Ustawiono wartość domyślną: 0.");
        }
        else if (!long.TryParse(PESELTextBox.Text, out pesel))
        {
            MessageBox.Show("PESEL musi być liczbą.");
            return;
        }

        // Tworzenie nowego obiektu Klient
        var nowyKlient = new Klient
        {
            Imie = ImieTextBox.Text,
            Nazwisko = NazwiskoTextBox.Text,
            Nazwa = NazwaTextBox.Text,
            Pesel = pesel,
            NrTelefonu = NrTelefonuTextBox.Text,
            DowodOsobisty = DowodOsobistyTextBox.Text
        };

        try
        {
            await _apiClient.AddKlientAsync(nowyKlient);
            LoadKlienci();
            MessageBox.Show("Dodano nowego klienta.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas dodawania klienta: {ex.Message}");
        }
    }


    // Edycja klienta
    private async void EdytujKlienta_Click(object sender, RoutedEventArgs e)
    {
        if (KlienciListView.SelectedItem is not Klient wybranyKlient)
        {
            MessageBox.Show("Nie wybrano klienta do edycji.");
            return;
        }

        // Walidacja danych wejściowych
        if (string.IsNullOrWhiteSpace(ImieTextBox.Text))
        {
            MessageBox.Show("Pole 'Imię' nie może być puste.");
            return;
        }

        if (string.IsNullOrWhiteSpace(NazwiskoTextBox.Text))
        {
            MessageBox.Show("Pole 'Nazwisko' nie może być puste.");
            return;
        }

        long pesel = 0;
        if (string.IsNullOrWhiteSpace(PESELTextBox.Text))
        {
            MessageBox.Show("PESEL nie może być pusty. Ustawiono wartość domyślną: 0.");
        }
        else if (!long.TryParse(PESELTextBox.Text, out pesel))
        {
            MessageBox.Show("PESEL musi być liczbą.");
            return;
        }

        // Aktualizacja wybranego klienta
        wybranyKlient.Imie = ImieTextBox.Text;
        wybranyKlient.Nazwisko = NazwiskoTextBox.Text;
        wybranyKlient.Nazwa = NazwaTextBox.Text;
        wybranyKlient.Pesel = pesel;
        wybranyKlient.NrTelefonu = NrTelefonuTextBox.Text;
        wybranyKlient.DowodOsobisty = DowodOsobistyTextBox.Text;

        try
        {
            Console.WriteLine(JsonSerializer.Serialize(wybranyKlient)); // Logowanie obiektu przed wysłaniem
            await _apiClient.UpdateKlientAsync(wybranyKlient.Id, wybranyKlient);
            LoadKlienci();
            MessageBox.Show("Zaktualizowano dane klienta.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas edytowania klienta: {ex.Message}");
        }
    }

    // Usunięcie klienta
    private async void UsunKlienta_Click(object sender, RoutedEventArgs e)
    {
        if (KlienciListView.SelectedItem is not Klient wybranyKlient)
        {
            MessageBox.Show("Nie wybrano klienta do usunięcia.");
            return;
        }

        try
        {
            await _apiClient.DeleteKlientAsync(wybranyKlient.Id);
            LoadKlienci();
            MessageBox.Show("Usunięto klienta.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas usuwania klienta: {ex.Message}");
        }
    }

    // Metoda pomocnicza do parsowania PESEL
    private long? TryParsePesel(string peselText)
    {
        return long.TryParse(peselText, out var pesel) ? pesel : null;
    }

    private void PESELTextBox_TextChanged()
    {

    }

    // Zamknięcie okna
    private void ZamknijOkno_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}


