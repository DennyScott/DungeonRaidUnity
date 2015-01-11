using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardModel : IGameBoard {

    private List<List<GamePieceModel>> rows;

    public GameBoardModel() {
        rows = new List<List<GamePieceModel>>();
        CreateGameBoard();
    }

    public List<List<GamePieceModel>> GetRows() {
        return rows;
    }

    public List<GamePieceModel> GetRow(int row){
        return GetRows()[row];
    }

    public List<GamePieceModel> GetColumn(int x){
        List<GamePieceModel> columnCollection = new List<GamePieceModel>();
        for (int i = 0; i < GameBoardConstants.ROWS; i++) {
            columnCollection.Add(GetGamePiece(i, x));
        }

        return columnCollection;
    }

    public void AddGamePiece(GamePieceModel gp, int y, int x){
        rows[y][x] = gp;
    }

    public GamePieceModel GetGamePiece(int y, int x){
        return rows[y][x];
    }

    public GamePieceModel RemoveGamePiece(int y, int x){
        GamePieceModel toReturn = rows[y][x];
        rows[y].RemoveAt(x);
        return toReturn;
    }

    public void RemoveList (List<GamePieceModel> toRemove) {
        for (int i = 0; i < toRemove.Count; i++) {
            RemoveGamePiece(toRemove[i].y, toRemove[i].x);
        }
    }

    private void CreateGameBoard() {
        for (int i = 0; i < GameBoardConstants.ROWS; i++) {
            rows.Add(CreateRow());
        }
    }

    private List<GamePieceModel> CreateRow(){
        List<GamePieceModel> row = new List<GamePieceModel>();

        for (int i = 0; i < GameBoardConstants.COLUMNS; i++) {
            row.Add(new GamePieceModel(new GameObject()));
        }

        return row;
    }


}
