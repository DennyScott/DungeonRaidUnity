using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour {

	#region Private Variables
	private ElementModel model;
	#endregion

	#region Element Types
	public enum Elements{AIR, EARTH, WATER, FIRE};
	public Elements elementType;
	#endregion

	#region Public Variables
	public bool isMoving = true;
	#endregion

	#region Standard Methods
	void Awake() {
		model = new ElementModel();
	}	
	#endregion
}
