using EPSICommunity.Utils.data;
using EPSICommunity.Utils.Session;
using EPSICommunity.Views.Code;
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
using EPSICommunity.Views.Administration;
using EPSICommunity.Views.Messagerie;
using EPSICommunity.Views.Communaute.Aide;
using FontAwesome.WPF;
using EPSICommunity.Utils.Habilitation;

namespace EPSICommunity.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;


        public MainWindow()
        {
            InitializeComponent();
            this._viewModel = new MainWindowViewModel();
            this.DataContext = this._viewModel;
        }


        private void ChangePage(object sender, RoutedEventArgs e)
        {
            string tagUid = String.Empty;

            if (e.Source is ImageAwesome awesome)
                tagUid = awesome.Tag.ToString();
            else if (e.Source is TextBlock block)
                tagUid = block.Tag.ToString();

            switch (tagUid)
            {
                case "PageProfil":
                    ContentArea.Content = new Profil.Profil();
                    break;
                case "PageAccueil":
                    
                    break;
                case "PageMessagerie":
                    ContentArea.Content = new MessagerieHome();
                    break;
                case "PageAide":
                    ContentArea.Content = new Aide();
                    break;
                case "PageDocumentation":
                    ContentArea.Content = new Communaute.Documentation.Doc();
                    break;
                case "PageCode":
                    ContentArea.Content = new ExtraitCodeHome();
                    break;
                case "PageIdees":

                    break;
                case "PageIDEs":

                    break;
                case "PageRecherche":

                    break;
                case "PageFavoris":

                    break;
                case "PageAdministration":
                    List<int> idRoles = UserConnected.GetUserConnected().GetIdRoles();
                    if (idRoles.Contains(5) || idRoles.Contains(4) || idRoles.Contains(3) || idRoles.Contains(2) || idRoles.Contains(1))
                    {
                        if (UserConnected.VerifyHabilitations()) {
                            ContentArea.Content = new Administration.Administration();
                        }
                        else {
                            MessageHabilitation.MessageNoHabilitate();
                        }
                    }
                    else
                    {
                        MessageHabilitation.MessageNoHabilitate();
                    }
                    break;
                case "PageParametres":

                    break;
            }
        }


        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Setter tooltip visibility
            if (Tgl_Btn.IsChecked == true)
            {
                tt_accueil.Visibility = Visibility.Collapsed;
                tt_messagerie.Visibility = Visibility.Collapsed;
                tt_code.Visibility = Visibility.Collapsed;
                tt_ideas.Visibility = Visibility.Collapsed;
                tt_ide.Visibility = Visibility.Collapsed;
                tt_search.Visibility = Visibility.Collapsed;
                tt_help.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_accueil.Visibility = Visibility.Visible;
                tt_messagerie.Visibility = Visibility.Visible;
                tt_code.Visibility = Visibility.Visible;
                tt_ideas.Visibility = Visibility.Visible;
                tt_ide.Visibility = Visibility.Visible;
                tt_search.Visibility = Visibility.Visible;
                tt_help.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
            }
        }
    }
}
