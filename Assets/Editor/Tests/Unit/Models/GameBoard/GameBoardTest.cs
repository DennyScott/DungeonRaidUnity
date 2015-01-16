using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
[Category("Game Board Testing")]
public class GameBoardTest {

    GameBoardModel gameboard;
    GamePieceModel gamePiece;
    int maxRows, maxColumns;

    [SetUp]
    public void Init() {
        maxRows = 10;
        maxColumns = 5;
        gameboard = new GameBoardModel(maxRows, maxColumns);
        gamePiece = new FireModel(1, 1);
    }

    [Test]
    public void CorrectAmountOfRowsCreated() {
        Assert.AreEqual(maxRows, gameboard.GetBoard().Count);
    }

    [Test]
    public void CorrectAmountOfColumnsCreated() {
        Assert.AreEqual(maxColumns, gameboard.GetRow(0).Count);
    }

    [Test]
    public void AddingGamePieceWillPlaceIntoGameBoardGettingWillReturn() {
        gameboard.AddGamePiece(gamePiece, 0, 0);
        Assert.AreEqual(gamePiece, gameboard.GetGamePiece(0, 0));
    }

    [Test]
    public void GetRowsReturnsAListOfList(){
        gameboard.AddGamePiece(gamePiece, 0, 0);
        Assert.AreEqual(gamePiece, gameboard.GetBoard()[0][0]);
    }

    [Test]
    public void GettingDataFromRowWorksCorrectly() {
        gameboard.AddGamePiece(gamePiece, 0, 0);
        Assert.AreEqual(gamePiece, gameboard.GetRow(0)[0]);
    }

    [Test]
    public void GetColumnReturnsColumnOfData() {
        gameboard.AddGamePiece(gamePiece, 0, 0);
        List<GamePieceModel> column = gameboard.GetColumn(0);
        Assert.AreEqual(gamePiece, column[0]);
        Assert.AreEqual(maxRows, column.Count);
    }

    [Test]
    public void RemoveGamePieceRemovesGamePieceFromList() {
        gameboard.AddGamePiece(gamePiece, 0, 0);
        Assert.AreEqual(gamePiece, gameboard.GetGamePiece(0,0));
        GamePieceModel removedNode = gameboard.RemoveGamePiece(0, 0);
        Assert.AreEqual(gamePiece, removedNode);
        Assert.AreNotEqual(gamePiece, gameboard.GetGamePiece(0,0));
    }

    [Test]
    public void RemoveListOfGamePiecesFromBoard() {
        gameboard.AddGamePiece(gamePiece, 0, 0);
        GamePieceModel secondPiece = new FireModel(1, 1);
        gameboard.AddGamePiece(gamePiece, 1, 0);
        List<GamePieceModel> gpList = new List<GamePieceModel>();
        gpList.Add(gamePiece);
        gpList.Add(secondPiece);
        gameboard.RemoveList(gpList);
        Assert.AreNotEqual(gamePiece, gameboard.GetGamePiece(0,0));
        Assert.AreNotEqual(secondPiece, gameboard.GetGamePiece(1, 0));
    }

    [Test]
    public void IsFullTrueWhenFullFalseOtherwise() {
        Assert.IsTrue(gameboard.IsFull());
        gameboard.RemoveGamePiece(0,0);
        Assert.IsFalse(gameboard.IsFull());
    }

    //[Test]
    //public void ReturnRowWillReturnARowsDataAndRemoveIt(){
        //gamePieceModel
    //}
}
