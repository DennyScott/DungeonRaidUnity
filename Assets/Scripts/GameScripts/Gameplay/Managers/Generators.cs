using UnityEngine;
using System.Collections;

public class Generators : MonoBehaviour {

	#region Private Variables
	private static GamePieceGenerator gamePieceGenerator;
	#endregion

	#region Properties
	public static GamePieceGenerator GamePieceGenerator {
		get {
			return gamePieceGenerator;
		}
	}

	#endregion

	#region Get Generators

	/// <summary>
	/// Gets the generators of the scene.
	/// </summary>
	public void GetGenerators() {
		gamePieceGenerator = GetComponentInChildren(typeof (GamePieceGenerator)) as GamePieceGenerator;
	}

	#endregion
}
