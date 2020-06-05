using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int IdWriter { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int IdTarget { get; set; }
        public String TypeTarget { get; set; }
        public String Content { get; set; }
        public String Date_Comment { get; set; }
        public List<int> ListIdLikers { get; set; }

        public Comment(int id, int idWriter, String nom, String prenom, int idTarget, String typeTarget, String content, String date_Comment, List<int> listIdLikers)
        {
            Id = id;
            IdWriter = idWriter;
            Nom = nom;
            Prenom = prenom;
            IdTarget = idTarget;
            TypeTarget = typeTarget;
            Content = content;
            Date_Comment = date_Comment;
            ListIdLikers = listIdLikers;
        }
    }
}
