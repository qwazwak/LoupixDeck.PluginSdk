namespace LoupixDeck.PluginSdk;

/// <summary>
/// A lightweight reference to a command and its parameter values, used as the
/// value of a <see cref="MenuNode.RotaryGroup"/> mapping. Mirrors the
/// <see cref="MenuNode.CommandName"/> + <see cref="MenuNode.Parameters"/> shape
/// of a normal menu leaf; the host bakes these into the same command string it
/// would build for that leaf.
/// </summary>
public sealed class MenuCommandRef
{
    /// <summary>The command this reference invokes.</summary>
    public required string CommandName { get; init; }

    /// <summary>Parameter values to bake into the built command string.</summary>
    public IReadOnlyDictionary<string, string> Parameters { get; init; }
        = new Dictionary<string, string>();
}
