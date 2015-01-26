using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

	private Generators generators;
	private Managers managers;

	void Awake () {
		generators = GetComponent(typeof (Generators)) as Generators;
		managers = GetComponent(typeof (Managers)) as Managers;
	}

	// Use this for initialization
	void Start () {
		generators.GetGenerators();
		managers.GetManagers();
		Managers.gameBoardManager.CreateBoard();
	}
}
