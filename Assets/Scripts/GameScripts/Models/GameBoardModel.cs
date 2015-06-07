using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardModel {
	#region Public Variables
	//A List of a list of slots that will make up the gameboard
	public List<List<Slot>> GameBoard;
	#endregion

	#region Constructors

	/// <summary>
	/// Initializes a new instance of the <see cref="GameBoardModel"/> class.
	/// </summary>
	/// <param name="rows">Number of rows in the GameBoard.</param>
	/// <param name="columns">Number of Columns in the GameBoard.</param>
	public GameBoardModel(int rows, int columns) {
		CreateBoard(rows, columns);
	}

	#endregion

	#region Private Methods
	/// <summary>
	/// Create Board. Iterate through total rows, and create a new
	/// row for each position.
	/// </summary>
	/// <param name="rows">Total amount of rows</param>
	/// <param name="columns">Total amount of columns</param>
	private void CreateBoard(int rows, int columns) {
		GameBoard = new List<List<Slot>>();
		for (var i = 0; i < rows; i++) {
			CreateRow(columns, i);
		}
	}

	/// <summary>
	/// Create Row. Iterate through size of row, and add
	/// a new slot for each spot.
	/// </summary>
	/// <param name="size">Total size of the row</param>
	/// <param name="row">Current row</param>
	private void CreateRow(int size, int row) {
		var newRow = new List<Slot>();
		for (var n = 0; n < size; n++) {
			newRow.Add(new Slot(row, n));
		}
		GameBoard.Add(newRow);
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
		return GameBoard[x][y].IsEmpty();
	}

	#endregion

}
