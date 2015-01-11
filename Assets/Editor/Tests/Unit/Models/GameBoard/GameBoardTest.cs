using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
[Category("Game Board Testing")]
public class GameBoardTest {

    GameBoardModel gameboard;
    GamePieceModel gamePiece;

    [SetUp]
    public void Init() {
        gameboard = new GameBoardModel();
        gamePiece = new GamePieceModel(new GameObject());
    }

    [Test]
    public void CorrectAmountOfRowsCreated() {
        Assert.AreEqual(GameBoardConstants.ROWS, gameboard.GetRows().Count);
    }

    [Test]
    public void CorrectAmountOfColumnsCreated() {
        Assert.AreEqual(GameBoardConstants.COLUMNS, gameboard.GetRow(0).Count);
    }

    [Test]
    public void AddingGamePieceWillPlaceIntoGameBoard() {
        gameboard.AddGamePiece(gamePiece, 0, 0);
        Assert.AreEqual(gamePiece, gameboard.GetGamePiece(0, 0));
    }

    [Test]
    public void GetRowsReturnsAListOfList(){
        gameboard.AddGamePiece(gamePiece, 0, 0);
        Assert.AreEqual(gamePiece, gameboard.GetRows()[0][0]);
    }

    [Test]
    public void GettingDataFromRowWorksCorrectly() {
        gameboard.AddGamePiece(gamePiece, 0, 0);
        Assert.AreEqual(gamePiece, gameboard.GetRow(0));
    }
}
