namespace LoupixDeck.PluginSdk;

/// <summary>
/// A plugin command that renders a dynamic image (PNG bytes) onto a touch
/// button, optionally with an overlay text. Host-side wiring is added
/// alongside the first plugin that needs it; until then plugins may declare
/// the interface but only the text path of <see cref="IDisplayCommand"/> is
/// guaranteed to render. Set <see cref="IPluginCommand.SupportedTargets"/> to
/// <see cref="ButtonTargets.TouchButton"/>.
/// </summary>
public interface IDisplayImageCommand : IPluginCommand
{
    /// <summary>How often the host should poll <see cref="GetImage"/>.</summary>
    TimeSpan UpdateInterval { get; }

    /// <summary>Produces the current image as PNG-encoded bytes, or null to
    /// fall back to the button's default icon. Must be fast and synchronous
    /// (called on a polling timer); do any decoding/network work asynchronously
    /// in <see cref="LoupixPlugin.Initialize"/> and cache the result.</summary>
    byte[]? GetImage(CommandContext ctx);

    /// <summary>Optional overlay text drawn beneath the image, or null for
    /// image-only rendering.</summary>
    string? GetText(CommandContext ctx);
}
