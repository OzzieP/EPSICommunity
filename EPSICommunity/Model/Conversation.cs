using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Conversation
    {
        public int Id { get; set; }
        public List<int> Users { get; set; }

        public List<int> Messages { get; set; }

        public Conversation(int id, List<int> users, List<int> messages)
        {
            Id = id;
            Users = users;
            Messages = messages;
        }

        public Conversation()
        {

        }
    }
}
