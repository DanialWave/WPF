using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            var currentUser = ApiService.GetLoggedInUser();
            if (currentUser != null) {
                var mainWindow = new MainWindow(); 
                mainWindow.Show();
            } else {
                var loginWindow = new LoginWindow();
                loginWindow.Show();
            }
        }

    }
}
