using UnityEngine;
using System.Collections;

public class Generators : MonoBehaviour {

	private static GamePieceGenerator gamePieceGenerator;

	public static GamePieceGenerator GamePieceGenerator {
		get {
			return gamePieceGenerator;
		}
	}

	public void GetGenerators() {
		gamePieceGenerator = GetComponentInChildren(typeof (GamePieceGenerator)) as GamePieceGenerator;
	}
}
