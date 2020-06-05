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
            dataUtils.SetDataUtils();

            UserConnected.SetUserConnected(dataUtils.GetListUsers()[0]);
        }


        private void ChangePage(object sender, RoutedEventArgs e)
        {
            string tagUid =  ((Button) e.Source).Tag.ToString();

            switch (tagUid)
            {
                case "PageAdministration":
                    ContentArea.Content = new Administration.Administration();
                    break;
                case "PageTools":
                    break;
                case "PageDocumentation":
                    break;
                case "PageHelp":
                    break;
            }
        }

        private void btn_profil(object sender, MouseButtonEventArgs e)
        {

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
                tt_favoris.Visibility = Visibility.Collapsed;
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
                tt_favoris.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
            }
        }

        private void Messagerie_click(object sender, RoutedEventArgs e)
        {

        }

        private void Code_Click(object sender, MouseButtonEventArgs e)
        {
            Body.Children.Add(new ExtraitCodeHome());
        }
    }
}
