using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour {
	ElementModel model;
	public enum Elements{AIR, EARTH, WATER, FIRE};
	public Elements elementType;

	void Awake() {
		model = new ElementModel();
	}
	
}
