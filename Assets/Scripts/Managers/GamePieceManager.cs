using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePieceManager : MonoBehaviour {
	public delegate void GamePieceEvent(GameObject g);
	public delegate void MovementEvent();

	public event GamePieceEvent OnClickDown;
	public event GamePieceEvent OnClickUp;
	public event GamePieceEvent OnMouseEnterPiece;
	public event GamePieceEvent OnMouseExitPiece;
	public event GamePieceEvent OnStartLerp;
	public event GamePieceEvent OnStopLerp;
	public event MovementEvent OnPiecesMoving;
	public event MovementEvent OnPiecesStopped;

	private List<GameObject> movingObjects = new List<GameObject>();


	void Start() {
		RegisterManagers();

	}

	void RegisterManagers() {

	}

	public void RegisterPiece(GameObject piece) {
		GamePiece gamePiece = piece.GetComponent(typeof (GamePiece)) as GamePiece;
		gamePiece.OnClickDown += HandleOnClickDown;
		gamePiece.OnClickUp += HandleOnClickUp;
		gamePiece.OnMouseEnterPiece += HandleOnMouseEnterPiece;
		gamePiece.OnStartLerp += HandleOnStartLerp;
		gamePiece.OnStopLerp += HandleOnStopLerp;
	}

	void HandleOnStopLerp (GameObject g) {
		movingObjects.Remove(g);
		if(movingObjects.Count == 0 && OnPiecesStopped != null) {
			OnPiecesStopped();
		}
	}

	void HandleOnStartLerp (GameObject g) {
		movingObjects.Add(g);
		if(OnStartLerp != null) {
			OnStartLerp(g);
		}

		if(OnPiecesMoving != null) {
			OnPiecesMoving();
		}
	}

	//Event Handlers
	void HandleOnMouseEnterPiece (GameObject g){
		if(OnMouseEnterPiece != null) {
			OnMouseEnterPiece(g);
		}
	}
	
	void HandleOnClickDown (GameObject g){
		if(OnClickDown != null) {
			OnClickDown(g);
		}	
	}

	void HandleOnClickUp (GameObject g){
		if(OnClickUp != null) {
			OnClickUp(g);
		}	
	}

	public void MovePiece(GameObject piece, int x, int y, float positionX, float positionY) {
		GamePiece gamePiece = piece.GetComponent(typeof (GamePiece)) as GamePiece;
		gamePiece.SetPosition(x, y);
		gamePiece.StartLerp(new Vector3 (positionX, positionY, 0.0f));
	}


}
