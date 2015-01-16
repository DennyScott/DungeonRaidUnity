using UnityEngine;
using System.Collections;

public class WaterModel : ElementModel {
	public WaterModel(int x, int y) : base(x, y) {
		
	}

	public override string ToString() {
		return string.Format ("[WaterModel]");
	}
}
