using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace EPSICommunity.Views.Communaute.Aide
{
    public class AideViewModel : ViewModelBase
    {

        private List<Aides> _listeAides;

        public ICollectionView ListeAides { get; set; }


        private String _selectedAides;
        public String SelectedAides
        {
            get { return _selectedAides; }
            set
            {
                _selectedAides = value;
                NotifyPropertyChanged("SelectedAides");
            }
        }


        private String _selectedNom;
        public String SelectedNom
        {
            get { return _selectedNom; }
            set
            {
                _selectedNom = value;
                NotifyPropertyChanged("SelectedNom");
            }
        }


        private String _selectedDescription;
        public String SelectedDescription
        {
            get { return _selectedDescription; }
            set
            {
                _selectedDescription = value;
                NotifyPropertyChanged("SelectedDescription");
            }
        }

        private bool _showFormDoc;
        public bool ShowFormDoc
        {
            get { return _showFormDoc; }
            set
            {
                _showFormDoc = value;
                NotifyPropertyChanged("ShowFormDoc");
            }
        }

        private List<String> _listeLanguage;

        public ICollectionView ListeLanguage { get; set; }

        private String _selectedLanguage;

        public String SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                NotifyPropertyChanged("SelectedLanguage");
            }
        }



        public AideViewModel()
        {
            _listeAides = new List<Aides>();

            _listeAides = new List<Aides>
            {
                new Aides { Nom = "WPF" , Description = "Matthieu est nul"},
                new Aides { Nom = "WPF" , Description = "Brendan"}
            };

            ListeAides = CollectionViewSource.GetDefaultView(_listeAides);

            _listeLanguage = new List<string>
            {
                "c#","java","sql"
            };

            ListeLanguage = CollectionViewSource.GetDefaultView(_listeLanguage);
        }

        public void AddAide()
        {
            Aides Aide = new Aides
            {
                Nom = SelectedNom,
                Description = SelectedDescription
            };

            _listeAides.Add(Aide);
            ListeAides.Refresh();
        }
    }
}