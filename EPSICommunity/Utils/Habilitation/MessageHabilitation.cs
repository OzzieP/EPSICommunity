using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EPSICommunity.Utils.Habilitation
{
    public class MessageHabilitation
    {
        public static void MessageNoHabilitate()
        {
            MessageBox.Show("Vous n'avez pas les autorisations requises !", "Espi Community", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MessageNoHabilitatePersonnalized(String endMessage)
        {
            MessageBox.Show("Vous n'êtes pas habilité à " + endMessage, "Espi Community", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
