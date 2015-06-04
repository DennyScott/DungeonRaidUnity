using UnityEngine;
using System.Collections;

public class GamePieceMovement : Grunt {

	#region Public Variables
	public float Speed = 1.0F;
	public float Smooth = 5.0F;
	#endregion

	#region Delatgates
	public System.Action<GameObject> OnGamePieceStartMove;
	public System.Action<GameObject> OnGamePieceStopMove;
	#endregion

	#region Movement Controls

	/// <summary>
	/// Starts the lerp for this object, as well as emits the OnStartLerpEvent
	/// </summary>
	/// <param name="endPosition">End position.</param>
	public void StartLerp(Vector3 endPosition) {
		StartCoroutine(MoveDown(endPosition));
	}

	/// <summary>
	/// Moves a piece down until it hits into the closeness threshold
	/// </summary>
	/// <param name="endPosition">The position the object should end at</param>
	/// <returns></returns>
	IEnumerator MoveDown(Vector3 endPosition) {

		//set all used variables
		var startPosition = transform.position;
		var startTime = Time.time;
		var journeyLength = Vector3.Distance(startPosition, endPosition);
		var distCovered = (Time.time - startTime) * Speed;
		var fracJourney = distCovered / journeyLength;

		//Call the OnGamePieceStartMove Action
		if (OnGamePieceStartMove != null) {
			OnGamePieceStartMove(gameObject);
		}

		//Start the coroutine to move down
		while (fracJourney >= 1.0f) {
			distCovered = (Time.time - startTime) * Speed;
			fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
			yield return null;
		}

		//Once the object is at the location, call the onStopLerp Action
		if (OnGamePieceStopMove != null) {
			OnGamePieceStopMove(gameObject);
		}
	}
	#endregion
}
