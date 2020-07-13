using EPSICommunity.Model;
using EPSICommunity.Utils.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Utils.data
{
    public class dataUtils
    {
        public static List<Role> listRoles;
        public static List<Droit> listDroits;
        public static List<User> listUsers;
        public static List<Classe> listClasses;
        public static List<UserRole> listUserRole;
        public static List<Conversation> listConversations;
        public static List<Message> listMessages;
        public static List<ExtraitCode> listExtraitsCodes;
        public static List<ExtraitCodeApprouved> listExtraitsCodeApprouved;
        public static List<Comment> listComments;
        public static List<Vote> listVotes;
        public static List<Favoris> listFavoris;
        public static List<DemandeSuppression> listDemandesSuppression;
        public static List<RestrictionDroit> listRestrictionDroit;

        /* -- Initializer -- */
        public static void SetDataUtils()
        {
            SetListRoles();
            SetListDroits();
            SetListUsers();
            SetListClasses();
            SetListUserRole();
            SetListMessages();
            SetListConversations();
            SetListExtraitsCode();
            SetListExtraitsCodeApprouved();
            SetListComments();
            SetListVote();
            SetListFavoris();
            SetListDemandeSuppression();
            SetListRestrictionDroit();
        }

        /* -- Role -- */
        public static void SetListRoles()
        {
            listRoles = new List<Role>
            {
                new Role(1, "Super Administrateur", new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41 ,42}),
                new Role(2, "Administrateur", new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42}),
                new Role(3, "Modérateur", new List<int>{22, 25}),
                new Role(4, "Administration", new List<int>{4, 5, 6, 7, 8 ,9, 11, 12, 13, 14, 15, 21, 33, 34, 35, 36, 37, 38, 39}),
                new Role(5, "Professeur", new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 ,18, 33, 34, 35, 36, 37, 38, 39}),
                new Role(6, "Etudiant", new List<int>{4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 15, 33, 34, 35, 36, 37, 38, 39})
            };
        }

        public static List<Role> GetListRoles()
        {
            return listRoles;
        }

        public static void AddRole(String libelle)
        {
            Role newRole = new Role(listRoles[listRoles.Count - 1].Id + 1, libelle, new List<int> { });
            listRoles.Add(newRole);
        }

        public static void RemoveRole(int idRole)
        {
            Role roleToRemove = GetListRoles().Find(x => x.Id == idRole);
            listRoles.Remove(roleToRemove);
        }

        /* -- Droit -- */
        public static void SetListDroits()
        {
            listDroits = new List<Droit>
            {
                new Droit(1, "100_1xLNG", "Ajouter un langage"),
                new Droit(2, "100_2xLNG", "Modifier un langage"),
                new Droit(3, "100_4xLNG", "Supprimer un langage"),
                new Droit(4, "100_1xCMT", "Ajouter un commentaire"), // V
                new Droit(5, "100_2xCMT", "Modifier un commentaire"), // X
                new Droit(6, "100_4xCMT", "Supprimer un commentaire"), // X
                new Droit(7, "100_1xCD0", "Ajouter un extrait de code"), // V
                new Droit(8, "100_2xCD0", "Modifier un extrait de code"), // X
                new Droit(9, "100_4xCD0", "Supprimer un extrait de code"), // V
                new Droit(10, "100_6xCD0", "Approuver un extrait de code"), // V
                new Droit(11, "100_5xCD0", "Ajouter une note à un extrait de code"), //V
                new Droit(12, "100_1xIDA", "Ajouter une idée de code"), // A -> Nicolas
                new Droit(13, "100_2xIDA", "Modifier une idée de code"), // A -> Nicolas
                new Droit(14, "100_4xIDA", "Supprimer une idée de code"), // A -> Nicolas
                new Droit(15, "100_5xIDA", "Ajouter une note à une idée de code"), // A -> Nicolas
                new Droit(16, "100_1xID2", "Ajouter un IDE"),
                new Droit(17, "100_2xID2", "Modifier un IDE"),
                new Droit(18, "100_4xID2", "Supprimer un IDE"),
                new Droit(19, "100_1xUTL", "Ajouter un utilisateur"),
                new Droit(20, "100_2xUTL", "Modifier les données primaires d'un utilisateur"),
                new Droit(21, "100_4xUTL", "Supprimer un utilisateur"),
                new Droit(22, "100_7xUTL", "Blamer un utilisateur"),
                new Droit(23, "100_1xDUL", "Ajouter un droit à un utilisateur"),
                new Droit(24, "100_8xDUL", "Retirer un droit à un utilisateur"),
                new Droit(25, "100_3xDUL", "Bloquer un droit à un utilisateur"),
                new Droit(26, "100_1xRUL", "Ajouter un rôle à un utilisateur"),
                new Droit(27, "100_8xRUL", "Retirer un rôle à un utilisateur"),
                new Droit(28, "100_1xRL0", "Ajouter un rôle"),
                new Droit(29, "100_2xRL0", "Modifier un rôle"),
                new Droit(30, "100_3xRL0", "Supprimer un rôle"),
                new Droit(31, "100_1xDRL", "Ajouter un droit à un rôle"),
                new Droit(32, "100_8xDRL", "Retirer un droit à un rôle"),
                new Droit(33, "100_1xFVS", "Ajouter un élément aux favoris"), // V
                new Droit(34, "100_8xFVS", "Retirer un élément aux favoris"), // V
                new Droit(35, "100_1xMSE", "Ajouter un message"),  // V
                new Droit(36, "100_4xMSE", "Supprimer un message"),  // X
                new Droit(37, "100_1xCVN", "Ajouter une conversation"), // V
                new Droit(38, "100_4xCVN", "Supprimer une conversation"), // V
                new Droit(39, "100_1xVTE", "Ajouter une vote"),
                new Droit(40, "100_1xCLE", "Ajouter une clase"),
                new Droit(41, "100_2xCLE", "Modifier une classe"),
                new Droit(42, "100_4xCLE", "Supprimer une classe")
            };
        }

        public static List<Droit> GetListDroits()
        {
            return listDroits;
        }

        /* -- User -- */
        public static void SetListUsers()
        {
            listUsers = new List<User>
            {
                new User(1, "CAZIN", "Nicolas", "nicolas.cazin@epsi.fr", "123NCN", "1", "rue du 11 Novembre", "", "62116", "Ablainzevelle", "Images/unnamed.png"),
                new User(2, "LEGRAND", "Quentin", "quentin.legrand@epsi.fr", "123QLD", "41", "rue de Bucquoy", "", "62000", "Arras", "Images/unnamed.png"),
                new User(3, "DUBOIS", "Mathieu", "mathieu.dubois@epsi.fr", "123MDS", "67 bis", "rue de l'Égalité", "", "62580", "Vimy", ""),
                new User(4, "LEGENDRE", "Brendan", "brendan.legendre@epsi.fr", "123BLE", "380", "rue des Acacias", "", "60480", "Noiremont", "Images/unnamed.png"),
                new User(5, "WILLERVAL", "Romain", "romain.willerval@epsi.fr", "123RWL", "8", "rue des Rosati", "", "62000", "Arras", "Images/unnamed.png"),
                new User(6, "LORENTE", "Romain", "romain.lorente@epsi.fr", "123RLE", "35", "rue des Écoles", "", "59500", "DOUAI", "Images/unnamed.png")
            };
        }

        public static List<User> GetListUsers()
        {
            return listUsers;
        }

        public static User GetUserByMailAdress(String mail)
        {
            return listUsers.Find(x => x.Mail == mail);
        }

        /* -- Classe -- */
        public static void SetListClasses()
        {
            listClasses = new List<Classe>
            {
                new Classe(1, "B1", new List<int>{}),
                new Classe(1, "B2", new List<int>{}),
                new Classe(1, "B3 DNT", new List<int>{1, 2, 3, 4, 5, 6}),
                new Classe(1, "B3 ASR", new List<int>{}),
                new Classe(1, "I1 DNT", new List<int>{}),
                new Classe(1, "I1 ASR", new List<int>{}),
                new Classe(1, "I2", new List<int>{}),

            };
        }

        public static List<Classe> GetListClasses()
        {
            return listClasses;
        }

        public static void AddClasse(String libelle)
        {
            Classe newClasse = new Classe(listClasses[listClasses.Count - 1].Id + 1, libelle, new List<int> { });
            listClasses.Add(newClasse);
        }

        public static void RemoveClasse(int idClasse)
        {
            Classe classeToRemove = GetListClasses().Find(x => x.Id == idClasse);
            listClasses.Remove(classeToRemove);
        }

        /* -- UserRole -- */
        public static void SetListUserRole()
        {
            listUserRole = new List<UserRole>
            {
                new UserRole(1, 1, 1),
                new UserRole(2, 2, 1),
                new UserRole(3, 3, 1),
                new UserRole(4, 4, 1),
                new UserRole(5, 5, 1),
                new UserRole(6, 6, 1),
                new UserRole(7, 1, 6),
                new UserRole(8, 2, 6),
                new UserRole(9, 3, 6),
                new UserRole(10, 4, 6),
                new UserRole(11, 5, 6),
                new UserRole(12, 6, 6),
            };
        }

        public static List<UserRole> GetListUserRole()
        {
            return listUserRole;
        }

        public static List<UserRole> GetRoleOfUser(int idUser)
        {
            return GetListUserRole().Where(x => x.IdUser == idUser).ToList();
        }

        public static void AddUserRole(int idUser, int idRole)
        {
            UserRole newUserRole = new UserRole(listUserRole[listUserRole.Count - 1].Id + 1, idUser, idRole);
            listUserRole.Add(newUserRole);
        }

        public static void RemoveUserRole(int idUser, int idRole)
        {
            UserRole userRoleToRemove = GetListUserRole().Find(x => (x.IdUser == idUser) &&( x.IdRole == idRole));
            listUserRole.Remove(userRoleToRemove);
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
            listMessages.Add(new Message(listMessages[listMessages.Count- 1].Id + 1, RecipientId, SenderId, nom, prenom, content, dateSending, horaireSending, 0));
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
            listConversations.Add(new Conversation(listConversations[listConversations.Count - 1].Id + 1, new List<int> { UserConnectedId, CorrespondantId }, new List<int> { MessageId }));
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
            ExtraitCode newExtraitCode = new ExtraitCode(listExtraitsCodes[listExtraitsCodes.Count - 1].Id + 1, IdCreator, Nom, Prenom, Title, Description, Code, Date_Creation, Horaire_Creation, 0);
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

        public static void AddExtraitCodeApprouved(int idEc)
        {
            if(GetListExtraitsCodeApprouved().Find(x => x.IdExtraitCode == idEc) != null)
            {
                AddApprouverToExtraitCode(idEc);
            }
            else
            {
                AddExtraitCodeApprouver(idEc);
            }
        }

        private static void AddApprouverToExtraitCode(int idEc)
        {
            ExtraitCodeApprouved eca = GetListExtraitsCodeApprouved().Find(x => x.IdExtraitCode == idEc);
            eca.ListApprouver.Add(UserConnected.GetUserConnected().Id);
        }

        private static void AddExtraitCodeApprouver(int idEc)
        {
            ExtraitCodeApprouved eca = new ExtraitCodeApprouved(listExtraitsCodeApprouved[listExtraitsCodeApprouved.Count - 1].Id + 1, idEc, new List<int> { UserConnected.GetUserConnected().Id });
            listExtraitsCodeApprouved.Add(eca);
        }

        public static void RemoveExtraitCodeApprouved(int idEc)
        {
            GetListExtraitsCodeApprouved().Find(x => x.IdExtraitCode == idEc).ListApprouver.Remove(UserConnected.GetUserConnected().Id);
            if (GetListExtraitsCodeApprouved().Find(x => x.IdExtraitCode == idEc).ListApprouver.Count == 0 || GetListExtraitsCodeApprouved().Find(x => x.IdExtraitCode == idEc).ListApprouver == null)
            {
                listExtraitsCodeApprouved.Remove(GetListExtraitsCodeApprouved().Find(x => x.IdExtraitCode == idEc));
            }
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
            Comment newComment = new Comment(listComments[listComments.Count - 1].Id + 1, IdWriter, Nom, Prenom, IdTarget, TypeTarget, Content, Date_Comment, new List<int> { });
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
            Vote newVote = new Vote(listVotes[listVotes.Count - 1] .Id + 1, idTarget, typeTarget, idVoter, note);
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
            Favoris newFavoris = new Favoris(listFavoris[listFavoris.Count - 1].Id + 1, idTarget, typeTarget, idUser);
            listFavoris.Add(newFavoris);
        }

        public static void RemoveFavoris(int idTarget, String typeTarget, int idUser)
        {
            Favoris favorisToRemove = dataUtils.GetListFavoris().Find(x => (x.IdTarget == idTarget) && (x.TypeTarget.Equals(typeTarget)) && (x.IdUser == idUser));
            listFavoris.Remove(favorisToRemove);
        }

        /* -- DemandeSuppression -- */
        public static void SetListDemandeSuppression()
        {
            listDemandesSuppression = new List<DemandeSuppression>
            {

            };
        }

        public static List<DemandeSuppression> GetListDemandeSuppression()
        {
            return listDemandesSuppression;
        }

        public static void AddDemandeSuppression(int idUser, int idElement, String typeElement, String message)
        {
            DateTime fullDate = DateTime.Now;
            string date = (fullDate.Day < 10 ? "0" + fullDate.Day.ToString() : fullDate.Day.ToString()) + "/" +
                (fullDate.Month < 10 ? "0" + fullDate.Month.ToString() : fullDate.Month.ToString()) + "/" +
                fullDate.Year.ToString();
            string nom = listUsers.Find(x => x.Id == idUser).Nom;
            string prenom = listUsers.Find(x => x.Id == idUser).Prenom;
            DemandeSuppression newDemandeSuppression = new DemandeSuppression(listDemandesSuppression[listDemandesSuppression.Count - 1].Id + 1, idUser, nom, prenom, idElement, typeElement, message, date, 0, 0, null);
            listDemandesSuppression.Add(newDemandeSuppression);
        }

        public static void RemoveDemandeSuppression(int idDemande)
        {
            listDemandesSuppression.Remove(GetListDemandeSuppression().Find(x => x.Id == idDemande));
        }

        public static void ValidateDemandeSuppression(int idDemande, int idValider)
        {
            DateTime fullDate = DateTime.Now;
            string date = (fullDate.Day < 10 ? "0" + fullDate.Day.ToString() : fullDate.Day.ToString()) + "/" +
                (fullDate.Month < 10 ? "0" + fullDate.Month.ToString() : fullDate.Month.ToString()) + "/" +
                fullDate.Year.ToString();
            DemandeSuppression demandeSuppression = GetListDemandeSuppression().Find(x => x.Id == idDemande);
            demandeSuppression.Validate = 1;
            demandeSuppression.IdValider = idValider;
            demandeSuppression.DateValidation = date;
        }

        public static void RefuseDemandeSuppression(int idDemande, int idValider)
        {
            DateTime fullDate = DateTime.Now;
            string date = (fullDate.Day < 10 ? "0" + fullDate.Day.ToString() : fullDate.Day.ToString()) + "/" +
                (fullDate.Month < 10 ? "0" + fullDate.Month.ToString() : fullDate.Month.ToString()) + "/" +
                fullDate.Year.ToString();
            DemandeSuppression demandeSuppression = GetListDemandeSuppression().Find(x => x.Id == idDemande);
            demandeSuppression.Validate = 0;
            demandeSuppression.IdValider = idValider;
            demandeSuppression.DateValidation = date;
        }

        /* -- RestrictionDroit -- */
        public static void SetListRestrictionDroit()
        {
            listRestrictionDroit = new List<RestrictionDroit>
            {
                new RestrictionDroit(1, 1, 38, "Propos injurieux", 2, "09/07/2020", "16/08/2020", 0, 0, "")
            };
        }

        public static List<RestrictionDroit> GetListRestrictionDroit()
        {
            return listRestrictionDroit;
        }

        public static void AddRestrictionDroit()
        {

        }
    }
}
