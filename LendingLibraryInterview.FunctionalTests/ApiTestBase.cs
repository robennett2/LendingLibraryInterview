using Chill;
using LendingLibraryInterview.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LendingLibraryInterview.FunctionalTests;

public class ApiTestBase : GivenWhenThen<HttpResponseMessage>
{
    protected HttpClient Client;
    protected IServiceProvider ServiceProvider;
    
    public ApiTestBase()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Development");
        });
        
        Client = webApplicationFactory.CreateClient();
        ServiceProvider = webApplicationFactory.Services;
        using (GetDbContext(out var db))
        {
            db.Database.Migrate();
        }
    }
    
    protected IDisposable GetDbContext(out SQLiteDbContext dbContext)
    {
        var scope = ServiceProvider.CreateScope();
        dbContext = scope.ServiceProvider.GetRequiredService<SQLiteDbContext>();
        return scope;
    }
}