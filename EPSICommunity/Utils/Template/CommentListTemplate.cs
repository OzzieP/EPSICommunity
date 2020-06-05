using EPSICommunity.Utils.Template.TemplateClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EPSICommunity.Utils.Template
{
    public class CommentListTemplate : DataTemplateSelector
    {
        public DataTemplate CommentTemplate { get; set; }
        public DataTemplate CommentResponseTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is CommentItem)
                return CommentTemplate;
            if (item is CommentItemResponse)
                return CommentResponseTemplate;

            return base.SelectTemplate(item, container);
        }
    }
}
