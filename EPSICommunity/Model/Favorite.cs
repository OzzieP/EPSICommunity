using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EPSICommunity.Model
{
    public class Favorite
    {
        public string Name { get; set; }

        public string UserControl { get; set; }


        public Favorite()
        {
            
        }

        public Favorite(string name, string userControl)
        {
            Name = name;
            UserControl = userControl;
        }
    }
}
