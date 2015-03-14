using UnityEngine;
using System.Collections;

/// <summary>
/// Attaching this component to a gameobject will allow that gameobject to continuously rotate
/// towards the mouse, or to quickly turn the gameobject to the mouse. This will not explicity
/// perform the action, but does allow the calls externally.
///
/// If you wish to create an item that will always follow the item, you can either call 
/// the api externally, or create a start function that calls continuous.
/// </summary>
public class RotateToMouse : MonoBehaviour {

#region States
	public enum ProductState {IDLE, IS_SELECTED, WAITING};
	public ProductState currentState = ProductState.IDLE;

#endregion

#region Delegates and Events
	public delegate bool IsAcceptable(GameObject g);
	public delegate void RotationEvent(GameObject g);

	public event IsAcceptable CanMove;
	public event IsAcceptable IsDropable;
	public event RotationEvent OnProductRotationStart;
	public event RotationEvent OnProductRotationFinish;
	public event RotationEvent OnProductRotationFailed;

#endregion

#region Private Variables
	private Vector3 lastGoodRotation;
	private Vector3 mousePosition;
	private GameObject rotator;
#endregion

#region Public Methods
	/// <summary>
	/// Continous Rotation of the Current gameObject to follow the Mouse.
	/// </summary>
	public void ContinuousRotateToMouse() {
		//If the object is allowed to rotate
		if(CanMove == null || CanMove(gameObject)){
			TriggerOnProductRotationStart();
			StartCoroutine("RotateItem");
		}
	}

	/// <summary>
	/// Stops the continours rotation of the current GameObject following the mouse.
	/// </summary>
	public void StopRotateToMouse() {
		StopCoroutine("RotateItem");
		TriggerOnProductRotationFinish();
		CheckRotation();
	}

	/// <summary>
	/// Turn the current gameobject to the mouse.
	/// </summary>
	public void SingleRotateToMouse() {
		//If the Object is allowed to rotate
		if(CanMove == null || CanMove(gameObject)){
			//Trigger onStart Callback
			TriggerOnProductRotationStart();

			//Rotate Object
			RotateItemToMouse();

			//Trigger onComplete callback
			TriggerOnProductRotationFinish();			
		}
	}

#endregion

#region Private Methods
	/// <summary>
	/// Finds the mouse.
	/// </summary>
	void FindMouse() {
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	/// <summary>
	/// Checks the rotationn of the object. If the product is dropabled, we reset the last good rotation.
	/// If it is not dropable, we move the product back to its last good rotation.
	/// </summary>
	private void CheckRotation() {
		if (IsDropable == null || IsDropable(gameObject)) {
			lastGoodRotation = gameObject.transform.eulerAngles;
		}
		else {
			gameObject.transform.eulerAngles = lastGoodRotation;
			TriggerRotationFailed();
		}
	}

#endregion

#region Event Triggers

	/// <summary>
	/// Triggers the on product rotation start event.
	/// </summary>
	void TriggerOnProductRotationStart() {
		currentState = ProductState.IS_SELECTED;
		if(OnProductRotationStart != null) {
			OnProductRotationStart(gameObject);
		}
	}

	/// <summary>
	/// Triggers the on product rotation finish event.
	/// </summary>
	void TriggerOnProductRotationFinish() {
		currentState = ProductState.IDLE;
		if(OnProductRotationFinish != null) {
			OnProductRotationFinish(gameObject);
		}		
	}

	/// <summary>
	/// Triggers the rotation failed event.
	/// </summary>
	void TriggerRotationFailed() {
		if(OnProductRotationFailed != null) {
			OnProductRotationFailed(gameObject);
		}
	}

	/// <summary>
	/// Rotate the current gameobject to the Mouse Position.
	/// </summary>
	void RotateItemToMouse() {
		FindMouse();
		Quaternion targetRotation = Quaternion.LookRotation(mousePosition - transform.position);
		targetRotation.x = 0;
		targetRotation.z = 0;

		transform.rotation = targetRotation;
	}

#endregion

#region State Checkers

	/// <summary>
	/// Gets a value indicating whether this instance is idle.
	/// </summary>
	/// <value><c>true</c> if this instance is idle; otherwise, <c>false</c>.</value>
	public bool IsIdle {
		get {
			return currentState == ProductState.IDLE;
		}
	}

	/// <summary>
	/// Gets a value indicating whether this instance is selected for rotation.
	/// </summary>
	/// <value><c>true</c> if this instance is selected for rotation; otherwise, <c>false</c>.</value>
	public bool IsSelected {
		get {
			return currentState == ProductState.IS_SELECTED;
		}
	}

#endregion

#region Coroutines

	/// <summary>
	/// Rotates the item.
	/// </summary>
	/// <returns>The item to rotate</returns>
	IEnumerator RotateItem() {
		while(true) {
			RotateItemToMouse();
			yield return null;
		}
	}
#endregion

}

