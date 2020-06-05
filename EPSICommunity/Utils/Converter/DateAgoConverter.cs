using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EPSICommunity.Utils.Converter
{
    public class DateAgoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateComment = DateTime.Parse(value.ToString());
            DateTime dateNow = DateTime.Now;
            if (dateComment.Date == dateNow.Date)
            {
                if (dateComment.ToString().Split(' ')[1].ToString().Split(':')[0] == dateNow.ToString().Split(' ')[1].ToString().Split(':')[0])
                {
                    int minNow = Int32.Parse(dateNow.ToString().Split(' ')[1].ToString().Split(':')[1]);
                    int minComment = Int32.Parse(dateComment.ToString().Split(' ')[1].ToString().Split(':')[1]);
                    int minutesDifference = minNow - minComment;
                    if (minutesDifference == 0)
                    {
                        return "À l'instant";
                    }
                    else if (minutesDifference == 1)
                    {
                        return minutesDifference + " minute";
                    }
                    else
                    {
                        return minutesDifference + " minutes";
                    }
                }
                else
                {
                    int heureNow = Int32.Parse(dateNow.ToString().Split(' ')[1].ToString().Split(':')[0]);
                    int heureComment = Int32.Parse(dateComment.ToString().Split(' ')[1].ToString().Split(':')[0]);
                    int heureDifference = heureNow - heureComment;
                    if (heureDifference < 2)
                    {
                        return heureDifference + " heure";
                    }
                    else
                    {
                        return heureDifference + " heures";
                    }
                }
            }
            else
            {
                TimeSpan TimeDifference = dateNow.Date.Subtract(dateComment.Date);
                int difference = Int32.Parse(TimeDifference.ToString().Split('.')[0]);
                if (difference <= 7)
                {
                    if (difference == 1)
                    {
                        return "Hier";
                    }
                    else if (difference == 2)
                    {
                        return "2 jours";
                    }
                    else if (difference == 3)
                    {
                        return "3 jours";
                    }
                    else if (difference == 4)
                    {
                        return "4 jours";
                    }
                    else if (difference == 5)
                    {
                        return "5 jours";
                    }
                    else if (difference == 6)
                    {
                        return "6 jours";
                    }
                    else
                    {
                        return "7 jours";
                    }
                }
                else
                {
                    if (!dateNow.ToString().Split('/')[2].ToString().Split(' ')[0].Equals(dateComment.ToString().Split('/')[2].ToString().Split(' ')[0]))
                    {
                        int yearNow = Int32.Parse(dateNow.ToString().Split('/')[2].ToString().Split(' ')[0]);
                        int yearComment = Int32.Parse(dateComment.ToString().Split('/')[2].ToString().Split(' ')[0]);
                        if (yearComment - yearNow == 1)
                        {
                            return "1 an";
                        }
                        else
                        {
                            return value.ToString().Split(' ')[0];
                        }
                    }
                    else
                    {
                        if (!dateNow.ToString().Split('/')[1].Equals(dateComment.ToString().Split('/')[1]))
                        {
                            int monthNow = Int32.Parse(dateNow.ToString().Split('/')[1]);
                            int monthComment = Int32.Parse(dateComment.ToString().Split('/')[1]);
                            if (monthNow - monthComment == 1)
                            {
                                return "1 mois";
                            }
                            else if (monthNow - monthComment == 2)
                            {
                                return "2 mois";
                            }
                            else if (monthNow - monthComment == 3)
                            {
                                return "3 mois";
                            }
                            else if (monthNow - monthComment == 4)
                            {
                                return "4 mois";
                            }
                            else if (monthNow - monthComment == 5)
                            {
                                return "5 mois";
                            }
                            else if (monthNow - monthComment == 6)
                            {
                                return "6 mois";
                            }
                            else if (monthNow - monthComment == 7)
                            {
                                return "7 mois";
                            }
                            else if (monthNow - monthComment == 8)
                            {
                                return "8 mois";
                            }
                            else if (monthNow - monthComment == 9)
                            {
                                return "9 mois";
                            }
                            else if (monthNow - monthComment == 10)
                            {
                                return "10 mois";
                            }
                            else if (monthNow - monthComment == 11)
                            {
                                return "11 mois";
                            }
                            else
                            {
                                return "12 mois";
                            }
                        }
                        else
                        {
                            if (difference <= 14)
                            {
                                return "1 semaine";
                            }
                            else if (difference <= 21)
                            {
                                return "2 semaines";
                            }
                            else
                            {
                                return "3 semaines";
                            }
                        }
                    }
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
