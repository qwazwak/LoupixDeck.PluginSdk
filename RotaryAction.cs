namespace LoupixDeck.PluginSdk;

/// <summary>
/// A discrete action of a rotary encoder. Used as the key of a
/// <see cref="MenuNode.RotaryGroup"/> mapping so a plugin can bind a set of
/// related commands to a rotary's three slots in one assignment.
/// </summary>
public enum RotaryAction
{
    /// <summary>Counter-clockwise turn (left). Maps to the rotary's left slot.</summary>
    CounterClockwise,

    /// <summary>Clockwise turn (right). Maps to the rotary's right slot.</summary>
    Clockwise,

    /// <summary>Knob press. Maps to the rotary's press slot.</summary>
    Press
}
