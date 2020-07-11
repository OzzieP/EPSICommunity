using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Droit
    {
        public int Id { get; set; }
        public String Libelle { get; set; }
        public String Description { get; set; }

        public Droit(int id, String libelle, String description)
        {
            Id = id;
            Libelle = libelle;
            Description = description;
        }
    }
}
