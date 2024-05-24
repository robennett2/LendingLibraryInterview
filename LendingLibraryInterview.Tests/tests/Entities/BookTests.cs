using Xunit;
using LendingLibraryInterview.Data.Entities;

namespace LendingLibraryInterview.Tests.Entities
{
    public class BookTests
    {
        [Fact]
        public void CheckOut_WhenBookIsNotCheckedOut_SetsIsCheckedOutToTrue()
        {
            // Arrange
            var book = new Book("Title", "Author", "ISBN");

            // Act
            book.CheckOut();

            // Assert
            Assert.True(book.IsCheckedOut);
        }

        [Fact]
        public void CheckOut_WhenBookIsCheckedOut_ThrowsInvalidOperationException()
        {
            // Arrange
            var book = new Book("Title", "Author", "ISBN");
            book.CheckOut();

            // Act
            void action() => book.CheckOut();

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void CheckIn_WhenBookIsCheckedOut_SetsIsCheckedOutToFalse()
        {
            // Arrange
            var book = new Book("Title", "Author", "ISBN");
            book.CheckOut();

            // Act
            book.CheckIn();

            // Assert
            Assert.False(book.IsCheckedOut);
        }

        [Fact]
        public void CheckIn_WhenBookIsNotCheckedOut_ThrowsInvalidOperationException()
        {
            // Arrange
            var book = new Book("Title", "Author", "ISBN");

            // Act
            void action() => book.CheckIn();

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}   