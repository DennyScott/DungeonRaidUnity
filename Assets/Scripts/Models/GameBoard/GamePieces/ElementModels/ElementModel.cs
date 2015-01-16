using UnityEngine;
using System.Collections;

public class ElementModel : GamePieceModel {
	public ElementModel(int x, int y) : base(x, y) {

	}

	public override string ToString() {
		return string.Format ("[ElementModel]");
	}
}
