using Castle.Infrastructure.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Castle.Infrastructure.Extensions;
public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDatabase(configuration);
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
}
