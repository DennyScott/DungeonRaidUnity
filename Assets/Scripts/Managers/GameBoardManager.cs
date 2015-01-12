using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardManager : MonoBehaviour{
	GameBoardController gameBoardController;
	public int rows = 10;
	public int columns = 5;

	void Awake() {
		gameBoardController = new GameBoardController(rows, columns);
	}

	void Start() {
//		gameBoardController.CheckForMatch();
	}
}
