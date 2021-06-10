using Library.Commands;
using Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryTests.Commands
{
    [TestClass]
    public class AddCommandTests
    {
        [TestMethod]
        public void Execute_WithInput_WritesBookToFile()
        {
            //Arrange
            string fileName = "../../../Commands/TestFiles/InputTestBooks.json";
            File.WriteAllText(fileName, "[]");

            List<Book> books = new List<Book>();

            int expected = 1;

            //Act
            new TestAddCommand(fileName).Execute();

            if (File.Exists(fileName) && new FileInfo(fileName).Length > 2)
            {
                string jsonString = File.ReadAllText(fileName);
                books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            }
            int actual = books.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }

    public class TestAddCommand : AddCommand
    {
        public TestAddCommand(string fileName) : base(fileName) { }

        protected override string GetIsbnInput()
        {
            return "test";
        }

        protected override string GetNameInput()
        {
            return "test";
        }

        protected override string GetAuthorInput()
        {
            return "test";
        }

        protected override string GetCategoryInput()
        {
            return "test";
        }

        protected override string GetLanguageInput()
        {
            return "test";
        }

        protected override DateTime GetPublicationDateInput()
        {
            return DateTime.Now;
        }
    }
}
