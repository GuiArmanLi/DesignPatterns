﻿using CompositeWeb.data.Repositories;
using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Services;
using CompositeWeb.Services.Interfaces;

namespace CompositeWeb.CrossCutting;

public static class IoCSetup
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(BaseRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}