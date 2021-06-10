using Library.Models;
using Library.Operations;
using System;
using System.Collections.Generic;

namespace Library.Commands
{
    public class FilterCommand : BaseCommand
    {
        public FilterCommand(string fileName) : base(fileName) { }

        public override void Execute()
        {
            Console.WriteLine("Filter books (leave blank to not filter)");

            string author = GetAuthorInput();
            string category = GetCategoryInput();
            string language = GetLanguageInput();
            string ISBN = GetIsbnInput();
            string name = GetNameInput();
            bool? isAvailable = GetIsAvailableInput();

            List<Book> books = new BookReader(FileName).GetFiltered(author, category, language, ISBN, name, isAvailable);

            WriteOutput(books);
        }

        protected virtual void WriteOutput(List<Book> books)
        {
            Console.WriteLine("List of books: ");

            foreach (Book book in books)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine(
                    "Name: {0}\n" +
                    "Author: {1}\n" +
                    "Category: {2}\n" +
                    "Language: {3}\n" +
                    "Publication date: {4}\n" +
                    "ISBN: {5}\n" +
                    "{6}\n" +
                    "Barcode: {7}",
                    book.Name,
                    book.Author,
                    book.Category,
                    book.Language,
                    book.PublicationDate.ToString("yyyy-MM-dd"),
                    book.ISBN,
                    book.Borrower == null ? "Available" : "Taken",
                    book.Barcode);
            }
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

        protected virtual bool? GetIsAvailableInput()
        {
            string availability = GetStringInput("Taken (t) or available (a): ");

            bool? isAvailable = null;

            if (availability == "t")
                isAvailable = false;
            else if (availability == "a")
                isAvailable = true;

            return isAvailable;
        }
    }
}
