using EPSICommunity.Model;
using EPSICommunity.Utils.data;
using EPSICommunity.Utils.Session;
using EPSICommunity.Utils.Template.TemplateClass;
using System;
using System.Collections.Generic;
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
using static EPSICommunity.Utils.Template.TemplateClass.ItemListMessage;

namespace EPSICommunity.Views.Messagerie.Chat
{
    /// <summary>
    /// Logique d'interaction pour Chat.xaml
    /// </summary>
    public partial class Chat : UserControl
    {
        private Conversation conv;
        private List<ItemListMessage> _listItemMessage;
        private User _correspondant;

        public Chat(Conversation conversation)
        {
            InitializeComponent();
            conv = conversation;
            OrganizeListMessage();
            this.TextBox_Comment.AcceptsTab = true;
            _correspondant = dataUtils.GetListUsers().Find(x => (x.Id == conversation.Users.Find(y => y != UserConnected.GetUserConnected().Id)));
            this.Nom_Correspondant.Text = _correspondant.Prenom + " " + _correspondant.Nom;
            if (_correspondant.Picture == null || _correspondant.Picture.Equals(""))
            {
                _correspondant.Picture = "Images/unnamed.png";
            }
            this.Picture_Correspondant.ImageSource = new BitmapImage(new Uri(String.Format("../../Resources/" + _correspondant.Picture), UriKind.Relative));
            this.ListMessages.ItemsSource = _listItemMessage;
        }

        private void OrganizeListMessage()
        {
            User correspondant = conv.Users[0] != UserConnected.GetUserConnected().Id ? (dataUtils.GetListUsers().Find(x => x.Id == conv.Users[0])) : (dataUtils.GetListUsers().Find(x => x.Id == conv.Users[1]));
            _listItemMessage = new List<ItemListMessage>();
            List<Message> messagesOfConv = new List<Message>();
            foreach (int idMessage in conv.Messages)
            {
                messagesOfConv.Add(dataUtils.GetListMessages().Find(x => x.Id == idMessage));
            }
            int previewIdSender = 0;
            int previewDateMessage = 0;
            foreach (Message m in messagesOfConv)
            {
                User userMessageSender = UserConnected.GetUserConnected().Id == m.Id_Sender ?
                    UserConnected.GetUserConnected() : correspondant;
                if (previewDateMessage != Int32.Parse(m.Date_Sending.Split('/')[0]))
                {
                    Message message = m;
                    if (UserConnected.GetUserConnected().Id == m.Id_Sender)
                    {
                        AddMessageSenderDateItem(new MessageSenderDateItem(), message, userMessageSender);
                    }
                    else
                    {
                        AddMessageToListMessageItem(new MessageRecipientDateItem(), message, userMessageSender);
                    }
                }
                else
                {
                    if (previewIdSender == m.Id_Sender)
                    {
                        if (UserConnected.GetUserConnected().Id == m.Id_Sender)
                        {
                            AddMessageToListMessageItem(new SecondMessageSenderItem(), m, userMessageSender);
                        }
                        else
                        {
                            AddMessageToListMessageItem(new SecondMessageRecipientItem(), m, userMessageSender);
                        }
                    }
                    else
                    {
                        if (UserConnected.GetUserConnected().Id == m.Id_Sender)
                        {
                            AddMessageToListMessageItem(new MessageSenderItem(), m, userMessageSender);
                        }
                        else
                        {
                            AddMessageToListMessageItem(new MessageRecipientItem(), m, userMessageSender);
                        }
                    }
                }
                previewIdSender = m.Id_Sender;
                previewDateMessage = Int32.Parse(m.Date_Sending.Split('/')[0]);
            }
        }

        private void AddMessageToListMessageItem(object typeMessageItem, Message m, User u)
        {
            if (typeMessageItem is MessageSenderItem item)
            {
                AddMessageSenderItem(item, m, u);
            }
            else if (typeMessageItem is MessageSenderDateItem)
            {
                AddMessageSenderDateItem((MessageSenderDateItem)typeMessageItem, m, u);
            }
            else if (typeMessageItem is SecondMessageSenderItem)
            {
                AddSecondMessageSenderItem((SecondMessageSenderItem)typeMessageItem, m, u);
            }
            else if (typeMessageItem is MessageRecipientItem)
            {
                AddMessageRecipientItem((MessageRecipientItem)typeMessageItem, m, u);
            }
            else if (typeMessageItem is MessageRecipientDateItem)
            {
                AddMessageRecipientDateItem((MessageRecipientDateItem)typeMessageItem, m, u);
            }
            else if (typeMessageItem is SecondMessageRecipientItem)
            {
                AddSecondMessageRecipientItem((SecondMessageRecipientItem)typeMessageItem, m, u);
            }
        }

        private void AddMessageSenderItem(MessageSenderItem messageSenderItem, Message m, User u)
        {
            messageSenderItem.Id = m.Id;
            messageSenderItem.Content = m.Content;
            messageSenderItem.Date_Sending = m.Date_Sending;
            messageSenderItem.Horaire_Sending = m.Horaire_Sending;
            messageSenderItem.Picture = u.Picture;
            _listItemMessage.Add(messageSenderItem);
        }

        private void AddMessageSenderDateItem(MessageSenderDateItem messageSenderDateItem, Message m, User u)
        {
            messageSenderDateItem.Id = m.Id;
            messageSenderDateItem.Content = m.Content;
            messageSenderDateItem.Date_Sending = m.Date_Sending;
            messageSenderDateItem.Horaire_Sending = m.Horaire_Sending;
            messageSenderDateItem.Picture = u.Picture;
            _listItemMessage.Add(messageSenderDateItem);
        }

