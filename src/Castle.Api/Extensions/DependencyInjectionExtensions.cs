using Castle.Application.Settings;
using Castle.Utils.Settings;

namespace Castle.Api.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddSetting<JwtSettings>(configuration);
    }
}
