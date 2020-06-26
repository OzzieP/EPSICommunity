using EPSICommunity.Model;
using EPSICommunity.Utils.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EPSICommunity.Views.Messagerie
{
    public class MessageViewModel : ViewModelBase
    {

        private Message _selectedMessage;
        private readonly List<Message> _listMessages;
        private readonly List<Conversation> _lesConversations;
        public ICollectionView Messages { get; set; }
        public ICollectionView Conversations { get; set; }

        public Message SelectedMessage
        {
            get { return _selectedMessage; }
            set
            {
                _selectedMessage = value;
                NotifyPropertyChanged("SelectedUser");
            }
        }

        public MessageViewModel()
        {
            _listMessages = dataUtils.GetListMessages();

            Messages = CollectionViewSource.GetDefaultView(_listMessages);
            Messages.Refresh();

            _lesConversations = dataUtils.GetListConversations();

            Conversations = CollectionViewSource.GetDefaultView(_lesConversations);
            Conversations.Refresh();
        }
    }
}
