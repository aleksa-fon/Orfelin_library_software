using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;
using System.Threading;

namespace Orfelin.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "Orfelin.API.exe",
                WindowStyle = ProcessWindowStyle.Hidden
            });

            Thread.Sleep(2000);
            base.OnStartup(e);
        }
    }

}
