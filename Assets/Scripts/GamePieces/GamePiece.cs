using UnityEngine;
using System.Collections;

public class GamePiece : MonoBehaviour {
	private bool isLerping = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	public float smooth = 5.0F;
	
	// Use this for initialization
	void Start () {
	
	}

	void Update() {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isLerping) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

			if(fracJourney>=1.0f) {
				isLerping = false;
			}
		}
	}
	
	public void StartLerp(Vector3 endPosition) {
		isLerping = true;
		startPosition = transform.position;
		this.endPosition = endPosition;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startPosition, this.endPosition);
	}

	void OnMouseDown() {
		if(!isLerping) {
			Debug.Log ("Click!");
		}
	}
}
