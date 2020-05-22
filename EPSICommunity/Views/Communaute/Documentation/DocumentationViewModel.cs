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

        public ObservableCollection<String> ListeLanguage { get; set; }

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
                "c#","java","sql"
            };

            ListeLanguage = new ObservableCollection<string>(_listeLanguage);

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


    }
}