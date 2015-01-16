using UnityEngine;
using System.Collections;

public abstract class GamePieceModel {

    private int _x, _y;

    public int x {
		get { return _x; }
		set { _x = value; }
	}

	public int y {
		get { return _y; }
		set { _y = value; }
	}

	public GamePieceModel(int row, int column) {
        y = row;
        x = column;
	}

    public GamePieceModel() {
        
    }

	public abstract override string ToString();
}
