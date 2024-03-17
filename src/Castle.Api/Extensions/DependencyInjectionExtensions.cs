using Castle.Application.Settings;
using Castle.Utils.Settings;

using Microsoft.Extensions.Options;

namespace Castle.Api.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddSetting<JwtSettings>(configuration);
    }

    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        var jwtSettings = serviceProvider.GetRequiredService<IOptionsMonitor<JwtSettings>>().CurrentValue;

        return services;
    }
}
