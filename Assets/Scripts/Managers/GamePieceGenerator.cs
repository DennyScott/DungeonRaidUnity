using UnityEngine;
using System.Collections;

public class GamePieceGenerator : MonoBehaviour {
	public GameObject Element;
	public GameObject GamePiece;

	public void CreateElement() {
		GameObject newPiece = Instantiate(GamePiece) as GameObject;
		GameObject newGraphic = Instantiate(Element) as GameObject;
		newGraphic.transform.parent = newPiece.transform;
		newGraphic.transform.position = new Vector2(0, 0);
	}
}
