using System;
using System.Windows;
using System.Collections.Generic;

namespace wpf_app
{
    public partial class SamochodyWindow : Window
    {
        private readonly ApiClient _apiClient;

        public SamochodyWindow()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
            LoadSamochody();
        }

        private async void LoadSamochody()
        {
            try
            {
                // Pobieranie samochodów z API
                var samochody = await _apiClient.GetSamochodyAsync();

                // Przypisywanie danych do ListBox
                SamochodyListBox.ItemsSource = samochody;

                // Przypisywanie danych do ComboBox
                SamochodyComboBox.ItemsSource = samochody;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania samochodów: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Dodawanie nowego samochodu
        private async void DodajSamochod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nowySamochod = new Samochod
                {
                    Marka = MarkaTextBox.Text,
                    Model = ModelTextBox.Text,
                    Paliwo = int.Parse(PaliwoTextBox.Text),
                    Typ = int.Parse(TypTextBox.Text), // Dodano obsługę Typ
                    MocKm = int.Parse(MocKmTextBox.Text),
                    RokProdukcji = int.Parse(RokProdukcjiTextBox.Text),
                    IloscOsob = int.Parse(IloscOsobTextBox.Text),
                    Klimatyzacja = KlimatyzacjaCheckBox.IsChecked ?? false,
                    Nawigacja = NawigacjaCheckBox.IsChecked ?? false,
                    CzujnikiParowania = CzujnikiCheckBox.IsChecked ?? false,
                    CzyDostepny = true
                };

                // Wyślij żądanie POST do API
                await _apiClient.AddSamochodAsync(nowySamochod);
                LoadSamochody();
                MessageBox.Show("Dodano nowy samochód.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania samochodu: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Usuwanie samochodu
        private async void UsunSamochod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SamochodyComboBox.Items.Count == 0)
                {
                    MessageBox.Show("Nie wybrano samochodu do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var wybranySamochod = SamochodyComboBox.SelectedItem as Samochod;
                if (wybranySamochod == null)
                {
                    MessageBox.Show("Proszę wybrać samochód do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Logowanie ID i URL
                Console.WriteLine($"Próbuję usunąć samochód z ID: {wybranySamochod.Id}");
                string requestUrl = $"http://localhost:5000/api/Samochod/{wybranySamochod.Id}";
                Console.WriteLine($"Wysyłam żądanie DELETE na URL: {requestUrl}");

                var wynik = MessageBox.Show($"Czy na pewno chcesz usunąć samochód {wybranySamochod.Marka} {wybranySamochod.Model}?",
                    "Potwierdzenie usunięcia",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (wynik != MessageBoxResult.Yes)
                {
                    return;
                }

                await _apiClient.DeleteSamochodAsync(wybranySamochod.Id);
                LoadSamochody();
                MessageBox.Show("Samochód został usunięty.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas usuwania samochodu: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Zamykanie okna
        private void ZamknijOkno_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
