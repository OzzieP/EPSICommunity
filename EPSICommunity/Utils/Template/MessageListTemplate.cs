using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static EPSICommunity.Utils.Template.TemplateClass.ItemListMessage;

namespace EPSICommunity.Utils.Template
{
    public class MessageListTemplate : DataTemplateSelector
    {
        public DataTemplate MessageSenderTemplate { get; set; }
        public DataTemplate MessageSenderDateTemplate { get; set; }
        public DataTemplate SecondMessageSenderTemplate { get; set; }
        public DataTemplate MessageRecipientTemplate { get; set; }
        public DataTemplate MessageRecipientDateTemplate { get; set; }
        public DataTemplate SecondMessageRecipientTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MessageSenderItem)
                return MessageSenderTemplate;
            if (item is MessageSenderDateItem)
                return MessageSenderDateTemplate;
            if (item is SecondMessageSenderItem)
                return SecondMessageSenderTemplate;
            if (item is MessageRecipientItem)
                return MessageRecipientTemplate;
            if (item is MessageRecipientDateItem)
                return MessageRecipientDateTemplate;
            if (item is SecondMessageRecipientItem)
                return SecondMessageRecipientTemplate;

            return base.SelectTemplate(item, container);
        }
    }
}
