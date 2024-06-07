using LendingLibraryInterview.Data;
using LendingLibraryInterview.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LendingLibraryInterview.Api.Services;

public class BookService : IBookService
{
    private readonly SQLiteDbContext _dbContext;

    public BookService(SQLiteDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task AddBookAsync(string title, string author)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Book>> SearchBooksByAuthorAsync(string author) => 
        await _dbContext.Books.Where(b => b.Author == author).ToListAsync();

    public Task<List<Book>> SearchBooksByIsbnAsync(string author)
    {
        throw new NotImplementedException();
    }

    public Task BorrowBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public Task ReturnBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }
}