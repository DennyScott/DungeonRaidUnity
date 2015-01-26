using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour {
	ElementModel model;
	public enum Elements{AIR, EARTH, WATER, FIRE};
	public Elements elementType;
	public bool isMoving = true;

	void Awake() {
		model = new ElementModel();
	}

	void Update() {
	}


	
}
