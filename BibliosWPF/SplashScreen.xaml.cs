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
using System.Threading.Tasks;


namespace Orfelin.WPF
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
            Loaded += SplashScreen_Loaded;
        }

        private async void SplashScreen_Loaded(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = "Učitavanje...";
            progressBar.Value = 30;
            await Task.Delay(600);

            txtStatus.Text = "Povezivanje sa serverom...";
            progressBar.Value = 70;
            await Task.Delay(600);

            txtStatus.Text = "Spremno!";
            progressBar.Value = 100;
            await Task.Delay(400);

            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}