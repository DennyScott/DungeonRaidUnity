using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IGameBoardManager {

    bool CheckForMatch(GamePieceModel from, GamePieceModel to);

    List<GamePieceModel> FillGameBoard();

    void ChangeTypeToType(GamePieceModel fromType, GamePieceModel toType);

}
