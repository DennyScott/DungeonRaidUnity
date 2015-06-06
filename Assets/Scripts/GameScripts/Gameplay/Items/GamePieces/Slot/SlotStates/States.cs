using UnityEngine;
using System.Collections;

public partial class Slot {

	/// <summary>
	/// Initalize the Slot States.
	/// </summary>
	private void InitalizeSlotStates() {
		slotStateMachine.AddState(SlotStates.Filled, new FilledState(this));
		slotStateMachine.AddState(SlotStates.Empty, new EmptyState(this));
	}

	/// <summary>
	/// Concrete State for the Slot States.
	/// </summary>
	public class ConcreteState : IFSMState {
		protected Slot Slot;

		/// <summary>
		/// Get the slot parent class.
		/// </summary>
		/// <param name="slot"></param>
		public ConcreteState(Slot slot) {
			Slot = slot;
		}

		public virtual void OnEntry() {}
		public virtual void OnExit() {}
		public virtual void AddPiece(GameObject piece) {}

		/// <summary>
		/// Remove the Piece, clearing out the piece, changing the current 
		/// state to the empty state, and triggering a remove.
		/// </summary>
		public virtual void RemovePiece() {
			var temp = Slot.piece;
			Slot.piece = null;
			Slot.slotStateMachine.SetCurrentState(SlotStates.Empty);
			Slot.OnPieceRemoved(temp);
		}
	}

	/// <summary>
	/// Filled State, when a piece is occupying the piece variable.
	/// </summary>
	public class FilledState : ConcreteState {
		public FilledState(Slot slot) : base(slot) {}

		/// <summary>
		/// If we are entering this state, a piece has just been added, and
		/// so we trigger the action.
		/// </summary>
		public override void OnEntry() {
			Slot.TriggerOnPieceAdded();
		}
		public override void OnExit() {}
	}

	/// <summary>
	/// Empty state, when a no piece is occupying the piece variable
	/// </summary>
	public class EmptyState : ConcreteState {
		public EmptyState(Slot slot) : base(slot) {}

		public override void OnEntry() {}
		public override void OnExit() {}

		/// <summary>
		/// Add a piece to the piece variable, and change the state to
		/// filled.
		/// </summary>
		/// <param name="piece">Piece to be added</param>
		public override void AddPiece(GameObject piece) {
			//Add Piece
			Slot.piece = piece;
			
			//Change to Normal State
			Slot.slotStateMachine.SetCurrentState(SlotStates.Filled);
		}

		public override void RemovePiece() {}
	}
}
