using Library.Commands;
using Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryTests.Commands
{
    [TestClass]
    public class FilterCommandTests
    {
        [TestMethod]
        public void Execute_FilterParametersAreNull_ReturnsAll()
        {
            //Arrange
            string fileName = "../../../Commands/TestFiles/OutputTestBooks.json";
            int expected = 2;

            //Act
            new TestFilterCommand(fileName, null, null, null, null, null, null).Execute();

            //Assert
            string jsonString = File.ReadAllText("../../../Commands/TestFiles/FilterOutputTestBooks.json");
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            int actual = books.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Execute_FilterParametersNotNull_ReturnsBook()
        {
            //Arrange
            string fileName = "../../../Commands/TestFiles/OutputTestBooks.json";
            int expected = 1;

            //Act
            new TestFilterCommand(fileName, "test1", "test1", "test1", "test1", "test1", true).Execute();

            string jsonString = File.ReadAllText("../../../Commands/TestFiles/FilterOutputTestBooks.json");
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            int actual = books.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }


    public class TestFilterCommand : FilterCommand
    {
        private string name { get; set; }

        private string author { get; set; }

        private string category { get; set; }

        private string language { get; set; }

        private string isbn { get; set; }

        private bool? isAvailable { get; set; }

        public TestFilterCommand(
            string fileName,
            string name,
            string author,
            string category,
            string language,
            string isbn,
            bool? isAvailable) : base(fileName)
        {
            this.name = name;
            this.author = author;
            this.category = category;
            this.language = language;
            this.isbn = isbn;
            this.isAvailable = isAvailable;
        }

        protected override void WriteOutput(List<Book> books)
        {
            string jsonString = JsonSerializer.Serialize(books);
            File.WriteAllText("../../../Commands/TestFiles/FilterOutputTestBooks.json", jsonString);
        }

        protected override string GetIsbnInput()
        {
            return isbn;
        }

        protected override string GetNameInput()
        {
            return name;
        }

        protected override string GetAuthorInput()
        {
            return author;
        }

        protected override string GetCategoryInput()
        {
            return category;
        }

        protected override string GetLanguageInput()
        {
            return language;
        }

        protected override bool? GetIsAvailableInput()
        {
            return isAvailable;
        }
    }
}
