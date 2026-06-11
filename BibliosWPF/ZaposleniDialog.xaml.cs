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
using System.Windows;
using System.Windows.Controls;

namespace Orfelin.WPF
{
    public partial class ZaposleniDialog : Window
    {
        private readonly ApiService _apiService;
        private readonly Zaposleni? _postojeciZaposleni;

        public ZaposleniDialog(ApiService apiService, Zaposleni? zaposleni = null)
        {
            InitializeComponent();
            _apiService = apiService;
            _postojeciZaposleni = zaposleni;

            if (_postojeciZaposleni != null)
            {
                txtNaslovDijaloga.Text = "Izmeni zaposlenog";
                txtIme.Text = zaposleni!.Ime;
                txtPrezime.Text = zaposleni.Prezime;
                txtUsername.Text = zaposleni.Username;
                cmbUloga.Text = zaposleni.Uloga;
                chkAktivan.IsChecked = zaposleni.Aktivan;
            }
        }

        private async void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Ime i username su obavezni!", "Greška");
                return;
            }

            var lozinka = txtLozinka.Password;
            var zaposleni = new Zaposleni
            {
                Id = _postojeciZaposleni?.Id ?? 0,
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Username = txtUsername.Text,
                PasswordHash = string.IsNullOrWhiteSpace(lozinka)
                    ? _postojeciZaposleni?.PasswordHash ?? string.Empty
                    : BCrypt.Net.BCrypt.HashPassword(lozinka),
                Uloga = (cmbUloga.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Bibliotekar",
                Aktivan = chkAktivan.IsChecked ?? true
            };

            if (_postojeciZaposleni == null)
                await _apiService.AddZaposleni(zaposleni);
            else
                await _apiService.UpdateZaposleni(zaposleni);

            this.Close();
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}