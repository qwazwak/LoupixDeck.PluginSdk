namespace LoupixDeck.PluginSdk;

/// <summary>
/// The single, stable bridge from a plugin back into the LoupixDeck core. An
/// instance is handed to each plugin in <see cref="LoupixPlugin.Initialize"/>.
/// Keeping all host interaction behind this interface keeps the plugin/core
/// coupling narrow.
/// </summary>
public interface IPluginHost
{
    /// <summary>Log sink scoped to the owning plugin.</summary>
    IPluginLogger Logger { get; }

    /// <summary>Isolated settings store for the owning plugin.</summary>
    IPluginSettings Settings { get; }

    /// <summary>The device currently driven by the host, or null if none.</summary>
    DeviceInfo? ActiveDevice { get; }

    /// <summary>Requests a re-render of touch buttons bound to the given
    /// command name (used by display commands after data changes).</summary>
    void RequestButtonRefresh(string commandName);

    /// <summary>Executes a command string through the host's command pipeline,
    /// enabling command chaining across plugin boundaries.</summary>
    void ExecuteCommand(string command);

    /// <summary>Opens a folder navigation view on the touch screen.</summary>
    void OpenFolder(IFolderProvider provider);
}
