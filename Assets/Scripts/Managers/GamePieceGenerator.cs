using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePieceGenerator : MonoBehaviour {
	public  GameObject airElement;
	public  GameObject fireElement;
	public  GameObject earthElement;
	public  GameObject waterElement;
	public GameObject gamePiece;
	public float blockSpacing;
	public float offset = 0.5f;
	public List<GameObject> positions;

	private Level level;

	public void Awake() {
		level = GameObject.FindGameObjectWithTag("Level").GetComponent(typeof (Level)) as Level;
	}

	private GameObject CreateElement(GameObject element, float x, float y) {
		GameObject newPiece = Instantiate(gamePiece) as GameObject;
		GameObject newGraphic = Instantiate(element) as GameObject;
		newGraphic.transform.parent = newPiece.transform;
		newGraphic.transform.position = new Vector3(0, 0, 0);
		newPiece.transform.position = new Vector3(x, y, 0.0f);
		return newPiece;
	}

	public void CreatePiece(int x, int y) {
		float startX = (float) x - 4 + offset;
		float startY = 5.0f;
		float endX = startX;
		float endY = (float)y - 4 + offset;
		int r = Random.Range(0, 4);
		GameObject newPiece = new GameObject();
		if(r == 0) {
			newPiece = CreateElement(airElement, startX, startY);
		} else if (r == 1) {
			newPiece = CreateElement(waterElement, startX, startY);
		} else if (r == 2) {
			newPiece = CreateElement(fireElement, startX, startY);
		} else if (r == 3) {
			newPiece = CreateElement(earthElement, startX, startY);
		}

		Managers.gamePieceManager.MovePiece(newPiece, endX, endY);

	}

}
