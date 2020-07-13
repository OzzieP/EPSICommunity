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

namespace EPSICommunity.Views.Communaute.Documentation
{
    /// <summary>
    /// Logique d'interaction pour Documentation.xaml
    /// </summary>
    public partial class Doc : UserControl
    {
        private DocumentationViewModel _viewModel;


        public Doc()
        {
            InitializeComponent();
            _viewModel = new DocumentationViewModel();
            this.DataContext = _viewModel;
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ShowFormDoc = true;
        }

        private void ButtonAddDoc_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddDoc();
            _viewModel.ShowFormDoc = false;

        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ShowFormDoc = true;
        }
    }
}
