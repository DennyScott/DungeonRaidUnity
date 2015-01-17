using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardRow {

	public GameBoardRow(int maxColumns) {

	}

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

	public int GamePieceCount {
		get {
			int count = 0;
			for(int i = 0; i < row.Count; i++) {
				if (row[i] != null) {
					count++;
				}
			}

			return count;
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

	public GamePieceModel GetGameBoardPiece(int index) {
		return row[index].gamePiece;
	}


}
