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
using EPSICommunity.Views.Code;

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

        private Tasks _selectedTasks;
        public Tasks SelectedTasks
        {
            get { return _selectedTasks; }
            set
            {
                _selectedTasks = value;
                NotifyPropertyChanged("SelectedTasks");
            }
        }

        private string _selectedDescription;
        public string SelectedDescription
        {
            get { return _selectedDescription; }
            set
            {
                _selectedDescription = value;
                NotifyPropertyChanged("SelectedDescription");
            }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                NotifyPropertyChanged("SelectedDate");
            }
        }


        private List<Tasks> _listTasks { get; set; }
        public ICollectionView Tasks { get; private set; }

        private List<Tasks> _listTasksDone { get; set; }
        public ICollectionView TasksDone { get; private set; }

        private List<Activity> _listActivities { get; set; }
        public ICollectionView Activities { get; private set; }

        private List<Favorite> _listFavorites { get; set; }
        public ICollectionView Favorites { get; private set; }


        public ProfilViewModel()
        {
            _listTasks = new List<Tasks>
            {
                new Tasks(1, "Rendre TP C#", false, DateTime.Now.AddDays(15)),
                new Tasks(2, "Rendre TP Java", false, DateTime.Now.AddMonths(1)),
                new Tasks(3, "Terminer MSPR Oracle", false, DateTime.Now.AddDays(3))
            };
            Tasks = CollectionViewSource.GetDefaultView(_listTasks);
            Tasks.Refresh();

            _listTasksDone = new List<Tasks>
            {
                new Tasks(4, "Rendre TP Python", true, DateTime.Now.AddMonths(-2)),
                new Tasks(5, "Faire documentation technique projet POIN", true, DateTime.Now.AddDays(-45))
            };
            TasksDone = CollectionViewSource.GetDefaultView(_listTasksDone);
            TasksDone.Refresh();

            _listActivities = new List<Activity>
            {
                new Activity(1, "A mis 5 étoiles à l'extrait de code : Links To Css in HTML", DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy")),
                new Activity(2, "A créé l'extrait de code : WPF Grid Exemple", "29/05/2020")
            };
            Activities = CollectionViewSource.GetDefaultView(_listActivities);
            Activities.Refresh();

            _listFavorites = new List<Favorite>
            {
                new Favorite("Links To Css in HTML", "ExtraitCodeHome"),
                new Favorite("WPF Grid Exemple", "ExtraitCodeHome")
            };
            Favorites = CollectionViewSource.GetDefaultView(_listFavorites);
            Favorites.Refresh();

            SelectedDate = DateTime.Today;
            ShowProfile = true;
        }


        public void CheckTasks()
        {
            if (SelectedTasks != null)
            {
                _listTasksDone.Add(SelectedTasks);
                _listTasks.Remove(SelectedTasks);

                Tasks.Refresh();
                TasksDone.Refresh();
            }
        }

        public void UncheckTasks()
        {
            if (SelectedTasks != null)
            {
                _listTasks.Add(SelectedTasks);
                _listTasksDone.Remove(SelectedTasks);

                TasksDone.Refresh();
                Tasks.Refresh();
            }
        }

        public void AddTasks()
        {
            if (!string.IsNullOrWhiteSpace(SelectedDescription) && SelectedDate != null)
            {
                _listTasks.Add(new Tasks(_listTasks.Count + 1, SelectedDescription, false, SelectedDate));
                Tasks.Refresh();
            }
            else
            {
                MessageBox.Show("Veuillez saisir une description pour la tâche à ajouter", "Attention",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}