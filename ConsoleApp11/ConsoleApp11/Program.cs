using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NewContext db = new NewContext())
            {
                bool autorize = false;
                var autors = db.Autors;
                var articles = db.Articles;
                var comments = db.Comments;
                Article news = new Article();
                Autor autor1 = new Autor();
                Article pl2 = new Article();

                while (autorize == false)
                {
                    Console.WriteLine("Выберите действие");
                    Console.WriteLine("1 - Регистрация\n2 - Вход");
                    int choise = int.Parse(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            Console.WriteLine("Введите логин для регистрации: ");
                            string newLogin = Console.ReadLine();
                            Console.WriteLine("Введите пароль: ");
                            string newPassword = Console.ReadLine();
                            Autor autor2 = new Autor { Login = newLogin, Password = newPassword };

                            // добавляем их в бд
                            db.Autors.Add(autor2);
                            db.SaveChanges();
                            Console.WriteLine("Вы успешно зарегистрировались");
                            break;
                        case 2:
                            Console.WriteLine("Введите логин для входа: ");
                            string login = Console.ReadLine();
                            Console.WriteLine("Введите пароль: ");
                            string password = Console.ReadLine();
                            foreach (Autor u in autors)
                            {
                                if (u.Login == login && u.Password == password)
                                {
                                    Console.WriteLine("Вы успешно вошли");
                                    autor1.Id = u.Id;
                                    autor1.Login = u.Login;
                                    autor1.Password = u.Password;
                                    autorize = true;
                                }
                            }
                            break;
                        default: Console.WriteLine("Такого варианта нет"); break;
                    }
                }
                //После входа
                int choise2=0;
                while (choise2 != 4)
                {
                    Console.WriteLine("Выберите действие");
                    Console.WriteLine("1 - Создать новость\n2 - Посмотреть новости\n3 - Добавить комментарий\n4 - Выход");
                    choise2 = int.Parse(Console.ReadLine());
                    switch (choise2)
                    {
                        case 1:
                            Console.WriteLine("Введите заголовок новости: ");
                            string title = Console.ReadLine();
                            Console.WriteLine("Введите текст новости: ");
                            string text = Console.ReadLine();
                            Console.WriteLine("Введите источник: ");
                            string source = Console.ReadLine();
                            // добавляем их в бд
                            Article pl1 = new Article { Source = source, PublicationTime = DateTime.Now, Title = title, Text = text, Autor = autor1 };

                            db.Articles.Add(pl1);
                            db.SaveChanges();
                            Console.WriteLine("Вы успешно добавили новость");
                            break;
                        case 2:
                            Console.WriteLine("Список новостей:\n");

                            foreach (Article article in articles)
                            {
                                List<Comment> commentss = new List<Comment>();
                                foreach (Comment coment in comments)
                                {
                                    if (coment.ArticleId == article.Id)
                                    {
                                        commentss.Add(coment);
                                    }
                                }
                                Console.WriteLine("{0}\nИсточник:{1}\n{2}\nАвтор новости:{3}\nКомментарии:{4}", article.Title,article.Source, article.Text, article.Autor, commentss);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Введите ID новости: ");
                            int newsId = int.Parse(Console.ReadLine());
                            foreach (Article article in articles)
                            {
                                if (article.Id == newsId)
                                {
                                    news = article;
                                }
                            }
                            Console.WriteLine("Введите комментарий: ");
                            string comment = Console.ReadLine();
                            // добавляем их в бд
                            Comment com1 = new Comment { Text = comment, CommentTime = DateTime.Now,Autor = autor1, Article= news };

                            db.Comments.Add(com1);
                            db.SaveChanges();
                            Console.WriteLine("Вы успешно добавили комментарий");
                            break;
                        default: Console.WriteLine("Такого варианта нет"); break;
                    }
                }
            }
            Console.Read();
        }
    }
}
