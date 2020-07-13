using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class DemandeSuppression
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int IdElement { get; set; }
        public String TypeElement { get; set; }
        public String Message { get; set; }
        public String DateDemande { get; set; }
        public int Validate { get; set; }
        public int? IdValider { get; set; }
        public String DateValidation { get; set; }

        public DemandeSuppression(int id, int idUser, String nom, String prenom, int idElement, String typeElement, String message, String dateDemande, int validate, int idValider, String dateValidation)
        {
            Id = id;
            IdUser = idUser;
            Nom = nom;
            Prenom = prenom;
            IdElement = idElement;
            TypeElement = typeElement;
            Message = message;
            DateDemande = dateDemande;
            Validate = validate;
            IdValider = idValider;
            DateValidation = dateValidation;
        }
    }
}
