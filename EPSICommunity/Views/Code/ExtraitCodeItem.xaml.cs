using EPSICommunity.Model;
using EPSICommunity.Utils.data;
using EPSICommunity.Utils.Session;
using EPSICommunity.Utils.Template.TemplateClass;
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
    /// Logique d'interaction pour ExtraitCodeItem.xaml
    /// </summary>
    public partial class ExtraitCodeItem : UserControl
    {
        private readonly ExtraitCode ec;
        private int IdCommentToResponse;
        private List<Comment> _listComments;
        private List<ItemListComment> _listItemComment;

        public ExtraitCodeItem(ExtraitCode extraitCode)
        {
            InitializeComponent();
            ec = extraitCode;
            List<User> listApprouvedUser = new List<User>();
            OrganizeListComment();
            if (_listComments.Count == 0 || _listComments == null)
            {
                this.CommentBlock.Children.Remove(ListComments);
                TextBlock NoComments = new TextBlock
                {
                    Text = "Pas de commentaire...",
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF")),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                this.CommentBlock.Children.Add(NoComments);
            }
            ExtraitCodeApprouved extraitCodeApprouved = dataUtils.GetListExtraitsCodeApprouved().Find(x => x.IdExtraitCode == extraitCode.Id);
            if (extraitCodeApprouved == null)
            {
                this.ApprouvedBlock.Visibility = Visibility.Hidden;
            }
            else
            {
                foreach (int i in extraitCodeApprouved.ListApprouver)
                {
                    listApprouvedUser.Add(dataUtils.GetListUsers().Find(x => x.Id == i));
                }
            }
            Binding binding = new Binding
            {
                Mode = BindingMode.OneWay
            };
            this.ExtraitCode_Creator.Text = dataUtils.GetListUsers().Find(x => x.Id == extraitCode.IdCreator).Nom + " " +
                dataUtils.GetListUsers().Find(x => x.Id == extraitCode.IdCreator).Prenom;
            this.ListComments.ItemsSource = _listItemComment;
            this.ExtraitCode_Title.Text = extraitCode.Title;
            this.ExtraitCode_Description.Text = extraitCode.Description;
            if (UserConnected.GetUserConnected().Id == ec.IdCreator)
            {
                this.DeleteExtraitCodeIcon.Visibility = Visibility.Visible;
            }
            else
            {
                this.DeleteExtraitCodeIcon.Visibility = Visibility.Collapsed;
            }
            Favoris isFavoris = dataUtils.GetListFavoris().Find(x =>
                (x.IdTarget == ec.Id) &&
                (x.IdUser == UserConnected.GetUserConnected().Id) &&
                (x.TypeTarget.Equals("ExtraitCode"))
            );
            if (isFavoris != null)
            {
                this.FavorisExtraitCodeIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.Heart;
            }
            else
            {
                this.FavorisExtraitCodeIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.HeartOutline;
            }
            this.ExtraitCode_Code.Text = TextEncoder.DecodeText(extraitCode.Code);
            this.ExtraitCode_Note.Text = extraitCode.Note.ToString();
            DisplayTotalVote(dataUtils.GetListVote().Where(x => (x.IdTarget == extraitCode.Id) && (x.TypeTarget.Equals("ExtraitCode"))).ToList().Count);
            ChangePersonalVote(extraitCode);
            ChangeApprouverList(listApprouvedUser);
            this.Picture_Creator.ImageSource = new BitmapImage
            (
                new Uri(String.Format("pack://application:,,,/Resources/" + dataUtils.GetListUsers().Find(x => x.Id == extraitCode.IdCreator).Picture))
            );
            this.ExtraitCode_DateCreation.Text = RebuildDateCreation(extraitCode.Date_Creation);
        }

        private void OrganizeListComment()
        {
            _listItemComment = new List<ItemListComment>();
            _listComments = dataUtils.GetListComments().ToList().Where(x => (x.TypeTarget.Equals("ExtraitCode")) && (x.IdTarget == ec.Id)).ToList();
            if (_listComments != null)
            {
                _listComments = _listComments.OrderByDescending(x => x.Id).ToList();
                foreach (Comment c in _listComments)
                {
                    List<Comment> commentOfComment = dataUtils.GetListComments().Where(x => (x.IdTarget == c.Id) && (x.TypeTarget.Equals("Comment"))).ToList();
                    if (commentOfComment.Find(x => x.IdTarget == c.Id) != null)
                    {
                        int nbTTLike = 0;
                        foreach (Comment coc in commentOfComment)
                        {
                            nbTTLike += coc.ListIdLikers.Count;
                        }
                        commentOfComment = nbTTLike > 0 ? commentOfComment.OrderByDescending(x => x.ListIdLikers.Count).ToList() : commentOfComment.OrderBy(x => x.Id).ToList();
                        _listItemComment.Add(new CommentItem
                        {
                            Id = c.Id,
                            IdWriter = c.IdWriter,
                            Nom = c.Nom,
                            Prenom = c.Prenom,
                            IdTarget = c.IdTarget,
                            TypeTarget = c.TypeTarget,
                            Content = c.Content,
                            Date_Comment = c.Date_Comment,
                            ListIdLikers = c.ListIdLikers
                        });
                        foreach (Comment coc in commentOfComment)
                        {
                            _listItemComment.Add(new CommentItemResponse
                            {
                                Id = coc.Id,
                                IdWriter = coc.IdWriter,
                                Nom = coc.Nom,
                                Prenom = coc.Prenom,
                                IdTarget = coc.IdTarget,
                                TypeTarget = coc.TypeTarget,
                                Content = coc.Content,
                                Date_Comment = coc.Date_Comment,
                                ListIdLikers = coc.ListIdLikers
                            });
                        }
                    }
                    else
                    {
                        _listItemComment.Add(new CommentItem
                        {
                            Id = c.Id,
                            IdWriter = c.IdWriter,
                            Nom = c.Nom,
                            Prenom = c.Prenom,
                            IdTarget = c.IdTarget,
                            TypeTarget = c.TypeTarget,
                            Content = c.Content,
                            Date_Comment = c.Date_Comment,
                            ListIdLikers = c.ListIdLikers
                        });
                    }

                }
            }
        }

        private void ChangeApprouverList(List<User> listApprouverUser)
        {
            if (listApprouverUser.Count != 0)
            {
                this.ApprouverList1.ImageSource = new BitmapImage(new Uri(VerifyPictureUser(listApprouverUser[0])));
                this.tt_approuver1.Content = listApprouverUser[0].Nom + " " + listApprouverUser[0].Prenom;
                if (listApprouverUser.Count >= 2)
                {
                    this.ApprouverList2.ImageSource = new BitmapImage(new Uri(VerifyPictureUser(listApprouverUser[1])));
                    this.tt_approuver2.Content = listApprouverUser[1].Nom + " " + listApprouverUser[1].Prenom;
                    if (listApprouverUser.Count >= 3)
                    {
                        this.ApprouverList3.ImageSource = new BitmapImage(new Uri(VerifyPictureUser(listApprouverUser[2])));
                        this.tt_approuver3.Content = listApprouverUser[2].Nom + " " + listApprouverUser[2].Prenom;
                        if (listApprouverUser.Count >= 4)
                        {
                            this.ApprouverList4.ImageSource = new BitmapImage(new Uri(VerifyPictureUser(listApprouverUser[3])));
                            this.tt_approuver4.Content = listApprouverUser[3].Nom + " " + listApprouverUser[3].Prenom;
                            if (listApprouverUser.Count >= 5)
                            {
                                this.ApprouverList5.ImageSource = new BitmapImage(new Uri(VerifyPictureUser(listApprouverUser[4])));
                                this.tt_approuver5.Content = listApprouverUser[4].Nom + " " + listApprouverUser[4].Prenom;
                                if (listApprouverUser.Count >= 6)
                                {
                                    for (int i = 6; i <= listApprouverUser.Count; i++)
                                    {
                                        if (i != listApprouverUser.Count)
                                        {
                                            this.tt_approuverList.Content += listApprouverUser[i].Nom + " " + listApprouverUser[i].Prenom + "\n";
                                        }
                                        else
                                        {
                                            this.tt_approuverList.Content += listApprouverUser[i].Nom + " " + listApprouverUser[i].Prenom;
                                        }
                                    }
                                }
                                else
                                {
                                    this.ApprouverListPLus.Visibility = Visibility.Collapsed;
                                }
                            }
                            else
                            {
                                this.ApprouverListContainer5.Visibility = Visibility.Collapsed;
                                this.ApprouverListPLus.Visibility = Visibility.Collapsed;
                            }
                        }
                        else
                        {
                            this.ApprouverListContainer4.Visibility = Visibility.Collapsed;
                            this.ApprouverListContainer5.Visibility = Visibility.Collapsed;
                            this.ApprouverListPLus.Visibility = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        this.ApprouverListContainer3.Visibility = Visibility.Collapsed;
                        this.ApprouverListContainer4.Visibility = Visibility.Collapsed;
                        this.ApprouverListContainer5.Visibility = Visibility.Collapsed;
                        this.ApprouverListPLus.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    this.ApprouverListContainer2.Visibility = Visibility.Collapsed;
                    this.ApprouverListContainer3.Visibility = Visibility.Collapsed;
                    this.ApprouverListContainer4.Visibility = Visibility.Collapsed;
                    this.ApprouverListContainer5.Visibility = Visibility.Collapsed;
                    this.ApprouverListPLus.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                this.ApprouverText.Visibility = Visibility.Collapsed;
                this.ApprouverListGrid.Visibility = Visibility.Collapsed;
            }
        }

        private String VerifyPictureUser(User user)
        {
            return user.Picture.Equals("") ? "pack://application:,,,/Resources/Images/unnamed.png" : "pack://application:,,,/Resources/" + user.Picture;
        }

        private String RebuildDateCreation(String dateCreation)
        {
            dateCreation = dateCreation.Split(' ')[0];
            String dateCreation_day = dateCreation.Split('/')[0];
            String dateCreation_month = dateCreation.Split('/')[1];
            String dateCreation_year = dateCreation.Split('/')[2];
            if (dateCreation_month.Equals("01"))
            {
                dateCreation_month = "Janvier";
            }
            else if (dateCreation_month.Equals("02"))
            {
                dateCreation_month = "Février";
            }
            else if (dateCreation_month.Equals("03"))
            {
                dateCreation_month = "Mars";
            }
            else if (dateCreation_month.Equals("04"))
            {
                dateCreation_month = "Avril";
            }
            else if (dateCreation_month.Equals("05"))
            {
                dateCreation_month = "Mai";
            }
            else if (dateCreation_month.Equals("06"))
            {
                dateCreation_month = "Juin";
            }
            else if (dateCreation_month.Equals("07"))
            {
                dateCreation_month = "Juillet";
            }
            else if (dateCreation_month.Equals("08"))
            {
                dateCreation_month = "Août";
            }
            else if (dateCreation_month.Equals("09"))
            {
                dateCreation_month = "Septembre";
            }
            else if (dateCreation_month.Equals("10"))
            {
                dateCreation_month = "Octobre";
            }
            else if (dateCreation_month.Equals("11"))
            {
                dateCreation_month = "Novembre";
            }
            else if (dateCreation_month.Equals("12"))
            {
                dateCreation_month = "Décembre";
            }
            return dateCreation_day + " " + dateCreation_month + " " + dateCreation_year;
        }

        private void Focus_AddTextBox(object sender, MouseButtonEventArgs e)
        {
            if (this.AddComment.Text.Equals("Écrire un commentaire..."))
            {
                this.AddComment.Text = "";
            }
        }

        private void LostFocus_TextBox(object sender, RoutedEventArgs e)
        {
            if (this.AddComment.Text.Equals(""))
            {
                this.AddComment.Text = "Écrire un commentaire...";
            }
        }

        private void SendComment(object sender, MouseButtonEventArgs e)
        {
            if (this.AddComment.Text.Equals("") || this.AddComment.Text.Equals("Écrire un commentaire..."))
            {
                MessageBox.Show("Veuillez écrire un commentaire !", "Espi Community", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DateTime fullDate = DateTime.Now;
                String date = (fullDate.Day < 10 ? "0" + fullDate.Day.ToString() : fullDate.Day.ToString()) + "/" +
                    (fullDate.Month < 10 ? "0" + fullDate.Month.ToString() : fullDate.Month.ToString()) + "/" +
                    fullDate.Year.ToString();
                String hour = (fullDate.Hour < 10 ? "0" + fullDate.Hour.ToString() : fullDate.Hour.ToString()) + ":" +
                    (fullDate.Minute < 10 ? "0" + fullDate.Minute.ToString() : fullDate.Minute.ToString()) + ":" +
                    (fullDate.Second < 10 ? "0" + fullDate.Second.ToString() : fullDate.Second.ToString());
                String dateComment = date + " " + hour;
                if ((this.TextBlock_ReponseName.Text != null || !this.TextBlock_ReponseName.Text.Equals(""))
                    && this.TextBlock_Reponse.Visibility == Visibility.Collapsed && this.TextBlock_ReponseName.Visibility == Visibility.Collapsed)
                {
                    dataUtils.AddComment(
                        UserConnected.GetUserConnected().Id,
                        UserConnected.GetUserConnected().Nom,
                        UserConnected.GetUserConnected().Prenom,
                        IdCommentToResponse,
                        "ExtraitCode",
                        this.AddComment.Text,
                        dateComment
                    );
                }
                else
                {
                    dataUtils.AddComment(
                        UserConnected.GetUserConnected().Id,
                        UserConnected.GetUserConnected().Nom,
                        UserConnected.GetUserConnected().Prenom,
                        IdCommentToResponse,
                        "Comment",
                        this.AddComment.Text,
                        dateComment
                    );
                }
                this.AddComment.Text = "Écrire un commentaire...";
                OrganizeListComment();
                this.ListComments.ItemsSource = _listItemComment;
            }
        }

        private void ChangePersonalVote(ExtraitCode extraitCode)
        {
            Vote MyVote = dataUtils.GetListVote().Find(x =>
                (x.IdTarget == extraitCode.Id) &&
                (x.TypeTarget == "ExtraitCode") &&
                (x.IdVoter == UserConnected.GetUserConnected().Id)
            );
            if (MyVote != null)
            {
                if (MyVote.Note > 0)
                {
                    if (MyVote.Note == 1)
                    {
                        this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                        this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                        this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                        this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                        this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                    }
                    else if (MyVote.Note == 2)
                    {
                        this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                        this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                        this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                        this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                    }
                    else if (MyVote.Note == 3)
                    {
                        this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                        this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                        this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                    }
                    else if (MyVote.Note == 4)
                    {
                        this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                        this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                    }
                    else if (MyVote.Note == 5)
                    {
                        this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                        this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                        this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                    }
                }
                else
                {
                    this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                    this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                    this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                    this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                    this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                    this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                    this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                    this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                    this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                    this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                }
            }
            else
            {
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
            }
        }

        private void HoverStarNote1(object sender, MouseEventArgs e)
        {
            if (this.StarNote1.Foreground == new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151")))
            {
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
            }
            else
            {
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
            }
        }

        private void HoverStarNot2(object sender, MouseEventArgs e)
        {
            if (this.StarNote2.Foreground == new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151")))
            {
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
            }
            else
            {
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
            }
        }

        private void HoverStarNote3(object sender, MouseEventArgs e)
        {
            if (this.StarNote3.Foreground == new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151")))
            {
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
            }
            else
            {
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
                this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
            }
        }

        private void HoverStarNote4(object sender, MouseEventArgs e)
        {
            if (this.StarNote4.Foreground == new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151")))
            {
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
            }
            else
            {
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.StarOutline;
            }
        }

        private void HoverStarNote5(object sender, MouseEventArgs e)
        {
            if (this.StarNote5.Foreground == new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151")))
            {
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
            }
            else
            {
                this.StarNote1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
                this.StarNote1.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote2.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote3.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote4.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
                this.StarNote5.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
            }
        }

        private void HoverStarNote(object sender, MouseEventArgs e)
        {
            ChangePersonalVote(ec);
        }

        private void HoverDelete(object sender, MouseEventArgs e)
        {
            this.DeleteExtraitCodeIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
        }

        private void LostHoverDelete(object sender, MouseEventArgs e)
        {
            this.DeleteExtraitCodeIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
        }

        private void DisplayTotalVote(int totalVote)
        {
            String voteString = totalVote <= 1 ? totalVote.ToString() + " Vote" : totalVote.ToString() + " Votes";
            this.ExtraitCode_TotalVote.Text = voteString;
        }

        private void ConfirmVote(int note)
        {
            Vote ExistingVote = dataUtils.GetListVote().Find(x =>
                (x.IdTarget == ec.Id) &&
                (x.TypeTarget.Equals("ExtraitCode")) &&
                (x.IdVoter == UserConnected.GetUserConnected().Id)
            );
            if (ExistingVote == null)
            {
                dataUtils.AddVote(ec.Id, "ExtraitCode", UserConnected.GetUserConnected().Id, note);
            }
            else
            {
                ExistingVote.Note = note;
            }
            ec.CalculNote();
            this.ExtraitCode_Note.Text = ec.Note.ToString();
            DisplayTotalVote(dataUtils.GetListVote().Where(x => (x.IdTarget == ec.Id) && (x.TypeTarget.Equals("ExtraitCode"))).ToList().Count);
        }

        private void ClickStarNote1(object sender, MouseButtonEventArgs e)
        {
            ConfirmVote(1);
        }

        private void ClickStarNote2(object sender, MouseButtonEventArgs e)
        {
            ConfirmVote(2);
        }

        private void ClickStarNote3(object sender, MouseButtonEventArgs e)
        {
            ConfirmVote(3);
        }

        private void ClickStarNote4(object sender, MouseButtonEventArgs e)
        {
            ConfirmVote(4);
        }

        private void ClickStarNote5(object sender, MouseButtonEventArgs e)
        {
            ConfirmVote(5);
        }

        private void DeleteExtraitCode(object sender, RoutedEventArgs e)
        {
            dataUtils.RemoveExtraitCode(ec.Id);
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

        private void HoverFavoris(object sender, MouseEventArgs e)
        {
            this.FavorisExtraitCodeIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#515151"));
        }

        private void LostHoverFavoris(object sender, MouseEventArgs e)
        {
            this.FavorisExtraitCodeIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BFBFBF"));
        }

        private void AddToFavoris(object sender, RoutedEventArgs e)
        {
            Favoris isFavoris = dataUtils.GetListFavoris().Find(x =>
                (x.IdTarget == ec.Id) &&
                (x.IdUser == UserConnected.GetUserConnected().Id) &&
                (x.TypeTarget.Equals("ExtraitCode"))
            );
            if (isFavoris != null)
            {
                dataUtils.RemoveFavoris(ec.Id, "ExtraitCode", UserConnected.GetUserConnected().Id);
                this.FavorisExtraitCodeIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.HeartOutline;
            }
            else
            {
                dataUtils.AddFavoris(ec.Id, "ExtraitCode", UserConnected.GetUserConnected().Id);
                this.FavorisExtraitCodeIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.Heart;
            }
        }

        private void LikeComment(object sender, RoutedEventArgs e)
        {
            ItemListComment commentSelected = (ItemListComment)(sender as FrameworkElement).DataContext;
            if (dataUtils.GetListComments().Find(x => x.Id == commentSelected.Id).ListIdLikers.Contains(UserConnected.GetUserConnected().Id))
            {
                dataUtils.GetListComments().Find(x => x.Id == commentSelected.Id).ListIdLikers.Remove(UserConnected.GetUserConnected().Id);
            }
            else
            {
                dataUtils.GetListComments().Find(x => x.Id == commentSelected.Id).ListIdLikers.Add(UserConnected.GetUserConnected().Id);
            }
            OrganizeListComment();
            this.ListComments.ItemsSource = _listItemComment;
        }

        private void AddResponse(object sender, RoutedEventArgs e)
        {
            ItemListComment commentSelected = (ItemListComment)(sender as FrameworkElement).DataContext;
            IdCommentToResponse = commentSelected.Id;
            this.TextBlock_ReponseName.Text = commentSelected.Nom + " " + commentSelected.Prenom;
            this.TextBlock_Reponse.Visibility = Visibility.Visible;
            this.TextBlock_ReponseName.Visibility = Visibility.Visible;
            this.AddComment.Text = "";
            this.AddComment.Focus();
        }
    }
}
