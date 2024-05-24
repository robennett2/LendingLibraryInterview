using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LendingLibraryInterview.Data.Migrations
{
    /// <inheritdoc />
    public partial class BookSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "IsCheckedOut", "Title" },
                values: new object[,]
                {
                    { 1, "Jill McCorkle", "978-1565122550", false, "Life After Life" },
                    { 2, "Dan Brown", "978-0307474278", false, "The Da Vinci Code" },
                    { 3, "Kate Atkinson", "978=0316176484", false, "Life After Life" },
                    { 4, "George Orwell", "978-0451524935", false, "1984" },
                    { 5, "F. Scott Fitzgerald", "978-0743273565", false, "The Great Gatsby" },
                    { 6, "J.D. Salinger", "978-0316769488", false, "The Catcher in the Rye" },
                    { 7, "Harper Lee", "978-0060935467", false, "To Kill a Mocking Bird" },
                    { 8, "J.R.R. Tolkien", "978-0547928227", false, "The Hobbit" },
                    { 9, "J.R.R. Tolkien", "978-0544003415", false, "The Lord of the Rings" },
                    { 10, "Harper Lee", "978-0062409850", false, "Go Set a Watchman" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
