using UnityEngine;
using System.Collections;

public class LerpToObject : MonoBehaviour {

	#region Private Variables
	private Vector3 productFacing;
	private Vector3 handleDestination;
	private GameObject target;
	private float lerpStartTime;
	#endregion

	#region Public Variables
	public float distanceFromProduct = 2.0f;
	public float lerpSpeed = 1f;
	#endregion


	#region Delegates and Events
	public delegate void LerpAction();
	public event LerpAction LerpCompleted;

	public delegate bool IsAcceptable(GameObject go);
	public event IsAcceptable CanMove;
	#endregion

	#region Enumerators

	/// <summary>
	/// Lerp the current object to the target game object. Once the perp has been completed
	/// we will trigger the lerpComleted event.
	/// </summary>
	IEnumerator LerpToDefault() {
		while (Time.time < lerpStartTime + lerpSpeed) {
			transform.position = Vector3.Lerp(transform.position, handleDestination, GetTimeForLerp());
			yield return null;
		}
		transform.position = handleDestination;
		TriggerLerpCompleted();
	}

	#endregion

	#region Private Methods
	/// <summary>
	/// Get the Time needed for the lerp. It will take the current time - the original 
	/// start time, and divide it be the speed.
	/// </summary>
	private float GetTimeForLerp() {
		return (Time.time - lerpStartTime)/lerpSpeed;
	}

	/// <summary>
	/// Sets variables necessary for handle to begin lerping. 
	/// Store the necessary variables and then begin the lerp coroutine.
	/// </summary>
	private void BeginHandleLerp() {
		lerpStartTime = Time.time;
		productFacing = target.transform.forward;
		FindHandleDestination();
		StartCoroutine("LerpToDefault");
	}

	/// <summary>
	/// Ends the lerp coroutine
	/// </summary>
	private void StopHandleLerp() {
		StopCoroutine("LerpToDefault");
	}

	/// <summary>
	/// Finds where the handle should be reset to
	/// </summary>
	private void FindHandleDestination() {
		handleDestination = Camera.main.WorldToScreenPoint(target.transform.position + distanceFromProduct*productFacing);
	}
	#endregion

	#region Triggers
	/// <summary>
	/// The Lerp has completed, so we call the Lerp Completed Delegate, to call any methods
	/// waiting to be called after animation.
	/// </summary>
	private void TriggerLerpCompleted() {
		if (LerpCompleted != null) {
			LerpCompleted();
		}
	}
	#endregion

	#region Public Methods

	/// <summary>
	///  Take the Game Object this component is attached to, and lerp it to the GameObject
	///  that is passed. You must also dictate the speed and the distance from the product
	///  the lerp needs to stop at.
	/// </summary>
	/// <param name="target">
	/// Game Object that "this" game object will lerp to.
	/// </param> 
	/// <param name="lerpSpeed">
	/// Speed to lerp the GameObject at, in seconds.
	/// </param>
	/// <param name="distanceFromProduct">
	/// The distance from the target to stop the lerp at.
	/// </param>
	public void LerpTo(GameObject target, float lerpSpeed, float distanceFromProduct) {
		//Set Instance Variables
		this.lerpSpeed = lerpSpeed;
		this.distanceFromProduct = distanceFromProduct;
		this.target = target;

		//Start Lerp
		if(CanMove == null || CanMove(gameObject)){
			BeginHandleLerp();
		}
	}

	/// <summary>
	/// Ceases the lerp action of an object immediatley, needed for certain interrupts
	/// </summary>
	public void StopLerpTo() {
		StopHandleLerp();
	}
#endregion
}


