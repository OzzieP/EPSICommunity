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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EPSICommunity.Views.Communaute.Aide
{
    /// <summary>
    /// Logique d'interaction pour Aide.xaml
    /// </summary>
    public partial class Aide : UserControl
    {
        private AideViewModel _viewModel;


        public Aide()
        {
            InitializeComponent();
            _viewModel = new AideViewModel();
            this.DataContext = _viewModel;
        }

        private void ButtonAddAide_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddAide();
            _viewModel.ShowFormDoc = false;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ShowFormDoc = true;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteAide();
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.FilterAide();
        }
    }
}