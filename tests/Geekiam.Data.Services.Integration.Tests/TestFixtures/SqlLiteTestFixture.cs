using System;
using Geekiam.Database;
using Microsoft.EntityFrameworkCore;

namespace Geekiam.Data.Services.Integration.Tests.TestFixtures;

public class SqlLiteTestFixture : IDisposable
{
    public GeekiamContext Context => TestContext();

    private GeekiamContext TestContext()
    {
        var options = new DbContextOptionsBuilder<GeekiamContext>()
            .UseNpgsql("User ID=posts;Password=Password12@;Host=localhost;Port=5432;Database=geekiam;Pooling=true;Integrated Security=true;")
            .Options;


        var context = new GeekiamContext(options);
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        return context;
    }
    public void Dispose()
    {
        Context?.Dispose();
        
    }
}