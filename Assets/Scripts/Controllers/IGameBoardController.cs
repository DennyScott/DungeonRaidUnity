using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IGameBoardController {

    bool CheckForMatch(GamePieceModel from, GamePieceModel to);

    void FillGameBoard();

    void ChangeTypeToType(GamePieceModel fromType, GamePieceModel toType);

    void RemoveType(GamePieceModel type);

	void ClearGameBoard();

	bool IsGameBoardEmpty();

	bool IsGameBoardFull();
}
