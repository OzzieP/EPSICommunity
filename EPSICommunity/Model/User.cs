using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class User
    {
        public int Id { get; set; }
        public String Picture { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }

        public User(int id, String picture, String nom, String prenom)
        {
            Id = id;
            Picture = picture;
            Nom = nom;
            Prenom = prenom;
        }
    }
}
