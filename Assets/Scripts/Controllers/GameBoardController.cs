using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardController : IGameBoardController {
	GameBoardModel _gameBoardModel;

	GameBoardModel gameBoardModel {
		get {
			return _gameBoardModel;
		}
	}

	public GameBoardController(int rows, int columns) {
		_gameBoardModel = new GameBoardModel(rows, columns);
	}

	public bool CheckForMatch(GamePieceModel from, GamePieceModel to) {
		return false;
	}

	public void ChangeTypeToType(GamePieceModel fromType, GamePieceModel toType) {
		
	}
	
	public void RemoveType(GamePieceModel type) {
		
	}
	
	public void FillGameBoard() {

	}

	public void ClearGameBoard() {

	}

	public bool IsGameBoardEmpty() {
		return false;
	}

	public bool IsGameBoardFull() {
		return false;
	}

}
