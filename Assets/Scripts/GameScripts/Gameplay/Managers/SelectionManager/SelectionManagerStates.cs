using UnityEngine;

public partial class SelectionManager {
  
    #region Initializer
    /// <summary>
	/// Intializes all states in the selection state FSM
	/// </summary>
	private void InitalizeStates() {
		_selectionFsm.AddState(SelectionStates.Idle, new IdleState(this));
		_selectionFsm.AddState(SelectionStates.DraggingPieces, new DragState(this));
		_selectionFsm.SetCurrentState(SelectionStates.Idle);
	}
    #endregion

    /// <summary>
	/// The ConcreteState class is the base state class for the selection manager selection state
	/// </summary>
	public abstract class ConcreteState : IFSMState {

        #region Protected Methods
        protected SelectionManager SelectionManager;
        #endregion

        #region Constructor
        protected ConcreteState(SelectionManager selectionManager) {
			SelectionManager = selectionManager;
		}
        #endregion

        #region Virtual Methods
        public virtual void OnEntry() {}

		public virtual void OnExit() {}

		/// <summary>
		/// Handles when the mouse enters a piece given
		/// </summary>
		/// <param name="piece">The piece the mouse just entered</param>
		public virtual void HandleOnMouseEnterPiece(GameObject piece) {}

		/// <summary>
		/// Handles when the mouse button is released
		/// </summary>
		public virtual void HandleMouseUp() {}

		/// <summary>
		/// Handles when the mouse is clicked down on the given piece
		/// </summary>
		/// <param name="piece">The peice clicked</param>
		public virtual void HandleClickDown(GameObject piece) {}

        #endregion

        #region Protected Methods
        /// <summary>
		/// Adds the piece to the selection list.
		/// </summary>
		/// <param name="piece">The game piece to add to the selection list</param>
		protected void AddPiece(GameObject piece) {
			if (!IsAcceptablePiece(piece)) {
				return;
			}

			SelectionManager._selectedPieces.Add(piece);
			if (SelectionManager.OnAddPiece != null) {
				SelectionManager.OnAddPiece(piece);
			}
			TriggerDraggingPiecesState();
		}

		/// <summary>
		/// Removes the piece from the selection list.
		/// </summary>
		/// <param name="piece">the game piece to remove from the selected list</param>
		protected void RemovePiece(GameObject piece) {
			SelectionManager._selectedPieces.RemoveAt(SelectionManager._selectedPieces.Count - 1);
			if (SelectionManager.OnRemovePiece != null) {
				SelectionManager.OnRemovePiece(piece);
			}
		}

        #endregion

        #region Selection List Helper Methods

        /// <summary>
		/// Determines whether this instance is the previous piece of the selection list.
		/// </summary>
		/// <returns><c>true</c> if this instance is the previous piece of the selection list; otherwise, <c>false</c>.</returns>
		/// <param name="piece">The piece to check</param>
		public bool IsPreviousPiece(GameObject piece) {
			return SelectionManager._selectedPieces.Count > 1 && SelectionManager._selectedPieces.IndexOf(piece) == SelectionManager._selectedPieces.Count - 2;
		}

		/// <summary>
		/// Determines whether this instance is an acceptable piece for the next spot in the selection list
		/// </summary>
		/// <returns><c>true</c> if this instance is an acceptable piece for the selection list; otherwise, <c>false</c>.</returns>
		/// <param name="piece">The game piece to check.</param>
		public bool IsAcceptablePiece(GameObject piece) {
			return !IsAlreadySelected(piece) && IsAcceptableRange(piece) && IsCorrectType(piece);
		}

		/// <summary>
		/// Determines whether this instance is already selected in the selction list
		/// </summary>
		/// <returns><c>true</c> if this instance is already selected and present in the selection list; otherwise, <c>false</c>.</returns>
		/// <param name="piece">The game piece to check.</param>
		public bool IsAlreadySelected(GameObject piece) {
			return SelectionManager._selectedPieces.IndexOf(piece) > -1;
		}

