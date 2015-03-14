using UnityEngine;
using System.Collections;

/// <summary>
/// GameObject will follow the mouse, but continue following a central game
/// </summary>
/// 
public class FollowMouse : MonoBehaviour {

#region States
	public enum FollowState {IDLE, IS_MOVING}
	public FollowState currentState = FollowState.IDLE;
#endregion

	#region Public Variables
	public float distanceFromProduct;
	public float lerpSpeed;
	#endregion

	#region Delegates and Events
	public delegate void RotatorAction(GameObject go);
	public event RotatorAction RotatorClicked;
	public event RotatorAction RotatorReleased;

	//Hook to Allow or Disallow Movement
	public delegate bool IsAcceptable(GameObject go);
	public event IsAcceptable CanMove;

	#endregion

	#region Coroutines
	/// <summary>
	/// Moves the Rotator Handle to follow the mouse
	/// </summary>
	IEnumerator MoveHandle() {
		while (true) {
			transform.position = MouseXY();
			yield return null;
		}
	}	
	#endregion

	#region Private Methods
	/// <summary>
	/// Finds the current mouse position on the screen
	/// </summary>
	/// <returns>The mouse xy coordinates.</returns>
	private Vector2 MouseXY() {
		return new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
	}

	#endregion

	#region Public Methods
	/// <summary>
	/// Public Call to Start Follow Mouse Functionality. The Game Object this component is 
	/// attached to will begin to follow the mouse.
	/// </summary>
	public void StartFollowMouse() {
		if(CanMove == null || CanMove(gameObject)){
			TriggerObjectClicked();
		}
	}

	/// <summary>
	/// Public call to Stop the Follow Mouse Functionality.
	/// </summary>
	public void StopFollowMouse() {
		TriggerObjectReleased();
	}
#endregion

#region Trigger Events
	/// <summary>
	/// Allows the button to move and the product to rotate
	/// </summary>
	private void TriggerObjectClicked() {
		currentState = FollowState.IS_MOVING; 
		if (RotatorClicked != null) {
			RotatorClicked(gameObject);
		}
		StartCoroutine("MoveHandle");
	}

	/// <summary>
	/// Disallows the button to move and the product from rotating
	/// </summary>
	private void TriggerObjectReleased() {
		currentState = FollowState.IDLE;
		if (RotatorReleased != null) {
			RotatorReleased(gameObject);
		}
		StopCoroutine("MoveHandle");
	}
	#endregion
}


