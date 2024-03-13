using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Castle.Utils.Settings;

public static class SettingsExtensions
{
    public static IServiceCollection AddSetting<T>(this IServiceCollection services, IConfiguration configuration)
        where T : SettingsBase<T>
    {
        var section = configuration.GetSection(SettingsBase<T>.SectionName);
        if (section.Get<T>() is null)
        {
            throw new SettingsNotFoundException<T>();
        }

        return services.Configure<T>(section);
    }

    public static IServiceCollection AddSetting<T>(this IServiceCollection services, IConfiguration configuration, string sectionName)
        where T : SettingsBase<T>
    {
        var section = configuration.GetSection(sectionName);
        if (section.Get<T>() is null)
        {
            throw new SettingsNotFoundException<T>(sectionName);
        }

        return services.Configure<T>(section);
    }
}
