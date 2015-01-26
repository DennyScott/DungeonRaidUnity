using UnityEngine;
using System.Collections;

public class GamePieceManager : MonoBehaviour {

	public void MovePiece(GameObject piece, float x, float y) {
		((GamePiece)(piece.GetComponent(typeof (GamePiece)))).StartLerp(new Vector3 (x, y, 0.0f));
	}
}
