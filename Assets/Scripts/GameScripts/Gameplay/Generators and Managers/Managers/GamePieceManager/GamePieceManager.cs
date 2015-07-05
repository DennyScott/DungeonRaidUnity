using UnityEngine;
using System.Collections.Generic;

public class GamePieceManager : Manager {

	#region Private Variables
	//List of object currently moving
	private readonly List<GameObject> _movingObjects = new List<GameObject>();
	
	#endregion

	#region Events
	public System.Action<GameObject> OnClickDown;               //Actioned when a gamepiece is clicked down on
	public System.Action<GameObject> OnClickUp;                 //Action when a gamepiece has the mouse released on it
	public System.Action<GameObject> OnMouseEnterPiece;         //Actioned when the gamepiece has the mouse enter it
	public System.Action<GameObject> OnMouseExitPiece;          //Action when the game piece has the mouse exit it
	public System.Action<GameObject> OnGamePieceStartMove;      //Actioned when the game piece starts moving
	public System.Action<GameObject> OnGamePieceStopMove;       //Actioned when the game piece stops moving
	public System.Action<GameObject> OnRemovePiece;             //Actioned when the piece is removed from the board
	public System.Action OnPiecesMoving;                        //Actioned when pieces begin moving when nothing was moving
	public System.Action OnPiecesStopped;                       //Actioned when all pieces have stopped movingas

	#endregion

    #region Initialize Methods
    /// <summary>
    /// The initalize method, currently is not used
    /// </summary>
    public override void Initialize() {}

    #endregion

    #region Event And Manager Registration
    /// <summary>
    /// Registers the piece into the game world at grid position [row, column] by using the GamePiece component attached to the given game object
    /// </summary>
    /// <param name="piece">The piece to register, must have a GamePiece attached</param>
    /// <param name="row">The row number of the piece</param>
    /// <param name="column">The column number of the piece</param>
	public void RegisterPiece(GameObject piece, int row, int column) {
        RegisterPiece(piece.GetComponent<GamePiece>(), row, column);
	}

    /// <summary>
    /// Registers the piece into the game world at grid position [row, column].
    /// </summary>
    /// <param name="gamePiece">The game piece to register</param>
    /// <param name="row">The row number of the piece</param>
    /// <param name="column">The column number of the piece</param>
    public void RegisterPiece(GamePiece gamePiece, int row, int column) {
        RegisterEvents(gamePiece);
        MovePiece(gamePiece, row, column);
    }

    /// <summary>
    /// Unregisters all events attached to the gamepiece
    /// </summary>
    /// <param name="piece">A gameobject with a GamePiece attached</param>
	public void UnRegisterPiece(GameObject piece) {
		UnRegisterPiece(piece.GetComponent<GamePiece>());
	}

    /// <summary>
    /// Unregisters all events attached to the gamePiece
    /// </summary>
    /// <param name="piece">The piece to remove the events from</param>
    public void UnRegisterPiece(GamePiece piece) {
        UnregisterEvents(piece);
    }

    /// <summary>
    /// Registers all events to the attached GamePiece
    /// </summary>
    /// <param name="gamePiece">The game piece to attach all events to</param>
    private void RegisterEvents(GamePiece gamePiece) {
        gamePiece.OnClickDown += HandleOnClickDown;
        gamePiece.OnClickUp += HandleOnClickUp;
        gamePiece.OnMouseEnterPiece += HandleOnMouseEnterPiece;
        gamePiece.OnGamePieceStartMove += HandleOnGamePieceStartMove;
        gamePiece.OnGamePieceStopMove += HandleOnGamePieceStopMove;
        gamePiece.OnRemovePiece += HandleOnRemovePiece;
    }

    /// <summary>
    /// Unregisters all events from the passed gamePiece
    /// </summary>
    /// <param name="gamePiece">The GamePiece to remove all events from</param>
    private void UnregisterEvents(GamePiece gamePiece) {
        gamePiece.OnClickDown -= HandleOnClickDown;
        gamePiece.OnClickUp -= HandleOnClickUp;
        gamePiece.OnMouseEnterPiece -= HandleOnMouseEnterPiece;
        gamePiece.OnGamePieceStartMove -= HandleOnGamePieceStartMove;
        gamePiece.OnGamePieceStopMove -= HandleOnGamePieceStopMove;
        gamePiece.OnRemovePiece -= HandleOnRemovePiece;
    }

	#endregion

	#region Event Handlers
    /// <summary>
    /// Handler for when a piece is removed from the game board
    /// </summary>
    /// <param name="g">The GamePiece removed from the board</param>
	void HandleOnRemovePiece (GameObject g) {
		UnRegisterPiece(g);
		if(OnRemovePiece != null)
			OnRemovePiece(g);
	}

	/// <summary>
	/// Handles the on stop lerp event.
	/// </summary>
	/// <param name="g">The gameObject that has just stopped lerping.</param>
	void HandleOnGamePieceStopMove(GameObject g) {
		_movingObjects.Remove(g);
		if(_movingObjects.Count == 0 && OnPiecesStopped != null) {
			OnPiecesStopped();
		}
	}

	/// <summary>
	/// Handles the on start lerp event.
	/// </summary>
	/// <param name="g">The gameObject that has just started lerping.</param>
	void HandleOnGamePieceStartMove(GameObject g) {
		_movingObjects.Add(g);
		if(OnGamePieceStartMove != null) {
			OnGamePieceStartMove(g);
		}

		if(OnPiecesMoving != null) {
			OnPiecesMoving();
		}
	}

	/// <summary>
	/// Handles the on mouse enter piece event.
	/// </summary>
	/// <param name="g">The Game Piece that just had the mouse enter it</param>
	void HandleOnMouseEnterPiece (GameObject g){
		if(OnMouseEnterPiece != null) {
			OnMouseEnterPiece(g);
		}
	}

	/// <summary>
	/// Handles the on click down event.
	/// </summary>
	/// <param name="g">The Game Piece that was just clicked down upon</param>
	void HandleOnClickDown (GameObject g){
		if(OnClickDown != null) {
			OnClickDown(g);
		}	
	}

	/// <summary>
	/// Handles the on click up.
	/// </summary>
	/// <param name="g">The Game Piece that was being hovered over when the mouse click went up.</param>
	void HandleOnClickUp (GameObject g){
		if(OnClickUp != null) {
			OnClickUp(g);
		}	
	}

	#endregion

	#region GamePiece Movement
	/// <summary>
	/// Moves the piece to the desginated x y.
	/// </summary>
	/// <param name="piece">The gamepiece to begin moving</param>
	/// <param name="x">The x coordinate to start at.</param>
	/// <param name="y">The y coordinate to start at.</param>
	public static void MovePiece(GamePiece piece, int x, int y) {
        piece.SetPiecePosition(y, x);
	}

    /// <summary>
    /// Moves the piece to the desginated x y.
    /// </summary>
    /// <param name="piece">The gameObject with a gamePiece component attached to begin moving</param>
    /// <param name="x">The x coordinate to start at.</param>
    /// <param name="y">The y coordinate to start at.</param>
    public static void MovePiece(GameObject piece, int x, int y) {
        MovePiece(piece.GetComponent<GamePiece>(), x, y);
    }

	#endregion
}
