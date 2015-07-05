using UnityEngine;

public partial class GamePiece {

    #region Initalize Methods
    public void InitalizeMovementStates() {
        _movementState.AddState(PieceMovementStates.Idle, new IdleState(this));
        _movementState.AddState(PieceMovementStates.Falling, new FallState(this));
        _movementState.AddState(PieceMovementStates.Selected, new SelectedState(this));
        _movementState.SetCurrentState(PieceMovementStates.Idle);
    }
    #endregion

    public abstract class ConcreteState : IFSMState {
       
        #region Protected Variables
        protected GamePiece GamePiece;          //The GamePiece that this Concrete state belongs to
        #endregion

        #region Constructors
        protected ConcreteState(GamePiece gamePiece) {
            GamePiece = gamePiece;
        }

        #endregion

        #region Inherited Members
        public virtual void OnEntry() {}

        public virtual void OnExit() {}

        #endregion

        #region Virtual Methods
        public virtual void Update() {}

        public virtual void SetPiecePosition(int row, int column) { }

        #endregion
    }

    public class IdleState : ConcreteState {
        
        #region Constructors
        public IdleState(GamePiece gamePiece) : base(gamePiece) { }

        #endregion

        #region Update Methods
        public override void SetPiecePosition(int row, int column) {
            base.SetPiecePosition(row, column);
            GamePiece.Row = row;
            GamePiece.Column = column;
            GamePiece._movementState.SetCurrentState(PieceMovementStates.Falling);
        }

        #endregion
    }

    public class FallState : ConcreteState {

        #region Private Variables
        private Vector3 _endPosition;
        private Vector3 _startPosition;
        private float _startTime;
        private float _journeyLength;
        private float _distCovered;
        private float _fracJourney;

        #endregion

        #region Constructors
        public FallState(GamePiece gamePiece) : base(gamePiece) { }
        #endregion

        #region OnEntry Methods
        public override void OnEntry() {
            base.OnEntry();
            GetEndPosition();
            SetUpMove();
            TriggerStartMove();
        }

        private void TriggerStartMove() {
            //Call the OnGamePieceStartMove Action
            if (GamePiece.OnGamePieceStartMove != null) {
                GamePiece.OnGamePieceStartMove(GamePiece.gameObject);
            }
        }

        private void GetEndPosition() {
            _endPosition = new Vector3(GamePiece.transform.position.x, GamePiece.Row - GamePiece.YOffset);
        }

        private void SetUpMove() {
            _startPosition = GamePiece.transform.position;
            _startTime = Time.time;
            _journeyLength = Vector3.Distance(_startPosition, _endPosition);
            _distCovered = (Time.time - _startTime) * GamePiece.Speed;
            _fracJourney = _distCovered / _journeyLength;
        }

        #endregion

        #region OnExit Methods

        public override void OnExit() {
            base.OnExit();
            TriggerStopMove();
            ResetVariables();
        }

        private void ResetVariables() {
            _endPosition = Vector3.zero;
            _startPosition = Vector3.zero;
            _startTime = 0.0f;
            _journeyLength = 0.0f;
            _distCovered = 0.0f;
            _fracJourney = 0.0f;
        }

        private void TriggerStopMove() {
            //Once the object is at the location, call the onStopLerp Action
            if (GamePiece.OnGamePieceStopMove != null) {
                GamePiece.OnGamePieceStopMove(GamePiece.gameObject);
            }
        }

        #endregion

        #region Update Methods

        public override void Update() {
            //Start the coroutine to move down
            if (!(_fracJourney < 1.0f)) {
                MoveCompleted();
                return;
            }
            MovePieceDown();
        }



        private void MovePieceDown() {
            _distCovered = (Time.time - _startTime) * GamePiece.Speed;
            _fracJourney = _distCovered / _journeyLength;
            GamePiece.transform.position = Vector3.Lerp(_startPosition, _endPosition, _fracJourney);
        }

        private void MoveCompleted() {
            GamePiece._movementState.SetCurrentState(PieceMovementStates.Idle);
        }

        #endregion
    }

    public class SelectedState : ConcreteState {
        
        #region Constructors
        public SelectedState(GamePiece gamePiece) : base(gamePiece) { }

        #endregion
    }
}
