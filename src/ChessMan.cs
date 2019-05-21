using System;

namespace SolarWinds.MSP.Chess
{
    public abstract class ChessMan : IChessMan
    {
        private ChessBoard _chessBoard;
        private int _xCoordinate;
        private int _yCoordinate;
        private PieceColor _pieceColor;

        protected ChessMan(PieceColor pieceColor, ChessBoard chessBoard)
        {
            _pieceColor = pieceColor;
            _chessBoard = chessBoard;
        }

        public ChessBoard Get_ChessBoard()
        {
            return _chessBoard;
        }

        public void Set_ChessBoard(ChessBoard chessBoard)
        {
            _chessBoard = chessBoard;
        }

        public int Get_X_Coord()
        {
            return _xCoordinate;
        }

        public void Set_X_Coord(int value)
        {
            _xCoordinate = value;
        }

        public int Get_Y_Coord()
        {
            return _yCoordinate;
        }

        public void Set_Y_Coord(int value)
        {
            _yCoordinate = value;
        }

        public PieceColor GetPieceColor()
        {
            return _pieceColor;
        }

        private void SetPieceColor(PieceColor value)
        {
            _pieceColor = value;
        }

        public void Move(MovementType movementType, int newXCoord, int newYCoord)
        {
            if (!IsValidMove(movementType, newXCoord, newYCoord)) return;

            var prevXCoord = _xCoordinate;
            var prevYCoord = _yCoordinate;

            Set_X_Coord(newXCoord);
            Set_Y_Coord(newYCoord);

            Get_ChessBoard().Move(this, prevXCoord, prevYCoord);
        }

        public abstract bool IsValidMove(MovementType movementType, int newXCoord, int newYCoord);

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, _xCoordinate, _yCoordinate, _pieceColor);
        }

        protected int GetYMoveDirection()
        {
            if (GetPieceColor() == (PieceColor.Black))
            {
                return -1;
            }

            return 1;
        }
    }
}
