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
            _listRoles = dataUtils.GetListRoles();

            Roles = CollectionViewSource.GetDefaultView(_listRoles);
            Roles.Refresh();
        }

        public void AddRole()
        {
            if (string.IsNullOrWhiteSpace(SelectedName))
                MessageBox.Show("Veuillez saisir un nom valide", "Attention", 
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);

            dataUtils.AddRole(SelectedName);
            _listRoles = dataUtils.GetListRoles();
            Roles.Refresh();
        }
        
        public void RemoveRole()
        {
            if (SelectedRole == null)
            {
                MessageBox.Show("Veuillez sélectionner un rôle à supprimer dans la liste", "Attention", 
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            dataUtils.RemoveRole(SelectedRole.Id);
            _listRoles = dataUtils.GetListRoles();
            Roles.Refresh();
        }
    }
}