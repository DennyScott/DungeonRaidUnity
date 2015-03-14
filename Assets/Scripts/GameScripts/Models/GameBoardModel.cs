using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardModel {
	#region Public Variables
	//A List of a list of slots that will make up the gameboard
	public List<List<Slot>> gameBoard;
	#endregion

	#region Constructors

	/// <summary>
	/// Initializes a new instance of the <see cref="GameBoardModel"/> class.
	/// </summary>
	/// <param name="rows">Number of rows in the GameBoard.</param>
	/// <param name="columns">Number of Columns in the GameBoard.</param>
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

	#endregion

	#region Game Board Flags

	/// <summary>
	/// Determines whether this the Slot at the given x y coordinate is empty
	/// </summary>
	/// <returns><c>true</c> if the slot is empty at the specified x y coordinate; otherwise, <c>false</c>.</returns>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public bool IsEmpty(int x, int y) {
		return gameBoard[x][y].IsEmpty();
	}

	#endregion
	
}
