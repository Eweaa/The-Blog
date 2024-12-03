using Microsoft.OpenApi.Models;

namespace BlogApp.Services;

public static class SwaggerService
{
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(g =>
        {
            g.SwaggerDoc("v1", new OpenApiInfo { Title = "The Blog API", Version = "v1" });

            var securityScheme = new OpenApiSecurityScheme
            {
                Description = "Jwt Authorization header using the Bearer scheme. Example \"Authorization:Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            
            g.AddSecurityDefinition("Bearer", securityScheme);
            
            var securityRequirement = new OpenApiSecurityRequirement
            {
                { securityScheme, ["Bearer"] }
            };
            
            g.AddSecurityRequirement(securityRequirement);
            
        });
        
        return services;
    }

    public static WebApplication UseSwaggerService(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}
