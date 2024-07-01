using CompositeWeb.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CompositeWeb.Data.Extensions;

public static class EntityFrameworkSetup
{
    private static IConfiguration? _configuration;

    public static void AddEntityFramework(this IServiceCollection service)
    {
        service.AddDbContext<AppDbContext>(options =>
            options.UseMySql(GetConnectionString(_configuration),
                new MySqlServerVersion(new Version(8, 0, 36))));
    }

    private static string? GetConnectionString(this IConfiguration? configuration)
    {
        return configuration.GetConnectionString("MySql");
    }
}