using UnityEngine;

public class GamePieceGenerator : Generator {

    #region Serialized Variables
    [SerializeField]
    [Tooltip("The GamePiece GameObject that individual pieces are ALWAYS children of")]
    private GameObject _gamePiece;
    
    [SerializeField]
    [Tooltip("All the different game peice types that can be instantiated")] 
    private GamePieceElements _elementTypes;

    [SerializeField]
    [Tooltip("The Offsets needed when spawning pieces")]
    private GamePiecePlacement _gamePiecePlacement;

    #endregion

    #region Private Variables
    private GameObject _allPieces;                  //The empty GameObject that will contain all GamePieces GameObjects as children
    private Transform _allPiecesTransform;          //The transform of the allPieces GameObject
    private GamePieceManager _gamePieceManager;     //The GamePieceManager
    #endregion

    #region Initialize Methods
    public override void Initialize() {
        _allPieces = new GameObject("GamePieces");
        _allPiecesTransform = _allPieces.transform;
        _gamePieceManager = Managers.GamePieceManager;
    }

    #endregion

    #region Create GamePiece

    /// <summary>
    /// Creates a new element game piece.
    /// </summary>
    /// <returns>The new gameObject of the element.</returns>
    /// <param name="element">The gameObject to Create</param>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    private GameObject CreateElement(GameObject element, float x, float y) {
        var newPiece = Instantiate(_gamePiece);
        var newGraphic = Instantiate(element);
        var pTrans = newPiece.transform;
        var gTrans = newGraphic.transform;
        gTrans.parent = pTrans;
        gTrans.position = Vector3.zero;
        pTrans.position = new Vector3(x, y, 0.0f);
        pTrans.parent = _allPiecesTransform;
        return newPiece;
    }

    /// <summary>
    /// Creates the a game piece at the given x y coordinate
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    public void CreatePiece(int x, int y) {
        var startX = x + _gamePiecePlacement.Offset;
        var newPiece = CreateElement(_elementTypes.GetRandomElement(), startX, _gamePiecePlacement.StartY);
        _gamePieceManager.RegisterPiece(newPiece, x, y);
    }

    #endregion

}
