using System;
using UnityEngine;

public abstract class State : IState{

	protected Action<int> SetState; //Allows the State to set the state of the state machine

	#region Event Triggers
	public System.Action<object> StateEnterAction, StateExitAction, UpdateAction;
	#endregion

	/// <summary>
	///		Used to attach the Set State Action, and to get the game Object. This should be called first,
	///		directly by the state machine.
	/// </summary>
	/// <param name="g"></param>
	/// <param name="setState"></param>
	public void StateMachineProperty(Action<int> setState) {
		SetState = setState;
	}

	/// <summary>
	///		On Update, Call this function. This method can be overridden
	///		and code will be called from it. It is recommended that if you
	///		do overridge this method, continue to call base, as the UpdateAction
	///		delegate is called here.
	/// </summary>
	/// <param name="g">GameObject state is attached to</param>
	public virtual void OnUpdate(GameObject g) {
		if (UpdateAction != null) {
			UpdateAction(g);
		}
	}

	/// <summary>
	///		On State Enter, Call this function. This method can be overridden
	///		and code will be called from it. It is recommended that if you
	///		do overridge this method, continue to call base, as the StateEnterAction
	///		delegate is called here.
	/// </summary>
	/// <param name="g">GameObject state is attached to</param>
	public virtual void OnStateEnter(GameObject g) {
		if (StateEnterAction != null) {
			StateEnterAction(g);
		}
	}

	/// <summary>
	///		On State Exit, Call this function. This method can be overridden
	///		and code will be called from it. It is recommended that if you
	///		do overridge this method, continue to call base, as the StateExitAction
	///		delegate is called here.
	/// </summary>
	/// <param name="g">GameObject state is attached to</param>
	public virtual void OnStateExit(GameObject g) {
		if (StateExitAction != null) {
			StateExitAction(g);
		}
	}
}
