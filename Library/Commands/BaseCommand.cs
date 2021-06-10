using System;

namespace Library.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected string FileName { get; set; }

        protected BaseCommand(string fileName)
        {
            FileName = fileName;
        }

        public abstract void Execute();

        protected static string GetStringInput(string caption)
        {
            Console.Write(caption);
            return Console.ReadLine();
        }

        protected static DateTime GetDateTimeInput(string caption)
        {
            bool success = false;
            DateTime date = new DateTime();
            while (!success)
            {
                Console.Write(caption);
                success = DateTime.TryParse(Console.ReadLine(), out date);
            }
            return date;
        }

        protected static int GetIntInput(string caption)
        {
            bool success = false;
            int number = new int();
            while (!success)
            {
                Console.WriteLine(caption);
                success = Int32.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }
    }
}
