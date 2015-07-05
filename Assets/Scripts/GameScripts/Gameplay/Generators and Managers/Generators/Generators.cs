using UnityEngine;

public class Generators : MonoBehaviour {

    public static GamePieceGenerator GamePieceGenerator { get; private set; }

    public void CollectGenerators() {
        GamePieceGenerator = GetComponentInChildren<GamePieceGenerator>();
    }

    public void InitalizeGenerators() {
        GamePieceGenerator.Initialize();
    }
}
