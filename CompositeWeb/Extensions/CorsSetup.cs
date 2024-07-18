namespace CompositeWeb.Extensions;

public static class CorsSetup
{
    public static void ConfigureService(this IServiceCollection service)
    {
        service.AddCors(options =>
            options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
    }
}