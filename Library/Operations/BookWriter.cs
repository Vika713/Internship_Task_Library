using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Operations
{
    public class BookWriter : Writer<Book>
    {
        public BookWriter(string fileName) : base(fileName) { }

        public void Create(Book book)
        {
            List<Book> books = new BookReader(FileName).GetAllBooksList();
            books.Add(book);
            Write(books);
        }

        public void Update(Book book)
        {
            List<Book> books = new BookReader(FileName).GetAllBooksList();
            int index = books.FindIndex(b => b.Barcode == book.Barcode);
            books[index] = book;
            Write(books);
        }

        public void Delete(string barcode)
        {
            List<Book> books = new BookReader(FileName).GetAllBooksList();
            books.Remove(books.FirstOrDefault(b => b.Barcode == barcode));
            Write(books);
        }
    }
}
