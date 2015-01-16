using UnityEngine;
using System.Collections;

public class EarthModel : ElementModel {
	public EarthModel(int x, int y) : base(x, y) {
		
	}

	public override string ToString() {
		return string.Format ("[EarthModel]");
	}
}
