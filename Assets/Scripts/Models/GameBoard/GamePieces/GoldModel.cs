using UnityEngine;
using System.Collections;

public class GoldModel : GamePieceModel {

	public GoldModel(int x, int y) : base(x, y) {

	}

	public override string ToString() {
		return string.Format ("[GoldModel]");
	}
}
