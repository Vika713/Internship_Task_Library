using Library.Models;
using Library.Operations;
using System;

namespace Library.Commands
{
    public class ReturnCommand : BaseCommand
    {
        public ReturnCommand(string fileName) : base(fileName) { }

        public override void Execute()
        {
            Console.WriteLine("Return a book");

            string barcode = GetBarcodeInput();

            Book book = new BookReader(FileName).GetByBarcode(barcode);

            if (book == null || book.Borrower == null)
            {
                Console.WriteLine("Book cannot be returned");
            }
            else
            {
                if (DateTime.Now > book.DueDate)
                {
                    Console.WriteLine("You are late");
                }

                book.Return();

                new BookWriter(FileName).Update(book);

                Console.WriteLine("Returned successfully");
            }
        }

        protected virtual string GetBarcodeInput()
        {
            return GetStringInput("Barcode: ");
        }
    }
}
