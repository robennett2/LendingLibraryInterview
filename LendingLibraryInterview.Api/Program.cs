using System.Runtime.CompilerServices;
using LendingLibraryInterview.Api.Services;
using LendingLibraryInterview.Data;
using Microsoft.EntityFrameworkCore;

[assembly:InternalsVisibleTo("LendingLibraryInterview.FunctionalTests")]

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SQLiteDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteDbContext"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
