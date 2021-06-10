using Library;
using Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibraryTests.Models
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Book_Initialize_WithCorrectBarcodeLength()
        {
            //Arrange
            int expected = Constants.BarcodeLength;

            //Act
            Book book = new Book("test", "test", "test", "test", "test", DateTime.Now);
            int actual = book.Barcode.Length;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
