using Library;
using Library.Commands;
using Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryTests.Commands
{
    [TestClass]
    public class TakeCommandTests
    {
        [TestMethod]
        public void Execute_ExistingBarcode_UpdatesBookWithBorrower()
        {
            //Arrange
            string fileName = "../../../Commands/TestFiles/InputTestBooks.json";
            File.WriteAllText(fileName, GetTakeTestFileContentsWithoutBorrower());
            string expected = "test";

            List<Book> books = new List<Book>();

            //Act
            new TestTakeCommand(fileName, "test", "test", 1).Execute();

            if (File.Exists(fileName) && new FileInfo(fileName).Length > 2)
            {
                string jsonString = File.ReadAllText(fileName);
                books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            }
            string actual = books[0].Borrower;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Execute_UserHasMoreThan3Books_DoesNotUpdateBook()
        {
            //Arrange
            string fileName = "../../../Commands/TestFiles/InputTestBooks.json";
            File.WriteAllText(fileName, GetTakeTestFileContentsWith3SameBorrowers());
            string expected = null;

            List<Book> books = new List<Book>();

            //Act
            new TestTakeCommand(fileName, "test4", "test", 1).Execute();

            if (File.Exists(fileName) && new FileInfo(fileName).Length > 2)
            {
                string jsonString = File.ReadAllText(fileName);
                books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            }
            string actual = books[3].Borrower;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Execute_MoreThanAllowedDays_DoesNotUpdateBook()
        {
            //Arrange
            string fileName = "../../../Commands/TestFiles/InputTestBooks.json";
            File.WriteAllText(fileName, GetTakeTestFileContentsWithoutBorrower());
            string expected = null;

            List<Book> books = new List<Book>();

            //Act
            new TestTakeCommand(fileName, "test", "test", Constants.MaxBorrowingDays + 1).Execute();

            if (File.Exists(fileName) && new FileInfo(fileName).Length > 2)
            {
                string jsonString = File.ReadAllText(fileName);
                books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            }
            string actual = books[0].Borrower;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private static string GetTakeTestFileContentsWithoutBorrower()
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
                "}]";
        }

        private static string GetTakeTestFileContentsWith3SameBorrowers()
        {
            return
                "[{" +
                    "\"Barcode\":\"test1\"," +
                    "\"Name\":\"test\"," +
                    "\"Author\":\"test\"," +
                    "\"Category\":\"test\"," +
                    "\"Language\":\"test\"," +
                    "\"PublicationDate\":\"2020-01-01T00:00:00\"," +
                    "\"ISBN\":\"test\"," +
                    "\"Borrower\":\"test\"," +
                    "\"DueDate\":null" +
                "}," +
                "{" +
                    "\"Barcode\":\"test2\"," +
                    "\"Name\":\"test\"," +
                    "\"Author\":\"test\"," +
                    "\"Category\":\"test\"," +
                    "\"Language\":\"test\"," +
                    "\"PublicationDate\":\"2020-01-01T00:00:00\"," +
                    "\"ISBN\":\"test\"," +
                    "\"Borrower\":\"test\"," +
                    "\"DueDate\":null" +
                "}," +
                "{" +
                    "\"Barcode\":\"test3\"," +
                    "\"Name\":\"test\"," +
                    "\"Author\":\"test\"," +
                    "\"Category\":\"test\"," +
                    "\"Language\":\"test\"," +
                    "\"PublicationDate\":\"2020-01-01T00:00:00\"," +
                    "\"ISBN\":\"test\"," +
                    "\"Borrower\":\"test\"," +
                    "\"DueDate\":null" +
                "}," +
                "{" +
                    "\"Barcode\":\"test4\"," +
                    "\"Name\":\"test\"," +
                    "\"Author\":\"test\"," +
                    "\"Category\":\"test\"," +
                    "\"Language\":\"test\"," +
                    "\"PublicationDate\":\"2020-01-01T00:00:00\"," +
                    "\"ISBN\":\"test\"," +
                    "\"Borrower\":null," +
                    "\"DueDate\":null" +
                "}]";
        }
    }

    public class TestTakeCommand : TakeCommand
    {
        private string barcode { get; set; }

        private string userName { get; set; }

        private int days { get; set; }

        public TestTakeCommand(
            string fileName,
            string barcode,
            string userName,
            int days) : base(fileName)
        {
            this.barcode = barcode;
            this.userName = userName;
            this.days = days;
        }

        protected override string GetBarcodeInput()
        {
            return barcode;
        }

        protected override string GetUserNameInput()
        {
            return userName;
        }

        protected override int GetDaysInput()
        {
            return days;
        }
    }
}
