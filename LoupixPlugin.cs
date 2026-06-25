namespace LoupixDeck.PluginSdk;

/// <summary>
/// The entry point of a LoupixDeck plugin.
/// </summary>
/// <remarks>
/// Each plugin assembly provides exactly one concrete subclass; the host discovers it, instantiates it,
/// calls <see cref="Initialize"/> once, collects its commands, and calls
/// <see cref="Shutdown"/> on unload or app exit.
/// </remarks>
public abstract class LoupixPlugin
{
    /// <summary>
    /// Identity and versioning of this plugin.
    /// </summary>
    public abstract PluginMetadata Metadata { get; }

    /// <summary>
    /// Called once after load, before commands are collected.
    /// </summary>
    /// <param name="host">The host bridge for this plugin, may be kept for the plugin's lifetime.</param>
    public virtual void Initialize(IPluginHost host) { }

    /// <summary>
    /// Called on plugin unload or application exit.
    /// </summary>
    /// <remarks>
    /// The plugin must release resources, stop background work, and close connections.
    /// </remarks>
    public virtual void Shutdown() { }

    /// <summary>
    /// Returns the commands this plugin contributes.
    /// </summary>
    public abstract IEnumerable<IPluginCommand> GetCommands();

    /// <summary>
    /// Returns the side-strip providers this plugin contributes (renderers a user can
    /// bind to a Razer side display strip in plugin-override mode).
    /// </summary>
    /// <remarks>
    /// Defaults to none.
    /// The host collects these after <see cref="Initialize"/>, alongside <see cref="GetCommands"/>.
    /// </remarks>
    public virtual IEnumerable<ISideStripProvider> GetSideStripProviders() =>
        Array.Empty<ISideStripProvider>();
}
