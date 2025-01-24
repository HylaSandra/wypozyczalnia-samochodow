using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_app;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ApiClient _apiClient;

    public MainWindow()
    {
        InitializeComponent();
        _apiClient = new ApiClient();
        //LoadData();
    }

    //private async void LoadData()
    //{
    //    List<Klient> klienci = await _apiClient.GetKlienciAsync();
    //    Console.WriteLine(klienci);
    //    KlientListView.ItemsSource = klienci;
    //}

    private void SamochodyButton_Click(object sender, RoutedEventArgs e)
    {
        // Otwieranie okna Samochody
        SamochodyWindow samochodyWindow = new SamochodyWindow();
        samochodyWindow.Show();
    }

    private void WypozyczeniaButton_Click(object sender, RoutedEventArgs e)
    {
        // Otwieranie okna Wypożyczenia
        WypozyczeniaWindow wypozyczeniaWindow = new WypozyczeniaWindow();
        wypozyczeniaWindow.Show();
    }

    private void KlienciButton_Click(object sender, RoutedEventArgs e)
    {
        // Otwieranie okna Klienci
        KlienciWindow klienciWindow = new KlienciWindow();
        klienciWindow.Show();
    }

    // Zamykanie okna
    private void ZamknijOkno_Click(object sender, RoutedEventArgs e)
    {
        this.Close(); 
    }

}
