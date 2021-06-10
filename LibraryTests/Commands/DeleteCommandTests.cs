using Library.Commands;
using Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryTests.Commands
{
    [TestClass]
    public class DeleteCommandTests
    {
        [TestMethod]
        public void Execute_ExistingBarcode_DeletesBookInFile()
        {
            //Arrange
            string fileName = "../../../Commands/TestFiles/InputTestBooks.json";
            File.WriteAllText(fileName, GetDeleteTestFileContents());

            List<Book> books = new List<Book>();

            int expected = 1;

            //Act
            new TestDeleteCommand(fileName).Execute();

            if (File.Exists(fileName) && new FileInfo(fileName).Length > 2)
            {
                string jsonString = File.ReadAllText(fileName);
                books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            }
            int actual = books.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private static string GetDeleteTestFileContents()
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
                    "\"Borrower\":null," +
                    "\"DueDate\":null" +
                "}," +
                "{" +
                    "\"Barcode\":\"test2\"," +
                    "\"Name\":\"test2\"," +
                    "\"Author\":\"test2\"," +
                    "\"Category\":\"test2\"," +
                    "\"Language\":\"test2\"," +
                    "\"PublicationDate\":\"2020-01-01T00:00:00\"," +
                    "\"ISBN\":\"test2\"," +
                    "\"Borrower\":null," +
                    "\"DueDate\":null" +
                "}]";
        }
    }

    public class TestDeleteCommand : DeleteCommand
    {
        public TestDeleteCommand(string fileName) : base(fileName) { }

        protected override string GetBarcodeInput()
        {
            return "test";
        }
    }
}
