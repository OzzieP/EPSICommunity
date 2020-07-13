using EPSICommunity.Model;
using EPSICommunity.Utils.data;
using EPSICommunity.Utils.Session;
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

namespace EPSICommunity.Views.Messagerie.Chat
{
    /// <summary>
    /// Logique d'interaction pour AddChat.xaml
    /// </summary>
    public partial class AddChat : UserControl
    {
        public AddChat()
        {
            InitializeComponent();
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            String[] conversationToUserTextBox = this.conversationToUserTextBox.Text.ToLower().Split(' ');
            String RecipientFirstName = char.ToUpper(conversationToUserTextBox[0][0]) + conversationToUserTextBox[0].Substring(1);
            String RecipientLastName = char.ToUpper(conversationToUserTextBox[1][0]) + conversationToUserTextBox[1].Substring(1);
            User Recipient = dataUtils.GetListUsers().Find(x => (x.Nom == RecipientLastName.ToUpper() && x.Prenom == RecipientFirstName) ||
                (x.Nom == RecipientFirstName && x.Prenom == RecipientLastName.ToUpper()));
            if (Recipient != null)
            {
                if (!String.IsNullOrWhiteSpace(this.MessageBody.Text))
                {
                    DateTime date = DateTime.Now;
                    String DateSending = (date.Day < 10 ? "0" + date.Day.ToString() : date.Day.ToString()) + "/" + (date.Month < 10 ? "0" + date.Month.ToString() : date.Month.ToString()) + "/" + date.Year.ToString();
                    String HoraireSending = (date.Hour < 10 ? "0" + date.Hour.ToString() : date.Hour.ToString()) + ":" + (date.Minute < 10 ? "0" + date.Minute.ToString() : date.Minute.ToString());
                    Message newMessage = new Message(
                        dataUtils.GetListMessages().Count + 1,
                        Recipient.Id,
                        UserConnected.GetUserConnected().Id,
                        UserConnected.GetUserConnected().Nom,
                        UserConnected.GetUserConnected().Prenom,
                        this.MessageBody.Text,
                        DateSending,
                        HoraireSending,
                        0
                    );
                    dataUtils.AddMessage(newMessage);
                    Conversation conversation = dataUtils.GetListConversations().Find(x => x.Users.Contains(UserConnected.GetUserConnected().Id) && x.Users.Contains(Recipient.Id));
                    if (conversation != null)
                    {
                        conversation.Messages.Add(newMessage.Id);
                    }
                    else
                    {
                        dataUtils.AddConversation(UserConnected.GetUserConnected().Id, Recipient.Id, newMessage.Id);
                    }
                    Conversation c = dataUtils.GetListConversations()
                        .Find(x => x.Users.Contains(UserConnected.GetUserConnected().Id) && x.Users.Contains(Recipient.Id));
                    if (c != null)
                    {
                        ((Grid)this.Parent).Children.Add(new Chat(c));
                        ((Grid)this.Parent).Children.Remove(this);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer un message !", "Epsi_Community");
                }
            }
            else
            {
                MessageBox.Show("Aucun Utilisateur ne correpond à celui indiqué !", "Epsi_Community");
            }
        }
    }
}
