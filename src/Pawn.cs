using System;

namespace SolarWinds.MSP.Chess
{
    public class Pawn : ChessMan
    {
        public Pawn(PieceColor pieceColor, ChessBoard board) : base(pieceColor, board) {}

        public override bool IsValidMove(MovementType movementType, int newXCoordCoord, int newYCoordCoord)
        {
            var res = false;

            if (!Get_ChessBoard().IsLegalBoardPosition(newXCoordCoord, newYCoordCoord)) return false;

            if (movementType == MovementType.Move)
            {
                res = Get_ChessBoard().IsSpaceEmpty(newXCoordCoord, newYCoordCoord) && newXCoordCoord == Get_X_Coord() && newYCoordCoord == (Get_Y_Coord() + (1 * GetYMoveDirection()));
            }
            else if (movementType == MovementType.Capture)
            {
                res = !Get_ChessBoard().IsSpaceEmpty(newXCoordCoord, newYCoordCoord) && (newXCoordCoord == (Get_X_Coord() + 1) || newXCoordCoord == (Get_X_Coord() - 1)) && newYCoordCoord == (Get_Y_Coord() + (1 * GetYMoveDirection())) &&
                           Get_ChessBoard().GetChessManAtPosition(newXCoordCoord, newYCoordCoord).GetPieceColor() != GetPieceColor();
            }

            return res;
        }
    }
}
