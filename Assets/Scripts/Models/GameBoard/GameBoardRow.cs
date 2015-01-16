using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardRow {

	public List<GameBoardSlot> row;

	public List<GamePieceModel> GetRowPeices() {
		var returnBoard = new List<GamePieceModel>();
		for (int i = 0; i < row.Count; i++) {
			returnBoard.Add(row[i].gamePiece); 
		}
		return returnBoard; 
	}

	public int Count {
		get {
			return row.Count;
		}
	}

	public GameBoardSlot GetSlot(int index) {
		return row[index];
	}

	public bool IsEmpty() {
		if(row.Count < 1) {
			return true;
		}
		return false;
	}
}
