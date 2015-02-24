using UnityEngine;
using System.Collections;

public class Managers : MonoBehaviour {

	#region Public Variables
	public static GamePieceManager gamePieceManager;
	public static GameBoardManager gameBoardManager;
	public static PlayerManager playerManager;
	public static SelectionManager selectionManager;

	#endregion

	#region Get Managers

	/// <summary>
	/// Gets the managers of the scene.
	/// </summary>
	public void GetManagers() {
		gamePieceManager = GetComponentInChildren(typeof (GamePieceManager)) as GamePieceManager;
		gameBoardManager = GetComponentInChildren(typeof (GameBoardManager)) as GameBoardManager;
		playerManager = GetComponentInChildren(typeof (PlayerManager)) as PlayerManager;
		selectionManager = GetComponentInChildren(typeof (SelectionManager)) as SelectionManager;
	}
	#endregion
}
