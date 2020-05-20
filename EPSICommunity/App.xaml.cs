using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EPSICommunity.Views.Login;
using ShowMeTheXAML;

namespace EPSICommunity
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void OnStartup(object sender, StartupEventArgs e)
        {
            var login = new Login();
            login.Show();
        }
    }
}
