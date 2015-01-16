using UnityEngine;
using System.Collections;

public class FireModel : ElementModel {
	public FireModel(int x, int y) : base(x, y) {
		
	}

	public override string ToString() {
		return string.Format ("[FireModel]");
	}
}
