using EPSICommunity.Utils.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class ExtraitCode
    {
        public int Id { get; set; }
        public int IdCreator { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Code { get; set; }
        public String Date_Creation { get; set; }
        public String Heure_Creation { get; set; }
        public float Note { get; set; }

        public ExtraitCode(int id, int idCreator, String nom, String prenom, String title, String description, String code, String date_creation, String heure_creation, float note)
        {
            Id = id;
            IdCreator = idCreator;
            Nom = nom;
            Prenom = prenom;
            Title = title;
            Description = description;
            Code = code;
            Date_Creation = date_creation;
            Heure_Creation = heure_creation;
            Note = note;
        }

        public void CalculNote()
        {
            List<Vote> listVote = dataUtils.GetListVote().Where(x => (x.IdTarget == Id) && (x.TypeTarget.Equals("ExtraitCode"))).ToList();
            if (listVote == null || listVote.Count == 0)
            {
                Note = 0;
            }
            else
            {
                int totalNote = 0;
                foreach (Vote v in listVote)
                {
                    totalNote += v.Note;
                }
                Note = totalNote / listVote.Count;
            }
        }
    }
}
