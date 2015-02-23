using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour {
	private PlayerManager playerManager;
	private GamePieceManager gamePieceManager;
	private List<GameObject> selectedPieces = new List<GameObject>();

	public enum SelectionState {IDLE, DRAGGING_PIECES};
	public  SelectionState selectionState { get; private set; }

	public delegate void ActionEvent();
	public delegate void StateChangeEvent();

	public event ActionEvent OnDropPieces;
	public event ActionEvent OnAddPiece;
	public event ActionEvent OnRemovePiece;
	public event StateChangeEvent OnDraggingPieces;
	public event StateChangeEvent OnIdle;

	void Start() {
		GetManagers();
		RegisterPieceEvents();
		selectionState = SelectionState.IDLE;
	}

	void Update() {
		if(Input.GetMouseButtonUp(0)) {
			HandleMouseUp();
		}
	}

	void GetManagers() {
		playerManager = Managers.playerManager;
		gamePieceManager = Managers.gamePieceManager;
	}

	void RegisterPieceEvents() {
		gamePieceManager.OnClickDown += HandleClickDown;
		gamePieceManager.OnMouseEnterPiece += HandleOnMouseEnterPiece;
	}

	public void HandleClickDown(GameObject piece) {
		if(playerManager.playerState == PlayerManager.PlayerState.IDLE && selectionState == SelectionState.IDLE) {
			AddPiece(piece);
		}
	}

	public void HandleOnMouseEnterPiece(GameObject piece) {
		if(selectionState == SelectionState.DRAGGING_PIECES) {
			if(IsPreviousPiece(piece)) {
				RemovePiece(piece);
			} else {
				AddPiece(piece);
			}
		}
	}

	void AddPiece(GameObject piece) {
		if(IsAcceptablePiece(piece)) {
			Debug.Log ("Adding Piece!");
			selectedPieces.Add(piece);
			if(OnAddPiece != null) {
				OnAddPiece();
			}
			TriggerDraggingPiecesState();
		}
	}

	void RemovePiece(GameObject piece) {
		Debug.Log ("Removing Piece");
		selectedPieces.RemoveAt(selectedPieces.Count - 1);
		if(OnRemovePiece != null) {
			OnRemovePiece();
		}
	}

	void HandleMouseUp() {
		if(selectionState == SelectionState.DRAGGING_PIECES) {
			SubmitSelectedPieces();
			if(OnDropPieces != null) {
				OnDropPieces();
			}
			TriggerIdleState();
		}
	}

	void SubmitSelectedPieces() {
		Debug.Log ("Submit!!");
		Debug.Log (selectedPieces.Count);
		selectedPieces.Clear();
	}

	public bool IsPreviousPiece(GameObject piece) {
		if(selectedPieces.Count > 1 && selectedPieces.IndexOf(piece) == selectedPieces.Count - 2) {
			return true;
		}
		return false;
	}

	public bool IsAcceptablePiece(GameObject piece) {
		if(!IsAlreadySelected(piece) && IsAcceptableRange(piece) && IsCorrectType(piece)) {
			return true;
		}  
		return false;
	}
	
	public bool IsAlreadySelected(GameObject piece) {
		if(selectedPieces.IndexOf(piece) > -1) {
			return true;
		}
		return false;
	}
	
	public bool IsAcceptableRange(GameObject piece) {
		if(HasNoPieces()) {
			return true;
		}
		
		GameObject otherPiece = selectedPieces[selectedPieces.Count-1];
		GamePiece originalGamePiece = otherPiece.GetComponent(typeof (GamePiece)) as GamePiece;
		GamePiece newGamePiece = piece.GetComponent(typeof (GamePiece)) as GamePiece;
		if(Mathf.Abs(originalGamePiece.row - newGamePiece.row) <= 1 && Mathf.Abs(originalGamePiece.column - newGamePiece.column) <= 1) {
			return true;
		}
		return false;
	}
	
	public bool IsCorrectType(GameObject piece) {
		return true;
	}

	public bool HasNoPieces() {
		if (selectedPieces.Count == 0) {
			return true;
		}
		return false;
	}

	void TriggerDraggingPiecesState() {
		if(selectionState != SelectionState.DRAGGING_PIECES) {
			selectionState = SelectionState.DRAGGING_PIECES;
			if(OnDraggingPieces != null) {
				OnDraggingPieces();
			}
		}
	}

	void TriggerIdleState() {
		if(selectionState != SelectionState.IDLE) {
			selectionState = SelectionState.IDLE;
			if(OnIdle != null) {
				OnIdle();
			}
		}
	}
}
