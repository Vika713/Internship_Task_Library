using Library.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests.Operations
{
    [TestClass]
    public class BookReaderTests
    {
        [TestMethod]
        public void GetCountByBorrower_BorrowerDoesNotExist_Returns0()
        {
            //Arrange
            string fileName = "../../../Operations/TestFiles/TestBooks.json";
            int expected = 0;

            //Act
            int actual = new BookReader(fileName).GetCountByBorrower("borrower");

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
