using UnityEngine;

public partial class GamePiece : Grunt {

	#region Auto Properties
	public int Row { get; private set; }            //The Row of this GamePiece
	public int Column { get; private set; }         //The Column of this GamePiece

	#endregion

    #region Public Variables
    [Tooltip("The Speed at which the GamePiece will fall from the top of the screen")]
    public float Speed = 5.0F;
    [Tooltip("The Smoothness that the GameObject will ease with as it comes to a stop")]
    public float Smooth = 5.0F;
    [Tooltip("The YOffset that the pieces will be at for the Y axis")]
    public float YOffset = 3.5f;
    #endregion

    #region MovementState FSM
    /// <summary>
    /// States a Piece can be in
    /// </summary>
    private enum PieceMovementStates {
        Idle,
        Falling,
        Selected
    }

    //The FSM for the different GamePiece Movement states
    private readonly FSM<PieceMovementStates, ConcreteState> _movementState = new FSM<PieceMovementStates, ConcreteState>();

    #endregion

    #region Events
    public System.Action<GameObject> OnClickDown;               //When the mouse is clicked down on a piece
	public System.Action<GameObject> OnClickUp;                 //When the mouse is released on an object
	public System.Action<GameObject> OnMouseEnterPiece;         //Actioned when a mouse enters a piece
	public System.Action<GameObject> OnMouseExitPiece;          //Actioned when the Mouse exits the piece
	public System.Action<GameObject> OnRemovePiece;             //Acioned when the piece is removed from the board
    public System.Action<GameObject> OnGamePieceStartMove;      //Actioned when the GamePiece starts moving
    public System.Action<GameObject> OnGamePieceStopMove;       //Actioned when the GamePiece stops moving
	#endregion

    #region Standard Methods
    /// <summary>
    /// Called when Program started
    /// </summary>
    void Awake() {
        InitalizeMovementStates();
    }

    #endregion

    #region MovementState FSM Calls
    /// <summary>
    /// Called every frame
    /// </summary>
    void Update() {
        _movementState.CurrentState.Update();  //Calls the movement FSM's current states update
    }

    /// <summary>
    /// Used to changes the row and/or column of the piece.
    /// </summary>
    /// <param name="row">The new row of the gamePiece</param>
    /// <param name="column">The new column of the gamePiece</param>
    public void SetPiecePosition(int row, int column) {
        _movementState.CurrentState.SetPiecePosition(row, column);  //Calls the mocementState FSM's current states SetPiecePosition
    }

    #endregion

    #region Public Methods
    /// <summary>
	/// 	Used to remove a piece from the gameboard
	/// </summary>
	public void RemovePiece() {
		TriggerOnRemovePiece();
		Destroy(gameObject);
	}

	#endregion

    #region Events

    /// <summary>
	/// When a piece is removed, this will call the delegate Action
	/// </summary>
	protected void TriggerOnRemovePiece() {
		if (OnRemovePiece != null) {
			OnRemovePiece(gameObject);
		}
	}

	/// <summary>
	/// Raises the mouse down event, and emits the OnClickDown event.
	/// </summary>
	protected void TriggerOnMouseDown() {
		if (OnClickDown != null) {
			OnClickDown(gameObject);
		}
	}

	/// <summary>
	/// Raises the mouse up event and emits the OnClickUp event.
	/// </summary>
    protected void TriggerOnMouseUp() {
		if (OnClickUp != null) {
			OnClickUp(gameObject);
		}
	}

	/// <summary>
	/// Raises the mouse enter event, and emits the OnMouseEnterPiece event.
	/// </summary>
    protected void TriggerOnMouseEnter() {
		if (OnMouseEnterPiece != null) {
			OnMouseEnterPiece(gameObject);
		}
	}

	/// <summary>
	/// Raises the mouse exit event, and emits the OnMouseExitPiece event.
	/// </summary>
    protected void TriggerOnMouseExit() {
		if (OnMouseExitPiece != null) {
			OnMouseExitPiece(gameObject);
		}
    }

    #endregion
}
