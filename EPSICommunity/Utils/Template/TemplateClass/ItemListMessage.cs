using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Utils.Template.TemplateClass
{
    public class ItemListMessage
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public String Date_Sending { get; set; }
        public String Horaire_Sending { get; set; }
        public String Picture { get; set; }

        public class MessageSenderItem : ItemListMessage
        {

        }

        public class MessageSenderDateItem : ItemListMessage
        {

        }

        public class SecondMessageSenderItem : ItemListMessage
        {

        }

        public class MessageRecipientItem : ItemListMessage
        {

        }

        public class MessageRecipientDateItem : ItemListMessage
        {

        }

        public class SecondMessageRecipientItem : ItemListMessage
        {

        }
    }
}
