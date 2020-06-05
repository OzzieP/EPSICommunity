using EPSICommunity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Utils.Session
{
    public class UserConnected
    {
        public static User userConnected;

        public static void SetUserConnected(User user)
        {
            userConnected = user;
        }

        public static User GetUserConnected()
        {
            return userConnected;
        }
    }
}
