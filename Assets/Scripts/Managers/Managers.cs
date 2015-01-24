using UnityEngine;
using System.Collections;

public class Managers : MonoBehaviour {

	public static GamePieceManager gamePieceManager;

	public void GetManagers() {
		gamePieceManager = GetComponentInChildren(typeof (GamePieceManager)) as GamePieceManager;
	}
}
