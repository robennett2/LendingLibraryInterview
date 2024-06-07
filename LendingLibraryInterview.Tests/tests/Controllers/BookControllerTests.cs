using FluentAssertions;
using LendingLibraryInterview.Api.Contracts.Responses;
using LendingLibraryInterview.Api.Controller;
using LendingLibraryInterview.Api.Services;
using LendingLibraryInterview.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;

namespace LendingLibraryInterview.Tests.Controllers;

public class BookControllerTests
{
    private AutoMocker _mocker = new(MockBehavior.Strict);
    public Mock<IBookService> BookServiceMock => _mocker.GetMock<IBookService>();

    private BookController CreateSut()
    {
        return _mocker.CreateInstance<BookController>();
    }
    
    [Fact]
    public async Task GetBooks_ByAuthorOnly_ReturnsBooksByAuthor()
    {
        // Arrange
        var author = "author";
        var bookController = CreateSut();
        var booksByAuthor = new List<Book>
        {
            new Book("title1", author, "ISBN1")
            {
                Id = 1
            },
            new Book("title2", author, "ISBN1")
            {
                Id = 2
            }
        };
        
        BookServiceMock
            .Setup(x => x.SearchBooksByAuthorAsync(author))
            .ReturnsAsync(booksByAuthor);
        
        // Act
        var result = await bookController.GetBooksAsync(author);
        
        // Assert
        var okObjectResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var books = okObjectResult.Value.Should().BeOfType<List<BookDto>>().Subject.ToList();
        books.Should().HaveCount(2);
        books.Should().BeEquivalentTo(new[]
        {
            new
            {
                Id = 1,
                Title = "title1",
                Author = author,
                ISBN = "ISBN1",
                IsCheckedOut = false
            },
            new
            {
                Id = 2,
                Title = "title2",
                Author = author,
                ISBN = "ISBN1",
                IsCheckedOut = false
            }
        });

        BookServiceMock.Verify(x => x.SearchBooksByAuthorAsync(author), Times.Once);
        BookServiceMock.VerifyNoOtherCalls();
    }
    
    [Fact]
    public async Task GetBooks_WithInvalidAuthor_ReturnsBadRequestWithCorrectMessage()
    {
        // Arrange
        string? author = null;
        var bookController = CreateSut();

        // Act
        var result = await bookController.GetBooksAsync(author);
        
        // Assert
        var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
        var badRequestDto = badRequestResult.Value.Should().BeOfType<BadRequestDto>().Subject;
        badRequestDto.Message.Should().Be("Author is required");

    }
    
    [Fact]
    public async Task GetBooks_UnexpectedException_ReturnsInternalSeverError()
    {
        // Arrange
        var author = "author";
        var bookController = CreateSut();

        BookServiceMock
            .Setup(x => x.SearchBooksByAuthorAsync(author))
            .ThrowsAsync(new Exception("Unexpected error"));
        
        // Act
        var result = await bookController.GetBooksAsync(author);
        
        // Assert
        var statusCodeResult = result.Should().BeOfType<StatusCodeResult>().Subject;
        statusCodeResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
    }
}