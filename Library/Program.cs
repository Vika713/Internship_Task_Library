using Library.Commands;
using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = Constants.BooksFilePath;
            bool done = false;

            while (!done)
            {
                Console.WriteLine("\nChoose from the following commands:");
                Console.WriteLine("\ta - Add a new book");
                Console.WriteLine("\tt - Take a book");
                Console.WriteLine("\tr - Return a book");
                Console.WriteLine("\tf - Filter the books");
                Console.WriteLine("\td - Delete a book");
                Console.Write("Your option: ");

                ICommand command = null;

                switch (Console.ReadLine())
                {
                    case "a":
                        command = new AddCommand(fileName);
                        break;
                    case "t":
                        command = new TakeCommand(fileName);
                        break;
                    case "r":
                        command = new ReturnCommand(fileName);
                        break;
                    case "f":
                        command = new FilterCommand(fileName);
                        break;
                    case "d":
                        command = new DeleteCommand(fileName);
                        break;
                    default:
                        done = true;
                        break;
                }

                if (command != null)
                    command.Execute();
                else
                    Console.WriteLine("Closing");
            }
        }
    }
}