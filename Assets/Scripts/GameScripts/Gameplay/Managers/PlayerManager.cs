public class PlayerManager : Manager {

	#region States
	public enum PlayerStates {WAITING, IDLE, ACTIONING};
	public  PlayerStates PlayerState { get; private set; }

	#endregion

	#region Delegates
	public delegate void StateChangeEvent();

	#endregion

	#region Events
	public event StateChangeEvent OnActioningStateChange;
	public event StateChangeEvent OnIdleStateChange;
	public event StateChangeEvent OnWaitingStateChange;

	#endregion

	#region Standard Methods
	void Start() {
		RegisterEvents();
	}

	#endregion

	#region Event And Manager Registration
	/// <summary>
	/// Registers the events to their event handlers.
	/// </summary>
	void RegisterEvents() {
		GamePieceManager gamePieceManager = Managers.gamePieceManager;
		SelectionManager selectionManager = Managers.selectionManager;
		gamePieceManager.OnPiecesMoving += HandleOnPiecesMoving;
		gamePieceManager.OnPiecesStopped += HandleOnPiecesStopped;
		selectionManager.OnDropPieces += HandleOnDropPieces;
		selectionManager.OnDraggingPieces += HandleOnDraggingPieces;
		selectionManager.OnIdle += HandleOnIdle;
	}

	#endregion

	#region Event Handlers

	/// <summary>
	/// Handles the on idle.
	/// </summary>
	void HandleOnIdle () {
		StartTurn();
	}

	/// <summary>
	/// Handles the on dragging pieces.
	/// </summary>
	void HandleOnDraggingPieces () {
		TriggerActioningState();
	}

	/// <summary>
	/// Handles the on drop pieces.
	/// </summary>
	void HandleOnDropPieces () {
		WaitForTurn();
	}

	/// <summary>
	/// Handles the on pieces stopped.
	/// </summary>
	void HandleOnPiecesStopped () {
		StartTurn();
	}

	/// <summary>
	/// Handles the on pieces moving.
	/// </summary>
	void HandleOnPiecesMoving (){
		WaitForTurn();
	}
	
	#endregion

	#region State Modifiers

	/// <summary>
	/// Starts the players turn state.
	/// </summary>
	void StartTurn() {
		TriggerIdleState();
	}

	/// <summary>
	/// Starts the Players waiting state
	/// </summary>
	void WaitForTurn() {
		TriggerWaitState();
	}

	/// <summary>
	/// Triggers the actioning player state and emits an event
	/// </summary>
	void TriggerActioningState() {
		if(PlayerState != PlayerStates.ACTIONING) {
			PlayerState = PlayerStates.ACTIONING;
			if(OnActioningStateChange != null) {
				OnActioningStateChange();
			}
		}
	}

	/// <summary>
	/// Triggers the idle player state and emits an event
	/// </summary>
	void TriggerIdleState() {
		if(PlayerState != PlayerStates.IDLE) {
			PlayerState = PlayerStates.IDLE;
			if(OnIdleStateChange != null) {
				OnIdleStateChange();
			}
		}
	}

	/// <summary>
	/// Triggers the waiting player state, and emits an event
	/// </summary>
	void TriggerWaitState() {
		if(PlayerState != PlayerStates.WAITING) {
			PlayerState = PlayerStates.WAITING;
			if(OnWaitingStateChange != null) {
				OnWaitingStateChange();
			}
		}
	}

	#endregion
}
