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

	public GameBoardController() {
		_gameBoardModel = new GameBoardModel();
	}

	public bool CheckForMatch(GamePieceModel from, GamePieceModel to) {
		if(from.GetType() == to.GetType()){
			return true;
		}
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
