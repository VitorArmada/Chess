using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;  

namespace SolarWinds.MSP.Chess
{
    [TestClass]
	public class ChessBoardTest
	{
		private ChessBoard _chessBoard;

        [TestInitialize]
		public void SetUp()
		{
			_chessBoard = new ChessBoard();
		}

        [TestMethod]
		public void Has_MaxBoardWidth_of_8()
		{
			Assert.AreEqual(ChessBoard.MaxBoardWidth, 8);
		}

        [TestMethod]
		public void Has_MaxBoardHeight_of_8()
		{
			Assert.AreEqual(ChessBoard.MaxBoardHeight, 8);
		}

        [TestMethod]
		public void IsLegalBoardPosition_True_X_equals_0_Y_equals_0()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 0);
			Assert.IsTrue(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_True_X_equals_5_Y_equals_5()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(5, 5);
            Assert.IsTrue(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_5()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(11, 5);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_X_equals_0_Y_equals_9()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 9);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_0()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(11, 0);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_For_Negative_X_Values()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(-1, 5);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_For_Negative_Y_Values()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(5, -1);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void Avoids_Duplicate_Positioning()
		{
			var firstPawn = new Pawn(PieceColor.Black, _chessBoard);
			var secondPawn = new Pawn(PieceColor.Black, _chessBoard);
			_chessBoard.Add(firstPawn, 6, 3);
			_chessBoard.Add(secondPawn, 6, 3);
			Assert.AreEqual(firstPawn.Get_X_Coord(), 6);
            Assert.AreEqual(firstPawn.Get_Y_Coord(), 3);
            Assert.AreEqual(secondPawn.Get_X_Coord(), -1);
            Assert.AreEqual(secondPawn.Get_Y_Coord(), -1);
		}

        [TestMethod]
		public void Limits_The_Number_Of_Pawns()
		{
			for (var i = 0; i < 10; i++)
			{
				var pawn = new Pawn(PieceColor.Black, _chessBoard);
				var row = i / ChessBoard.MaxBoardWidth;
				_chessBoard.Add(pawn, 7 + row, i % ChessBoard.MaxBoardWidth);
				if (row < 1)
				{
					Assert.AreEqual(pawn.Get_X_Coord(), (7 + row));
					Assert.AreEqual(pawn.Get_Y_Coord(), (i % ChessBoard.MaxBoardWidth));
				}
				else
				{
					Assert.AreEqual(pawn.Get_X_Coord(), -1);
                    Assert.AreEqual(pawn.Get_Y_Coord(), -1);
				}
			}
		}
    }
}
