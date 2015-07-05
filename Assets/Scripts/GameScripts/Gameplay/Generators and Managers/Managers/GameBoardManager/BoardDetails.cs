using System;
using UnityEngine;

[Serializable]
public class BoardDetails {
    [Tooltip("The amount of rows to appear on the game board")]
    public int Rows;

    [Tooltip("The amount of columns to appear on the game board")]
    public int Columns;
}
