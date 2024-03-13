namespace Castle.Utils.Settings;

public abstract class SettingsBase<T>
{
    public static string SectionName => typeof(T).Name;
}
