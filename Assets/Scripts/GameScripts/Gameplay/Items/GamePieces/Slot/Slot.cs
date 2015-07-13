using System;
using UnityEngine;

/// <summary>
/// Slot piece for a grid square, on the Grid board. This slot can contain
/// a piece, or be empty.
/// </summary>
[Serializable]
public partial class Slot {

	#region Private Variables
    public int X { get; private set; }              //The X coord of the this slot in the game board
    public int Y { get; private set; }              //The Y coord of the this slot in the game board
    public GameObject Piece { get; private set; }   //The piece that is occupying this slot
    #endregion

    #region Actions and Funcs
    public Action<GameObject> OnPieceAdded, OnPieceRemoved;
	#endregion

	private FSM<SlotStates, ConcreteState> _slotStateMachine = new FSM<SlotStates, ConcreteState>();

	#region Constructors

	/// <summary>
	/// Initializes a new instance of the <see cref="Slot"/> class.
	/// </summary>
	/// <param name="x">The x coordinate of this slot in the game board.</param>
	/// <param name="y">The y coordinate of this slot in the game board.</param>
	public Slot(int x, int y) {
		X = x;
		Y = y;
		InitalizeSlotStates();
	}

	#endregion

	#region Slot Flags Methods

	/// <summary>
	/// Determines whether this slot is empty.
	/// </summary>
	/// <returns><c>true</c> if game piece is empty; otherwise, <c>false</c>.</returns>
	public bool IsEmpty() {
		return _slotStateMachine.isCurrentState(SlotStates.Empty);
	}

    /// <summary>
    /// Calls the states AddPiece method
    /// </summary>
    /// <param name="newPiece">The newPiece to add</param>
    public void AddPiece(GameObject newPiece) {
        _slotStateMachine.CurrentState.AddPiece(newPiece);
    }

	/// <summary>
	/// Remove the current piece. Pass the responsibility to the current state.
	/// </summary>
	public void RemovePiece() {
		_slotStateMachine.CurrentState.RemovePiece();
	}

	#endregion

	#region Triggers

	/// <summary>
	/// Game piece was added to the slot.
	/// </summary>
    protected void TriggerOnPieceAdded() {
		if (OnPieceAdded != null) {
			OnPieceAdded(Piece);
		}
	}

	/// <summary>
	/// Game piece was removed from the slot.
	/// </summary>
	/// <param name="g">Gameobject that was removed.</param>
	protected void TriggerOnPieceRemoved(GameObject g) {
		if (OnPieceRemoved != null) {
			OnPieceRemoved(g);
		}
	}

	#endregion
}
