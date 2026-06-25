namespace LoupixDeck.PluginSdk;

/// <summary>
/// Convenience base for <see cref="IFolderProvider"/> implementations — handles
/// the <see cref="EntriesChanged"/> plumbing and supplies an empty default for
/// <see cref="RotaryOverrides"/>.
/// </summary>
public abstract class FolderProviderBase : IFolderProvider
{
    private static readonly IReadOnlyDictionary<int, RotaryOverride> EmptyOverrides =
        new Dictionary<int, RotaryOverride>();

    /// <inheritdoc />
    public abstract string Title { get; }

    /// <inheritdoc />
    public abstract IReadOnlyList<FolderEntry> BuildEntries();

    /// <inheritdoc />
    public virtual IReadOnlyDictionary<int, RotaryOverride> RotaryOverrides => EmptyOverrides;

    /// <inheritdoc />
    public virtual void OnEnter() { }

    /// <inheritdoc />
    public virtual void OnExit() { }

    /// <inheritdoc />
    public event Action? EntriesChanged;

    /// <inheritdoc />
    protected void RaiseEntriesChanged() => EntriesChanged?.Invoke();
}
