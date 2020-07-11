using EPSICommunity.Utils.data;
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
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Mail { get; set; }
        public String Password { get; set; }
        public String NumeroVoie { get; set; }
        public String NomVoie { get; set; }
        public String ComplementAdresse { get; set; }
        public String CodePostal { get; set; }
        public String Ville { get; set; }
        public String Picture { get; set; }

        public User(int id, String nom, String prenom,  String mail, String password, String numeroVoie, String nomVoie, String complementAdresse, String codePostal, String ville, String picture)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Mail = mail;
            Password = password;
            NumeroVoie = numeroVoie;
            NomVoie = nomVoie;
            ComplementAdresse = complementAdresse;
            CodePostal = codePostal;
            Ville = ville;
            Picture = picture;
        }

        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            foreach(UserRole ur in dataUtils.GetListUserRole().Where(x => x.IdUser == Id))
            {
                roles.Add(dataUtils.GetListRoles().Find(x => x.Id == ur.Id));
            }
            return roles;
        }

        public List<int> GetIdRoles()
        {
            List<int> idRoles = new List<int>();
            foreach(UserRole ur in dataUtils.GetListUserRole().Where(x => x.IdUser == Id))
            {
                idRoles.Add(dataUtils.GetListRoles().Find(x => x.Id == ur.IdRole).Id);
            }
            return idRoles;
        }

        public List<String> GetHabilitations()
        {
            List<String> habilitations = new List<String>();
            foreach (UserRole ur in dataUtils.GetListUserRole().Where(x => x.IdUser == Id))
            {
                Role r = dataUtils.GetListRoles().Find(x => x.Id == ur.IdRole);
                foreach(int hid in r.ListHabilitations){
                    habilitations.Add(dataUtils.GetListDroits().Find(x => x.Id == hid).Libelle);
                }
            }
            return habilitations;
        }
    }
}
