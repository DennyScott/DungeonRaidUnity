using System;
using UnityEngine;
using System.Collections.Generic;

public class FSM<TEnum, T> where T : IFSMState {

    #region Private Methods
    private readonly Dictionary<TEnum, T> _states = new Dictionary<TEnum, T>();
    #endregion

    #region Auto Properties
    public T CurrentState { get; private set; }

    public TEnum CurrentStateName { get; private set; }

    #endregion

    #region Public Methods
    public void AddState(TEnum key, T state) {
        _states.Add(key, state);
    }

    public void RemoveState(TEnum key) {
        _states.Remove(key);
    }

    public void SetCurrentState(TEnum key) {
        //If the fsm does not contain this key
        if (!_states.ContainsKey(key)) {
            Debug.LogError("State Machine Does not contian the key: " + key);
            return;
        }

        //If this si the first state added
        if (CurrentState != null) {
            CurrentState.OnExit();   
        }

        CurrentState = _states[key];
        CurrentStateName = key;
        CurrentState.OnEntry();
    }

    public void SetCurrentStateIf(TEnum key, Func<bool> checkFunc) {
        if (checkFunc()) {
            SetCurrentState(key);
        }
    }

	public bool isCurrentState(TEnum state) {
		return CurrentStateName.Equals(state);
	}

    #endregion
}
