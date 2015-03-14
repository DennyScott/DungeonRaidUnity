using UnityEngine;
using System.Collections.Generic;

public class GamePieceGenerator : Generator {

	#region Public Varables
	public GameObject _airElement;
	public GameObject _fireElement;
	public GameObject _earthElement;
	public GameObject _waterElement;
	public GameObject _gamePiece;
	public float _blockSpacing;
	public float _offset = 0.5f;
	public List<GameObject> _positions;

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
		var newPiece = Instantiate(_gamePiece);
		var newGraphic = Instantiate(element);
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
		float startX = (float) x - 4 + _offset;
		const float startY = 5.0f;
		float endX = startX;
		float endY = (float)y - 4 + _offset;
		int r = Random.Range(0, 4);
		GameObject newPiece;
		switch (r) {
			case 0:
				newPiece = _airElement;
				break;
			case 1:
				newPiece = _waterElement;
				break;
			case 2:
				newPiece = _fireElement;
				break;
			case 3:
				newPiece = _earthElement;
				break;
			default:
			  	newPiece = _airElement;
				break;
		}

		newPiece = CreateElement(newPiece, startX, startY);
		gamePieceManager.RegisterPiece(newPiece);
		gamePieceManager.MovePiece(newPiece, x, y, endX, endY);

	}

	#endregion

}
