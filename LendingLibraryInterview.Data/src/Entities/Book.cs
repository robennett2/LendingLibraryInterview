using System.ComponentModel.DataAnnotations;

namespace LendingLibraryInterview.Data.Entities
{
    public class Book
    {
        public int Id { get; init; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string? ISBN { get; set; }

        public bool IsCheckedOut { get; private set; }

        protected Book() // EF Core requires a parameterless constructor
        {
            Title = string.Empty;
            Author = string.Empty;
            ISBN = string.Empty;
            IsCheckedOut = false;
        }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsCheckedOut = false;
        }

        public void CheckOut()
        {
            if (IsCheckedOut)
            {
                throw new InvalidOperationException("Book is already checked out");
            }

            IsCheckedOut = true;
        }

        public void CheckIn()
        {
            if (!IsCheckedOut)
            {
                throw new InvalidOperationException("Book is already checked in");
            }

            IsCheckedOut = false;
        }
    }
}