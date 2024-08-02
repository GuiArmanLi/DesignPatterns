using Microsoft.EntityFrameworkCore;
using CompositeWeb.Data.Context;

namespace CompositeWeb.Data.Extensions;

public static class EntityFrameworkSetup
{
    public static void AddEntityFramework(this IServiceCollection service)
    {
        service.AddDbContext<AppDbContext>(options =>
            options.UseMySql(GetConnectionString(),
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