using UnityEngine;
using System.Collections;

public class GameBoardManager : Manager {
    #region Private Variables

    private GameBoardModel _model;                      //The model that controls where pieces are
    private GamePieceGenerator _gamePieceGenerator;     //The game piece generator that creates game pieces

    #endregion

    #region Serialized Fields

    [SerializeField] 
    [Tooltip("The details on the size of the game board")] 
    private BoardDetails _boardDetails;

    [SerializeField] 
    [Tooltip("The details on spawning game objects like speed, etc.")] 
    private SpawnDetails _spawnDetails;

    #endregion

    #region Initialize Methods

    /// <summary>
    /// Runs when the scene starts
    /// </summary>
    public override void Initialize() {
        CollectManagersAndGenerators();
        CreateBoard();
    }

    /// <summary>
    /// Collects all needed Managers and Generators needed by this mono behavior
    /// </summary>
    private void CollectManagersAndGenerators() {
        _gamePieceGenerator = Generators.GamePieceGenerator;
    }

    /// <summary>
    /// Creates the board and then beings filling it.
    /// </summary>
    private void CreateBoard() {
        _model = new GameBoardModel(_boardDetails.Rows, _boardDetails.Columns);
    }

    #endregion

    #region Create Board Methods

    /// <summary>
    /// Runs at the start of the scene
    /// </summary>
    private void Start() {
        StartCoroutine(FillBoard());
    }

    /// <summary>
    /// Fills the board with GamePieces.
    /// </summary>
    /// <returns>Coroutine Enumerator</returns>
    private IEnumerator FillBoard() {
        yield return new WaitForSeconds(1.0f);
        for (var y = 0; y < _boardDetails.Rows; y++) {
            for (var x = 0; x < _boardDetails.Columns; x++) {
                if (CreatePieceAt(x, y)) {
                    yield return new WaitForSeconds(_spawnDetails.PieceWaitTime);
                }
            }
            yield return new WaitForSeconds(_spawnDetails.RowWaitTime);
        }
    }

    /// <summary>
    /// Creates a piece at the given position if it is empty.
    /// </summary>
    /// <param name="x">The row to create the piece at</param>
    /// <param name="y">The column to create the piece at</param>
    /// <returns>true if the piece was created, false if not</returns>
    private bool CreatePieceAt(int x, int y) {
        if (!_model.IsEmpty(x, y)) {
            return false;
        }
        _gamePieceGenerator.CreatePiece(x, y);
        return true;
    }

    #endregion
}