using CompositeWeb.data.Repositories;
using CompositeWeb.Data.Repositories.Interfaces;

namespace CompositeWeb.Data.Extensions;

public static class IoCSetup
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(BaseRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}