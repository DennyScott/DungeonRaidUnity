using UnityEngine;
using System.Collections;

public class Managers : MonoBehaviour {

	public static GamePieceManager gamePieceManager;
	public static GameBoardManager gameBoardManager;
	public static PlayerManager playerManager;
	public static SelectionManager selectionManager;

	public void GetManagers() {
		gamePieceManager = GetComponentInChildren(typeof (GamePieceManager)) as GamePieceManager;
		gameBoardManager = GetComponentInChildren(typeof (GameBoardManager)) as GameBoardManager;
		playerManager = GetComponentInChildren(typeof (PlayerManager)) as PlayerManager;
		selectionManager = GetComponentInChildren(typeof (SelectionManager)) as SelectionManager;
	}
}
