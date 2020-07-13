using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Utils.Template.TemplateClass
{
    public class ItemListComment
    {
        public String Name { get; set; }
        public int Id { get; set; }
        public int IdWriter { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int IdTarget { get; set; }
        public String TypeTarget { get; set; }
        public String Content { get; set; }
        public String Date_Comment { get; set; }
        public List<int> ListIdLikers { get; set; }
    }
    public class CommentItem : ItemListComment
    {

    }

    public class CommentItemResponse : ItemListComment
    {

    }
}
