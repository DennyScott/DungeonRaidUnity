using UnityEngine;
using System.Collections;

public class PotionsModel : GamePieceModel {
	public PotionsModel(int x, int y) : base(x, y) {

	}

	public override string ToString () {
		return string.Format ("[PotionsModel]");
	}
}
