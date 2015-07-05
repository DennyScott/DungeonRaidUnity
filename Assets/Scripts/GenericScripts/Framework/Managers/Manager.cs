
/// <summary>
/// Base Manager. All Managers should inherit from this class.
/// </summary>
public abstract class Manager : AdvMonoBehaviour, iManager {
    public abstract void Initialize();
}
