using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Role
    {
        public int IdRole { get; set; }

        public string Name { get; set; }



        public Role() { }

        public Role(int idRole, string name)
        {
            IdRole = idRole;
            Name = name;
        }
    }
}
