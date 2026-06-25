namespace LoupixDeck.PluginSdk;

/// <summary>
/// How the host pushes an <see cref="IExclusiveModeProvider"/>'s touch-slot frames
/// to the device.
/// </summary>
/// <remarks>
/// The trade-off is data volume vs. presentation guarantees:
/// <para>
/// the device is bottlenecked by the serial transfer (~259 KB for a full screen),
/// so sending fewer/smaller framebuffers is the main lever for higher frame rates.
/// </para>
/// </remarks>
public enum ExclusiveRenderMode
{
    /// <summary>
    /// Composite every slot into one full-screen framebuffer and issue a DRAW
    /// refresh. (Default)
    /// </summary>
    /// <remarks>
    /// Simplest and safest; best for low-frequency, whole-screen content such as a screensaver.
    /// </remarks>
    FullScreen = 0,

    /// <summary>
    /// Draw every slot as its own 90x90 tile (one framebuffer per tile, no DRAW
    /// refresh).
    /// </summary>
    /// <remarks>
    /// Use for full-grid content that updates frequently.
    /// </remarks>
    Grid = 1,

    /// <summary>
    /// Like <see cref="Grid"/>, but the host re-sends only the tiles whose visible
    /// content changed since the previous frame.
    /// </summary>
    /// <remarks>
    /// Optimal for per-tile live data where just a few
    /// tiles change each frame (telemetry HUDs, dashboards).
    /// </remarks>
    DirtyTiles = 2,

    /// <summary>
    /// Draw a single 90x90 slot (see <see cref="IExclusiveModeProvider.SingleTileSlot"/>),
    /// framebuffer only, no DRAW refresh.
    /// </summary>
    /// <remarks>
    /// Mirrors streaming a GIF/video onto one button.
    /// </remarks>
    SingleTile = 3
}
