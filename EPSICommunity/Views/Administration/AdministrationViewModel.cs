using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EPSICommunity.Views.Administration
{
    public class AdminstrationViewModel : ViewModelBase
    {
        private bool _showUserControl;
        public bool ShowUserControl
        {
            get { return _showUserControl; }
            set
            {
                _showUserControl = value;
                NotifyPropertyChanged("ShowUserControl");
            }
        }


        public AdminstrationViewModel()
        {

        }
    }
}