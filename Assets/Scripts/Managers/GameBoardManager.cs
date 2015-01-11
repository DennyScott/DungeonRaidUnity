using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardManager : MonoBehaviour{
    public int rows = 10;
    public int columns = 5;
	GameBoardController gameBoardController;

    void Start() {
        gameBoardController = new GameBoardController(rows, columns);
    }
}
