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

	private Level level;

	public void Awake() {
		level = GameObject.FindGameObjectWithTag("Level").GetComponent(typeof (Level)) as Level;
	}

	private void CreateElement(GameObject element, float x, float y) {
		GameObject newPiece = Instantiate(gamePiece) as GameObject;
		GameObject newGraphic = Instantiate(element) as GameObject;
		newGraphic.transform.parent = newPiece.transform;
		newGraphic.transform.position = new Vector2(x, y);
	}

	public void CreateElements() {
		for(int y = -4; y < 4; y++) {
			for(int x = -4; x < 4; x++) {
				float posX = (float) (x / blockSpacing);
				float posY = (float) (y / blockSpacing);
				int r = Random.Range(0, 4);
				if(r == 0) {
					CreateElement(airElement, posX, posY);
				} else if (r == 1) {
					CreateElement(waterElement, posX, posY);
				} else if (r == 2) {
					CreateElement(fireElement, posX, posY);
				} else if (r == 3) {
					CreateElement(earthElement, posX, posY);
				}
			}
		}
	}
}
