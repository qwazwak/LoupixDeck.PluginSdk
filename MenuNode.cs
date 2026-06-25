namespace LoupixDeck.PluginSdk;

/// <summary>
/// A node in a dynamically built command submenu (e.g. one OBS scene, one
/// CoolerControl mode, one sensor).
/// </summary>
/// <remarks>
/// A node is exactly one of:
/// <list type="bullet">
///   <item>
///     <term>A Folder</term>
///     <description>
///       Has <see cref="Children"/> and no <see cref="CommandName"/>.
///       The host renders it as a submenu.
///     </description>
///   </item>
///   <item>
///     <term>A Leaf</term>
///     <description>
///       Procuces a command when selected.
///       Has <see cref="CommandName"/> and optionally <see cref="Parameters"/>.
///     </description>
///   </item>
/// </list>
/// </remarks>
public sealed class MenuNode
{
    /// <summary>
    /// Label shown in the menu tree.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Command this leaf builds, or null when the node is a folder.
    /// </summary>
    public string? CommandName { get; init; }

    /// <summary>
    /// Parameter values to bake into the built command string.
    /// </summary>
    public IReadOnlyDictionary<string, string> Parameters { get; init; }
        = new Dictionary<string, string>();

    /// <summary>
    /// Child nodes when this node is a folder.
    /// </summary>
    public IReadOnlyList<MenuNode> Children { get; init; } = [];
}
