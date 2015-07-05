using System;
using UnityEngine;

[Serializable]
public class GamePieceElements {
    public GameObject EarthElement;
    public GameObject AirElement;
    public GameObject WaterElement;
    public GameObject FireElement;
    private const int ElementCount = 4;

    public GameObject GetRandomElement() {
        var returnNum = UnityEngine.Random.Range(0, ElementCount);

        switch (returnNum) {
            case 0:
                return AirElement;
            case 1:
                return EarthElement;
            case 2:
                return FireElement;
            case 3:
                return WaterElement;
        }
        Debug.LogError("Creating Default Element.  ReturnNum: " + returnNum);
        return EarthElement;
    }
}
