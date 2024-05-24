﻿// <auto-generated />
using LendingLibraryInterview.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LendingLibraryInterview.Data.Migrations
{
    [DbContext(typeof(SQLiteDbContext))]
    [Migration("20240517125139_Book Seed Data")]
    partial class BookSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("LendingLibraryInterview.Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCheckedOut")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Jill McCorkle",
                            ISBN = "978-1565122550",
                            IsCheckedOut = false,
                            Title = "Life After Life"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Dan Brown",
                            ISBN = "978-0307474278",
                            IsCheckedOut = false,
                            Title = "The Da Vinci Code"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Kate Atkinson",
                            ISBN = "978=0316176484",
                            IsCheckedOut = false,
                            Title = "Life After Life"
                        },
                        new
                        {
                            Id = 4,
                            Author = "George Orwell",
                            ISBN = "978-0451524935",
                            IsCheckedOut = false,
                            Title = "1984"
                        },
                        new
                        {
                            Id = 5,
                            Author = "F. Scott Fitzgerald",
                            ISBN = "978-0743273565",
                            IsCheckedOut = false,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 6,
                            Author = "J.D. Salinger",
                            ISBN = "978-0316769488",
                            IsCheckedOut = false,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Harper Lee",
                            ISBN = "978-0060935467",
                            IsCheckedOut = false,
                            Title = "To Kill a Mocking Bird"
                        },
                        new
                        {
                            Id = 8,
                            Author = "J.R.R. Tolkien",
                            ISBN = "978-0547928227",
                            IsCheckedOut = false,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 9,
                            Author = "J.R.R. Tolkien",
                            ISBN = "978-0544003415",
                            IsCheckedOut = false,
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Harper Lee",
                            ISBN = "978-0062409850",
                            IsCheckedOut = false,
                            Title = "Go Set a Watchman"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}