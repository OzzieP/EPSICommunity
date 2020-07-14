using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Tasks
    {
        public int IdTask { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public DateTime EndDate { get; set; }

        public Tasks()
        {
            
        }

        public Tasks(int idTask, string description, bool isDone, DateTime endDate)
        {
            IdTask = idTask;
            Description = description;
            IsDone = isDone;
            EndDate = endDate;
        }
    }
}
