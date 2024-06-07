namespace LendingLibraryInterview.Api.Contracts.Responses;

public class BookDto
{
    public int Id { get; init; }

    public string Title { get; init; }

    public string Author { get; init; }

    public string? ISBN { get; init; }

    public bool IsCheckedOut { get; init; }
}