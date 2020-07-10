using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class RestrictionDroit
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdDroit { get; set; }
        public String Cause { get; set; }
        public int IdSanctionner { get; set; }
        public String DateDebutSanction { get; set; }
        public String DateFinSanction { get; set; }
        public int Levement { get; set; }
        public int IdLeveur { get; set; }
        public String DateLevement { get; set; }

        public RestrictionDroit(int id, int idUser, int idDroit, String cause, int idSanctionner, String dateDebutSanction, String dateFinSanction, int levement, int idLeveur, String dateLevement)
        {
            Id = id;
            IdUser = idUser;
            IdDroit = idDroit;
            Cause = cause;
            IdSanctionner = idSanctionner;
            DateDebutSanction = dateDebutSanction;
            DateFinSanction = dateFinSanction;
            Levement = levement;
            IdLeveur = idLeveur;
            DateLevement = dateLevement;
        }
    }
}
