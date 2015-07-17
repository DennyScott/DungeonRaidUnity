using UnityEngine;

public partial class PlayerManager {

	/// <summary>
	/// Initalize the PlayerAction StateMachine.
	/// </summary>
	private void InitializeStates() {
		PlayerActionFsm.AddState(PlayerStates.Idle, new IdleState(this));
		PlayerActionFsm.AddState(PlayerStates.Actioning, new ActioningState(this));
		PlayerActionFsm.AddState(PlayerStates.Waiting, new WaitingState(this));
		PlayerActionFsm.SetCurrentState(PlayerStates.Idle);
	}

	
	/// <summary>
	/// Concrete state for the PlayerAction StateMachine. Defines the default values
	/// such as OnDragPiece, OnWaitForTurn and OnStartTurn.
	/// </summary>
	public abstract class ConcreteState : IFSMState {

		protected PlayerManager PlayerManager;

		/// <summary>
		/// Constuctor getting the PlayerManager object.
		/// </summary>
		/// <param name="playerManager">PlayerManager object</param>
		protected ConcreteState(PlayerManager playerManager) {
			PlayerManager = playerManager;
		}

		public virtual void OnEntry() {}
		public virtual void OnExit() {}

		/// <summary>
		/// If piece is dragged, set the current state to actioning
		/// </summary>
		public virtual void OnDragPiece() {
			PlayerManager.PlayerActionFsm.SetCurrentState(PlayerStates.Actioning);
		}

		/// <summary>
		/// If player is waiting before turn start, set the current state to waiting.
		/// </summary>
		public virtual void OnWaitForTurn() {
			PlayerManager.PlayerActionFsm.SetCurrentState(PlayerStates.Waiting);
		}

		/// <summary>
		/// If we are starting turn, set the state to id.e
		/// </summary>
		public virtual void OnStartTurn() {
			PlayerManager.PlayerActionFsm.SetCurrentState(PlayerStates.Idle);
		}
	}
	
	/// <summary>
	/// Idle state. Player is able to make a new selection
	/// </summary>
	public class IdleState : ConcreteState {
		public IdleState(PlayerManager playerManager) : base(playerManager) {}

		/// <summary>
		/// Don't make a change if we start turn.
		/// </summary>
		public override void OnStartTurn() {}
	}


	/// <summary>
	/// Waiting State. Player is waiting for next turn to start, and is unable
	/// to do anything.
	/// </summary>
	public class WaitingState : ConcreteState {
		public WaitingState(PlayerManager playerManager) : base(playerManager) {}

		/// <summary>
		/// Don't change state if wait is called again
		/// </summary>
		public override void OnWaitForTurn() {}
	}

	/// <summary>
	/// Actioning State. This is triggered when the player is attempting a move.
	/// </summary>
	public class ActioningState : ConcreteState {
		public ActioningState(PlayerManager playerManager) : base(playerManager) {}

		/// <summary>
		/// Don't change the state if the player attempts to drag piece again.
		/// </summary>
		public override void OnDragPiece() {}
	}
}
