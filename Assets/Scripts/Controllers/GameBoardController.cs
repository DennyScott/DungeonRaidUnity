using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardController : IGameBoardController {

	public bool CheckForMatch(GamePieceModel from, GamePieceModel to) {
		return false;
	}
	
	public List<GamePieceModel> FillGameBoard() {
		return new List<GamePieceModel>();
	}
	
	public void ChangeTypeToType(GamePieceModel fromType, GamePieceModel toType) {
		
	}
	
	public void RemoveType(GamePieceModel type) {
		
	}

}
