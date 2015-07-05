using System;
using UnityEngine;
[Serializable]
public class GamePiecePlacement {
    [Tooltip("The Offset to place the object at for the x axis")]
    public float Offset = -3.5f;
    [Tooltip("The Start position of the objexts before coming into the board")]
    public float StartY = 5.0f;
}
