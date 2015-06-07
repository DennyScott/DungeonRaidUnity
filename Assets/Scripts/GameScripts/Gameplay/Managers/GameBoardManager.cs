using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardManager : Manager{

	#region Private Variables
	private GameBoardModel _model;
	private GamePieceGenerator _gamePieceGenerator;
	#endregion

	#region Public Variables
	public GameObject GamePieceManager;
	public int Rows = 8;
	public int Columns = 8;
	public float MinWaitTimePerRow = 0.15f;
	public float WaitTimePerPiece = 0.05f;
	#endregion

	#region Standard Methods
	void Awake() {
		_gamePieceGenerator = GamePieceManager.GetComponent<GamePieceGenerator>();
	}

	void Start() {
		CreateBoard();
	}
	#endregion

	#region Create Board Methods

	/// <summary>
	/// Creates the board and then beings filling it.
	/// </summary>
	public void CreateBoard() {
		_model = new GameBoardModel(Rows, Columns);
		StartCoroutine(FillBoard());
	}
	#endregion

	#region Coroutines

	/// <summary>
	/// Fills the board with GamePieces.
	/// </summary>
	/// <returns>Coroutine Enumerator</returns>
	IEnumerator FillBoard() {
		yield return new WaitForSeconds(1.0f);
		for(var y = 0; y < Rows; y++) {
			var timeOnRow = 0.0f;
			for(var x = 0; x < Columns; x++) {
				if (!_model.IsEmpty(x, y)) {
					continue;
				}
				_gamePieceGenerator.CreatePiece(x, y);
				timeOnRow += WaitTimePerPiece;
				yield return new WaitForSeconds(WaitTimePerPiece);
			}
			if(timeOnRow < MinWaitTimePerRow) {
				yield return new WaitForSeconds(MinWaitTimePerRow - timeOnRow);
			}
		}

	}
	#endregion
}
