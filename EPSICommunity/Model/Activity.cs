using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class Activity
    {
        public int IdActivity { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }

        public Activity()
        {
            
        }

        public Activity(int idActivity, string description, string date)
        {
            IdActivity = idActivity;
            Description = description;
            Date = date;
        }
    }
}
