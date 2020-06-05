using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EPSICommunity.Views.Profil
{
    public class ProfilViewModel : ViewModelBase
    {
        private bool _showTodoList;
        public bool ShowTodoList
        {
            get { return _showTodoList; }
            set
            {
                _showTodoList = value;
                NotifyPropertyChanged("ShowTodoList");
            }
        }

        private bool _showProfile;
        public bool ShowProfile
        {
            get { return _showProfile; }
            set
            {
                _showProfile = value;
                NotifyPropertyChanged("ShowProfile");
            }
        }


        public ProfilViewModel()
        {
            ShowProfile = true;
        }
    }
}