using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using EPSICommunity.Model;

namespace EPSICommunity.Views.Administration.Utilisateurs
{
    public class GestionUtilisateursViewModel : ViewModelBase
    {
        private List<User> _listUsers { get; set; }

        public ICollectionView Users { get; private set; }


        public GestionUtilisateursViewModel()
        {
            _listUsers = new List<User>
            {
                new User(1, "abc", "LEGENDRE", "Brendan"),
                new User(1, "abc", "DUBOIS", "Matthieu"),
                new User(1, "abc", "CAZIN", "Nicolas"),
                new User(1, "abc", "LORENTE", "Romain"),
                new User(1, "abc", "LEGRAND", "Quentin")
            };

            Users = CollectionViewSource.GetDefaultView(_listUsers);
            Users.Refresh();
        }
    }
}