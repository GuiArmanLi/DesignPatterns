using CompositeWeb.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MySqlConnector;

namespace CompositeWeb.Data.Extensions;

public static class EntityFrameworkSetup
{
    public static void AddEntityFramework(this IServiceCollection service)
    {
        var connection = GetConnectionString();

        service.AddDbContext<AppDbContext>(options =>
            options.UseMySql("Server=localhost; Port=3306; Database=composite;User=guilherme;Password=admin;",
                new MySqlServerVersion(new Version(8, 0, 36))));
        // options.UseInMemoryDatabase("MemoryDatabase"));
    }

    private static string? GetConnectionString()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var configuration = builder.Build();
        return configuration.GetConnectionString("MySql");
    }
}