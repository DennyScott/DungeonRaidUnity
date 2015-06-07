using UnityEngine;
using System.Collections;

public class Managers : MonoBehaviour {

	public static GamePieceManager GamePieceManager;
	public static GameBoardManager GameBoardManager;
	public static SelectionManager SelectionManager;
	public static PlayerManager PlayerManager;

	// Use this for initialization
	void Awake () {
		GamePieceManager = GetComponentInChildren<GamePieceManager>();
		GameBoardManager = GetComponentInChildren<GameBoardManager>();
		SelectionManager = GetComponentInChildren<SelectionManager>();
		PlayerManager = GetComponentInChildren<PlayerManager>();
	}
}
