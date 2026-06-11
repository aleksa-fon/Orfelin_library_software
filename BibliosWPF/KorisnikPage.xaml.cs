using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Orfelin.Core.Models;
using Orfelin.WPF.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orfelin.WPF
{
    public partial class KorisnikPage : Page
    {
        private readonly ApiService _apiService;
        private List<Korisnik> _sviKorisnici = new();

        public KorisnikPage(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e) =>
            await UcitajKorisnike();

        private async Task UcitajKorisnike()
        {
            var korisnici = await _apiService.GetAllKorisnici();
            _sviKorisnici = korisnici ?? new List<Korisnik>();
            dgKorisnici.ItemsSource = _sviKorisnici;
        }

        private void txtPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tekst = txtPretraga.Text.ToLower();
            dgKorisnici.ItemsSource = _sviKorisnici
                .Where(k => k.Ime.ToLower().Contains(tekst) ||
                            k.Prezime.ToLower().Contains(tekst) ||
                            k.Email.ToLower().Contains(tekst))
                .ToList();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new KorisnikDialog(_apiService);
            dialog.ShowDialog();
            _ = UcitajKorisnike();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dgKorisnici.SelectedItem is not Korisnik odabran)
            {
                MessageBox.Show("Odaberite čitaoca!", "Upozorenje");
                return;
            }
            var dialog = new KorisnikDialog(_apiService, odabran);
            dialog.ShowDialog();
            _ = UcitajKorisnike();
        }

        private async void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgKorisnici.SelectedItem is not Korisnik odabran)
            {
                MessageBox.Show("Odaberite čitaoca!", "Upozorenje");
                return;
            }
            var potvrda = MessageBox.Show(
                $"Da li ste sigurni da želite obrisati '{odabran.Ime} {odabran.Prezime}'?",
                "Potvrda brisanja", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (potvrda == MessageBoxResult.Yes)
            {
                await _apiService.DeleteKorisnik(odabran.Id);
                await UcitajKorisnike();
            }
        }
    }
}