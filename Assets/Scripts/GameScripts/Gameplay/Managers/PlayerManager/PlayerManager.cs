using UnityEngine;

public partial class PlayerManager : Manager {

	#region States
	public enum PlayerStates {Waiting, Idle, Actioning};

	public FSM<PlayerStates, ConcreteState> PlayerActionFsm = new FSM<PlayerStates, ConcreteState>(); 
	#endregion

	#region Standard Methods
	void Start() {
		InitializeStates();
		PlayerActionFsm.SetCurrentState(PlayerStates.Idle);
		RegisterEvents();
	}
	#endregion

	#region Event And Manager Registration
	/// <summary>
	/// Registers the events to their event handlers.
	/// </summary>
	void RegisterEvents() {
		Managers.GamePieceManager.OnPiecesMoving += PlayerActionFsm.CurrentState.OnWaitForTurn;
		Managers.GamePieceManager.OnPiecesStopped += PlayerActionFsm.CurrentState.OnStartTurn;
		Managers.SelectionManager.OnDropPieces += PlayerActionFsm.CurrentState.OnWaitForTurn;
		Managers.SelectionManager.OnDraggingPieces += PlayerActionFsm.CurrentState.OnDragPiece;
		Managers.SelectionManager.OnIdle += PlayerActionFsm.CurrentState.OnStartTurn;
	}

	/// <summary>
	/// Unregester the events from the event handlers.
	/// </summary>
	void DeregisterEvents() {
		Managers.GamePieceManager.OnPiecesMoving -= PlayerActionFsm.CurrentState.OnWaitForTurn;
		Managers.GamePieceManager.OnPiecesStopped -= PlayerActionFsm.CurrentState.OnStartTurn;
		Managers.SelectionManager.OnDropPieces -= PlayerActionFsm.CurrentState.OnWaitForTurn;
		Managers.SelectionManager.OnDraggingPieces -= PlayerActionFsm.CurrentState.OnDragPiece;
		Managers.SelectionManager.OnIdle -= PlayerActionFsm.CurrentState.OnStartTurn;
	}
	#endregion
}
