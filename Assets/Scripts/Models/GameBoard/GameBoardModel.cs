using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardModel : IGameBoard {

    private List<List<GamePieceModel>> board;
    private int maxRows, maxColumns; 

    public GameBoardModel(int maxRows, int maxColumns) {
        this.maxRows = maxRows;
        this.maxColumns = maxColumns;
        board = new List<List<GamePieceModel>>();
        CreateGameBoard();
    }

    public List<List<GamePieceModel>> GetRows() {
        return board;
    }

    public List<GamePieceModel> GetRow(int row){
        return GetRows()[row];
    }

    public List<GamePieceModel> GetColumn(int x){
        List<GamePieceModel> columnCollection = new List<GamePieceModel>();
        for (int i = 0; i < board.Count; i++) {
            columnCollection.Add(GetGamePiece(i, x));
        }

        return columnCollection;
    }

    public void AddGamePiece(GamePieceModel gp, int row, int column){
        
        if(board.Count < y){

        }
        if(x.Count < x){
            
        }
        gp.x = x;
        gp.y = y;
        board[y][x] = gp;
    }

    public GamePieceModel GetGamePiece(int row, int column){
        return board[row][column];
    }

    public GamePieceModel RemoveGamePiece(int row, int column){
        GamePieceModel toReturn = board[row][column];
        board[row].RemoveAt(x);
        return toReturn;
    }

    public List<GamePieceModel> RemoveRow(int row) {
        List<GamePieceModel> toReturn = new List<GamePieceModel>();
        for (int i = 0; i < board[row].Count; i++){
            toReturn = board[row][i];
            RemoveGamePiece(row, i);
        }

        return toReturn;
    }

    public List<GamePieceModel> RemoveColumn(int column){

    }

    public void RemoveList (List<GamePieceModel> toRemove) {
        for (int i = 0; i < toRemove.Count; i++) {
            RemoveGamePiece(toRemove[i].y, toRemove[i].x);
        }
    }

    public bool IsFull (){
        for (int i = 0; i < maxRows; i++){
            if(board[i].Count < maxColumns){
                return false;
            }            
        }

        return true;
    }

    private bool i

    private void CreateGameBoard() {
        for (int i = 0; i < maxRows; i++) {
            board.Add(CreateRow(i));
        }
    }

    private List<GamePieceModel> CreateRow(int column){
        List<GamePieceModel> row = new List<GamePieceModel>();

        for (int i = 0; i < maxColumns; i++) {
            row.Add(new GamePieceModel(column, i));
        }

        return row;
    }


}
