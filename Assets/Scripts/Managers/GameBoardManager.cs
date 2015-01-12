using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardManager : MonoBehaviour{
	private GameBoardModel _gameBoardModel;
	private List<GameObject> gamePieces;

	public int rows = 10;
	public int columns = 5;
	
	GameBoardModel gameBoardModel {
		get {
			return _gameBoardModel;
		}
	}

	void Awake() {
		_gameBoardModel = new GameBoardModel(rows, columns);
		CreateBoardViewPieces();
	}

	void Start() {

	}

	void CreateBoardViewPieces() {
		List<List<GamePieceModel>> board = gameBoardModel.GetBoard();
		foreach (List<GamePieceModel> row in board) {
			foreach (GamePieceModel piece in row) {
				Debug.Log (piece.ToString());
			}
		}
	}


}
