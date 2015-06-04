public class Element : Grunt {

	#region Private Variables
	private ElementModel model;
	#endregion

	#region Element Types
	public enum Elements{AIR, EARTH, WATER, FIRE};
	public Elements _elementType;
	#endregion

	#region Public Variables
	public bool _isMoving = true;
	#endregion

	#region Standard Methods
	void Awake() {
		model = new ElementModel();
	}	
	#endregion
}
