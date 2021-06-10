using Library.Commands;
using Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryTests.Commands
{
    [TestClass]
    public class ReturnCommandTests
    {
        [TestMethod]
        public void Execute_ExistingBarcode_UpdatesBookWithoutBorrower()
        {
            //Arrange
            string fileName = "../../../Commands/TestFiles/InputTestBooks.json";
            File.WriteAllText(fileName, GetReturnTestFileContentsWithBorrower());
            string expected = null;

            List<Book> books = new List<Book>();

            //Act
            new TestReturnCommand(fileName).Execute();

            if (File.Exists(fileName) && new FileInfo(fileName).Length > 2)
            {
                string jsonString = File.ReadAllText(fileName);
                books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            }
            string actual = books[0].Borrower;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private static string GetReturnTestFileContentsWithBorrower()
        {
            return
                "[{" +
                    "\"Barcode\":\"test\"," +
                    "\"Name\":\"test\"," +
                    "\"Author\":\"test\"," +
                    "\"Category\":\"test\"," +
                    "\"Language\":\"test\"," +
                    "\"PublicationDate\":\"2020-01-01T00:00:00\"," +
                    "\"ISBN\":\"test\"," +
                    "\"Borrower\":\"test\"," +
                    "\"DueDate\":\"2020-02-01T00:00:00\"" +
                "}]";
        }
    }

    public class TestReturnCommand : ReturnCommand
    {
        public TestReturnCommand(string fileName) : base(fileName) { }

        protected override string GetBarcodeInput()
        {
            return "test";
        }
    }
}
