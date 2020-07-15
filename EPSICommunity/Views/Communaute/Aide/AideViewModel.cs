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


        private Aides _selectedAides;
        public Aides SelectedAides
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

        //private bool _showFormUpdateDoc;
        //public bool ShowFormUpdateDoc
        //{
        //    get { return _showFormUpdateDoc; }
        //    set
        //    {
        //        _showFormUpdateDoc = value;
        //        NotifyPropertyChanged("ShowFormUpdateDoc");
        //    }
        //}

        private bool _showFormUpdateDoc;
        public bool ShowFormUpdateDoc
        {
            get { return _showFormUpdateDoc; }
            set
            {
                _showFormUpdateDoc = value;
                NotifyPropertyChanged("ShowFormUpdateDoc");
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

        private List<Aides> _listeFiltered;

        public AideViewModel()
        {
            _listeFiltered = new List<Aides>();

            _listeAides = new List<Aides>();

            _listeAides = new List<Aides>
            {
                new Aides { Nom = "SQL" , Description = "Créer une view", Language = "SQL"},
                new Aides { Nom = "C#" , Description = "Utiliser LINQ", Language = "C#"},
                new Aides { Nom = "Testing" , Description = "Utiliser MSTest en C#", Language = "Testing"}
            };

            ListeAides = CollectionViewSource.GetDefaultView(_listeAides);

            _listeLanguage = new List<string>
            {
                "C#","Java","SQL","Testing"
            };

            ListeLanguage = CollectionViewSource.GetDefaultView(_listeLanguage);

            ListeAides.Refresh();
            ListeLanguage.Refresh();
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

        public void DeleteAide()
        {
            _listeAides.Remove(SelectedAides);
            ListeAides.Refresh();

        }

        public void FilterAide()
        {
            List<Aides> tempAides = _listeAides.FindAll(a => a.Language == SelectedLanguage);

            _listeAides.Clear();
            _listeAides.AddRange(tempAides);
            ListeAides.Refresh();
        }
    }
}