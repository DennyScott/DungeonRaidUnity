public class WorldManager : Manager {

	#region Private Variables
	private Generators generators;
	private Managers managers;

	#endregion

	#region Standard Methods
	void Awake () {
		generators = gameObject.GetComponent<Generators>();
		managers = GetComponent<Managers>();
		generators.GetGenerators();
		managers.GetManagers();
		Managers.gameBoardManager.CreateBoard();
	}

	#endregion
}
