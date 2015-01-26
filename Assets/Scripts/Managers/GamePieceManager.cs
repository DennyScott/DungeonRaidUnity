using UnityEngine;
using System.Collections;

public class GamePieceManager : MonoBehaviour {

	public void MovePiece(GameObject piece, int x, int y, float positionX, float positionY) {
		GamePiece gamePiece = piece.GetComponent(typeof (GamePiece)) as GamePiece;
		gamePiece.SetPosition(x, y);
		gamePiece.StartLerp(new Vector3 (positionX, positionY, 0.0f));
	}
}
