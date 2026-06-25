namespace LoupixDeck.PluginSdk;

/// <summary>
/// A plugin command that additionally renders dynamic text onto a touch button.
/// </summary>
/// <remarks>
/// Replaces the core's <c>IDynamicTextProvider</c>.
/// Display commands should set <see cref="IPluginCommand.SupportedTargets"/> to <see cref="ButtonTargets.TouchButton"/>.
/// </remarks>
public interface IDisplayCommand : IPluginCommand
{
    /// <summary>
    /// How often the host should poll <see cref="GetText"/>.
    /// </summary>
    TimeSpan UpdateInterval { get; }

    /// <summary>
    /// Produces the current text to display.
    /// </summary>
    /// <remarks>
    /// Must be fast and synchronous (called on a polling timer).
    /// </remarks>
    string GetText(CommandContext ctx);
}
