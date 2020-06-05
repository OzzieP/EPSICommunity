using EPSICommunity.Model;
using EPSICommunity.Utils.data;
using EPSICommunity.Utils.Session;
using EPSICommunity.Utils.Transformer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EPSICommunity.Views.Code
{
    /// <summary>
    /// Logique d'interaction pour AddExtraitCode.xaml
    /// </summary>
    public partial class AddExtraitCode : UserControl
    {
        public AddExtraitCode()
        {
            InitializeComponent();
            this.Code_TextBox.AcceptsTab = true;
            this.Code_TextBox.AcceptsReturn = true;
        }

        private void SendExtraitCode(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.Titre_Textbox.Text) || this.Titre_Textbox.Text.Equals(""))
            {
                MessageBox.Show("Veuillez entrer un titre !", "Espi Community", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (String.IsNullOrWhiteSpace(this.Titre_Textbox.Text))
            {
                MessageBox.Show("Le titre n'est pas conforme !", "Espi Community", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (String.IsNullOrEmpty(this.Description_Textbox.Text) || this.Description_Textbox.Text.Equals(""))
                {
                    MessageBox.Show("Veuillez entrer une description !", "Espi Community", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (String.IsNullOrWhiteSpace(this.Description_Textbox.Text))
                {
                    MessageBox.Show("La description n'est pas conforme !", "Epsi Community", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (String.IsNullOrEmpty(this.Code_TextBox.Text) || this.Code_TextBox.Text.Equals(""))
                    {
                        MessageBox.Show("Veuillez entrer un code !", "Espi Community", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (String.IsNullOrWhiteSpace(this.Code_TextBox.Text))
                    {
                        MessageBox.Show("Le code n'est pas conforme !", "Espi Community", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        try
                        {
                            DateTime fullDate = DateTime.Now;
                            String date = (fullDate.Day < 10 ? "0" + fullDate.Day.ToString() : fullDate.Day.ToString()) + "/" +
                                (fullDate.Month < 10 ? "0" + fullDate.Month.ToString() : fullDate.Month.ToString()) + "/" +
                                fullDate.Year.ToString();
                            String hour = (fullDate.Hour < 10 ? "0" + fullDate.Hour.ToString() : fullDate.Hour.ToString()) + ":" +
                                (fullDate.Minute < 10 ? "0" + fullDate.Minute.ToString() : fullDate.Minute.ToString()) + ":" +
                                (fullDate.Second < 10 ? "0" + fullDate.Second.ToString() : fullDate.Second.ToString());
                            String textTransform = TextEncoder.EncodeText(this.Code_TextBox.Text);
                            dataUtils.AddExtraitCode(
                                UserConnected.GetUserConnected().Id,
                                UserConnected.GetUserConnected().Nom,
                                UserConnected.GetUserConnected().Prenom,
                                Titre_Textbox.Text,
                                Description_Textbox.Text,
                                textTransform,
                                date,
                                hour
                            );
                            MessageBox.Show("Nouvel extrait de code créé !", "Espi Community", MessageBoxButton.OK, MessageBoxImage.Information);
                            TextBlock NoExtraitText = new TextBlock
                            {
                                Text = "Aucun extrait à afficher...",
                                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151")),
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Name = "NoExtraitText"
                            };
                            ((ListView)((Grid)((Grid)((Grid)this.Parent).Parent).Children[0]).Children[3]).ItemsSource = dataUtils.GetListExtraitsCode().Cast<ExtraitCode>().OrderBy(x => x.Date_Creation).ToList();
                            ((Grid)this.Parent).Children.Add(NoExtraitText);
                            ((Grid)this.Parent).Children.Remove(this);
                        }
                        catch
                        {
                            MessageBox.Show("Erreur lors de la création du nouvel extrait de code !", "Espi Community", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private void ClickToCancel(object sender, MouseButtonEventArgs e)
        {
            TextBlock NoExtraitText = new TextBlock
            {
                Text = "Aucun extrait à afficher...",
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151")),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Name = "NoExtraitText"
            };
            ((ListView)((Grid)((Grid)((Grid)this.Parent).Parent).Children[0]).Children[3]).ItemsSource = dataUtils.GetListExtraitsCode().Cast<ExtraitCode>().OrderBy(x => x.Date_Creation).ToList();
            ((Grid)this.Parent).Children.Add(NoExtraitText);
            ((Grid)this.Parent).Children.Remove(this);
        }
    }
}
