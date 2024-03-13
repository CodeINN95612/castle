using Castle.Utils.Settings;

namespace Castle.Application.Settings;

public class JwtSettings : SettingsBase<JwtSettings>
{
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required string Key { get; init; }
}
