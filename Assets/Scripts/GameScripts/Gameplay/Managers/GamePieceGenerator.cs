using UnityEngine;
using System.Collections.Generic;

public class GamePieceGenerator : Generator {

	#region Public Varables
	public GameObject AirElement;
	public GameObject FireElement;
	public GameObject EarthElement;
	public GameObject WaterElement;
	public GameObject GamePiece;
	public float BlockSpacing;
	public float Offset = 0.5f;
	public List<GameObject> Positions;

	#endregion

	#region Private Variables
	private Level _level;
	private GameObject _dynamicObjects;
	private GamePieceManager _gamePieceManager;
	#endregion

	#region Standard Methods
	public void Awake() {
		_level = GameObject.FindGameObjectWithTag("Level").GetComponent(typeof (Level)) as Level;
		_dynamicObjects = GameObject.FindWithTag("DynamicObjects");
		_gamePieceManager = gameObject.GetComponent<GamePieceManager>();
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
		var newPiece = Instantiate(GamePiece);
		var newGraphic = Instantiate(element);
		newGraphic.transform.parent = newPiece.transform;
		newGraphic.transform.position = new Vector3(0, 0, 0);
		newPiece.transform.position = new Vector3(x, y, 0.0f);
		newPiece.transform.parent = _dynamicObjects.transform;
		return newPiece;
	}

	/// <summary>
	/// Creates the a game piece at the given x y coordinate
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public void CreatePiece(int x, int y) {
		var startX = (float) x - 4 + Offset;
		const float startY = 5.0f;
		var endX = startX;
		var endY = (float)y - 4 + Offset;
		var r = Random.Range(0, 4);
		GameObject newPiece;
		switch (r) {
			case 0:
				newPiece = AirElement;
				break;
			case 1:
				newPiece = WaterElement;
				break;
			case 2:
				newPiece = FireElement;
				break;
			case 3:
				newPiece = EarthElement;
				break;
			default:
			  	newPiece = AirElement;
				break;
		}

		newPiece = CreateElement(newPiece, startX, startY);
		_gamePieceManager.RegisterPiece(newPiece);
		GamePieceManager.MovePiece(newPiece, x, y, endX, endY);

	}

	#endregion

}
