using UnityEngine;
using System.Collections;

public class WorldManager : Manager {

	#region Private Variables
	private Generators generators;
	private Managers managers;

	#endregion

	#region Standard Methods
	void Awake () {
		generators = GetComponent(typeof (Generators)) as Generators;
		managers = GetComponent(typeof (Managers)) as Managers;
		generators.GetGenerators();
		managers.GetManagers();
		Managers.gameBoardManager.CreateBoard();
	}

	#endregion
}
