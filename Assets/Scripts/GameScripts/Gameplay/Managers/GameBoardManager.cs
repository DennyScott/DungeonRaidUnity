using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardManager : MonoBehaviour{

	#region Private Variables
	private GameBoardModel model;

	#endregion

	#region Public Variables
	public int rows = 8;
	public int columns = 8;
	public float minWaitTimePerRow = 0.15f;
	public float waitTimePerPiece = 0.05f;
	#endregion

	#region Create Board Methods

	/// <summary>
	/// Creates the board and then beings filling it.
	/// </summary>
	public void CreateBoard() {
		model = new GameBoardModel(rows, columns);
		StartCoroutine("FillBoard");
	}
	#endregion

	#region Coroutines

	/// <summary>
	/// Fills the board with GamePieces.
	/// </summary>
	/// <returns>Coroutine Enumerator</returns>
	IEnumerator FillBoard() {
		for(int y = 0; y < rows; y++) {
			float timeOnRow = 0.0f;
			for(int x = 0; x < columns; x++) {

				if(model.IsEmpty(x, y)) {
					Generators.GamePieceGenerator.CreatePiece(x, y);
					timeOnRow += waitTimePerPiece;
					yield return new WaitForSeconds(waitTimePerPiece);
				}
			}
			if(timeOnRow < minWaitTimePerRow) {
				yield return new WaitForSeconds(minWaitTimePerRow - timeOnRow);
			}
		}

	}
	#endregion
}
