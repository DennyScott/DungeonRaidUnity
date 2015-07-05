using UnityEngine;

public class Managers : MonoBehaviour {

	public static GamePieceManager GamePieceManager { get; private set; }
    public static GameBoardManager GameBoardManager { get; private set; }
    public static SelectionManager SelectionManager { get; private set; }
    public static PlayerManager PlayerManager { get; private set; }

    /// <summary>
    /// Gets all managers and assigns them to the correct property
    /// </summary>
    public void CollectManagers() {
        GamePieceManager = GetComponentInChildren<GamePieceManager>();
        GameBoardManager = GetComponentInChildren<GameBoardManager>();
        SelectionManager = GetComponentInChildren<SelectionManager>();
        PlayerManager = GetComponentInChildren<PlayerManager>();
    }

    public void InitializeManagers() {
        GamePieceManager.Initialize();
        GameBoardManager.Initialize();
        SelectionManager.Initialize();
        PlayerManager.Initialize();
    }
}
