﻿using UnityEngine;

public class GamePiece : Mediator {
	
	#region Private Variables
	private bool isLerping;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float startTime;
	private float journeyLength;

	#endregion

	#region Public Variables
	private int _row;
	private int _column;
	public float _speed = 1.0F;
	public float _smooth = 5.0F;

	#endregion

	#region Delegates
	public delegate void GamePieceEvent(GameObject g);

	#endregion

	#region Events
	public event GamePieceEvent OnClickDown;
	public event GamePieceEvent OnClickUp;
	public event GamePieceEvent OnMouseEnterPiece;
	public event GamePieceEvent OnMouseExitPiece;
	public event GamePieceEvent OnStartLerp;
	public event GamePieceEvent OnStopLerp;
	public event GamePieceEvent OnRemovePiece;
	#endregion
	
	#region Standard Methods
	void FixedUpdate () {
		if (isLerping) {
			float distCovered = (Time.time - startTime) * _speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

			if(fracJourney>=1.0f) {
				StopLerp();
			}
		}
	}
	#endregion

	#region Movement Controls

	/// <summary>
	/// Sets the position of the piece in terms of column and row
	/// </summary>
	/// <param name="row">The game pieces row.</param>
	/// <param name="column">The game pieces column.</param>
	public void SetPosition(int row, int column) {
		_row = row;
		_column = column;
	}

	/// <summary>
	/// Stops the lerping of this object, as well as emits the OnStopLerp event
	/// </summary>
	public void StopLerp() {
		isLerping = false;
		if(OnStopLerp != null) {
			OnStopLerp(gameObject);
		}
	}

	/// <summary>
	/// Starts the lerp for this object, as well as emits the OnStartLerpEvent
	/// </summary>
	/// <param name="endPosition">End position.</param>
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

	/// <summary>
	/// 	Used to remove a piece from the gameboard
	/// </summary>
	public void RemovePiece() {
		TriggerOnRemovePiece();
		Destroy(gameObject);
	}
	#endregion

	#region Event Handling

	/// <summary>
	/// Raises the mouse down event, and emits the OnClickDown event.
	/// </summary>
	void OnMouseDown() {
		if(OnClickDown != null) {
			OnClickDown(gameObject);
		}
	}

	/// <summary>
	/// Raises the mouse up event and emits the OnClickUp event.
	/// </summary>
	void OnMouseUp() {
		if(OnClickUp != null) {
			OnClickUp(gameObject);
		}
	}

	/// <summary>
	/// Raises the mouse enter event, and emits the OnMouseEnterPiece event.
	/// </summary>
	void OnMouseEnter() {
		if(OnMouseEnterPiece != null) {
			OnMouseEnterPiece(gameObject);
		}
	}

	/// <summary>
	/// Raises the mouse exit event, and emits the OnMouseExitPiece event.
	/// </summary>
	void OnMouseExit() {
		if(OnMouseExitPiece != null) {
			OnMouseExitPiece(gameObject);
		}
	}

	/// <summary>
	/// 	Removes the gameObject from the board, and calls all listening handlers
	/// </summary>
	void TriggerOnRemovePiece() {
		if(OnRemovePiece != null) {
			OnRemovePiece(gameObject);
		}
	}
	#endregion

	public int Row {get; set;}

	public int Column{get; set;}
}
