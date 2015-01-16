using UnityEngine;
using System.Collections;

public class GamePieceManager : MonoBehaviour {
	public GameObject gamePiece;

	private Transform gamePieceTransform;

	void Awake() {
		gamePieceTransform = gamePiece.transform;
	}

	public void CreateGamePeice(float x, float y) {
		Vector3 pos = new Vector3(x, y, gamePieceTransform.position.z);
		Instantiate(gamePiece, pos, gamePieceTransform.rotation);
	}

}
