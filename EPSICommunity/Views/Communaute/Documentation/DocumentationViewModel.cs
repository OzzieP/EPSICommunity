using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace EPSICommunity.Views.Communaute.Documentation
{
    public class DocumentationViewModel : ViewModelBase
    {

        private List<Docs> _listeDocumentation; // creation de la liste

        // public ObservableCollection<String> ListeDocumentation;

        public ICollectionView ListeDocumentation { get; set; }

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


        private String _selectedLink;
        public String SelectedLink
        {

            get { return _selectedLink; }
            set
            {
                _selectedLink = value;
                NotifyPropertyChanged("SelectedLink");
            }
        }


        private String _selectedTitre;
        public String SelectedTitre
        {
            get { return _selectedTitre; }
            set
            {
                _selectedTitre = value;
                NotifyPropertyChanged("SelectedTitre");
            }
        }

        private Docs _selectedDocumentation;
        public Docs SelectedDocumentation
        {
            get { return _selectedDocumentation; }
            set
            {
                _selectedDocumentation = value;
                NotifyPropertyChanged("SelectedDocumentation");
            }
        }


        public DocumentationViewModel()
        {

            _listeDocumentation = new List<Docs> // isntanciation de la liste

            {
                new Docs { Language = "C#", Link = "https://docs.microsoft.com/fr-fr/dotnet/csharp/" , Titre = " Documentation C#"  },
                new Docs { Language = "Java", Link = "https://www.tutorialspoint.com/java/java_documentation.htm" , Titre = " Documentation Java"  },

                //"brendan","matthieu","françois"
            };

            //ListeDocumentation = new ObservableCollection<string>(_listeDocumentation); // permet l'affichage de la liste 

            ListeDocumentation = CollectionViewSource.GetDefaultView(_listeDocumentation); // permet l'affiche mais aussi de la trier 


            _listeLanguage = new List<string>
            {
                "C#","Java","Sql","Python"
            };

            ListeLanguage = CollectionViewSource.GetDefaultView(_listeLanguage);

        }

        public void AddDoc()
        {

            Docs Doc = new Docs
            {

                Language = SelectedLanguage,
                Link = SelectedLink,
                Titre = SelectedTitre


            };

            _listeDocumentation.Add(Doc); //ajout a la site privé 
            ListeDocumentation.Refresh();

        }

        public void DeleteDocumentation()
        {
            _listeDocumentation.Remove(SelectedDocumentation);
            ListeDocumentation.Refresh();

        }


        public void FilterDoc()
        {
            List<Docs> tempDocs = _listeDocumentation.FindAll(d => d.Language == SelectedLanguage);

            _listeDocumentation.Clear();
            _listeDocumentation.AddRange(tempDocs);
            ListeDocumentation.Refresh();
        }
    }
}