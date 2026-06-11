using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Orfelin.Core.Models;
using Orfelin.WPF.Services;

namespace Orfelin.WPF
{
    public partial class KnjigePage : Page
    {
        private readonly ApiService _apiService;
        private List<Knjiga> _sveKnjige = new();

        public KnjigePage(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await UcitajKnjige();
        }

        private async Task UcitajKnjige()
        {
            var knjige = await _apiService.GetAllKnjige();
            _sveKnjige = knjige ?? new List<Knjiga>();
            dgKnjige.ItemsSource = _sveKnjige;
        }

        private void txtPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tekst = txtPretraga.Text.ToLower();
            dgKnjige.ItemsSource = _sveKnjige
                .Where(k => k.Naslov.ToLower().Contains(tekst) ||
                            k.Autor.ToLower().Contains(tekst) ||
                            k.ISBN.ToLower().Contains(tekst))
                .ToList();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new KnjigaDialog(_apiService);
            dialog.ShowDialog();
            _ = UcitajKnjige();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dgKnjige.SelectedItem is not Knjiga odabrana)
            {
                MessageBox.Show("Odaberite knjigu!", "Upozorenje");
                return;
            }
            var dialog = new KnjigaDialog(_apiService, odabrana);
            dialog.ShowDialog();
            _ = UcitajKnjige();
        }

        private async void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgKnjige.SelectedItem is not Knjiga odabrana)
            {
                MessageBox.Show("Odaberite knjigu!", "Upozorenje");
                return;
            }

            var potvrda = MessageBox.Show(
                $"Da li ste sigurni da želite obrisati '{odabrana.Naslov}'?",
                "Potvrda brisanja",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (potvrda == MessageBoxResult.Yes)
            {
                await _apiService.DeleteKnjiga(odabrana.Id);
                await UcitajKnjige();
            }
        }
    }
}