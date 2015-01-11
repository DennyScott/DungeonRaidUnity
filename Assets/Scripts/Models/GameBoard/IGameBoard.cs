using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IGameBoard {

    List<List<GamePieceModel>> GetRows();

    List<GamePieceModel> GetRow(int row);

    List<GamePieceModel> GetColumn(int y);

    void AddGamePiece(GamePieceModel gp, int y, int x);
    
    GamePieceModel GetGamePiece(int y, int x);
    
    GamePieceModel RemoveGamePiece(int y, int x);

    List<GamePieceModel> RemoveRow(int row);

    List<GamePieceModel> RemoveColumn(int column);

    void RemoveList(List<GamePieceModel> toRemove);

    bool IsFull();

    bool IsEmpty();

}
