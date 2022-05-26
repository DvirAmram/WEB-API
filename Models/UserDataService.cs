namespace DivChatWEBAPI.Models
{
    public class UserDataService : IUserDataService
    {
        private static List<User> users = new List<User>()
        {
            new User()
            {
                Username="Niv_Nahman",
                Nickname = "niven",
                Password = "Q1w2e3r4",
                SrcImg = null,
                chats = new List<Chat>()
                {
                    new Chat()
                    {
                        contact = new contact ()
                        {
                            id = "Dvir_Amram",
                            name = "dvir",
                            server = "localhost:7261",
                            last = "world",
                            lastdate = DateTime.Now
                        },
                        messages = new List<message> ()
                        {
                            new message()
                            {
                                id = 3,
                                content = "hello",
                                created = DateTime.Now,
                                sent = true
                            },
                            new message()
                            {
                                id = 5,
                                content = "world",
                                created = DateTime.Now,
                                sent = false
                            }
                        }
                    },
                    new Chat()
                    {
                        contact = new contact ()
                        {
                            id = "noampdut",
                            name = "noamit",
                            server = "localhost:5001",
                            last = "hapoel",
                            lastdate = DateTime.Now
                        },
                        messages = new List<message>()
                        {
                            new message()
                            {
                                id = 3,
                                content = "yalla",
                                created = DateTime.Now,
                                sent = true
                            },
                            new message()
                            {
                                id = 5,
                                content = "hapoel",
                                created = DateTime.Now,
                                sent = false
                            }
                        }
                    }
                }
            },

            new User()
            {
                Username="Dvir_Amram",
                Nickname = "dvir",
                Password = "T5y6u7i8",
                SrcImg = null,
                chats = new List<Chat>()
                {
                    new Chat()
                    {
                        contact = new contact()
                        {
                            id = "Niv_Nahman",
                            name = "niven",
                            server = "localhost:7261",
                            last = "world",
                            lastdate = DateTime.Now
                        },
                        messages = new List<message>()
                        {
                            new message()
                            {
                                id = 3,
                                content = "hello",
                                created = DateTime.Now,
                                sent = false
                            },
                            new message()
                            {
                                id = 5,
                                content = "world",
                                created = DateTime.Now,
                                sent = true
                            }
                        }
                    },
                    new Chat()
                    {
                        contact = new contact ()
                        {
                            id = "Ron_Solomon",
                            name = "Ronchu",
                            server = "localhost:7261",
                            last = "I will Help you",
                            lastdate = DateTime.Now
                        },
                        messages = new List<message>()
                        {
                            new message()
                            {
                                id = 7,
                                content = "Dvirrr, please help me with bdida",
                                created = DateTime.Now,
                                sent = false
                            },
                            new message()
                            {
                                id = 8,
                                content = "I will Help you",
                                created = DateTime.Now,
                                sent = true
                            }
                        }
                    }
                }
            },

            new User()
            {
                Username="Ron_Solomon",
                Nickname = "Ronchu",
                Password = "1Qazxsw2",
                SrcImg = null,
                chats = new List<Chat>()
                {
                    new Chat()
                    {
                        contact = new contact ()
                        {
                            id = "Dvir_Amram",
                            name = "dvir",
                            server = "localhost:7261",
                            last = "I will Help you",
                            lastdate = DateTime.Now
                        },
                        messages = new List<message>()
                        {
                            new message()
                            {
                                id = 7,
                                content = "Dvirrr, please help me with bdida",
                                created = DateTime.Now,
                                sent = true
                            },
                            new message()
                            {
                                id = 8,
                                content = "I will Help you",
                                created = DateTime.Now,
                                sent = false
                            }
                        }
                    }
                }
            },
        };

        public List<User> GetAll()
        {
            return users;
        }
        public User Get(string id)
        {
            return users.Where(x => x.Username == id).FirstOrDefault();
        }
        public void Create(User user)
        {
            users.Add(user);
        }
        public void Edit(string id, User user)
        {
            User u = Get(id);
            u.Nickname = user.Nickname;
            u.Password = user.Password;
            u.SrcImg = user.SrcImg;
            u.chats = user.chats;
        }

        public void Delete(string id)
        {
            users.Remove(Get(id));
        }

    }
}
