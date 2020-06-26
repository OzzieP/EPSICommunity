using EPSICommunity.Model;
using EPSICommunity.Utils.data;
using EPSICommunity.Utils.Session;
using EPSICommunity.Views.Messagerie.Chat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EPSICommunity.Views.Messagerie
{
    /// <summary>
    /// Logique d'interaction pour MessagerieHome.xaml
    /// </summary>
    public partial class MessagerieHome : UserControl
    {
        private readonly MessageViewModel _messageViewModel;
        public List<User> listUsers = dataUtils.GetListUsers();
        private List<Message> _lastsMessages;
        public MessagerieHome()
        {
            InitializeComponent();
            _messageViewModel = new MessageViewModel();

            this.ListView_Messages.Style = null;

            _lastsMessages = OrganiseLastMessageInContactList(_messageViewModel.Conversations);
            ICollectionView _lastMessageViewModel = CollectionViewSource.GetDefaultView(_lastsMessages);
            this.ListView_Messages.ItemsSource = _lastMessageViewModel;
        }
        public List<Message> OrganiseLastMessageInContactList(ICollectionView collectionView)
        {
            List<Message> lastsMessages = new List<Message>();
            foreach (Conversation c in collectionView)
            {
                if (c.Users.Contains(UserConnected.GetUserConnected().Id))
                {
                    List<Message> msgs = new List<Message>();
                    foreach (int mid in c.Messages)
                    {
                        msgs.Add(_messageViewModel.Messages.Cast<Message>().ToList().Find(x => x.Id == mid));
                    }
                    Message message = msgs[msgs.Count - 1];
                    User correspondant = c.Users[0] != UserConnected.GetUserConnected().Id ? (listUsers.Find(x => x.Id == c.Users[0])) : (listUsers.Find(x => x.Id == c.Users[1]));
                    lastsMessages.Add(
                        new Message(
                            message.Id,
                            message.Id_Recipient,
                            message.Id_Sender,
                            correspondant.Nom,
                            correspondant.Prenom,
                            message.Id_Sender == UserConnected.GetUserConnected().Id ? "Moi : " + message.Content : message.Content,
                            message.Date_Sending,
                            message.Horaire_Sending,
                            message.Vu
                        )
                    );
                }
            }
            return lastsMessages;
        }

        public void ShowConversation(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            Message item = (Message)ListView_Messages.ItemContainerGenerator.ItemFromContainer(dep);
            User correspondant = listUsers.Find(x => (x.Nom == item.Nom) && (x.Prenom == item.Prenom));
            Conversation conversation = _messageViewModel.Conversations.Cast<Conversation>().ToList()
                .Find(x => x.Users.Contains(UserConnected.GetUserConnected().Id) && x.Users.Contains(correspondant.Id));
            if (conversation != null)
            {
                Body_Conversation.Children.Remove(NoChatText);
                Body_Conversation.Children.Add(new Chat.Chat(conversation));
            }
        }

        private void AddNewConversation(object sender, RoutedEventArgs e)
        {
            this.Body_Conversation.Children.Clear();
            this.Body_Conversation.Children.Add(new AddChat());
        }
    }
}
