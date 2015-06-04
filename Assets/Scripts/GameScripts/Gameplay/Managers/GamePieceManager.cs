using UnityEngine;
using System.Collections.Generic;

public class GamePieceManager : Manager {

	#region Private Variables
	//List of object currently moving
	private List<GameObject> movingObjects = new List<GameObject>();
	
	#endregion

	#region Events
	public System.Action<GameObject> OnClickDown;
	public System.Action<GameObject> OnClickUp;
	public System.Action<GameObject> OnMouseEnterPiece;
	public System.Action<GameObject> OnMouseExitPiece;
	public System.Action<GameObject> OnGamePieceStartMove;
	public System.Action<GameObject> OnGamePieceStopMove;
	public System.Action<GameObject> OnRemovePiece;
	public System.Action OnPiecesMoving;
	public System.Action OnPiecesStopped;

	#endregion

	#region Event And Manager Registration
	/// <summary>
	/// Registers all the event handlers for each piece.
	/// </summary>
	/// <param name="piece">Game Piece to Register</param>
	public void RegisterPiece(GameObject piece) {
		var gamePiece = piece.GetComponent<GamePiece>();
		var gpMovement = piece.GetComponent<GamePieceMovement>();
		gamePiece.OnClickDown += HandleOnClickDown;
		gamePiece.OnClickUp += HandleOnClickUp;
		gamePiece.OnMouseEnterPiece += HandleOnMouseEnterPiece;
		gpMovement.OnGamePieceStartMove += HandleOnGamePieceStartMove;
		gpMovement.OnGamePieceStopMove += HandleOnGamePieceStopMove;
		gamePiece.OnRemovePiece += HandleOnRemovePiece;
	}

	public void UnRegisterPiece(GameObject piece) {
		var gamePiece = piece.GetComponent<GamePiece>();
		var gpMovement = piece.GetComponent<GamePieceMovement>();
		gamePiece.OnClickDown -= HandleOnClickDown;
		gamePiece.OnClickUp -= HandleOnClickUp;
		gamePiece.OnMouseEnterPiece -= HandleOnMouseEnterPiece;
		gpMovement.OnGamePieceStartMove -= HandleOnGamePieceStartMove;
		gpMovement.OnGamePieceStopMove -= HandleOnGamePieceStopMove;
		gamePiece.OnRemovePiece -= HandleOnRemovePiece;
	}

	#endregion

	#region Event Handlers
	void HandleOnRemovePiece (GameObject g) {
		UnRegisterPiece(g);
		if(OnRemovePiece != null)
			OnRemovePiece(g);
	}

	/// <summary>
	/// Handles the on stop lerp event.
	/// </summary>
	/// <param name="g">The gameObject that has just stopped lerping.</param>
	void HandleOnGamePieceStopMove(GameObject g) {
		movingObjects.Remove(g);
		if(movingObjects.Count == 0 && OnPiecesStopped != null) {
			OnPiecesStopped();
		}
	}

	/// <summary>
	/// Handles the on start lerp event.
	/// </summary>
	/// <param name="g">The gameObject that has just started lerping.</param>
	void HandleOnGamePieceStartMove(GameObject g) {
		movingObjects.Add(g);
		if(OnGamePieceStartMove != null) {
			OnGamePieceStartMove(g);
		}

		if(OnPiecesMoving != null) {
			OnPiecesMoving();
		}
	}

	/// <summary>
	/// Handles the on mouse enter piece event.
	/// </summary>
	/// <param name="g">The Game Piece that just had the mouse enter it</param>
	void HandleOnMouseEnterPiece (GameObject g){
		if(OnMouseEnterPiece != null) {
			OnMouseEnterPiece(g);
		}
	}

	/// <summary>
	/// Handles the on click down event.
	/// </summary>
	/// <param name="g">The Game Piece that was just clicked down upon</param>
	void HandleOnClickDown (GameObject g){
		if(OnClickDown != null) {
			OnClickDown(g);
		}	
	}

	/// <summary>
	/// Handles the on click up.
	/// </summary>
	/// <param name="g">The Game Piece that was being hovered over when the mouse click went up.</param>
	void HandleOnClickUp (GameObject g){
		if(OnClickUp != null) {
			OnClickUp(g);
		}	
	}

	#endregion

	#region GamePiece Movement
	/// <summary>
	/// Moves the piece to the desginated x y.
	/// </summary>
	/// <param name="piece">The gamepiece to begin moving</param>
	/// <param name="x">The x coordinate to start at.</param>
	/// <param name="y">The y coordinate to start at.</param>
	/// <param name="positionX">The x position to end at</param>
	/// <param name="positionY">The y position to end at</param>
	public static void MovePiece(GameObject piece, int x, int y, float positionX, float positionY) {
		var gamePiece = piece.GetComponent<GamePiece>();
		var gpMovement = piece.GetComponent<GamePieceMovement>();
		gamePiece.Row = x;
		gamePiece.Column = y;
		gpMovement.StartLerp(new Vector3(positionX, positionY, 0.0f));
	}

	#endregion
}
