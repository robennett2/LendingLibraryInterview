using LendingLibraryInterview.Data.Entities;

namespace LendingLibraryInterview.Api.Services
{
    public interface IBookService
    {
        Task AddBookAsync(string title, string author);
        Task<List<Book>> SearchBooksByAuthorAsync(string author);
        Task<List<Book>> SearchBooksByIsbnAsync(string author);
        Task BorrowBookAsync(int bookId);
        Task ReturnBookAsync(int bookId);
    }
}
