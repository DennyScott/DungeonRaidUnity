using UnityEngine;
using System.Collections;

public class AirModel : ElementModel {
	public AirModel(int x, int y) : base(x, y) {
		
	}

	public override string ToString() {
		return string.Format ("[AirModel]");
	}
}
