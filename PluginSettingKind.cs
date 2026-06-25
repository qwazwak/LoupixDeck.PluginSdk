namespace LoupixDeck.PluginSdk;

/// <summary>
/// The editor kind the host renders for a plugin setting, and the value type
/// it is stored as in <see cref="IPluginSettings"/>.
/// </summary>
public enum PluginSettingKind
{
    /// <summary>
    /// Single-line text.
    /// </summary>
    /// <remarks>
    /// Stored as <see cref="string"/>
    /// </remarks>
    Text,

    /// <summary>
    /// Masked text (e.g. a password).
    /// </summary>
    /// <remarks>
    /// Stored as <see cref="string"/>.
    /// </remarks>
    Password,

    /// <summary>
    /// Integer number.
    /// </summary>
    /// <remarks>
    /// Stored as a JSON integer (read with <c>Get&lt;long&gt;</c>).
    /// </remarks>
    Number,

    /// <summary>
    /// On/off switch.
    /// </summary>
    /// <remarks>
    /// Stored as <see cref="bool"/>
    /// </remarks>
    Toggle,

    /// <summary>
    /// Display-only heading/separator used to group fields.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Has no editor and stores no value only <see cref="PluginSettingDescriptor.Label"/>
    /// (and optionally <see cref="PluginSettingDescriptor.Description"/>) are read by the host.
    /// </para>
    /// <para>
    /// <see cref="PluginSettingDescriptor.Key"/> must still be unique within the schema.
    /// </para>
    /// </remarks>
    Heading,
}
