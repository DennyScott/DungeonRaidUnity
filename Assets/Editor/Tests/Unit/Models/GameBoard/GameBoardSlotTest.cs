using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
[Category("Game Board Slot Testing")]
public class GameBoardSlotTest {
    private GameBoardSlot gameboardSlot;
    private GamePieceModel gamePiece;

    [SetUp]
    public void Init() {
        gamePiece = new GamePieceModel();
        gameboardSlot = new GameBoardSlot(gamePiece);
    }

    [Test]
    public void GameBoardSlotStartsNotEmpty(){
        Assert.IsFalse(gameboardSlot.IsEmpty());
    }

    [Test]
    public void GameBoardSlotWithNoGamePieceInitIsEmpty() {
        gameboardSlot = new GameBoardSlot();
        Assert.IsTrue(gameboardSlot.IsEmpty());
    }

    [Test]
    public void gamePieceReturnsThePassedGamePieceModel() {
        Assert.AreEqual(gamePiece, gameboardSlot.gamePiece);
    }

    [Test]
    public void AddGamePieceAddsNewGamePiece(){
        GamePieceModel secondPiece = new GamePieceModel();
        gameboardSlot.AddGamePiece(secondPiece);
        Assert.AreEqual(secondPiece, gameboardSlot.gamePiece);
    }

    [Test]
    public void AddGamePieceSetsEmptyToTrue() {
        gameboardSlot = new GameBoardSlot();
        Assert.IsTrue(gameboardSlot.IsEmpty());
        gameboardSlot.AddGamePiece(gamePiece);
        Assert.IsFalse(gameboardSlot.IsEmpty());
    }

    [Test]
    public void RemoveGamePieceReturnsTheGamePiece() {
        Assert.AreEqual(gamePiece, gameboardSlot.RemoveGamePiece());
    }

    [Test]
    public void RemoveGamePieceSetsEmptyToTrue() {
        gameboardSlot.RemoveGamePiece();
        Assert.IsTrue(gameboardSlot.IsEmpty());
    }

    [Test]
    public void RemovingEmptyGamePieceReturnsNull() {
        gameboardSlot = new GameBoardSlot();
        Assert.AreEqual(null, gameboardSlot.RemoveGamePiece());
    }
}
