using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Classe
    {
        public int Id { get; set; }
        public String Libelle { get; set; }
        public List<int> ListEtudiants { get; set; }

        public Classe(int id, String libelle, List<int> listEtudiants)
        {
            Id = id;
            Libelle = libelle;
            ListEtudiants = listEtudiants;
        }
    }
}
