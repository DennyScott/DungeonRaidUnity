using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
[Category("Game Board Controller Testing")]
public class GameBoardControllerTest {

	GameBoardController gameBoardController;
	GameBoardModel gameboard;
	GamePieceModel firePieceOne;
	GamePieceModel firePieceTwo;
	GamePieceModel waterPieceOne;
	GamePieceModel waterPieceTwo;
	GamePieceModel earthPieceOne;
	GamePieceModel earthPieceTwo;
	GamePieceModel airPieceOne;
	GamePieceModel airPieceTwo;
	
	[SetUp]
	public void Init() {
		gameBoardController = new GameBoardController();
		firePieceOne = new FireModel();
		firePieceTwo = new FireModel();
		waterPieceOne = new WaterModel();
		waterPieceTwo = new WaterModel();
		earthPieceOne = new EarthModel();
		earthPieceTwo = new EarthModel();
		airPieceOne = new AirModel();
		airPieceTwo = new AirModel();
	}
	
	[Test]
	public void CheckForMatchOnMatchIsTrue() {
		Assert.IsTrue(gameBoardController.CheckForMatch(firePieceOne, firePieceTwo));
		Assert.IsTrue(gameBoardController.CheckForMatch(waterPieceOne, waterPieceTwo));
		Assert.IsTrue(gameBoardController.CheckForMatch(earthPieceOne, earthPieceTwo));
		Assert.IsTrue(gameBoardController.CheckForMatch(airPieceOne, airPieceTwo));
	}

	[Test]
	public void CheckForMatchOnNonMatchIsNotTrue() {
		Assert.IsTrue(gameBoardController.CheckForMatch(firePieceOne, waterPieceTwo));
		Assert.IsTrue(gameBoardController.CheckForMatch(waterPieceOne,earthPieceTwo ));
		Assert.IsTrue(gameBoardController.CheckForMatch(earthPieceOne, airPieceTwo));
		Assert.IsTrue(gameBoardController.CheckForMatch(airPieceOne, firePieceTwo));
	}

	[Test]
	public void CheckFillGameBoard() {
		gameBoardController.ClearGameBoard();
		gameBoardController.FillGameBoard();
		Assert.IsFalse(gameBoardController.IsGameBoardEmpty());
		Assert.IsTrue(gameBoardController.IsGameBoardFull());
	}

	[Test]
	public void CheckClearGameBoard() {
		gameBoardController.FillGameBoard();
		gameBoardController.ClearGameBoard();
		Assert.IsTrue(gameBoardController.IsGameBoardEmpty());
		Assert.IsFalse(gameBoardController.IsGameBoardFull());
	}

	[Test]
	public void CheckIsGameBoardEmpty() {
		gameBoardController.ClearGameBoard();
		Assert.IsTrue(gameBoardController.IsGameBoardEmpty());
		gameBoardController.FillGameBoard();
		Assert.IsFalse(gameBoardController.IsGameBoardEmpty());
	}

	[Test]
	public void CheckIsGameBoardFull() {
		gameBoardController.ClearGameBoard();
		Assert.IsFalse(gameBoardController.IsGameBoardFull());
		gameBoardController.FillGameBoard();
		Assert.IsTrue(gameBoardController.IsGameBoardFull());
	}
}
