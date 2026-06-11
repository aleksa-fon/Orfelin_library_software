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
using BibliosWPF;
using Orfelin.WPF.Services;

namespace Orfelin.WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ApiService _apiService;
        public LoginWindow()
        {
            InitializeComponent();  
            _apiService = new ApiService();
        }
        private async void btnPrijava_Click(object sender, RoutedEventArgs e)
        {
            btnPrijava.IsEnabled = false;
            txtGreska.Visibility = Visibility.Collapsed;

            var response = await _apiService.Login(txtUsername.Text, txtPassword.Password);

            if (response == null || !response.Success)
            {
                txtGreska.Text = "Pogrešno korisničko ime ili lozinka!";
                txtGreska.Visibility = Visibility.Visible;
                btnPrijava.IsEnabled = true;
                return;
            }

            var mainWindow = new MainWindow(response);
            mainWindow.Show();
            this.Close();
        }
    }
}
