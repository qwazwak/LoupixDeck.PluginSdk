namespace LoupixDeck.PluginSdk;

/// <summary>
/// Identity and versioning information a plugin exposes about itself.
/// </summary>
/// <remarks>
/// The values typically mirror the plugin's <c>plugin.json</c> manifest.
/// </remarks>
public sealed class PluginMetadata
{
    /// <summary>
    /// Stable, filesystem-safe identifier (e.g. <c>obs</c>)
    /// </summary>
    /// <remarks>
    /// Scopes the
    /// plugin's settings directory <c>plugins/&lt;<see cref="id"/>&gt;/</c>.
    /// </remarks>
    public required string Id { get; init; }

    /// <summary>
    /// Human-readable plugin name
    /// </summary>
    /// <remarks>
    /// Used to order plugin groups alphabetically in the command-selection menu.
    /// </remarks>
    public required string Name { get; init; }

    /// <summary>
    /// The plugin's own version.
    /// </summary>
    public required Version Version { get; init; }

    /// <summary>
    /// SDK contract version the plugin was built against.
    /// </summary>
    /// <remarks>
    /// The host loads the plugin only when the major component matches its own SDK.
    /// </remarks>
    public required Version SdkVersion { get; init; }

    public string Author { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Optional icon bytes (PNG/SVG).
    /// Null when the plugin ships none.
    /// </summary>
    public byte[]? Icon { get; init; }
}
