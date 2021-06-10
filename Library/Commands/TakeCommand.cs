using Library.Models;
using Library.Operations;
using System;

namespace Library.Commands
{
    public class TakeCommand : BaseCommand
    {
        public TakeCommand(string fileName) : base(fileName) { }

        public override void Execute()
        {
            Console.WriteLine("Take a book");

            string barcode = GetBarcodeInput();

            Book book = new BookReader(FileName).GetByBarcode(barcode);

            if (book == null || book.Borrower != null)
            {
                Console.WriteLine("Book cannot be taken");
            }
            else
            {
                string userName = GetUserNameInput();

                if (new BookReader(FileName).GetCountByBorrower(userName) >= Constants.MaxBooksPerUser)
                {
                    Console.WriteLine("This user cannot borrow anymore books");
                }
                else
                {
                    int days = GetDaysInput();

                    if (days > Constants.MaxBorrowingDays)
                    {
                        Console.WriteLine("Cannot borrow for this long");
                    }
                    else
                    {
                        book.Borrow(userName, DateTime.Now.AddDays(days));

                        new BookWriter(FileName).Update(book);

                        Console.WriteLine("Borrowed successfully");
                    }
                }
            }
        }

        protected virtual string GetBarcodeInput()
        {
            return GetStringInput("Barcode: ");
        }

        protected virtual string GetUserNameInput()
        {
            return GetStringInput("User name: ");
        }

        protected virtual int GetDaysInput()
        {
            return GetIntInput("Borrowing days (no more than " + Constants.MaxBorrowingDays + "): ");
        }
    }
}
