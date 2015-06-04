using UnityEngine;

/// <summary>
/// Slot piece for a grid square, on the Grid board. This slot can contain
/// a piece, or be empty.
/// </summary>
public partial class Slot {

	#region Private Variables
	private int x;	//The X coord of the this slot in the game board
	private int y;	//The Y coord of the this slot in the game board
	private GameObject piece;
	#endregion

	#region Actions and Funcs
	public System.Action<GameObject> OnPieceAdded, OnPieceRemoved;
	#endregion

	private FSM<SlotStates, ConcreteState> slotStateMachine;

	#region Public Variables
	#endregion

	#region Constructors

	/// <summary>
	/// Initializes a new instance of the <see cref="Slot"/> class.
	/// </summary>
	/// <param name="x">The x coordinate of this slot in the game board.</param>
	/// <param name="y">The y coordinate of this slot in the game board.</param>
	public Slot(int x, int y) {
		this.x = x;
		this.y = y;
		slotStateMachine = new FSM<SlotStates, ConcreteState>();
		InitalizeSlotStates();
		slotStateMachine.SetCurrentState(SlotStates.Empty);
	}

	#endregion

	#region Slot Flags Methods

	/// <summary>
	/// Determines whether this slot is empty.
	/// </summary>
	/// <returns><c>true</c> if game piece is empty; otherwise, <c>false</c>.</returns>
	public bool IsEmpty() {
		return slotStateMachine.isCurrentState(SlotStates.Empty);
	}

	/// <summary>
	/// Get or Set the piece. If the piece is set, we pass responsibility
	/// to the current state of the slot.
	/// </summary>
	public GameObject Piece {
		get { return piece; }
		set {
			slotStateMachine.CurrentState.AddPiece(value);
		}
	}

	/// <summary>
	/// Remove the current piece. Pass the responsibility to the current state.
	/// </summary>
	public void RemovePiece() {
		slotStateMachine.CurrentState.RemovePiece();
	}

	#endregion

	#region Triggers

	/// <summary>
	/// Game piece was added to the slot.
	/// </summary>
	private void TriggerOnPieceAdded() {
		if (OnPieceAdded != null) {
			OnPieceAdded(piece);
		}
	}

	/// <summary>
	/// Game piece was removed from the slot.
	/// </summary>
	/// <param name="g">Gameobject that was removed.</param>
	private void TriggerOnPieceRemoved(GameObject g) {
		if (OnPieceRemoved != null) {
			OnPieceRemoved(g);
		}
	}

	#endregion
}
