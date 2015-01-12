using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardManager : MonoBehaviour{
	GameBoardController gameBoardController;

	void Awake() {
		gameBoardController = new GameBoardController();
	}

	void Start() {
//		gameBoardController.CheckForMatch();
	}
}
