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
using System.Windows;
using System.Windows.Controls;

namespace Orfelin.WPF
{
    public partial class ZaposleniPage : Page
    {
        private readonly ApiService _apiService;
        private List<Zaposleni> _sviZaposleni = new();

        public ZaposleniPage(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e) =>
            await UcitajZaposlene();

        private async Task UcitajZaposlene()
        {
            var zaposleni = await _apiService.GetAllZaposleni();
            _sviZaposleni = zaposleni ?? new List<Zaposleni>();
            dgZaposleni.ItemsSource = _sviZaposleni;
        }

        private void txtPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tekst = txtPretraga.Text.ToLower();
            dgZaposleni.ItemsSource = _sviZaposleni
                .Where(z => z.Ime.ToLower().Contains(tekst) ||
                            z.Prezime.ToLower().Contains(tekst) ||
                            z.Username.ToLower().Contains(tekst))
                .ToList();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ZaposleniDialog(_apiService);
            dialog.ShowDialog();
            _ = UcitajZaposlene();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dgZaposleni.SelectedItem is not Zaposleni odabran)
            {
                MessageBox.Show("Odaberite zaposlenog!", "Upozorenje");
                return;
            }
            var dialog = new ZaposleniDialog(_apiService, odabran);
            dialog.ShowDialog();
            _ = UcitajZaposlene();
        }

        private async void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgZaposleni.SelectedItem is not Zaposleni odabran)
            {
                MessageBox.Show("Odaberite zaposlenog!", "Upozorenje");
                return;
            }
            var potvrda = MessageBox.Show(
                $"Da li ste sigurni da želite obrisati '{odabran.Ime} {odabran.Prezime}'?",
                "Potvrda brisanja", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (potvrda == MessageBoxResult.Yes)
            {
                await _apiService.DeleteZaposleni(odabran.Id);
                await UcitajZaposlene();
            }
        }
    }
}
