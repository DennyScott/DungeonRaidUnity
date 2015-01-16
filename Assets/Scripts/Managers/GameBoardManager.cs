using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardManager : MonoBehaviour{
	private GameBoardModel _gameBoardModel;
	private List<GameObject> gamePieces;
	private GamePieceManager manager;

	public int rows = 10;
	public int columns = 5;
	
	GameBoardModel gameBoardModel {
		get {
			return _gameBoardModel;
		}
	}

	void Awake() {
		manager = gameObject.GetComponent<GamePieceManager>();
		_gameBoardModel = new GameBoardModel(rows, columns);
	}

	void Start() {
		CreateBoardViewPieces();
	}
	
	void CreateBoardViewPieces() {
		Debug.Log (_gameBoardModel.Count);
		List<List<GamePieceModel>> board = gameBoardModel.GetBoard();
		foreach (List<GamePieceModel> row in board) {
			foreach (GamePieceModel piece in row) {
				Debug.Log(piece.ToString());
				manager.CreateGamePeice(0, 0);
			}
		}
	}


}
