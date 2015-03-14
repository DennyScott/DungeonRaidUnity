using UnityEngine;
using System.Collections;

/// <summary>
/// Rotate the current game object to a desired target game object. This will not inately turn
/// a game object, but must be called externally through one of its public apis.
/// </summary>
public class RotateToObject : MonoBehaviour {

#region States
	public enum ObjectState {IDLE, IS_ROTATING};
	public ObjectState currentState = ObjectState.IDLE;
#endregion

#region Private Variables
	private GameObject target;
	private Vector3 thisRotation;
#endregion

#region Delegates and Events
	public delegate bool IsAcceptable(GameObject g);
	public delegate void RotationEvent(GameObject g);

	public event IsAcceptable CanMove;
	public event IsAcceptable IsDropable;
	public event RotationEvent OnRotationStart;
	public event RotationEvent OnRotationFinish;

#endregion

#region Public Methods
	/// <summary>
	/// Rotate the gameObject that this component is attached to the target
	/// gameObject that is passed.
	/// </summary>
	/// <param name="target">
	/// GameObject to rotate to
	/// </param>
	public void SingleRotateTo(GameObject target) {
		this.target = target;
		if(CanMove == null || CanMove(gameObject)){
			TriggerOnRotationStart();
			RotateObject();
			TriggerOnRotationFinish();
		}
	}

	/// <summary>
	/// Continously rotate the gameObjec tthat this component is attached to, to the 
	/// target gameObject that is passed. This is done through a coroutine.
	/// </summary>
	/// <param name="target">
	/// GameObject to Rotate to
	/// </param>
	public void ContinuousRotateTo(GameObject target) {
		this.target = target;
		if(CanMove == null || CanMove(gameObject)){
			TriggerOnRotationStart();
			StartCoroutine("RunRotateObject");
		}
	}

	/// <summary>
	/// Stop the rotation coroutine from running.
	/// </summary>
	public void StopRotate() {
		StopCoroutine("RunRotateObject");
		TriggerOnRotationFinish();
	}
#endregion

#region Event Tiggers
	/// <summary>
	/// Trigger On Rotation Start. This will set the current state to IS_ROTATING and then
	/// call any subs in the OnRotationStart event.
	/// </summary>
	void TriggerOnRotationStart() {
		currentState = ObjectState.IS_ROTATING;
		if(OnRotationStart != null){
			OnRotationStart(gameObject);
		}
	}

	/// <summary>
	/// Trigger On Rotation Finish. This will set the current state to IDLE and then call
	/// any subs in the OnRotationFinish event.
	/// </summary> 
	void TriggerOnRotationFinish() {
		currentState = ObjectState.IDLE;
		if(OnRotationFinish != null){
			OnRotationFinish(gameObject);
		}
	}
#endregion

#region Private Methods
	/// <summary>
	/// Finds the angle necessary to let the button face the product
	/// </summary>
	private void FindAngle() {
		thisRotation = transform.eulerAngles;
		thisRotation.z = -target.transform.eulerAngles.y + 180;
	}

	/// <summary>
	/// Rotate the current gameObject to the target game object.
	/// </summary>
	private void RotateObject() {
		FindAngle();
		transform.eulerAngles = thisRotation;
	}
#endregion

#region Coroutines
	/// <summary>
	/// Continue to call the RotateObject method, turning the current game object to
	/// the target game object.
	/// </summary>
	IEnumerator RunRotateObject() {
		while(true) {
			RotateObject();
			yield return null;

		}
	}
#endregion
}
