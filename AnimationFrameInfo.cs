namespace LoupixDeck.PluginSdk;

/// <summary>
/// Result of a single <see cref="IAnimatedDisplayCommand.RenderAnimatedFrame"/> call.
/// Tells the host whether the plugin drew anything this tick (so the host can skip an unnecessary device
/// push) and whether the animation has finished (one-shot animations freeze on their last frame).
/// </summary>
/// <remarks>
/// Use the factory helpers instead of constructing directly:
/// <list type="bullet">
///   <item><see cref="Skip"/> — nothing changed this tick; leave the button as-is.</item>
///   <item><see cref="Frame"/> — a frame was drawn; the animation continues.</item>
///   <item><see cref="Final"/> — the last frame was drawn; stop ticking and hold it.</item>
/// </list>
/// </remarks>
public readonly struct AnimationFrameInfo
{
    /// <summary>
    /// Monotonic index of the content frame the plugin drew. The host treats this as the
    /// plugin's dirty key: it only pushes the button to the device when this value differs
    /// from the previously pushed one, so returning the same number twice costs no device I/O.
    /// </summary>
    public long FrameNumber { get; }

    /// <summary>
    /// True when the plugin drew a frame this tick; false to leave the button unchanged.
    /// </summary>
    public bool Drawn { get; }

    /// <summary>True when this is the final frame of a one-shot animation. The host stops ticking
    /// the command and keeps the last frame on screen.</summary>
    public bool IsFinal { get; }

    private AnimationFrameInfo(long frameNumber, bool drawn, bool isFinal)
    {
        FrameNumber = frameNumber;
        Drawn = drawn;
        IsFinal = isFinal;
    }

    /// <summary>
    /// Nothing changed this tick — the host leaves the button unchanged.
    /// </summary>
    public static AnimationFrameInfo Skip() => new(0, drawn: false, isFinal: false);

    /// <summary>
    /// A frame numbered <paramref name="frameNumber"/> was drawn; the animation continues.
    /// </summary>
    public static AnimationFrameInfo Frame(long frameNumber) => new(frameNumber, drawn: true, isFinal: false);

    /// <summary>
    /// The final frame (<paramref name="frameNumber"/>) of a one-shot animation was drawn;
    /// the host stops ticking and holds it.
    /// </summary>
    public static AnimationFrameInfo Final(long frameNumber) => new(frameNumber, drawn: true, isFinal: true);
}
