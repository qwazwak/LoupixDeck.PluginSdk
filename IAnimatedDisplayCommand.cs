namespace LoupixDeck.PluginSdk;

/// <summary>
/// Timing snapshot handed to <see cref="IAnimatedDisplayCommand.RenderAnimatedFrame"/> for one
/// frame. Mirrors the host's internal animation render context (minus host-only types) so a plugin
/// can animate against wall-clock time rather than counting ticks: drive the visual from
/// <see cref="Elapsed"/> so playback stays correct even when the host clamps the effective rate.
/// </summary>
public readonly struct AnimationFrameContext
{
    /// <summary>Zero-based frame counter since the host started ticking this command.</summary>
    public long FrameNumber { get; init; }

    /// <summary>Total time elapsed since the host started ticking this command.</summary>
    public TimeSpan Elapsed { get; init; }

    /// <summary>Wall-clock time since the previous frame.</summary>
    public TimeSpan Delta { get; init; }

    /// <summary>The rate the host is actually ticking at (after clamping to its global limit).</summary>
    public int EffectiveFps { get; init; }
}

/// <summary>
/// A plugin command that draws an animated touch button onto a host-provided
/// <see cref="IRenderCanvas"/> (90×90), driven by the host's central animation scheduler at
/// <see cref="TargetFps"/> instead of the fixed polling interval used by
/// <see cref="IDisplayImageCommand"/>. Set <see cref="IPluginCommand.SupportedTargets"/> to
/// <see cref="ButtonTargets.TouchButton"/>.
///
/// Backward compatibility: this is an independent, optional interface. A command that only needs a
/// slow periodic redraw should keep implementing <see cref="IDisplayImageCommand"/>; implement this
/// one only for genuine animation. A command may implement both — the host prefers the animated
/// path. Existing plugins are unaffected.
/// </summary>
public interface IAnimatedDisplayCommand : IPluginCommand
{
    /// <summary>
    /// Desired frame rate. The host clamps this to its global animation FPS limit, so the
    /// effective rate may be lower; read <see cref="AnimationFrameContext.EffectiveFps"/> for the
    /// actual rate. A value &lt;= 0 means "use the host's default limit".
    /// </summary>
    int TargetFps { get; }

    /// <summary>
    /// Draws the current animation frame onto <paramref name="canvas"/>. Called off the UI thread
    /// at up to <see cref="TargetFps"/>; must be fast and synchronous (do network/decoding work
    /// asynchronously in <see cref="LoupixPlugin.Initialize"/> and cache it). Return
    /// <see cref="AnimationFrameInfo.Skip"/> when nothing changed (no device push), or
    /// <see cref="AnimationFrameInfo.Frame"/> / <see cref="AnimationFrameInfo.Final"/> with a
    /// monotonic frame number the host uses to dirty-check the push.
    /// </summary>
    AnimationFrameInfo RenderAnimatedFrame(CommandContext ctx, IRenderCanvas canvas, AnimationFrameContext frame);
}
