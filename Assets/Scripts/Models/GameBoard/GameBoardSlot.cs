using UnityEngine;
using System.Collections;

public class GameBoardSlot {

    private GamePieceModel _gamePiece;
    private bool isEmpty = true;

    public GamePieceModel gamePiece {
        get { return _gamePiece; }
    }

    public bool IsEmpty() {
        return isEmpty;
    }

    public void AddGamePiece(GamePieceModel gp){
        _gamePiece = gp;
        isEmpty = false;
    }

    public GamePieceModel RemoveGamePiece(){
        if(isEmpty){
            return ;
        }
        GamePieceModel gp = gamePiece;
        _gamePiece = null;
        isEmpty = true;
        return gp;
    }    
}
