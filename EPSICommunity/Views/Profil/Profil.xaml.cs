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

namespace EPSICommunity.Views.Profil
{
    /// <summary>
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class Profil : UserControl
    {
        private ProfilViewModel _viewModel;


        public Profil()
        {
            InitializeComponent();
            _viewModel = new ProfilViewModel();
            this.DataContext = _viewModel;
        }

        private void Button_OpenTodoList(object sender, RoutedEventArgs e)
        {
            _viewModel.ShowTodoList = true;
            _viewModel.ShowProfile = false;
        }
        
        private void Button_CloseTodoList(object sender, RoutedEventArgs e)
        {
            _viewModel.ShowTodoList = false;
            _viewModel.ShowProfile = true;
        }
    }
}
