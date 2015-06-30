using UnityEngine;
using System.Collections.Generic;

public partial class SelectionManager : Manager {

	#region Public Variables

	private GamePieceManager _gamePieceManager;
	private PlayerManager _playerManager;

	#endregion

	#region Private Variables

	private readonly List<GameObject> _selectedPieces = new List<GameObject>();

	#endregion

	#region States

	private readonly FSM<SelectionStates, ConcreteState> _selectionFsm = new FSM<SelectionStates, ConcreteState>();

	public enum SelectionStates {
		Idle,
		DraggingPieces
	};

	#endregion

	#region Action

	public System.Action OnDropPieces;
	public System.Action<GameObject> OnAddPiece;
	public System.Action<GameObject> OnRemovePiece;
	public System.Action OnDraggingPieces;
	public System.Action OnIdle;

	#endregion

	#region Standard Methods

	private void Start() {
		_gamePieceManager = Managers.GamePieceManager;
		_playerManager = Managers.PlayerManager;
		RegisterPieceEvents();
		InitalizeStates();
	}

	private void Update() {
		if (Input.GetMouseButtonUp(0)) {
			HandleMouseUp();
		}
	}

	#endregion

	#region Event and Manager Registration

	/// <summary>
	/// Registers the piece events to thier event handlers.
	/// </summary>
	private void RegisterPieceEvents() {
		_gamePieceManager.OnClickDown += HandleClickDown;
		_gamePieceManager.OnMouseEnterPiece += HandleOnMouseEnterPiece;
	}

	#endregion

	#region Event Handlers

	/// <summary>
	/// Handles the click down.
	/// </summary>
	/// <param name="piece">The game piece that was just clicked down upon.</param>
	public void HandleClickDown(GameObject piece) {
		_selectionFsm.CurrentState.HandleClickDown(piece);
	}

	/// <summary>
	/// Handles the on mouse enter piece.
	/// </summary>
	/// <param name="piece">The game piece that just had the mouse enter it.</param>
	public void HandleOnMouseEnterPiece(GameObject piece) {
		_selectionFsm.CurrentState.HandleOnMouseEnterPiece(piece);
	}

	/// <summary>
	/// Handles the mouse up.
	/// </summary>
	private void HandleMouseUp() {
		_selectionFsm.CurrentState.HandleMouseUp();
	}

	#endregion
}
