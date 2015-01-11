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
		gameboard = new GameBoardModel();
		firePieceOne = new FireModel();
		firePieceTwo = new FireModel();
	}
//	
//	[Test]
//	public void CheckForMatchOnMatchIsTrue() {
//		Assert.IsTrue(gameBoardController.CheckForMatch(gamePieceOne, gamePieceTwo));
//	}
}
