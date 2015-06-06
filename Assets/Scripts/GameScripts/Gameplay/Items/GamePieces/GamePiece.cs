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

	/// <summary>
	/// Raises the mouse down event, and emits the OnClickDown event.
	/// </summary>
	void OnMouseDown() {
		if (OnClickDown != null) {
			OnClickDown(gameObject);
		}
	}

	/// <summary>
	/// Raises the mouse up event and emits the OnClickUp event.
	/// </summary>
	void OnMouseUp() {
		if (OnClickUp != null) {
			OnClickUp(gameObject);
		}
	}

	/// <summary>
	/// Raises the mouse enter event, and emits the OnMouseEnterPiece event.
	/// </summary>
	void OnMouseEnter() {
		if (OnMouseEnterPiece != null) {
			OnMouseEnterPiece(gameObject);
		}
	}

	/// <summary>
	/// Raises the mouse exit event, and emits the OnMouseExitPiece event.
	/// </summary>
	void OnMouseExit() {
		if (OnMouseExitPiece != null) {
			OnMouseExitPiece(gameObject);
		}
	}
}
