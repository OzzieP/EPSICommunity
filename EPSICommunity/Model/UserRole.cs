using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class UserRole
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdRole { get; set; }

        public UserRole(int id, int idUser, int idRole)
        {
            Id = id;
            IdUser = idUser;
            IdRole = idRole;
        }
    }
}
