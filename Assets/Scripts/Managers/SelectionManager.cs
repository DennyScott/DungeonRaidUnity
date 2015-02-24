using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour {

	#region Private Variables
	private PlayerManager playerManager;
	private GamePieceManager gamePieceManager;
	private List<GameObject> selectedPieces = new List<GameObject>();

	#endregion

	#region States
	public enum SelectionState {IDLE, DRAGGING_PIECES};
	public  SelectionState selectionState { get; private set; }

	#endregion

	#region Delegates
	public delegate void ActionEvent();
	public delegate void StateChangeEvent();

	#endregion

	#region Events
	public event ActionEvent OnDropPieces;
	public event ActionEvent OnAddPiece;
	public event ActionEvent OnRemovePiece;
	public event StateChangeEvent OnDraggingPieces;
	public event StateChangeEvent OnIdle;

	#endregion

	#region Standard Methods
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
	#endregion

	#region Event and Manager Registration


	/// <summary>
	/// Gets the managers.
	/// </summary>
	void GetManagers() {
		playerManager = Managers.playerManager;
		gamePieceManager = Managers.gamePieceManager;
	}

	/// <summary>
	/// Registers the piece events to thier event handlers.
	/// </summary>
	void RegisterPieceEvents() {
		gamePieceManager.OnClickDown += HandleClickDown;
		gamePieceManager.OnMouseEnterPiece += HandleOnMouseEnterPiece;
	}

	#endregion

	#region Event Handlers

	/// <summary>
	/// Handles the click down.
	/// </summary>
	/// <param name="piece">The game piece that was just clicked down upon.</param>
	public void HandleClickDown(GameObject piece) {
		if(playerManager.playerState == PlayerManager.PlayerState.IDLE && selectionState == SelectionState.IDLE) {
			AddPiece(piece);
		}
	}

	/// <summary>
	/// Handles the on mouse enter piece.
	/// </summary>
	/// <param name="piece">The game piece that just had the mouse enter it.</param>
	public void HandleOnMouseEnterPiece(GameObject piece) {
		if(selectionState == SelectionState.DRAGGING_PIECES) {
			if(IsPreviousPiece(piece)) {
				RemovePiece(piece);
			} else {
				AddPiece(piece);
			}
		}
	}

	/// <summary>
	/// Handles the mouse up.
	/// </summary>
	void HandleMouseUp() {
		if(selectionState == SelectionState.DRAGGING_PIECES) {
			SubmitSelectedPieces();
			if(OnDropPieces != null) {
				OnDropPieces();
			}
			TriggerIdleState();
		}
	}

	#endregion
	
	#region Selection List Modifiers

	/// <summary>
	/// Adds the piece to the selection list.
	/// </summary>
	/// <param name="piece">The game piece to add to the selection list</param>
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

	/// <summary>
	/// Removes the piece from the selection list.
	/// </summary>
	/// <param name="piece">the game piece to remove from the selected list</param>
	void RemovePiece(GameObject piece) {
		Debug.Log ("Removing Piece");
		selectedPieces.RemoveAt(selectedPieces.Count - 1);
		if(OnRemovePiece != null) {
			OnRemovePiece();
		}
	}

	/// <summary>
	/// Submits the selected pieces in the selection list to be destroyed.
	/// </summary>
	void SubmitSelectedPieces() {
		Debug.Log ("Submit!!");
		Debug.Log (selectedPieces.Count);
		selectedPieces.Clear();
	}

	#endregion

	#region Selection List Flags

	/// <summary>
	/// Determines whether this instance is the previous piece of the selection list.
	/// </summary>
	/// <returns><c>true</c> if this instance is the previous piece of the selection list; otherwise, <c>false</c>.</returns>
	/// <param name="piece">The piece to check</param>
	public bool IsPreviousPiece(GameObject piece) {
		if(selectedPieces.Count > 1 && selectedPieces.IndexOf(piece) == selectedPieces.Count - 2) {
			return true;
		}
		return false;
	}

	/// <summary>
	/// Determines whether this instance is an acceptable piece for the next spot in the selection list
	/// </summary>
	/// <returns><c>true</c> if this instance is an acceptable piece for the selection list; otherwise, <c>false</c>.</returns>
	/// <param name="piece">The game piece to check.</param>
	public bool IsAcceptablePiece(GameObject piece) {
		if(!IsAlreadySelected(piece) && IsAcceptableRange(piece) && IsCorrectType(piece)) {
			return true;
		}  
		return false;
	}

	/// <summary>
	/// Determines whether this instance is already selected in the selction list
	/// </summary>
	/// <returns><c>true</c> if this instance is already selected and present in the selection list; otherwise, <c>false</c>.</returns>
	/// <param name="piece">The game piece to check.</param>
	public bool IsAlreadySelected(GameObject piece) {
		if(selectedPieces.IndexOf(piece) > -1) {
			return true;
		}
		return false;
	}

	/// <summary>
	/// Determines whether this instance is in the acceptable range for the next piece in the selection list.
	/// </summary>
	/// <returns><c>true</c> if this instance is in an acceptable range for the selection list; otherwise, <c>false</c>.</returns>
	/// <param name="piece">The game piece to check.</param>
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

	/// <summary>
	/// Determines whether this instance is the correct type for the next piece in the selection list.
	/// </summary>
	/// <returns><c>true</c> if this instance is the correct type for the selection lit; otherwise, <c>false</c>.</returns>
	/// <param name="piece">The game piece to check.</param>
	public bool IsCorrectType(GameObject piece) {
		return true;
	}

	/// <summary>
	/// Determines whether the selection list has no pieces.
	/// </summary>
	/// <returns><c>true</c> if the selection list has no pieces; otherwise, <c>false</c>.</returns>
	public bool HasNoPieces() {
		if (selectedPieces.Count == 0) {
			return true;
		}
		return false;
	}

	#endregion

	#region State Modifiers

	/// <summary>
	/// Triggers the Dragging Pieces selection state, and emits an event
	/// </summary>
	void TriggerDraggingPiecesState() {
		if(selectionState != SelectionState.DRAGGING_PIECES) {
			selectionState = SelectionState.DRAGGING_PIECES;
			if(OnDraggingPieces != null) {
				OnDraggingPieces();
			}
		}
	}

	/// <summary>
	/// Triggers the Idle selection state, and emits an event
	/// </summary>
	void TriggerIdleState() {
		if(selectionState != SelectionState.IDLE) {
			selectionState = SelectionState.IDLE;
			if(OnIdle != null) {
				OnIdle();
			}
		}
	}

	#endregion
}
