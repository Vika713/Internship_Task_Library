using Library.Models;
using Library.Operations;
using System;

namespace Library.Commands
{
    public class AddCommand : BaseCommand
    {
        public AddCommand(string fileName) : base(fileName) { }

        public override void Execute()
        {
            Console.WriteLine("Add a new book");

            string ISBN = GetIsbnInput();
            string name = GetNameInput();
            string author = GetAuthorInput();
            string category = GetCategoryInput();
            string language = GetLanguageInput();
            DateTime publicationDate = GetPublicationDateInput();

            Book book = new Book(ISBN, name, author, category, language, publicationDate);

            new BookWriter(FileName).Create(book);

            Console.WriteLine("The book was created");
        }

        protected virtual string GetIsbnInput()
        {
            return GetStringInput("ISBN: ");
        }

        protected virtual string GetNameInput()
        {
            return GetStringInput("Name: ");
        }

        protected virtual string GetAuthorInput()
        {
            return GetStringInput("Author: ");
        }

        protected virtual string GetCategoryInput()
        {
            return GetStringInput("Category: ");
        }

        protected virtual string GetLanguageInput()
        {
            return GetStringInput("Language: ");
        }

        protected virtual DateTime GetPublicationDateInput()
        {
            return GetDateTimeInput("Publication date (yyyy-MM-dd): ");
        }
    }
}
