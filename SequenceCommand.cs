namespace LoupixDeck.PluginSdk;

/// <summary>
/// One command of a button's &amp;&amp;-joined sequence: its name and the positional
/// parameters parsed from its parentheses. Exposed via
/// <see cref="CommandContext.SequenceCommands"/> so a display command can compose a
/// layout from the sibling commands sharing its button.
/// </summary>
public sealed record SequenceCommand(string Name, string[] Parameters);
