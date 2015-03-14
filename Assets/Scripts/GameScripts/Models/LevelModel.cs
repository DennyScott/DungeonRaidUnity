using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelModel {

	#region Public Variables
	//A list of all available game piece types for this level
	public List<string> gamePieceTypes = new List<string>();
	#endregion

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="LevelModel"/> class.
	/// </summary>
	public LevelModel() {
		gamePieceTypes.Add ("Air");
		gamePieceTypes.Add ("Water");
		gamePieceTypes.Add ("Earth");
		gamePieceTypes.Add ("Fire");
	}
	#endregion
}
