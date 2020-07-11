using EPSICommunity.Model;
using EPSICommunity.Utils.data;
using EPSICommunity.Utils.Session;
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

namespace EPSICommunity.Views.Login
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            dataUtils.SetDataUtils();
            ErrorMessage.Visibility = Visibility.Hidden;
        }

        private void send_loginForm(object sender, RoutedEventArgs e)
        {
            User userToConnect = dataUtils.GetUserByMailAdress(MailAdressTextBox.Text);
            if (userToConnect != null && PasswordTextBox.Password == userToConnect.Password)
            {
                UserConnected.SetUserConnected(userToConnect);
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                PasswordTextBox.Clear();
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
