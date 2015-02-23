using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {
	public enum PlayerState {IDLE, ACTIONING, WAITING};
	public  PlayerState playerState { get; private set; }

	public delegate void StateChangeEvent();

	public event StateChangeEvent OnActioningStateChange;
	public event StateChangeEvent OnIdleStateChange;
	public event StateChangeEvent OnWaitingStateChange;

	void Start() {
		playerState = PlayerState.WAITING;
		RegisterManagers();
		RegisterEvents();
	}

	void RegisterManagers() {

	}

	void RegisterEvents() {
		GamePieceManager gamePieceManager = Managers.gamePieceManager;
		SelectionManager selectionManager = Managers.selectionManager;
		gamePieceManager.OnPiecesMoving += HandleOnPiecesMoving;
		gamePieceManager.OnPiecesStopped += HandleOnPiecesStopped;
		selectionManager.OnDropPieces += HandleOnDropPieces;
		selectionManager.OnDraggingPieces += HandleOnDraggingPieces;
		selectionManager.OnIdle += HandleOnIdle;
	}

	void HandleOnIdle () {
		StartTurn();
	}

	void HandleOnDraggingPieces () {
		TriggerActioningState();
	}

	void HandleOnDropPieces () {
		WaitForTurn();
	}

	void HandleOnPiecesStopped () {
		StartTurn();
	}

	void HandleOnPiecesMoving (){
		WaitForTurn();
	}

	void StartTurn() {
		TriggerIdleState();
	}

	void WaitForTurn() {
		TriggerWaitState();
	}

	void TriggerActioningState() {
		if(playerState != PlayerState.ACTIONING) {
			playerState = PlayerState.ACTIONING;
			if(OnActioningStateChange != null) {
				OnActioningStateChange();
			}
		}
	}

	void TriggerIdleState() {
		if(playerState != PlayerState.IDLE) {
			playerState = PlayerState.IDLE;
			if(OnIdleStateChange != null) {
				OnIdleStateChange();
			}
		}
	}

	void TriggerWaitState() {
		if(playerState != PlayerState.WAITING) {
			playerState = PlayerState.WAITING;
			if(OnWaitingStateChange != null) {
				OnWaitingStateChange();
			}
		}
	}
}
