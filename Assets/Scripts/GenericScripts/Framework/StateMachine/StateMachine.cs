using UnityEngine;
using System.Collections;

public class StateMachine<TEnum> {

	#region Private Variables
	private TEnum _currentState;
	//Create an array of states the size of Enums in the passed generic
	private readonly State[] _states = new State[System.Enum.GetNames(typeof(TEnum)).Length];
	private readonly GameObject _gameObject;
	private bool _firstStateTriggered;
	#endregion

	#region Delegates
	public System.Action<GameObject> OnStateChange;
	public System.Action<GameObject> OnStateExit;
	public System.Action<GameObject> OnStateEnter;
	public System.Action<GameObject> OnStateStart;
	public System.Action<GameObject> OnStateUpdate;
	#endregion

	/// <summary>
	///		State Machine Contstructor. We will go through the total number of Enum
	///		Values passed in the Generic. 
	/// 
	///		Each of these states will have a default State added to them. 
	///		It is intended that new states will be added on top of them.
	/// </summary>
	/// <param name="g">GameObject of the Object with the Statemachine</param>
	public StateMachine() {
		foreach (var stateValue in System.Enum.GetValues(typeof(TEnum))) {
			BindToState(new Default(), (int)stateValue);
		}
	}

	/// <summary>
	///		Get or Set the Current State. While setting the current state, trigger
	///		events needed in the changing of states.
	/// </summary>
	public void SetState(int value) {
		if (System.Enum.IsDefined(typeof (TEnum), value) && IsAllowableState(value)){
			TriggerStateExit();
			_currentState = (TEnum)(object)value;
			TriggerStateChange();
			TriggerStateEnter();
			TriggerStateStart();
		}
	}

	/// <summary>
	///		Update function will call the trigger state update. If the developer wants to
	///		have an OnUpdate in the state, they must put the update function of the state machine
	///		into the update function of a monobehaviour.
	/// </summary>
	public void Update() {
		TriggerStateUpdate();
	}

	/// <summary>
	///		Is the Value passed not the current state, or the first time being triggered.
	/// </summary>
	/// <param name="value">Value to check</param>
	/// <returns>bool determining if the state is about to be triggered</returns>
	bool IsAllowableState(int value) {
		bool isTriggered = (value != (int)(object)_currentState || !_firstStateTriggered);
		_firstStateTriggered = true;
		return isTriggered;
	}

	/// <summary>
	///		Get the Current State
	/// </summary>
	/// <returns>TEnum State</returns>
	public TEnum GetState() {
		return _currentState;
	}

	public State GetStateObject() {
		return _states[(int)(object)_currentState];
	}

	/// <summary>
	///		Bind a State Object to an Enum State. We will use the statemchineproperty function
	///		of the state object, and pass both the gameObject and the setState Action to the state.
	/// 
	///		This action is passed so the state itself can set state, but does not know about the 
	///		state machine.
	/// </summary>
	/// <param name="newState"> State Object, which contains functions like onStateEnter and OnUpdate</param>
	/// <param name="state">TEnum state id to bind to</param>
	public void BindToState(State newState, TEnum state) {
		_states[(int)(object)state] = newState;
		newState.StateMachineProperty(SetState);
	}

	/// <summary>
	///		Bind a State Object to an Enum State. We will use the statemchineproperty function
	///		of the state object, and pass both the gameObject and the setState Action to the state.
	/// 
	///		This action is passed so the state itself can set state, but does not know about the 
	///		state machine.	
	/// </summary>
	/// <param name="newState"> State Object, which contains functions like onStateEnter and OnUpdat</param>
	/// <param name="state">TEnum state id to bind to</param>
	public void BindToState(State newState, int state) {
		_states[state] = newState;
		newState.StateMachineProperty(SetState);
	}


	#region Event Triggers
	/// <summary>
	///		Trigger OnStateChange Action
	/// </summary>
	void TriggerStateChange() {
		if(OnStateChange != null) {
			OnStateChange(_gameObject);
		}
	}

	/// <summary>
	///		Trigger OnStateEnter. This will also connect all the methods
	///		of the the current state to the Actions in the State Machine.
	/// </summary>
	void TriggerStateEnter() {
		OnStateEnter += _states[(int)(object)_currentState].OnStateEnter;
		OnStateExit += _states[(int)(object)_currentState].OnStateExit;
		OnStateUpdate += _states[(int)(object)_currentState].OnUpdate;
		OnStateEnter(_gameObject);
	}

	/// <summary>
	///		Trigger State Start Action
	/// </summary>
	void TriggerStateStart() {
		if(OnStateStart != null) {
			OnStateStart(_gameObject);
		}
	}

	/// <summary>
	///		Trigger State Update Action
	/// </summary>
	void TriggerStateUpdate() {
		if(OnStateUpdate != null) {
			OnStateUpdate(_gameObject);
		}
	}

	/// <summary>
	///		Trigger State Exit. This will also disconnect all the methods of the
	///		current state 
	/// </summary>
	void TriggerStateExit() {
		if(OnStateExit == null) {
			return;
		}
		OnStateExit(_gameObject);
		OnStateEnter -= _states[(int)(object)_currentState].OnStateEnter;
		OnStateExit -= _states[(int)(object)_currentState].OnStateExit;
		OnStateUpdate -= _states[(int)(object)_currentState].OnUpdate;
	}
	#endregion

	#region Private Default State
	/// <summary>
	///		Private Default State. This is effectivly a null value when creating a 
	///		State Machine. These are intended to be overwritten with new State values.
	/// </summary>
	private class Default : State {
		/// <summary>
		///		Warn the User that this state currently being used is a default
		///		null state.
		/// </summary>
		/// <param name="g"></param>
		public override void OnStateEnter(GameObject g) {
			Debug.Log("State has not been implemented");
		}

		public override void OnStateExit(GameObject g) {}
		public override void OnUpdate(GameObject g) {}
	}
	#endregion
}
