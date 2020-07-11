using EPSICommunity.Model;
using EPSICommunity.Utils.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public static bool VerifyHabilitations()
        {
            bool habilitate = true;
            foreach(String s in userConnected.GetHabilitations())
            {
                if (habilitate)
                {
                    Droit d = dataUtils.GetListDroits().Find(x => x.Libelle == s);
                    if (d != null)
                    {
                        habilitate = CheckInDatabase(userConnected, d);
                    }
                    else
                    {
                        MessageBox.Show("Une erreur est survenue", "Espi Community", MessageBoxButton.OK, MessageBoxImage.Error);
                        habilitate = false;
                    }
                }
                else
                {
                    break;
                }
            }
            return habilitate;
        }

        public static bool VerifyHabilitation(String h)
        {
            return CheckInDatabase(userConnected, dataUtils.GetListDroits().Find(x => x.Libelle == h));
        }

        private static bool CheckInDatabase(User u, Droit d)
        {
            if (dataUtils.GetListRestrictionDroit().Count > 0)
            {
                RestrictionDroit rd = dataUtils.GetListRestrictionDroit().Find(x => (x.IdUser == u.Id) && (x.IdDroit == d.Id));
                if (rd != null)
                {
                    DateTime fullDate = DateTime.Now;
                    int _d = fullDate.Day < 10 ? Int32.Parse("0" + fullDate.Day.ToString()) : Int32.Parse(fullDate.Day.ToString());
                    int _m = fullDate.Month < 10 ? Int32.Parse("0" + fullDate.Month.ToString()) : Int32.Parse(fullDate.Month.ToString());
                    int _y = Int32.Parse(fullDate.Year.ToString());
                    if (_y < Int32.Parse(rd.DateFinSanction.Split('/')[2]))
                    {
                        return true;
                    }
                    else
                    {
                        if (_m < Int32.Parse(rd.DateFinSanction.Split('/')[1]))
                        {
                            return false;
                        }
                        else if (_m == Int32.Parse(rd.DateFinSanction.Split('/')[1]))
                        {
                            if (_d == Int32.Parse(rd.DateFinSanction.Split('/')[0]) || _d > Int32.Parse(rd.DateFinSanction.Split('/')[0]))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
