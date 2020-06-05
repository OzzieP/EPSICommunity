using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Favoris
    {
        public int Id { get; set; }
        public int IdTarget { get; set; }
        public String TypeTarget { get; set; }
        public int IdUser { get; set; }

        public Favoris(int id, int idTarget, String typeTarget, int idUser)
        {
            Id = id;
            IdTarget = idTarget;
            TypeTarget = typeTarget;
            IdUser = idUser;
        }
    }
}
