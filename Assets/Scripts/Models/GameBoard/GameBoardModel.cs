using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoardModel : IGameBoard {

    private List<GameBoardRow> board;
    private int maxRows, maxColumns; 

//	public GamePieceModel[] gamePeiceTypes = [];

    public GameBoardModel(int maxRows, int maxColumns) {
        this.maxRows = maxRows;
        this.maxColumns = maxColumns;
        board = new List<GameBoardRow>();
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
        return board[row].GetRowPeices();
    }

    public List<GamePieceModel> GetColumn(int x){
        var columnCollection = new List<GamePieceModel>();
        for (int i = 0; i < board.Count; i++) {
            columnCollection.Add(GetGamePiece(i, x));
        }

        return columnCollection;
    }

    public void AddGamePiece(GamePieceModel gp, int row, int column){
        board[row].GetSlot(column).AddGamePiece(gp);  
    }

    public GamePieceModel GetGamePiece(int row, int column){
        return board[row].GetSlot(column).gamePiece;
    }

    public GamePieceModel RemoveGamePiece(int row, int column){
        return board[row].GetSlot(column).RemoveGamePiece();
    }

    public List<GamePieceModel> RemoveRow(int row) {
        List<GamePieceModel> toReturn = new List<GamePieceModel>();
        for (int i = 0; i < board[row].Count; i++){
            toReturn.Add(board[row].GetSlot(i).RemoveGamePiece());
        }

        return toReturn;
    }

    public List<GamePieceModel> RemoveColumn(int column){
        var toReturn = new List<GamePieceModel>();
        for (int i = 0; i < board.Count; i++) {
            toReturn.Add(board[i].GetSlot(column).RemoveGamePiece());
        }
        return toReturn;
    }

	public int Count {
		get {
			int count = 0;
			foreach(List<GamePieceModel> row in board) {
				count += row.Count;
			}
		}
	}

    public void RemoveList (List<GamePieceModel> toRemove) {
        for (int i = 0; i < toRemove.Count; i++) {
            RemoveGamePiece(toRemove[i].y, toRemove[i].x);
        }
    }

    public bool IsFull (){
        for (int i = 0; i < maxRows; i++){
            for (int j = 0; j < maxColumns; j++) {
                if(board[i].GetSlot(j).IsEmpty()){
                    return false;
                }
            }          
        }

        return true;
    }

    public bool IsEmpty() {
        for (int i = 0; i < maxRows; i++){
            for (int j = 0; j < maxColumns; j++) {
                if(!board[i].GetSlot(j).IsEmpty()){
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
            row.Add(new GameBoardSlot(CreateRandomGamePeice(column, i)));

        }

        return row;
    }

	private GamePieceModel CreateRandomGamePeice(int x, int y) {
		int randomNum = (int) Mathf.Floor(Random.Range(0, 4));

		if(randomNum == 0) {
			return new FireModel(x, y);
		} else if (randomNum == 1) {
			return new WaterModel(x, y);
		} else if (randomNum == 2) {
			return new EarthModel(x, y);
		} else {
			return new AirModel(x, y);
		}
	}

}
