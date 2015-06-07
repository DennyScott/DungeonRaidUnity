public class Element : Grunt {

	#region Private Variables
	private ElementModel _model;
	#endregion

	#region Element Types
	public enum Elements{Air, Earth, Water, Fire};
	public Elements ElementType;
	#endregion

	#region Public Variables
	public bool IsMoving = true;
	#endregion

	#region Standard Methods
	void Awake() {
		_model = new ElementModel();
	}	
	#endregion
}
