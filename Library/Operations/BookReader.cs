using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Operations
{
    public class BookReader : Reader<Book>
    {
        public BookReader(string fileName) : base(fileName) { }

        public List<Book> GetFiltered(string author, string category, string language, string ISBN, string name, bool? isAvailable)
        {
            return GetAll().Where(b =>
                (author == null || b.Author.ToLower().Contains(author.ToLower())) &&
                (category == null || b.Category.ToLower().Contains(category.ToLower())) &&
                (language == null || b.Language.ToLower().Contains(language.ToLower())) &&
                (ISBN == null || b.ISBN.ToLower().Contains(ISBN.ToLower())) &&
                (name == null || b.Name.ToLower().Contains(name.ToLower())) &&
                (isAvailable == null || (b.Borrower == null) == isAvailable)).ToList();
        }

        public List<Book> GetAllBooksList()
        {
            return GetAll().ToList();
        }

        public Book GetByBarcode(string barcode)
        {
            Book book = GetAll().FirstOrDefault(b => b.Barcode == barcode);
            return book;
        }

        public int GetCountByBorrower(string borrower)
        {
            int count = GetAll().Where(b => b.Borrower == borrower).Count();
            return count;
        }
    }
}
