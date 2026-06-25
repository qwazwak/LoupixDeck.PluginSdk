namespace LoupixDeck.PluginSdk;

/// <summary>
/// Everything a command needs at execution time.
/// </summary>
/// <remarks>
/// Wraps the positional parameters parsed from the persisted <c>CommandName(arg1,arg2)</c> string,
/// the button type that triggered the command and the host bridge.
/// </remarks>
public sealed class CommandContext
{
    /// <summary>
    /// Positional parameters, exactly as parsed from the command string's parentheses.
    /// </summary>
    /// <remarks>
    /// Never <see langword="null"/>; empty when the command takes none.
    /// </remarks>
    public required string[] Parameters { get; init; }

    /// <summary>
    /// The button type the command was invoked from.
    /// </summary>
    public required ButtonTargets Target { get; init; }

    /// <summary>
    /// Identifier of the originating control (rotary index, touch slot, simple
    /// button index) when <see cref="Target"/> denotes an indexed source.
    /// <see langword="null"/> when invoked from chained commands or CLI.
    /// </summary>
    public int? SourceIndex { get; init; }

    /// <summary>
    /// The active device, or <see langword="null"/> if none.
    /// </summary>
    public DeviceInfo? Device { get; init; }

    /// <summary>
    /// The host bridge of the owning plugin.
    /// </summary>
    public required IPluginHost Host { get; init; }
}
