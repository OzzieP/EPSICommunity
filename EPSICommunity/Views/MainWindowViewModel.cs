using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Views
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _selectedName;
        public string SelectedName
        {
            get { return _selectedName; }
            set
            {
                _selectedName = value;
                NotifyPropertyChanged("SelectedName");
            }
        }


        public MainWindowViewModel()
        {

        }

    }
}
