using System;
using UnityEngine;

[Serializable]
public class SpawnDetails {
    [Tooltip("The amount of wait time before the next row beings being spawned")]
    public float RowWaitTime = 0.0f;

    [Tooltip("The amount of wait time after a piece is spawned and the next begins")]
    public float PieceWaitTime = 0.05f;
}
