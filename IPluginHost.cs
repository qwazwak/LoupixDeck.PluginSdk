namespace LoupixDeck.PluginSdk;

/// <summary>
/// The single, stable bridge from a plugin back into the LoupixDeck core.
/// </summary>
/// <remarks>
/// An instance is handed to each plugin in <see cref="LoupixPlugin.Initialize"/>.
/// Keeping all host interaction behind this interface keeps the plugin/core coupling narrow.
/// </remarks>
public interface IPluginHost
{
    /// <summary>
    /// Log sink scoped to the owning plugin.
    /// </summary>
    IPluginLogger Logger { get; }

    /// <summary>
    /// Isolated settings store for the owning plugin.
    /// </summary>
    IPluginSettings Settings { get; }

    /// <summary>
    /// The device currently driven by the host, or null if none.
    /// </summary>
    DeviceInfo? ActiveDevice { get; }

    /// <summary>
    /// Requests a re-render of touch buttons bound to the given command name (used by display commands after data changes).
    /// </summary>
    void RequestButtonRefresh(string commandName);

    /// <summary>
    /// Executes a command string through the host's command pipeline,
    /// enabling command chaining across plugin boundaries.
    /// </summary>
    void ExecuteCommand(string command);

    /// <summary>
    /// Opens a folder navigation view on the touch screen.
    /// </summary>
    void OpenFolder(IFolderProvider provider);

    /// <summary>
    /// Opens <paramref name="url"/> in the user's default browser.
    /// </summary>
    /// <returns><see href="true"/> if the launch was dispatched</returns>
    /// <remarks>
    /// The host abstracts OS specifics (Windows: shell-execute, Linux: xdg-open)
    /// so OAuth and similar flows don't need per-plugin platform branches.
    /// </remarks>
    bool OpenBrowser(string url);

    /// <summary>
    /// Temporarily paints <paramref name="text"/> on the touch slot at
    /// <paramref name="slot"/>, restoring the slot's normal content after
    /// <paramref name="duration"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A later call to this method on the same slot supersedes any
    /// pending restore: use it for transient feedback
    /// like volume changes or playback skips without dedicating a button.
    /// </para>
    /// Fires and forgets; the host does the timing.
    /// </remarks>
    void OverlayTouchText(int slot, string text, TimeSpan duration);

    /// <summary>
    /// Returns the touch slot that visually sits next to the rotary encoder at
    /// <paramref name="rotaryIndex"/>.
    /// </summary>
    /// <returns>
    /// The touch slot index adjacent to the rotary encoder,
    /// or -1 if the active device has no such neighbour.
    /// </returns>
    /// <remarks>
    /// Use this together with <see cref="OverlayTouchText"/> to flash a value (e.g. "75 %") on the
    /// slot adjacent to the rotary that fired the command, without having to
    /// hard-code per-device geometry in the plugin.
    /// </remarks>
    int GetTouchSlotForRotary(int rotaryIndex);

    /// <summary>
    /// Asks the host to put the active device into exclusive mode driven by
    /// <paramref name="provider"/>.
    /// </summary>
    /// <returns>
    /// <see langword="false"/> if another provider already owns the device (no stealing).
    /// The host calls <see cref="IExclusiveModeProvider.OnEnter"/> before returning <see langword="true"/>.
    /// </returns>
    bool RequestExclusiveMode(IExclusiveModeProvider provider);

    /// <summary>
    /// Releases exclusive mode.
    /// </summary>
    /// <remarks>
    /// The provider parameter must match the currently active provider; otherwise the call is a no-op.
    /// The host calls <see cref="IExclusiveModeProvider.OnExit"/> and restores the normal page.
    /// </remarks>
    void ReleaseExclusiveMode(IExclusiveModeProvider provider);

    /// <summary>
    /// True while a provider currently owns the active device.
    /// </summary>
    bool IsInExclusiveMode { get; }
}
