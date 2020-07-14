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

namespace EPSICommunity.Views.Administration.Roles
{
    /// <summary>
    /// Logique d'interaction pour GestionRoles.xaml
    /// </summary>
    public partial class GestionRoles : UserControl
    {
        private GestionRolesViewModel _viewModel;


        public GestionRoles()
        {
            InitializeComponent();
            _viewModel = new GestionRolesViewModel();
            this.DataContext = _viewModel;
        }

        private void ShowFormAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.ShowFormEdit = false;
            _viewModel.ShowFormAdd = true;
        }

        private void SelectorRoles_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_viewModel.SelectedRole != null)
            {
                _viewModel.ShowFormAdd = false;
                _viewModel.ShowFormEdit = true;
            }
        }

        private void ValidateAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.AddRole();
        }
        
        private void RemoveRole_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveRole();
        }
    }
}
