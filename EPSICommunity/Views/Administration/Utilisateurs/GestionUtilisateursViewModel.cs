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
        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                NotifyPropertyChanged("SelectedUser");
            }
        }

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


        private List<User> _listUsers = new List<User>();

        public ICollectionView Users { get; private set; }


        public GestionUtilisateursViewModel()
        {
            _listUsers.AddRange(dataUtils.GetListUsers());

            Users = CollectionViewSource.GetDefaultView(_listUsers);
            Users.Refresh();
        }

        public void RemoveUser()
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer dans la liste", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            _listUsers.Remove(SelectedUser);
            Users.Refresh();
        }

        public void FilterUsers()
        {
            string name = SelectedName.ToUpper();
            List<User> tempUsers = _listUsers.FindAll(u => u.Nom == name);

            _listUsers.Clear();
            _listUsers.AddRange(tempUsers);
            Users.Refresh();
        }

        public void ResetFilter()
        {
            _listUsers.Clear();
            _listUsers.AddRange(dataUtils.GetListUsers());
            Users.Refresh();
        }
    }
}