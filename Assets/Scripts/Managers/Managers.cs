using UnityEngine;
using System.Collections;

public class Managers : MonoBehaviour {

	public static GamePieceManager gamePieceManager;
	public static GameBoardManager gameBoardManager;

	public void GetManagers() {
		gamePieceManager = GetComponentInChildren(typeof (GamePieceManager)) as GamePieceManager;
		gameBoardManager = GetComponentInChildren(typeof (GameBoardManager)) as GameBoardManager;
	}
}
