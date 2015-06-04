using UnityEngine;

public class Slot {

	#region Private Variables
	private int x;	//The X coord of the this slot in the game board
	private int y;	//The Y coord of the this slot in the game board
	private GameObject piece; //The game piece this slot is holding
	#endregion

	
	private StateMachine<SlotState> slotStateMachine;

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
	}

	#endregion

	#region Slot Flags Methods

	/// <summary>
	/// Determines whether this slot is empty.
	/// </summary>
	/// <returns><c>true</c> if game piece is empty; otherwise, <c>false</c>.</returns>
	public bool IsEmpty() {
		return piece == null;
	}

	public GameObject Piece {get; set;}

	#endregion
}