        private void AddSecondMessageSenderItem(SecondMessageSenderItem secondMessageSenderItem, Message m, User u)
        {
            secondMessageSenderItem.Id = m.Id;
            secondMessageSenderItem.Content = m.Content;
            secondMessageSenderItem.Date_Sending = m.Date_Sending;
            secondMessageSenderItem.Horaire_Sending = m.Horaire_Sending;
            secondMessageSenderItem.Picture = u.Picture;
            _listItemMessage.Add(secondMessageSenderItem);
        }

        private void AddMessageRecipientItem(MessageRecipientItem messageRecipientItem, Message m, User u)
        {
            messageRecipientItem.Id = m.Id;
            messageRecipientItem.Content = m.Content;
            messageRecipientItem.Date_Sending = m.Date_Sending;
            messageRecipientItem.Horaire_Sending = m.Horaire_Sending;
            messageRecipientItem.Picture = u.Picture;
            _listItemMessage.Add(messageRecipientItem);
        }

        private void AddMessageRecipientDateItem(MessageRecipientDateItem messageRecipientDateItem, Message m, User u)
        {
            messageRecipientDateItem.Id = m.Id;
            messageRecipientDateItem.Content = m.Content;
            messageRecipientDateItem.Date_Sending = m.Date_Sending;
            messageRecipientDateItem.Horaire_Sending = m.Horaire_Sending;
            messageRecipientDateItem.Picture = u.Picture;
            _listItemMessage.Add(messageRecipientDateItem);
        }

        private void AddSecondMessageRecipientItem(SecondMessageRecipientItem secondMessageRecipientItem, Message m, User u)
        {
            secondMessageRecipientItem.Id = m.Id;
            secondMessageRecipientItem.Content = m.Content;
            secondMessageRecipientItem.Date_Sending = m.Date_Sending;
            secondMessageRecipientItem.Horaire_Sending = m.Horaire_Sending;
            secondMessageRecipientItem.Picture = u.Picture;
            _listItemMessage.Add(secondMessageRecipientItem);
        }

        private void SendComment(string content)
        {
            DateTime fullDate = DateTime.Now;
            string date = (fullDate.Day < 10 ? "0" + fullDate.Day.ToString() : fullDate.Day.ToString()) + "/" +
                (fullDate.Month < 10 ? "0" + fullDate.Month.ToString() : fullDate.Month.ToString()) + "/" +
                fullDate.Year.ToString();
            string hour = (fullDate.Hour < 10 ? "0" + fullDate.Hour.ToString() : fullDate.Hour.ToString()) + ":" +
                (fullDate.Minute < 10 ? "0" + fullDate.Minute.ToString() : fullDate.Minute.ToString()) + ":" +
                (fullDate.Second < 10 ? "0" + fullDate.Second.ToString() : fullDate.Second.ToString());
            Message newMessage = new Message(
                dataUtils.GetListMessages().Count + 1,
                _correspondant.Id,
                UserConnected.GetUserConnected().Id,
                UserConnected.GetUserConnected().Nom,
                UserConnected.GetUserConnected().Prenom,
                content,
                date,
                hour,
                0
            );
            dataUtils.AddMessage(newMessage);
            dataUtils.AddMessageToConversation(conv.Id, newMessage.Id);
            this.TextBox_Comment.Text = "";
            ReOrganiseLastMessageInContactList();
            ((Grid)this.Parent).Children.Add(new Chat(dataUtils.GetConversation(conv.Id)));
            ((Grid)this.Parent).Children.Remove(this);
        }

        private void SendComment(object sender, MouseButtonEventArgs e)
        {
            SendComment(this.TextBox_Comment.Text);
        }

        private void DeleteConversation(object sender, MouseButtonEventArgs e)
        {
            dataUtils.DeleteMessages(dataUtils.GetMessagesOfConversation(conv.Id));
            dataUtils.DeleteConversation(conv.Id);
            TextBlock NoChatText = new TextBlock
            {
                Text = "Aucun message à afficher...",
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151")),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Name = "NoChatText"
            };
            ReOrganiseLastMessageInContactList();
            ((Grid)this.Parent).Children.Add(NoChatText);
            ((Grid)this.Parent).Children.Remove(this);
        }

        private void ReOrganiseLastMessageInContactList()
        {
            List<Message> lastsMessages = new List<Message>();
            foreach (Conversation c in dataUtils.GetListConversations().Where(x => x.Users.Contains(UserConnected.GetUserConnected().Id)))
            {
                List<Message> msgs = new List<Message>();
                foreach (int mid in c.Messages)
                {
                    msgs.Add(dataUtils.GetListMessages().Find(x => x.Id == mid));
                }
                Message message = msgs[msgs.Count - 1];
                User correspondant = c.Users[0] != UserConnected.GetUserConnected().Id ? (dataUtils.GetListUsers().Find(x => x.Id == c.Users[0])) : (dataUtils.GetListUsers().Find(x => x.Id == c.Users[1]));
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
            ((System.Windows.Controls.ListView)((Grid)((Grid)((Grid)this.Parent).Parent).Children[0]).Children[3]).ItemsSource = CollectionViewSource.GetDefaultView(lastsMessages);
        }
    }
}
