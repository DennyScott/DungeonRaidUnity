using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelModel {

	public List<string> gamePieceTypes = new List<string>();

	public LevelModel() {
		gamePieceTypes.Add ("Air");
		gamePieceTypes.Add ("Water");
		gamePieceTypes.Add ("Earth");
		gamePieceTypes.Add ("Fire");
	}
}
