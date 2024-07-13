using CompositeWeb.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CompositeWeb.Data.Extensions;

public static class EntityFrameworkSetup
{
    private static IConfiguration _configuration;

    public static void AddEntityFramework(this IServiceCollection service)
    {
        var connection = GetConnectionString();

        service.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("MemoryDatabase"));
            // options.UseMySql("Server=localhost; Port=3306; Database=compositeweb;User=guilherme;Password=admin;",
                // new MySqlServerVersion(new Version(8, 0, 36))));
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