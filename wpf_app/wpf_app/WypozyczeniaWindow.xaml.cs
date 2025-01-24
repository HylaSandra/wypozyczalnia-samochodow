using System;
using System.Windows;
using wpf_app.Controls;
using wpf_app.Models;

namespace wpf_app
{
    public partial class WypozyczeniaWindow : Window
    {
        private readonly ApiClient _apiClient;

        public WypozyczeniaWindow()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
            LoadWypozyczenia();
        }

        private async Task LoadWypozyczenia()
        {
            try
            {
                var wypozyczenia = await _apiClient.GetWypozyczeniaAsync();
                WypozyczeniaListView.ItemsSource = wypozyczenia;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania wypożyczeń: {ex.Message}");
            }
        }

        private async void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Pobranie daty i czasu z elementów DateTimePicker
                if (!DataOdDateTimePicker.SelectedDateTime.HasValue || !DataDoDateTimePicker.SelectedDateTime.HasValue)
                {
                    MessageBox.Show("Wprowadź poprawne daty i godziny dla 'Data i Czas Od' oraz 'Data i Czas Do'.");
                    return;
                }

                DateTime dataOd = DataOdDateTimePicker.SelectedDateTime.Value;
                DateTime dataDo = DataDoDateTimePicker.SelectedDateTime.Value;

                // Tworzenie obiektu Wypozyczenie
                var wypozyczenie = new Wypozyczenie
                {
                    IdKlient = int.Parse(IdKlientaTextBox.Text),
                    IdSamochod = int.Parse(IdSamochoduTextBox.Text),
                    DataOd = dataOd,
                    DataDo = dataDo,
                    Ilosc = int.Parse(IloscTextBox.Text),
                    TypIlosci = int.Parse(TypIlosciTextBox.Text),
                    Stawka = decimal.Parse(StawkaTextBox.Text),
                    Kwota = decimal.Parse(KwotaTextBox.Text)
                };

                // Wysyłanie danych do API
                await _apiClient.AddWypozyczenieAsync(wypozyczenie);

                // Odświeżenie widoku
                await LoadWypozyczenia();

                MessageBox.Show("Wypożyczenie zostało dodane.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania wypożyczenia: {ex.Message}");
            }
        }
        private void ZamknijOkno_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Zamyka okno
        }

        private async void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            if (WypozyczeniaListView.SelectedItem is Wypozyczenie wypozyczenie)
            {
                try
                {
                    await _apiClient.DeleteWypozyczenieAsync(wypozyczenie.Id);
                    LoadWypozyczenia();
                    MessageBox.Show("Wypożyczenie usunięte pomyślnie.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas usuwania wypożyczenia: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Wybierz wypożyczenie do usunięcia.");
            }
        }
    }
}
