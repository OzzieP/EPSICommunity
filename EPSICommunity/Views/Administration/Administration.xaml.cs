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
using EPSICommunity.Views.Administration.Roles;
using EPSICommunity.Views.Administration.Utilisateurs;

namespace EPSICommunity.Views.Administration
{
    /// <summary>
    /// Logique d'interaction pour Adminstration.xaml
    /// </summary>
    public partial class Administration : UserControl
    {
        private AdminstrationViewModel _viewModel;


        public Administration()
        {
            InitializeComponent();
            _viewModel = new AdminstrationViewModel();
            this.DataContext = _viewModel;
        }

        private void ButtonChangePage_Click(object sender, RoutedEventArgs e)
        {
            string tag = ((Button) e.Source).Tag.ToString();

            switch (tag)
            {
                case "PageUtilisateurs":
                    ContentArea.Content = new GestionUtilisateurs();
                    break;
                case "PageRoles":
                    ContentArea.Content = new GestionRoles();
                    break;
            }

            _viewModel.ShowUserControl = true;
        }
    }
}
