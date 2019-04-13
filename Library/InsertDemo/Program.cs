using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertDemo
{
    class Program
    {
        public delegate void showall();
        public delegate void insertbook();
        public delegate void delete(int i);
        public delegate void Editbook();
   
        static List<Book> bookList = new List<Book>();
        static void Main(string[] args)
        {
            DatabaseHelper.SetupDatabase();
            BookDataAccess dataAccess = new BookDataAccess(ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString);

            Console.WriteLine("\n");
            Console.WriteLine("                      Library Project                                     ");
            Console.WriteLine("\n");
            Console.WriteLine(" ************************************************************************ ");
            Console.WriteLine("\n");
            Console.WriteLine("db   d8b   db d88888b db      db       .o88b.  .d88b.  .88b  d88. d88888b ");
            Console.WriteLine("88   I8I   88 88      88      88      d8P  Y8 .8P  Y8. 88 YbdP 88 88      ");
            Console.WriteLine("88   I8I   88 88ooooo 88      88      8P      88    88 88  88  88 88ooooo ");
            Console.WriteLine("Y8   I8I   88 88~~~~~ 88      88      8b      88    88 88  88  88 88~~~~~ ");
            Console.WriteLine("`8b d8'8b d8' 88      88booo. 88booo. Y8b  d8 `8b  d8' 88  88  88 88      ");
            Console.WriteLine(" `8b8' `8d8'  Y88888P  88888P Y88888P  `Y88P'  `Y88P'  YP  YP  YP Y88888P ");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n PLibrary: Show All Books, Add a Book, Edit Book and Delete a Book in Database.");
            Console.WriteLine("\n");
            Console.WriteLine("\n  ***** Parvin Faraji ******  ");
            Console.WriteLine("\n Please Peres A key to contnue.");
            Console.ReadKey();
            int optionsCount = 5;

            int selected = 0;
            int exitmenu = 1;
            bool done = false;
            while (exitmenu != 0)
            {
                Console.Clear();
                while (!done)
                {
                    for (int i = 0; i < optionsCount; i++)
                    {
                        if (selected == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("> ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }

                        switch (i)
                        {
                            case 0:
                                Console.WriteLine($"{i} Show All Books");
                                break;
                            case 1:
                                Console.WriteLine($"{i} Add Book");
                                break;
                            case 2:
                                Console.WriteLine($"{i} Delete Book");
                                break;
                            case 3:
                                Console.WriteLine($"{i} Edit Book");
                                break;
                            case 4:
                                Console.WriteLine($"{i} Exit");
                                break;

                        }

                        Console.ResetColor();
                    }

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            selected = Math.Max(0, selected - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            selected = Math.Min(optionsCount - 1, selected + 1);
                            break;
                        case ConsoleKey.Enter:
                            done = true;
                            break;
                    }

                    if (!done)
                        Console.CursorTop = Console.CursorTop - optionsCount;
                }

                done = false;

                switch (selected)
                {
                    case 0:
                        {
                            showall();
                            Console.ReadKey();
                            break;
                        }

                    case 1:
                        {
                            showall();
                            insertbook();
                            Console.ReadKey();
                            break;

                        }

                    case 2:
                        {
                            showall();
                            deletebook();
                            Console.ReadKey();
                            break;
                        }

                    case 3:
                        {
                            showall();
                            Editbook();
                            Console.ReadKey();
                            break;
                        }

                    case 4:

                        {
                            exitmenu = 0;
                            Console.WriteLine("\n Thank you.");
                            Console.Write("Press any key to Exit.");
                            break;
                        }
                }
                
            }

            // Show All Data of Table
            void showall()
            {
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID    Book   Auther   Creat Date");
                Console.WriteLine("-------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                var books = dataAccess.GetAll();
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("--------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

            }

            /*  ------ Insert a Book ------ */
           void insertbook()
            {
                //showall();
                Console.Write("\n Add A Book. ");
                Book newBook = new Book();
                Console.Write("\n Title: ");
                newBook.Title = Console.ReadLine();
                if (newBook.Title.Length != 0)
                {
                    Console.Write("Author: ");
                    newBook.Author = Console.ReadLine();
                    newBook.CreatedDate = DateTime.Now;
                    newBook.ModifiedDate = DateTime.Now;
                    dataAccess.Insert(newBook);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Book {0} is Add to Data Base.",newBook.Title);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write("Press any key to return the main menu.");
                }
            }

            /*  ------------------------- Remove a Book -------------------- */
            void deletebook()
            {

                Console.Write("\n Enter Book ID to be deleted : ");
                int index = int.Parse(Console.ReadLine());
                if (index != ' ')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    dataAccess.delete(index);
                    Console.WriteLine("\n Book id {0} has been deleted", index);
                }
                else
                {
                    Console.Write("Press any key to return the main menu.");

                }
            }

                /*  -------------------------End of Remove a Book -------------------- */


                /*  ------------------------- Edit a Book -------------------- */
                void Editbook()
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n Enter Book id to edit : ");
                    int indx = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    Book TheBook = new Book();
                    TheBook = dataAccess.GetABook(indx);
                    if (TheBook != null)
                    {
                        //////////////////////////////////////////
                        Console.WriteLine("Title:{0} ", TheBook.Title);
                        Console.Write("Enter new Title:");
                        TheBook.Title = Console.ReadLine();
                        if (TheBook.Title.Length != 0)
                        {
                            Console.WriteLine("Author:{0} ", TheBook.Author);
                            Console.Write("Enter new Author:");
                            TheBook.Author = Console.ReadLine();
                            dataAccess.edit(TheBook);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Book id {0} has been changed", indx);
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                        else
                        {
                            Console.WriteLine("Book id {0} did not changed", indx);
                            Console.Write("Press any key to return the main menu.");
                        }

                    }
                    else
                        Console.WriteLine("Invalid Book id");
                }
            return;
        }
            /*  -------------------------End of Edit a Book -------------------- */

            
            }

        }
    


        

    

