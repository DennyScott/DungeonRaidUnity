using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardModel {

	private List<List<GamePieceModel>> rows;

	public GameBoardModel() {
        rows = new List<List<GamePieceModel>>();
        CreateGameBoard();
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

    public List<List<GamePieceModel>> GetRows() {
        return rows;
    }

    public List<GamePieceModel> GetRow(int row){
        return GetRows()[row];
    }

    public void AddGamePiece(GamePieceModel gp, int y, int x){
        rows[y][x] = gp;
    }

    public GamePieceModel GetGamePiece(int y, int x){
        return rows[y][x];
    }

}
