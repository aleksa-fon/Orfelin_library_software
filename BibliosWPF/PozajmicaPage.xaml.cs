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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Orfelin.WPF
{
    public partial class PozajmicaPage : Page
    {
        private readonly ApiService _apiService;
        private List<Pozajmica> _svePozajmice = new();

        public PozajmicaPage(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e) =>
            await UcitajPozajmice();

        private async Task UcitajPozajmice()
        {
            var pozajmice = await _apiService.GetAllPozajmice();
            _svePozajmice = pozajmice ?? new List<Pozajmica>();
            dgPozajmice.ItemsSource = _svePozajmice;
        }

        private void txtPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tekst = txtPretraga.Text.ToLower();
            dgPozajmice.ItemsSource = _svePozajmice
                .Where(p => (p.Korisnik?.Ime?.ToLower().Contains(tekst) ?? false) ||
                            (p.Knjiga?.Naslov?.ToLower().Contains(tekst) ?? false))
                .ToList();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PozajmicaDialog(_apiService);
            dialog.ShowDialog();
            _ = UcitajPozajmice();
        }

        private async void btnVrati_Click(object sender, RoutedEventArgs e)
        {
            if (dgPozajmice.SelectedItem is not Pozajmica odabrana)
            {
                MessageBox.Show("Odaberite pozajmicu!", "Upozorenje");
                return;
            }
            if (odabrana.Status == "Vraćena")
            {
                MessageBox.Show("Ova knjiga je već vraćena!", "Upozorenje");
                return;
            }

            odabrana.DatumVracanja = DateTime.Now;
            odabrana.Status = "Vraćena";
            await _apiService.UpdatePozajmica(odabrana);
            await UcitajPozajmice();
        }

        private async void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgPozajmice.SelectedItem is not Pozajmica odabrana)
            {
                MessageBox.Show("Odaberite pozajmicu!", "Upozorenje");
                return;
            }
            var potvrda = MessageBox.Show(
                "Da li ste sigurni da želite obrisati ovu pozajmicu?",
                "Potvrda brisanja", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (potvrda == MessageBoxResult.Yes)
            {
                await _apiService.DeletePozajmica(odabrana.Id);
                await UcitajPozajmice();
            }
        }
    }
}