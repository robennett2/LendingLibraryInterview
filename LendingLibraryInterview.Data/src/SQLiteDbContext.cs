using LendingLibraryInterview.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LendingLibraryInterview.Data;

public class SQLiteDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(b => b.Id); modelBuilder.Entity<Book>().Property(b => b.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Author).IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.ISBN);
        modelBuilder.Entity<Book>().Property(b => b.IsCheckedOut);
    }
}
