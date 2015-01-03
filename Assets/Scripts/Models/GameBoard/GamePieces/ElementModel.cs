using UnityEngine;
using System.Collections;

public class ElementModel : GamePieceModel {

	public enum ElementType {	
		FIRE, EARTH, AIR, WATER
	}

	public ElementType type{
		get { return type; }
		set { type = value; }
	}

	public int baseDamage {
		get { return baseDamage; }
		set { baseDamage = value; }
	}

	public ElementModel(GameObject go, ElementType et, int dmg) : base(go){
		type = et;
		baseDamage = dmg;
	}	
}
