using UnityEngine;
using System.Collections.Generic;

public partial class SelectionManager : Manager {

    #region Private Variables
    private List<GameObject> _selectedPieces = new List<GameObject>();      //The selected peices when a user is dragging pieces
    private GamePieceManager _gamePieceManager;                             //The game piece manager
	private PlayerManager _playerManager;                                   //The player manager

	#endregion

	#region States

	private FSM<SelectionStates, ConcreteState> _selectionFsm = new FSM<SelectionStates, ConcreteState>();     //The selection state FSM

    /// <summary>
    /// The states the selection manager can be in
    /// </summary>
	private enum SelectionStates {
		Idle,
		DraggingPieces
	};

	#endregion

	#region Action

	public System.Action OnDropPieces;                  //Actioned when all pieces are dropped
	public System.Action<GameObject> OnAddPiece;        //Action when a piece is added to the selection list
	public System.Action<GameObject> OnRemovePiece;     //Actioned when a piece is removed from the selection list
	public System.Action OnDraggingPieces;              //Actioned when dragging on pieces has begun
	public System.Action OnIdle;                        //Actioned when the Idle state has been triggered

	#endregion

    #region Triggers

    /// <summary>
    /// Trigger the OnDropPieces Action
    /// </summary>
    private void TriggerOnDropPieces() {
        if (OnDropPieces != null) {
            OnDropPieces();
        }
    }

    /// <summary>
    /// Trigger the OnAddPiece Action
    /// </summary>
    private void TriggerOnAddPiece() {
        if (OnAddPiece != null) {
            OnAddPiece(gameObject);
        }
    }

    /// <summary>
    /// Trigger the OnRemovePiece Action
    /// </summary>
    private void TriggerOnRemovePiece() {
        if (OnRemovePiece != null) {
            OnRemovePiece(gameObject);
        }
    }
    
    /// <summary>
    /// Trigger the OnDraggingPieces Action
    /// </summary>
    private void TriggerOnDraggingPieces() {
        if (OnDraggingPieces != null) {
            OnDraggingPieces();
        }
    }

    /// <summary>
    /// Trigger the OnIdle Action
    /// </summary>
    private void TriggerOnIdle() {
        if (OnIdle != null) {
            OnIdle();
        }
    }

    #endregion

    #region Standard Methods

    /// <summary>
    /// Initializes the class
    /// </summary>
    public override void Initialize() {
        CollectManagers();
		RegisterPieceEvents();
		InitalizeStates();
    }

	void OnDisable() {
		UnRegisterPieceEvents();
	}

    /// <summary>
    /// Collects all managers needed for this class
    /// </summary>
    private void CollectManagers() {
        _gamePieceManager = Managers.GamePieceManager;
        _playerManager = Managers.PlayerManager;
    }

    /// <summary>
    /// Runs every frame
    /// </summary>
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

	private void UnRegisterPieceEvents() {
		_gamePieceManager.OnClickDown -= HandleClickDown;
		_gamePieceManager.OnMouseEnterPiece -= HandleOnMouseEnterPiece;
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
