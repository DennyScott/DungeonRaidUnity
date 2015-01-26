using UnityEngine;
using System.Collections;

public class Slot {

	private int x;
	private int y;
	public GameObject piece;

	public Slot(int x, int y) {
		this.x = x;
		this.y = y;
	}

	public bool IsEmpty() {
		if (piece == null) {
			return true;
		}
		return false;
	}
}
