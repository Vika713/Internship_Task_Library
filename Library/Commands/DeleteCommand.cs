using Library.Models;
using Library.Operations;
using System;

namespace Library.Commands
{
    public class DeleteCommand : BaseCommand
    {
        public DeleteCommand(string fileName) : base(fileName) { }

        public override void Execute()
        {
            Console.WriteLine("Delete a book");

            string barcode = GetBarcodeInput();

            Book book = new BookReader(FileName).GetByBarcode(barcode);

            if (book == null)
            {
                Console.WriteLine("Book does not exist");
            }
            else
            {
                new BookWriter(FileName).Delete(barcode);

                Console.WriteLine("The book was deleted");
            }
        }

        protected virtual string GetBarcodeInput()
        {
            return GetStringInput("Barcode: ");
        }
    }
}
