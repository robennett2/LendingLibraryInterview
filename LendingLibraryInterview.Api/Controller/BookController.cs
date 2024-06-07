using LendingLibraryInterview.Api.Contracts.Responses;
using LendingLibraryInterview.Api.Services;
using LendingLibraryInterview.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LendingLibraryInterview.Api.Controller;

[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet("api/v1/books")]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestDto), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooksAsync([FromQuery] string? author)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            return BadRequest(new BadRequestDto("Author is required"));
        }

        try
        {
            var books = await _bookService.SearchBooksByAuthorAsync(author);
            return Ok(books.Select(x => new BookDto
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                ISBN = x.ISBN,
                IsCheckedOut = x.IsCheckedOut
            }).ToList());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}