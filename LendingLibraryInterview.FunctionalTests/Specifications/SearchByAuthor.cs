using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LendingLibraryInterview.Api.Contracts.Responses;
using LendingLibraryInterview.Data.Entities;
using LendingLibraryInterview.FunctionalTests;

namespace Specifications;

public class Given_a_list_of_books_When_I_search_for_an_author : ApiTestBase
{
    private const string Author = "Harper Lee";
    
    public Given_a_list_of_books_When_I_search_for_an_author()
    {
        Given(() => { });
        
        When(async () => await Client.GetAsync($"api/v1/books?author={Author}"));
    }
    
    [Test]
    public void Then_the_response_is_ok() =>
        Result.StatusCode.Should().Be(HttpStatusCode.OK);

    [Test]
    public async Task Then_the_response_contains_books_by_the_author()
    {
        var response = Result;
        var books = (await response.Content.ReadFromJsonAsync<IEnumerable<BookDto>>())?.ToList();
        books.Should().NotBeNullOrEmpty();
        books.Should().BeEquivalentTo(new[]
        {
            new
            {
                Id = 7,
                Title = "To Kill a Mocking Bird",
                Author = Author,
                ISBN = "978-0060935467",
                IsCheckedOut = false
            },
            new
            {
                Id = 10,
                Title = "Go Set a Watchman",
                Author = Author,
                ISBN = "978-0062409850",
                IsCheckedOut = false
            }
        });
    }
}