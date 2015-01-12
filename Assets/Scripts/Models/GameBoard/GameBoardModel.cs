using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardModel : IGameBoard {

    private List<List<GameBoardSlot>> board;
    private int maxRows, maxColumns; 

    public GameBoardModel(int maxRows, int maxColumns) {
        this.maxRows = maxRows;
        this.maxColumns = maxColumns;
        board = new List<List<GameBoardSlot>>();
        CreateGameBoard();
    }

    public List<List<GamePieceModel>> GetBoard() {
        var returnBoard = new List<List<GamePieceModel>>();
        for (int i = 0; i < board.Count; i++) {
            returnBoard.Add(GetRow(i));
        }
        return returnBoard;
    }

    public List<GamePieceModel> GetRow(int row){
        var returnBoard = new List<GamePieceModel>();
        for (int i = 0; i < board[row].Count; i++) {
            returnBoard.Add(board[row][i].gamePiece); 
        }
        return returnBoard;        
    }

    public List<GamePieceModel> GetColumn(int x){
        var columnCollection = new List<GamePieceModel>();
        for (int i = 0; i < board.Count; i++) {
            columnCollection.Add(GetGamePiece(i, x));
        }

        return columnCollection;
    }

    public void AddGamePiece(GamePieceModel gp, int row, int column){
        board[row][column].AddGamePiece(gp);  
    }

    public GamePieceModel GetGamePiece(int row, int column){
        return board[row][column].gamePiece;
    }

    public GamePieceModel RemoveGamePiece(int row, int column){
        return board[row][column].RemoveGamePiece();
    }

    public List<GamePieceModel> RemoveRow(int row) {
        List<GamePieceModel> toReturn = new List<GamePieceModel>();
        for (int i = 0; i < board[row].Count; i++){
            toReturn.Add(board[row][i].RemoveGamePiece());
        }

        return toReturn;
    }

    public List<GamePieceModel> RemoveColumn(int column){
        var toReturn = new List<GamePieceModel>();
        for (int i = 0; i < board.Count; i++) {
            toReturn.Add(board[i][column].RemoveGamePiece());
        }
        return toReturn;
    }

    public void RemoveList (List<GamePieceModel> toRemove) {
        for (int i = 0; i < toRemove.Count; i++) {
            RemoveGamePiece(toRemove[i].y, toRemove[i].x);
        }
    }

    public bool IsFull (){
        for (int i = 0; i < maxRows; i++){
            for (int j = 0; j < maxColumns; j++) {
                if(board[i][j].IsEmpty()){
                    return false;
                }
            }          
        }

        return true;
    }

    public bool IsEmpty() {
        for (int i = 0; i < maxRows; i++){
            for (int j = 0; j < maxColumns; j++) {
                if(!board[i][j].IsEmpty()){
                    return false;
                }
            }          
        }

        return true;
    }

    private void CreateGameBoard() {
        for (int i = 0; i < maxRows; i++) {
            board.Add(CreateRow(i));
        }
    }

    private List<GameBoardSlot> CreateRow(int column){
        var row = new List<GameBoardSlot>();

        for (int i = 0; i < maxColumns; i++) {
            row.Add(new GameBoardSlot(new GamePieceModel(column, i)));

        }

        return row;
    }


}
