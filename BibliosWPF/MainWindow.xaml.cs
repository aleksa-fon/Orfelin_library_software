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
using Orfelin;
using Orfelin.Core.DTO;
using Orfelin.WPF;
using Orfelin.WPF.Services;

namespace Orfelin.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LoginResponse _ulogovaniKorisnik;
        private readonly ApiService _apiService;
        public MainWindow(LoginResponse _ulogovaniKorisnik)

        {
            InitializeComponent();
            this._ulogovaniKorisnik = _ulogovaniKorisnik;
            _apiService = new ApiService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtKorisnik.Text = $"{_ulogovaniKorisnik.Ime} {_ulogovaniKorisnik.Prezime}\n{_ulogovaniKorisnik.Uloga}";

            if (_ulogovaniKorisnik.Uloga == "Rukovodilac")
                btnZaposleni.Visibility = Visibility.Visible;

            // Učitaj knjige kao početni ekran
            mainFrame.Navigate(new KnjigePage(_apiService));
        }

        private void btnKnjige_Click(object sender, RoutedEventArgs e) =>
            mainFrame.Navigate(new KnjigePage(_apiService));

        private void btnCitaoci_Click(object sender, RoutedEventArgs e) =>
            mainFrame.Navigate(new KorisnikPage(_apiService));

        private void btnPozajmice_Click(object sender, RoutedEventArgs e) =>
            mainFrame.Navigate(new PozajmicaPage(_apiService));

        private void btnZaposleni_Click(object sender, RoutedEventArgs e) =>
            mainFrame.Navigate(new ZaposleniPage(_apiService));

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}