using UnityEngine;

public class GamePiece : Grunt {

	#region Auto Properties
	public int Row { get; set; }

	public int Column { get; set; }

	#endregion

	#region Events
	public System.Action<GameObject> OnClickDown;
	public System.Action<GameObject> OnClickUp;
	public System.Action<GameObject> OnMouseEnterPiece;
	public System.Action<GameObject> OnMouseExitPiece;
	public System.Action<GameObject> OnRemovePiece;
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
