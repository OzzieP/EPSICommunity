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

namespace EPSICommunity.Views.Administration.Utilisateurs
{
    /// <summary>
    /// Logique d'interaction pour GestionUtilisateurs.xaml
    /// </summary>
    public partial class GestionUtilisateurs : UserControl
    {
        private GestionUtilisateursViewModel _viewModel;


        public GestionUtilisateurs()
        {
            InitializeComponent();
            _viewModel = new GestionUtilisateursViewModel();
            this.DataContext = _viewModel;
        }

        private void RemoveUser(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveUser();
        }

        private void CbxName_OnUnchecked(object sender, RoutedEventArgs e)
        {
            _viewModel.ResetFilter();
        }

        private void BtnFilter_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.FilterUsers();
        }
    }
}
