using UnityEngine;
using System.Collections;

public class SelectionManager : MonoBehaviour {
	private PlayerManager playerManager;
	private GamePieceManager gamePieceManager;
	

	public void AddPiece(GameObject piece) {
		if(playerManager == null) {
			GetManagers();
		}

		if(playerManager.HasNoPieces()) {
			playerManager.selectedPieces.Add (piece);
		} else {
			if(playerManager.IsPreviousPiece(piece)) {
				playerManager.RemoveLastPiece();
			} else if(playerManager.IsAcceptablePiece(piece)) {
				playerManager.selectedPieces.Add(piece);
			}
		}
	}

	void GetManagers() {
		playerManager = Managers.playerManager;
		gamePieceManager = Managers.gamePieceManager;
	}
}
