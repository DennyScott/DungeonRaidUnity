using UnityEngine;
using System.Collections;

public class Managers : MonoBehaviour {

	public static GamePieceManager gamePieceManager;
	public static GameBoardManager gameBoardManager;
	public static PlayerManager playerManager;
	public static LevelManager levelManager;

	public void GetManagers() {
		gamePieceManager = GetComponentInChildren(typeof (GamePieceManager)) as GamePieceManager;
		gameBoardManager = GetComponentInChildren(typeof (GameBoardManager)) as GameBoardManager;
		playerManager = GetComponentInChildren(typeof (PlayerManager)) as PlayerManager;
		levelManager = GetComponentInChildren(typeof (LevelManager)) as LevelManager;
	}
}
