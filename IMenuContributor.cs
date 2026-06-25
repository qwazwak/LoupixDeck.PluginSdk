namespace LoupixDeck.PluginSdk;

/// <summary>
/// Optional capability a <see cref="LoupixPlugin"/> can implement to contribute
/// dynamically built submenu entries (e.g. live OBS scenes, available sensors)
/// instead of, or in addition to, the flat list from <c>GetCommands</c>.
/// </summary>
/// <remarks>
/// The host calls this when building the command-selection menu.
/// </remarks>
public interface IMenuContributor
{
    /// <summary>
    /// Builds the dynamic menu nodes for the given button type.
    /// </summary>
    /// <remarks>
    /// Implementations must be resilient: the host applies a timeout and treats failures as an
    /// empty contribution so a slow/offline integration cannot block the UI.
    /// </remarks>
    Task<IReadOnlyList<MenuNode>> GetMenuNodes(ButtonTargets target);
}
