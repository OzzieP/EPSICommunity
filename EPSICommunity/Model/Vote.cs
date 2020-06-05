using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Vote
    {
        public int Id { get; set; }
        public int IdTarget { get; set; }
        public String TypeTarget { get; set; }
        public int IdVoter { get; set; }
        public int Note { get; set; }

        public Vote(int id, int idTarget, String typeTarget, int idVoter, int note)
        {
            Id = id;
            IdTarget = idTarget;
            TypeTarget = typeTarget;
            IdVoter = idVoter;
            Note = note;
        }
    }
}
