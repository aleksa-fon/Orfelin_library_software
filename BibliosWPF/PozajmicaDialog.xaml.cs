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
using System.Windows.Shapes;
using Orfelin.Core.Models;
using Orfelin.WPF.Services;
using System;
using System.Windows;

namespace Orfelin.WPF
{
    public partial class PozajmicaDialog : Window
    {
        private readonly ApiService _apiService;

        public PozajmicaDialog(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
            Loaded += PozajmicaDialog_Loaded;
        }

        private async void PozajmicaDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var korisnici = await _apiService.GetAllKorisnici();
            var knjige = await _apiService.GetAllKnjige();
            cmbKorisnik.ItemsSource = korisnici;
            cmbKnjiga.ItemsSource = knjige;
            dpRokVracanja.SelectedDate = DateTime.Now.AddDays(14);
        }

        private async void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (cmbKorisnik.SelectedItem is not Korisnik korisnik ||
                cmbKnjiga.SelectedItem is not Knjiga knjiga ||
                dpRokVracanja.SelectedDate == null)
            {
                MessageBox.Show("Sva polja su obavezna!", "Greška");
                return;
            }

            var pozajmica = new Pozajmica
            {
                KorisnikId = korisnik.Id,
                KnjigaId = knjiga.Id,
                DatumPozajmice = DateTime.Now,
                RokVracanja = dpRokVracanja.SelectedDate.Value,
                Status = "Aktivna"
            };

            await _apiService.AddPozajmica(pozajmica);
            this.Close();
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}