using UnityEngine;

public class GamePiece : Grunt {

	public int Row { get; set; }

	public int Column { get; set; }



	#region Delegates
	public delegate void GamePieceEvent(GameObject g);

	#endregion

	#region Events
	public event GamePieceEvent OnClickDown;
	public event GamePieceEvent OnClickUp;
	public event GamePieceEvent OnMouseEnterPiece;
	public event GamePieceEvent OnMouseExitPiece;
	public event GamePieceEvent OnRemovePiece;
	#endregion

	#region Public Methods
	/// <summary>
	/// 	Used to remove a piece from the gameboard
	/// </summary>
	public void RemovePiece() {
		TriggerOnRemovePiece();
		Destroy(gameObject);
	}

	#endregion

	void TriggerOnRemovePiece() {
		if (OnRemovePiece != null) {
			OnRemovePiece(gameObject);
		}
	}
}
