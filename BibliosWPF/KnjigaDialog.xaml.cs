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

namespace Orfelin.WPF
{
    public partial class KnjigaDialog : Window
    {
        private readonly ApiService _apiService;
        private readonly Knjiga? _postojecaKnjiga;

        public KnjigaDialog(ApiService apiService, Knjiga? knjiga = null)
        {
            InitializeComponent();
            _apiService = apiService;
            _postojecaKnjiga = knjiga;

            if (_postojecaKnjiga != null)
            {
                txtNaslovDijaloga.Text = "Izmeni knjigu";
                txtNaslov.Text = knjiga!.Naslov;
                txtAutor.Text = knjiga.Autor;
                txtISBN.Text = knjiga.ISBN;
                txtZanr.Text = knjiga.Zanr;
                txtGodina.Text = knjiga.GodinaIzdavanja.ToString();
                txtUkupno.Text = knjiga.UkupanBrojKopija.ToString();
                txtDostupno.Text = knjiga.DostupnoKopija.ToString();
            }
        }

        private async void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaslov.Text) ||
                string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("Naslov i autor su obavezni!", "Greška");
                return;
            }

            var knjiga = new Knjiga
            {
                Id = _postojecaKnjiga?.Id ?? 0,
                Naslov = txtNaslov.Text,
                Autor = txtAutor.Text,
                ISBN = txtISBN.Text,
                Zanr = txtZanr.Text,
                GodinaIzdavanja = int.TryParse(txtGodina.Text, out int god) ? god : 0,
                UkupanBrojKopija = int.TryParse(txtUkupno.Text, out int ukupno) ? ukupno : 0,
                DostupnoKopija = int.TryParse(txtDostupno.Text, out int dostupno) ? dostupno : 0
            };

            if (_postojecaKnjiga == null)
                await _apiService.AddKnjiga(knjiga);
            else
                await _apiService.UpdateKnjiga(knjiga);

            this.Close();
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
