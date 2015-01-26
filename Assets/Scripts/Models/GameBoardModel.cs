using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardModel {
	public List<List<Slot>> gameBoard;

	public GameBoardModel(int rows, int columns) {
		gameBoard = new List<List<Slot>>();
		for(int i = 0; i < rows; i++) {
			List<Slot> newRow = new List<Slot>();
			for(int n = 0; n < columns; n++) {
				newRow.Add(new Slot(i, n));
			}
			gameBoard.Add (newRow);
		}
	}

	public bool IsEmpty(int x, int y) {
		return gameBoard[x][y].IsEmpty();
	}
	
}
