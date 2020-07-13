using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using EPSICommunity.Model;
using EPSICommunity.Utils.data;

namespace EPSICommunity.Views.Administration.Utilisateurs
{
    public class GestionUtilisateursViewModel : ViewModelBase
    {
        private List<User> _listUsers { get; set; }

        public ICollectionView Users { get; private set; }


        public GestionUtilisateursViewModel()
        {
            _listUsers = dataUtils.GetListUsers();

            Users = CollectionViewSource.GetDefaultView(_listUsers);
            Users.Refresh();
        }
    }
}