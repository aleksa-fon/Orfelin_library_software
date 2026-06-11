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
    public partial class KorisnikDialog : Window
    {
        private readonly ApiService _apiService;
        private readonly Korisnik? _postojeciKorisnik;

        public KorisnikDialog(ApiService apiService, Korisnik? korisnik = null)
        {
            InitializeComponent();
            _apiService = apiService;
            _postojeciKorisnik = korisnik;

            if (_postojeciKorisnik != null)
            {
                txtNaslovDijaloga.Text = "Izmeni čitaoca";
                txtIme.Text = korisnik!.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtEmail.Text = korisnik.Email;
                txtBrojClanskeKarte.Text = korisnik.BrojClanskeKarte;
                chkAktivan.IsChecked = korisnik.Aktivan;
            }
        }

        private async void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text) ||
                string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                MessageBox.Show("Ime i prezime su obavezni!", "Greška");
                return;
            }

            var korisnik = new Korisnik
            {
                Id = _postojeciKorisnik?.Id ?? 0,
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Email = txtEmail.Text,
                BrojClanskeKarte = txtBrojClanskeKarte.Text,
                DatumClanstva = _postojeciKorisnik?.DatumClanstva ?? DateTime.Now,
                Aktivan = chkAktivan.IsChecked ?? true
            };

            if (_postojeciKorisnik == null)
                await _apiService.AddKorisnik(korisnik);
            else
                await _apiService.UpdateKorisnik(korisnik);

            this.Close();
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
