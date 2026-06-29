namespace LoupixDeck.PluginSdk;

/// <summary>
/// A node in a dynamically built command submenu (e.g. one OBS scene, one
/// CoolerControl mode, one sensor). A node is either a folder (has
/// <see cref="Children"/>, no <see cref="CommandName"/>), a leaf that produces a
/// command (has <see cref="CommandName"/>), or a rotary command group (has
/// <see cref="RotaryGroup"/>).
/// </summary>
public sealed class MenuNode
{
    /// <summary>Label shown in the menu tree.</summary>
    public required string Name { get; init; }

    /// <summary>Command this leaf builds, or null when the node is a folder.</summary>
    public string? CommandName { get; init; }

    /// <summary>Parameter values to bake into the built command string.</summary>
    public IReadOnlyDictionary<string, string> Parameters { get; init; }
        = new Dictionary<string, string>();

    /// <summary>Child nodes when this node is a folder.</summary>
    public IReadOnlyList<MenuNode> Children { get; init; } = [];

    /// <summary>
    /// When set, this node is a rotary command group: an assignment helper that
    /// fills several rotary slots at once. The host applies each
    /// <see cref="RotaryAction"/>'s command to the matching slot of the selected
    /// rotary encoder (counter-clockwise → left, clockwise → right, press →
    /// press); actions omitted from the map leave their slot untouched. A group
    /// node has no <see cref="CommandName"/> or <see cref="Children"/>. Plugins
    /// should emit it only for the <see cref="ButtonTargets.RotaryEncoder"/>
    /// target — the individual commands stay available for separate assignment.
    /// </summary>
    public IReadOnlyDictionary<RotaryAction, MenuCommandRef>? RotaryGroup { get; init; }
}
