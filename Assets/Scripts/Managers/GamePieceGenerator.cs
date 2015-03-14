using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePieceGenerator : MonoBehaviour {

	#region Public Varables
	public  GameObject airElement;
	public  GameObject fireElement;
	public  GameObject earthElement;
	public  GameObject waterElement;
	public GameObject gamePiece;
	public float blockSpacing;
	public float offset = 0.5f;
	public List<GameObject> positions;

	#endregion

	#region Private Variables
	private GamePieceManager gamePieceManager;
	private Level level;
	private GameObject dynamicObjects;

	#endregion

	#region Standard Methods
	public void Awake() {
		level = GameObject.FindGameObjectWithTag("Level").GetComponent(typeof (Level)) as Level;
		dynamicObjects = GameObject.FindWithTag("DynamicObjects");
	}

	#endregion

	#region Event and Manager Registration
	/// <summary>
	/// Checks to see if the managers have been initalized, if not, it will initalize them
	/// </summary>
	void CheckManagers() {
		if(gamePieceManager == null) {
			gamePieceManager = Managers.gamePieceManager;
		}
	}
	
	#endregion

	#region Create GamePiece

	/// <summary>
	/// Creates a new element game piece.
	/// </summary>
	/// <returns>The new gameObject of the element.</returns>
	/// <param name="element">The gameObject to Create</param>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	private GameObject CreateElement(GameObject element, float x, float y) {
		GameObject newPiece = Instantiate(gamePiece) as GameObject;
		GameObject newGraphic = Instantiate(element) as GameObject;
		newGraphic.transform.parent = newPiece.transform;
		newGraphic.transform.position = new Vector3(0, 0, 0);
		newPiece.transform.position = new Vector3(x, y, 0.0f);
		newPiece.transform.parent = dynamicObjects.transform;
		return newPiece;
	}

	/// <summary>
	/// Creates the a game piece at the given x y coordinate
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public void CreatePiece(int x, int y) {
		CheckManagers();
		float startX = (float) x - 4 + offset;
		float startY = 5.0f;
		float endX = startX;
		float endY = (float)y - 4 + offset;
		int r = Random.Range(0, 4);
		GameObject newPiece = airElement;
		if(r == 0) {
			newPiece = airElement;
		} else if (r == 1) {
			newPiece = waterElement;
		} else if (r == 2) {
			newPiece = fireElement;
		} else if (r == 3) {
			newPiece = earthElement;
		}

		newPiece = CreateElement(newPiece, startX, startY);
		gamePieceManager.RegisterPiece(newPiece);
		gamePieceManager.MovePiece(newPiece, x, y, endX, endY);

	}

	#endregion

}
