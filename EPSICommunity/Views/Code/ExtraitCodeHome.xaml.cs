using EPSICommunity.Model;
using EPSICommunity.Utils.Habilitation;
using EPSICommunity.Utils.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EPSICommunity.Views.Code
{
    /// <summary>
    /// Logique d'interaction pour ExtraitCodeHome.xaml
    /// </summary>
    public partial class ExtraitCodeHome : UserControl
    {
        private readonly CodeViewModel _codeViewModel;

        public ExtraitCodeHome()
        {
            InitializeComponent();
            _codeViewModel = new CodeViewModel();

            this.ListView_ExtraitsCode.Style = null;

            if (!UserConnected.VerifyHabilitation("100_1xCD0"))
            {
                BtnAddExtrait.Cursor = Cursors.No;
            }

            ICollectionView lesExtraitsCode = _codeViewModel.ExtraitsCode;
            this.ListView_ExtraitsCode.ItemsSource = lesExtraitsCode.Cast<ExtraitCode>().OrderBy(x => x.Date_Creation).ToList();
        }

        private void ShowExtraitCode(Object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            ExtraitCode extraitCode = (ExtraitCode)ListView_ExtraitsCode.ItemContainerGenerator.ItemFromContainer(dep);
            if (extraitCode != null)
            {
                this.Body_Extrait.Children.Remove(NoExtraitText);
                this.Body_Extrait.Children.Add(new ExtraitCodeItem(extraitCode));
            }
        }

        private void ClickNewExtraitCode(object sender, MouseButtonEventArgs e)
        {
            if (!UserConnected.VerifyHabilitation("100_1xCD0"))
            {
                MessageHabilitation.MessageNoHabilitatePersonnalized("créer un nouvel extrait de code !");
            }
            else
            {
                this.Body_Extrait.Children.Remove(NoExtraitText);
                this.Body_Extrait.Children.Add(new AddExtraitCode());
            }
        }
    }
}
