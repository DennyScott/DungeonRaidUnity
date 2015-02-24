using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	#region Public Variables
	public LevelModel model;
	#endregion

	#region Standard Methods
	// Use this for initialization
	void Start () {
		model = new LevelModel();
	}
	#endregion
}
