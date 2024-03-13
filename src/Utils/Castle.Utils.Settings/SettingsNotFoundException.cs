namespace Castle.Utils.Settings;

public class SettingsNotFoundException<T> : Exception
    where T : SettingsBase<T>
{
    public SettingsNotFoundException() : base($"Settings `{SettingsBase<T>.SectionName}` not found for type {nameof(T)}.") { }
    public SettingsNotFoundException(string sectionName) : base($"Settings `{sectionName}` not found for type {nameof(T)}.") { }
}
