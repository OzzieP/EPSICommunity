using EPSICommunity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Utils.data
{
    public class dataUtils
    {
        public static List<User> listUsers;
        public static List<Conversation> listConversations;
        public static List<Message> listMessages;
        public static List<ExtraitCode> listExtraitsCodes;
        public static List<ExtraitCodeApprouved> listExtraitsCodeApprouved;
        public static List<Comment> listComments;
        public static List<Vote> listVotes;
        public static List<Favoris> listFavoris;

        /* -- User -- */
        public static void SetDataUtils()
        {
            SetListUsers();
            SetListMessages();
            SetListConversations();
            SetListExtraitsCode();
            SetListExtraitsCodeApprouved();
            SetListComments();
            SetListVote();
            SetListFavoris();
        }

        public static void SetListUsers()
        {
            listUsers = new List<User>
            {
                new User(1, "Images/unnamed.png", "CAZIN", "Nicolas"),
                new User(2, "Images/unnamed.png", "LEGRAND", "Quentin"),
                new User(3, "", "DUBOIS", "Mathieu"),
                new User(4, "Images/unnamed.png", "LEGENDRE", "Brendan"),
                new User(5, "Images/unnamed.png", "WILLERVAL", "Romain"),
                new User(6, "Images/unnamed.png", "LORENTE", "Romain")
            };
        }

        public static List<User> GetListUsers()
        {
            return listUsers;
        }

        /* -- Message -- */
        public static void SetListMessages()
        {
            listMessages = new List<Message>
            {
                new Message(1, 3, 1, "CAZIN", "Nicolas", "Salut tu vas bien ?", "19/05/2020", "22:37:12", 1),
                new Message(2, 1, 3, "DUBOIS", "Mathieu", "Niquel et toi ?", "20/05/2020", "22:41:48", 1),
                new Message(3, 3, 1, "CAZIN", "Nicolas", "Tranquile tranquille", "20/05/2020", "22:47:52", 1),
                new Message(4, 2, 1, "CAZIN", "Nicolas", "J'ai fais la merge request", "19/05/2020", "23:01:15", 1),
                new Message(5, 2, 1, "CAZIN", "Nicolas", "C'est à jour", "19/05/2020", "23:02:45", 1),
                new Message(6, 1, 2, "LEGRAND", "Quentin", "Ok niquel merci !", "19/05/2020", "23:05:37", 0),
                new Message(7, 4, 6, "LORENTE", "Romain", "Hey mon beau", "19/05/2020", "14:12:12", 1),
                new Message(8, 6, 4, "LEGENDRE", "Brendan","Bien ou bien", "19/05/2020", "14:18:19", 0),
                new Message(9, 6, 4, "LEGENDRE", "Brendan", "Je suis HS", "19/05/2020", "14:19:11", 0),
                new Message(10, 3, 5, "WILLERVAL", "Romain", "Hello", "19/05/2020", "10:33:38", 1),
                new Message(11, 5, 3, "DUBOIS", "Mathieu", "Hi bien ?", "19/05/2020", "12:08:49", 1),
                new Message(12, 3, 5, "WILLERVAL", "Romain", "Oklm et toi", "19/05/2020", "12:11:02", 1),
                new Message(13, 2, 6, "LORENTE", "Romain", "Salut tu vas bien ?", "19/05/2020", "15:17:14", 0),
                new Message(14, 5, 6, "LORENTE", "Romain", "Oui ca commence à aller mieux ! Merci :)", "19/05/2020", "16:48:33", 0),
                new Message(15, 1, 6, "LORENTE", "Romain", "Bien mon pote ?", "20/05/2020", "17:11:46", 0),
                new Message(16, 3, 1, "CAZIN", "Nicolas", "Re", "21/05/2020", "11:06:52", 1),
                new Message(17, 1, 3, "DUBOIS", "Mathieu", "Re", "21/05/2020", "11:14:08", 1),
                new Message(18, 3, 1, "CAZIN", "Nicolas", "Est-ce que tu pourrais me dire où est-ce que tu en es sur le projet ?", "21/05/2020", "11:18:43", 1),
                new Message(19, 3, 1, "CAZIN", "Nicolas", "Parce que sur ma partie je vais avoir besoin d'utiliser ce que tu as  fait, ou le refaire par dessus.. mais c'est pas ouf", "21/05/2020", "11:19:28", 1),
                new Message(20, 3, 1, "CAZIN", "Nicolas", "Merci :D", "21/05/2020", "11:19:46", 1),
                new Message(21, 1, 3, "DUBOIS", "Mathieu", "Oui désolé, j'ai fini mais j'ai oublié de commit mon travail", "21/05/2020", "11:21:22", 1),
                new Message(22, 1, 3, "DUBOIS", "Mathieu", "Je te fais ça tout de suite", "21/05/2020", "11:21:53", 1),
                new Message(23, 3, 1, "CAZIN", "Nicolas", "Ok merci !", "21/05/2020", "11:22:03", 1),
                new Message(24, 1, 3, "DUBOIS", "Mathieu", "C'est fait !", "21/05/2020", "11:25:14", 1),
                new Message(25, 1, 3, "DUBOIS", "Mathieu", "Tout est bon ?", "21/05/2020", "11:25:32", 1),
                new Message(26, 3, 1, "CAZIN", "Nicolas", "Oui nickel merci", "21/05/2020", "11:27:53", 1),
                new Message(27, 1, 3, "DUBOIS", "Mathieu", "Dac bon courage", "21/05/2020", "11:28:46", 1),
                new Message(28, 3, 1, "CAZIN", "Nicolas", "Merci !", "21/05/2020", "11:29:12", 1)
            };
        }

        public static List<Message> GetListMessages()
        {
            return listMessages;
        }

        public static void AddMessage(Message message)
        {
            listMessages.Add(message);
        }

        public static void AddMessage(int RecipientId, int SenderId, String nom, String prenom, String content, String dateSending, String horaireSending)
        {
            listMessages.Add(new Message(listMessages.Count + 1, RecipientId, SenderId, nom, prenom, content, dateSending, horaireSending, 0));
        }

        public static Message GetMessage(int idMessage)
        {
            return listMessages.Find(x => x.Id == idMessage);
        }

        public static void DeleteMessage(Message message)
        {
            listMessages.Remove(message);
        }

        public static void DeleteMessages(List<int> idsMessages)
        {
            foreach (int i in idsMessages)
            {
                DeleteMessage(listMessages.Find(x => x.Id == i));
            }
        }

        public static void DeleteMessages(List<Message> messages)
        {
            foreach (Message m in messages)
            {
                DeleteMessage(m);
            }
        }


        /* -- Conversation -- */
        public static void SetListConversations()
        {
            listConversations = new List<Conversation>
            {
                new Conversation(1, new List<int>{3, 1}, new List<int>{1, 2, 3, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28}),
                new Conversation(2, new List<int>{2, 1}, new List<int>{4, 5, 6}),
                new Conversation(3, new List<int>{4, 6}, new List<int>{7, 8, 9}),
                new Conversation(4, new List<int>{3, 5}, new List<int>{10, 11, 12}),
                new Conversation(5, new List<int>{2, 6}, new List<int>{13}),
                new Conversation(6, new List<int>{5, 6}, new List<int>{14}),
                new Conversation(7, new List<int>{1, 6}, new List<int>{15})
            };
        }

        public static void AddConversation(int UserConnectedId, int CorrespondantId, int MessageId)
        {
            listConversations.Add(new Conversation(listConversations.Count + 1, new List<int> { UserConnectedId, CorrespondantId }, new List<int> { MessageId }));
        }

        public static void AddMessageToConversation(int idConversation, int idMessage)
        {
            GetListConversations().Find(x => x.Id == idConversation).Messages.Add(idMessage);
        }

        public static Conversation GetConversation(int idConversation)
        {
            return GetListConversations().Find(x => x.Id == idConversation);
        }

        public static List<Message> GetMessagesOfConversation(int idConversation)
        {
            List<Message> messagesOfConversation = new List<Message>();
            foreach (int i in GetConversation(idConversation).Messages)
            {
                messagesOfConversation.Add(GetMessage(i));
            }
            return messagesOfConversation;
        }

        public static List<Conversation> GetListConversations()
        {
            return listConversations;
        }

        public static void DeleteConversation(int idConversation)
        {
            listConversations.Remove(listConversations.Find(x => x.Id == idConversation));
        }

        /* -- Extrait code -- */
        public static void SetListExtraitsCode()
        {
            listExtraitsCodes = new List<ExtraitCode>
            {
                new ExtraitCode(1, 1, "CAZIN", "Nicolas", "Links To Css in HTML",
                                                        "Appel du ou des fichiers css dans l'entête de la page HTML",
                                                        "<!DOCTYPE&#x20;html>&#x0A;" +
                                                            "<html>&#x0A;" +
                                                            "&#xA7;<head>&#x0A;" +
                                                            "&#xA7;&#xA7;<link&#x20;rel=&#x22;stylesheet&#x22;&#x20;type=&#x22;text/css&#x22;&#x20;href=&#x22;mystyle.css&#x22;&#x20;/>&#x0A;" +
                                                            "&#xA7;</head>&#x0A;" +
                                                            "&#xA7;<body>&#x0A;" +
                                                            "&#xA7;&#xA7;<h1>This&#x20;is&#x20;a&#x20;heading</h1>&#x0A;" +
                                                            "&#xA7;&#xA7;<p>This&#x20;is&#x20;a&#x20;paragraph.</p>&#x0A;" +
                                                            "&#xA7;</body>&#x0A;" +
                                                            "</html>&#x0A;",
                                                        "27/05/2020", "14:30", 5),
                new ExtraitCode(2, 4, "LEGENDRE", "Brendan", "WPF Grid Exemple",
                                                            "Voici un exemple d'une grille en WPF",
                                                            "&#xA7;<Grid>&#x0A;" +
                                                                "&#xA7;&#xA7;<Grid.ColumnDefinitions>&#x0A;" +
                                                                    "&#xA7;&#xA7;&#xA7;<ColumnDefinition&#x20;Width=&#x22;2*&#x22;&#x20;/>&#x0A;" +
                                                                    "&#xA7;&#xA7;&#xA7;<ColumnDefinition&#x20;Width=&#x22;1*&#x22;&#x20;/>&#x0A;" +
                                                                    "&#xA7;&#xA7;&#xA7;<ColumnDefinition&#x20;Width=&#x22;1*&#x22;&#x20;/>&#x0A;" +
                                                                    "&#xA7;&#xA7;</Grid.ColumnDefinitions>&#x0A;" +
                                                                    "&#xA7;&#xA7;<Grid.RowDefinitions>&#x0A;" +
                                                                    "&#xA7;&#xA7;&#xA7;<RowDefinition&#x20;Height=&#x22;2*&#x22;&#x20;/>&#x0A;" +
                                                                    "&#xA7;&#xA7;&#xA7;<RowDefinition&#x20;Height=&#x22;1*&#x22;&#x20;/>&#x0A;" +
                                                                    "&#xA7;&#xA7;&#xA7;<RowDefinition&#x20;Height=&#x22;1*&#x22;&#x20;/>&#x0A;" +
                                                                    "&#xA7;&#xA7;</Grid.RowDefinitions>&#x0A;&#x0A;" +
                                                                    "&#xA7;&#xA7;<Button>Button&#x20;1</Button>&#x0A;"+
                                                                    "&#xA7;&#xA7;<Button&#x20;Grid.Column=&#x22;1&#x22;>Button&#x20;2</Button>&#x0A;" +
                                                                    "&#xA7;&#xA7;<Button&#x20;Grid.Column=&#x22;2&#x22;>Button&#x20;3</Button>&#x0A;" +
                                                                    "&#xA7;&#xA7;<Button&#x20;Grid.Row=&#x22;1&#x22;>Button&#x20;4</Button>&#x0A;" +
                                                                    "&#xA7;&#xA7;<Button&#x20;Grid.Column=&#x22;1&#x20;Grid.Row=&#x22;1&#x22;>Button&#x20;5</Button>&#x0A;" +
                                                                    "&#xA7;&#xA7;<Button&#x20;Grid.Column=&#x22;2&#x22;&#x20;Grid.Row=&#x22;1&#x22;>Button&#x20;6</Button>&#x0A;" +
                                                                    "&#xA7;&#xA7;<Button&#x20;Grid.Row=&#x22;2&#x22;>Button&#x20;7</Button>&#x0A;" +
                                                                    "&#xA7;&#xA7;<Button&#x20;Grid.Column=&#x22;1&#x22;&#x20;Grid.Row=&#x22;2&#x22;>Button&#x20;8</Button>&#x0A;" +
                                                                    "&#xA7;&#xA7;<Button&#x20;Grid.Column=&#x22;2&#x22;&#x20;Grid.Row=&#x22;2&#x22;>Button&#x20;9</Button>&#x0A;" +
                                                                "&#xA7;</Grid>",
                                                                "29/05/2020", "09:21", 4)
            };
        }

        public static List<ExtraitCode> GetListExtraitsCode()
        {
            return listExtraitsCodes;
        }

        public static void RemoveExtraitCode(int idExtraitCode)
        {
            ExtraitCode extraitCodeToRemove = dataUtils.GetListExtraitsCode().Find(x => x.Id == idExtraitCode);
            listExtraitsCodes.Remove(extraitCodeToRemove);
        }

        public static void AddExtraitCode(int IdCreator, String Nom, String Prenom, String Title, String Description, String Code, String Date_Creation, String Horaire_Creation)
        {
            ExtraitCode newExtraitCode = new ExtraitCode(GetListExtraitsCode().Count + 1, IdCreator, Nom, Prenom, Title, Description, Code, Date_Creation, Horaire_Creation, 0);
            listExtraitsCodes.Add(newExtraitCode);
        }

        /* -- Approuved Extrait Code -- */
        public static void SetListExtraitsCodeApprouved()
        {
            listExtraitsCodeApprouved = new List<ExtraitCodeApprouved>
            {
                new ExtraitCodeApprouved(1, 1, new List<int>{2, 3})
            };
        }

        public static List<ExtraitCodeApprouved> GetListExtraitsCodeApprouved()
        {
            return listExtraitsCodeApprouved;
        }

        /* -- Comments -- */
        public static void SetListComments()
        {
            listComments = new List<Comment>
            {
                new Comment(1, 3, "DUBOIS", "Mathieu", 1, "ExtraitCode", "Merci !", "02/05/2020 10:08:12", new List<int>{ }),
                new Comment(2, 5, "WILLERVAL", "Romain", 1, "ExtraitCode", "Très bon exemple, simple et efficace", "27/05/2020 13:34:46", new List<int>{2,3,6}),
                new Comment(3, 2, "LEGRAND", "Quentin", 1, "ExtraitCode", "Merci à chaque fois j'oublie ca va me faire gagner beaucoup de temps pour un si petit truc un très grand merci !", "28/05/2020 13:46:36", new List<int>{4,6}),
                new Comment(4, 4, "LEGENDRE", "Brendan", 3, "Comment", "Pareil j'avoue ^^", "28/05/2020 17:16:05", new List<int>{ }),
            };
        }

        public static List<Comment> GetListComments()
        {
            return listComments;
        }

        public static void AddComment(int IdWriter, String Nom, String Prenom, int IdTarget, String TypeTarget, String Content, String Date_Comment)
        {
            Comment newComment = new Comment(GetListComments().Count + 1, IdWriter, Nom, Prenom, IdTarget, TypeTarget, Content, Date_Comment, new List<int> { });
            listComments.Add(newComment);
        }

        /* -- Vote -- */
        public static void SetListVote()
        {
            listVotes = new List<Vote>
            {
                new Vote(1, 1, "ExtraitCode", 2, 5),
                new Vote(2, 2, "ExtraitCode", 1, 4)
            };
        }

        public static List<Vote> GetListVote()
        {
            return listVotes;
        }

        public static void AddVote(int idTarget, String typeTarget, int idVoter, int note)
        {
            Vote newVote = new Vote(dataUtils.GetListVote().Count + 1, idTarget, typeTarget, idVoter, note);
            listVotes.Add(newVote);
        }

        /* -- Favoris -- */
        public static void SetListFavoris()
        {
            listFavoris = new List<Favoris>()
            {

            };
        }

        public static List<Favoris> GetListFavoris()
        {
            return listFavoris;
        }

        public static void AddFavoris(int idTarget, String typeTarget, int idUser)
        {
            Favoris newFavoris = new Favoris(dataUtils.GetListFavoris().Count + 1, idTarget, typeTarget, idUser);
            listFavoris.Add(newFavoris);
        }

        public static void RemoveFavoris(int idTarget, String typeTarget, int idUser)
        {
            Favoris favorisToRemove = dataUtils.GetListFavoris().Find(x => (x.IdTarget == idTarget) && (x.TypeTarget.Equals(typeTarget)) && (x.IdUser == idUser));
            listFavoris.Remove(favorisToRemove);
        }
    }
}
