using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Services.Interfaces;
using CompositeWeb.data.Repositories;
using CompositeWeb.Services;

namespace CompositeWeb.CrossCutting.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(BaseRepository<>));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}