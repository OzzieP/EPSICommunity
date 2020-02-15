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
            GridBodyContent.Children.Clear();
            string tagUid =  ((Button) e.Source).Uid;

            switch (tagUid)
            {
                case "PageCommunity":
                    break;
                case "PageTools":
                    break;
                case "PageDocumentation":
                    break;
                case "PageHelp":
                    break;
            }
        }
    }
}
