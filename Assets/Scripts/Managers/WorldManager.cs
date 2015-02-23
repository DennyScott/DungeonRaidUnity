using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

	private Generators generators;
	private Managers managers;

	void Awake () {
		generators = GetComponent(typeof (Generators)) as Generators;
		managers = GetComponent(typeof (Managers)) as Managers;
		generators.GetGenerators();
		managers.GetManagers();
		Managers.gameBoardManager.CreateBoard();
	}

	// Use this for initialization
	void Start () {

	}
}
