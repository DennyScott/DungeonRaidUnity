using UnityEngine;
using System.Collections;

public class GamePieceModel {

	public GameObject go;

	public int x {
		get { return x; }
		set { x = value; }
	}

	public int y {
		get { return y; }
		set { y = value; }
	}

	public GamePieceModel() {

	}

	public GamePieceModel(GameObject temp) {
		this.go = temp;
	}

	public void destory () {
		GameObject.Destroy(go);
	}
}
