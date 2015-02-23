using UnityEngine;
using System.Collections;

public class GamePiece : MonoBehaviour {
	//Private variables
	private bool isLerping = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float startTime;
	private float journeyLength;

	//Public variables
	public int row;
	public int column;
	public float speed = 1.0F;
	public float smooth = 5.0F;

	//Delegates
	public delegate void GamePieceEvent(GameObject g);

	//Events
	public event GamePieceEvent OnClickDown;
	public event GamePieceEvent OnClickUp;
	public event GamePieceEvent OnMouseEnterPiece;
	public event GamePieceEvent OnMouseExitPiece;
	public event GamePieceEvent OnStartLerp;
	public event GamePieceEvent OnStopLerp;

	
	// Update is called once per frame
	void FixedUpdate () {
		if (isLerping) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

			if(fracJourney>=1.0f) {
				StopLerp();
			}
		}
	}

	//Movement Controls
	public void SetPosition(int row, int column) {
		this.row = row;
		this.column = column;
	}

	public void StopLerp() {
		isLerping = false;
		if(OnStopLerp != null) {
			OnStopLerp(gameObject);
		}
	}

	public void StartLerp(Vector3 endPosition) {
		isLerping = true;
		startPosition = transform.position;
		this.endPosition = endPosition;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startPosition, this.endPosition);
		if(OnStartLerp != null) {
			OnStartLerp(gameObject);
		}
	}
	//End of Movement Controls

	//Unity Event Handling
	void OnMouseDown() {
		if(OnClickDown != null) {
			OnClickDown(gameObject);
		}
	}

	void OnMouseUp() {
		if(OnClickUp != null) {
			OnClickUp(gameObject);
		}
	}

	void OnMouseEnter() {
		if(OnMouseEnterPiece != null) {
			OnMouseEnterPiece(gameObject);
		}
	}

	void OnMouseExit() {
		if(OnMouseExitPiece != null) {
			OnMouseExitPiece(gameObject);
		}
	}
}
