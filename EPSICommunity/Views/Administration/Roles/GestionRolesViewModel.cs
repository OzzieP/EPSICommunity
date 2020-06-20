using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using EPSICommunity.Model;

namespace EPSICommunity.Views.Administration.Roles
{
    public class GestionRolesViewModel : ViewModelBase
    {
        private List<Role> _listRoles { get; set; }

        public ICollectionView Roles { get; set; }

        private Role _selectedRole;
        public Role SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                _selectedRole = value;
                NotifyPropertyChanged("SelectedRole");
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

        private bool _showFormAdd;
        public bool ShowFormAdd
        {
            get { return _showFormAdd; }
            set
            {
                _showFormAdd = value;
                NotifyPropertyChanged("ShowFormAdd");
            }
        }

        private bool _showFormEdit;
        public bool ShowFormEdit
        {
            get { return _showFormEdit; }
            set
            {
                _showFormEdit = value;
                NotifyPropertyChanged("ShowFormEdit");
            }
        }


        public GestionRolesViewModel()
        {
            _listRoles = new List<Role>
            {
                new Role(1, "Administrateur"),
                new Role(2, "Super Administrateur"),
                new Role(3, "Utilisateur"),
                new Role(4, "Professeur")
            };

            Roles = CollectionViewSource.GetDefaultView(_listRoles);
            Roles.Refresh();
        }

        public void AddRole()
        {
            if (string.IsNullOrWhiteSpace(SelectedName))
                MessageBox.Show("Veuillez saisir un nom valide", "Attention", 
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);

            _listRoles.Add(new Role(5, SelectedName));
            Roles.Refresh();
        }
    }
}