using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardController : IGameBoardController {
	GameBoardModel gameBoardModel;

	public GameBoardController() {
		gameBoardModel = new GameBoardModel();
	}

	public bool CheckForMatch(GamePieceModel from, GamePieceModel to) {
		return false;
	}
	
	public void FillGameBoard() {

	}
	
	public void ChangeTypeToType(GamePieceModel fromType, GamePieceModel toType) {
		
	}
	
	public void RemoveType(GamePieceModel type) {
		
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
