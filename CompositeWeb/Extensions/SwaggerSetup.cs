﻿using System.Reflection;
using Microsoft.OpenApi.Models;

namespace CompositeWeb.Extensions;

public static class SwaggerSetup
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Composite",
                    Version = "v1"
                });
        });
    }

    //     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //     {
    //         Description = @"JWT Authorization header using the Bearer scheme. 
    //                             Enter 'Bearer' [space] and then your token in the text input below. 
    //                             Example: 'Bearer 12345abcdef'",
    //         Name = "Authorization",
    //         In = ParameterLocation.Header,
    //         Type = SecuritySchemeType.ApiKey,
    //         Scheme = "Bearer"
    //     });
    //     c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    //     {
    //         {
    //             new OpenApiSecurityScheme
    //             {
    //                 Reference = new OpenApiReference
    //                 {
    //                     Type = ReferenceType.SecurityScheme,
    //                     Id = "Bearer"
    //                 },
    //                 Scheme = "oauth2",
    //                 Name = "Bearer",
    //                 In = ParameterLocation.Header,
    //             },
    //             new List<string>()
    //         }
    //     });
    //     var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //     var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //     c.IncludeXmlComments(xmlPath);
    // });


    public static void UseSwaggerUI(this IApplicationBuilder builder)
    {
        builder.UseSwagger();
        builder.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Composite"));
    }
}