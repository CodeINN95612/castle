using Castle.Application.Settings;
using Castle.Infrastructure.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Castle.Infrastructure.Extensions;
public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDatabase(configuration)
            .AddAuth();
    }

    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using CastleDbContext db = scope.ServiceProvider.GetRequiredService<CastleDbContext>();

        db.Database.Migrate();
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<CastleDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("CastleDbConnection"));
            });
    }

    private static IServiceCollection AddAuth(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        var jwtSettings = serviceProvider.GetRequiredService<IOptionsMonitor<JwtSettings>>().CurrentValue;


        return services;
    }
}
