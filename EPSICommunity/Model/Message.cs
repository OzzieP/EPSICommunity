using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Message
    {
        public int Id { get; set; }
        public int Id_Recipient { get; set; }
        public int Id_Sender { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Content { get; set; }
        public String Date_Sending { get; set; }
        public String Horaire_Sending { get; set; }
        public int Vu { get; set; }

        public Message(int id, int id_recipient, int id_sender, String nom, String prenom, String content, String date_sending, String horaire_sending, int vu)
        {
            Id = id;
            Id_Recipient = id_recipient;
            Id_Sender = id_sender;
            Nom = nom;
            Prenom = prenom;
            Content = content;
            Date_Sending = date_sending;
            Horaire_Sending = horaire_sending;
            Vu = vu;
        }
    }
}
