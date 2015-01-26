using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {
	public List<GameObject> selectedPieces;

	public bool HasNoPieces() {
		if (selectedPieces.Count == 0) {
			Debug.Log ("Had No Pieces");
			return true;
		}
		return false;
	}

	public bool IsPreviousPiece(GameObject piece) {
		if(selectedPieces.Count>1 && selectedPieces.IndexOf(piece) == selectedPieces.Count - 2) {
			return true;
		}
		return false;
	}

	public void RemoveLastPiece() {
		selectedPieces.RemoveAt(selectedPieces.Count - 1);
	}

	public bool IsAcceptablePiece(GameObject piece) {
		if(!IsAlreadySelected(piece) && IsAcceptableRange(piece) && IsCorrectType(piece)) {
			return true;
		}  
		return false;
	}

	public bool IsAlreadySelected(GameObject piece) {
		if(selectedPieces.IndexOf(piece) > -1) {
			return true;
		}
		return false;
	}

	public bool IsAcceptableRange(GameObject piece) {
		GameObject otherPiece = selectedPieces[selectedPieces.Count-1];
		GamePiece originalGamePiece = otherPiece.GetComponent(typeof (GamePiece)) as GamePiece;
		GamePiece newGamePiece = piece.GetComponent(typeof (GamePiece)) as GamePiece;
		if(Mathf.Abs(originalGamePiece.row - newGamePiece.row) <= 1 && Mathf.Abs(originalGamePiece.column - newGamePiece.column) <= 1) {
			return true;
		}
		return false;
	}

	public bool IsCorrectType(GameObject piece) {
		return true;
	}


}
