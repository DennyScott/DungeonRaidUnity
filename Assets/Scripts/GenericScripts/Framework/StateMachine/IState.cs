using UnityEngine;

public interface IState {

	void OnUpdate(GameObject g);

	void OnStateEnter(GameObject g);

	void OnStateExit(GameObject g);
}