		/// <summary>
		/// Determines whether this instance is in the acceptable range for the next piece in the selection list.
		/// </summary>
		/// <returns><c>true</c> if this instance is in an acceptable range for the selection list; otherwise, <c>false</c>.</returns>
		/// <param name="piece">The game piece to check.</param>
		public bool IsAcceptableRange(GameObject piece) {
			if (HasNoPieces()) {
				return true;
			}

			var otherPiece = SelectionManager._selectedPieces[SelectionManager._selectedPieces.Count - 1];
			var originalGamePiece = otherPiece.GetComponent<GamePiece>();
			var newGamePiece = piece.GetComponent<GamePiece>();
			return Mathf.Abs(originalGamePiece.Row - newGamePiece.Row) <= 1 && Mathf.Abs(originalGamePiece.Column - newGamePiece.Column) <= 1;
		}

		/// <summary>
		/// Determines whether this instance is the correct type for the next piece in the selection list.
		/// </summary>
		/// <returns><c>true</c> if this instance is the correct type for the selection lit; otherwise, <c>false</c>.</returns>
		/// <param name="piece">The game piece to check.</param>
		public bool IsCorrectType(GameObject piece) {
			//Needs to check for matching type
			return true;
		}

		/// <summary>
		/// Determines whether the selection list has no pieces.
		/// </summary>
		/// <returns><c>true</c> if the selection list has no pieces; otherwise, <c>false</c>.</returns>
		public bool HasNoPieces() {
			return SelectionManager._selectedPieces.Count == 0;
		}

		#endregion

		#region State Modifiers

		/// <summary>
		/// Triggers the Dragging Pieces selection state, and emits an event
		/// </summary>
		protected void TriggerDraggingPiecesState() {
			SelectionManager._selectionFsm.SetCurrentState(SelectionStates.DraggingPieces);
			if (SelectionManager.OnDraggingPieces != null) {
				SelectionManager.OnDraggingPieces();
			}
		}

		/// <summary>
		/// Triggers the Idle selection state, and emits an event
		/// </summary>
		protected void TriggerIdleState() {
			SelectionManager._selectionFsm.SetCurrentState(SelectionStates.Idle);
			if (SelectionManager.OnIdle != null) {
				SelectionManager.OnIdle();
			}
		}

		#endregion

		#region Selection List Modifiers

		/// <summary>
		/// Submits the selected pieces in the selection list to be destroyed.
		/// </summary>
		protected void SubmitSelectedPieces() {
			//Need to add Submission Code
			foreach (var piece in SelectionManager._selectedPieces) {
				//piece.Action	
				Debug.Log(piece.transform.GetChild(0).name);
			}
			SelectionManager._selectedPieces.Clear();
		}

		#endregion
	}

	/// <summary>
	/// Used when the SelectionManager is in the IdleState
	/// </summary>
	public class IdleState : ConcreteState {

        #region Constructor
        /// <summary>
		/// The constructor for the IdleState class
		/// </summary>
		/// <param name="selectionManager"></param>
		public IdleState(SelectionManager selectionManager)
			: base(selectionManager) {

		}

        #endregion


        #region Event Handlers
        /// <summary>
		/// Overrides the HandleClickDown method
		/// </summary>
		/// <param name="piece"></param>
		public override void HandleClickDown(GameObject piece) {
			base.HandleClickDown(piece);
			if (SelectionManager._playerManager.PlayerActionFsm.isCurrentState(PlayerManager.PlayerStates.Idle)) {
				AddPiece(piece);
			}
        }

        #endregion
    }

	/// <summary>
	/// Used when the SelectionManager has changed to be dragging rather then Idle
	/// </summary>
	public class DragState : ConcreteState {

        #region Constructor
        /// <summary>
		/// Constructor for the DragState class
		/// </summary>
		/// <param name="selectionManager"></param>
		public DragState(SelectionManager selectionManager)
			: base(selectionManager) {

		}

        #endregion

        #region Event Handlers
        /// <summary>
		/// Overrides the HandleOnMouseEnterPiece class
		/// </summary>
		/// <param name="piece">The gamepiece that the mouse is over</param>
		public override void HandleOnMouseEnterPiece(GameObject piece) {
			base.HandleOnMouseEnterPiece(piece);
			if (IsPreviousPiece(piece)) {
				RemovePiece(piece);
			} else {
				AddPiece(piece);
			}
		}

		/// <summary>
		/// Overrides the HandleMouseUp class
		/// </summary>
		public override void HandleMouseUp() {
			base.HandleMouseUp();
			SubmitSelectedPieces();
			if (SelectionManager.OnDropPieces != null) {
				SelectionManager.OnDropPieces();
			}
			TriggerIdleState();
        }

        #endregion
    }
}
