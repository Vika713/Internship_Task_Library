using System;
using System.Text.Json.Serialization;

namespace Library.Models
{
    public class Book
    {
        public string Barcode { get; private set; }

        public string Name { get; private set; }

        public string Author { get; private set; }

        public string Category { get; private set; }

        public string Language { get; private set; }

        public DateTime PublicationDate { get; private set; }

        public string ISBN { get; private set; }

        public string Borrower { get; private set; }

        public DateTime? DueDate { get; private set; }

        [JsonConstructor]
        public Book(
            string barcode,
            string name,
            string author,
            string category,
            string language,
            DateTime publicationDate,
            string isbn,
            string borrower,
            DateTime? dueDate)
        {
            Barcode = barcode;
            Name = name;
            Author = author;
            Category = category;
            Language = language;
            PublicationDate = publicationDate;
            ISBN = isbn;
            Borrower = borrower;
            DueDate = dueDate;
        }

        public Book(
            string isbn,
            string name,
            string author,
            string category,
            string language,
            DateTime publicationDate)
        {
            ISBN = isbn;
            Name = name;
            Author = author;
            Category = category;
            Language = language;
            PublicationDate = publicationDate;
            Barcode = GetBarcode();
        }

        public void Borrow(string borrower, DateTime dueDate)
        {
            Borrower = borrower;
            DueDate = dueDate;
        }

        public void Return()
        {
            Borrower = null;
            DueDate = null;
        }

        private static string GetBarcode()
        {
            int length = Constants.BarcodeLength;
            const string numbers = "0123456789";
            char[] barcode = new char[length];

            for (int i = 0; i < length; i++)
                barcode[i] = numbers[new Random().Next(numbers.Length)];

            return new string(barcode);
        }
    }
}
