using System;
using Geek.Database;
using Microsoft.EntityFrameworkCore;

namespace Geekiam.Data.Services.Integration.Tests.TestFixtures;

public class SqlLiteTestFixture : IDisposable
{
    public GeekContext Context => TestContext();

    private GeekContext TestContext()
    {
        var options = new DbContextOptionsBuilder<GeekContext>()
            .UseNpgsql("User ID=posts;Password=Password12@;Host=localhost;Port=5432;Database=geekiam;Pooling=true;Integrated Security=true;")
            .Options;


        var context = new GeekContext(options);
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        return context;
    }
    public void Dispose()
    {
        Context?.Dispose();
        
    }
}