using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ListHabilitations { get; set; }



        public Role() { }

        public Role(int id, string name, List<int> listHabilitations)
        {
            Id = id;
            Name = name;
            ListHabilitations = listHabilitations;
        }
    }
}
