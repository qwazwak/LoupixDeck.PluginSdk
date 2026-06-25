namespace LoupixDeck.PluginSdk;

/// <summary>
/// A single user-assignable action contributed by a plugin.
/// </summary>
/// <remarks>
/// Replaces the core's <c>IExecutableCommand</c> + <c>[CommandAttribute]</c>\
/// with an explicit and reflection-free declaration.
/// </remarks>
public interface IPluginCommand
{
    /// <summary>
    /// Describes the command for the selection menu and command builder.
    /// </summary>
    CommandDescriptor Descriptor { get; }

    /// <summary>
    /// Button types this command may be assigned to.
    /// </summary>
    ButtonTargets SupportedTargets { get; }

    /// <summary>
    /// Performs the action.
    /// </summary>
    Task Execute(CommandContext ctx);
}
