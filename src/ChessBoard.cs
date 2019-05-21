namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;
        private readonly ChessMan[,] _pieces;

        public ChessBoard ()
        {
            _pieces = new ChessMan[MaxBoardWidth, MaxBoardHeight];
        }

        public void Add(ChessMan pawn, int xCoordinate, int yCoordinate)
        {
            if (!IsLegalBoardPosition(xCoordinate, yCoordinate) || _pieces[xCoordinate,yCoordinate] != null)
            {
                xCoordinate = -1;
                yCoordinate = -1;
            }
            else
            {
                _pieces[xCoordinate,yCoordinate] = pawn;
            }

            pawn.Set_X_Coord(xCoordinate);
            pawn.Set_Y_Coord(yCoordinate);
        }

        public void Move(ChessMan piece, int prevX, int prevY)
        {
            if (IsLegalBoardPosition(piece.Get_X_Coord(), piece.Get_Y_Coord()))
            {
                _pieces[prevX,prevY] = null;

                _pieces[piece.Get_X_Coord(),piece.Get_Y_Coord()] = piece;
            }
            else
            { 
                piece.Set_X_Coord(prevX);
                piece.Set_Y_Coord(prevY);
            }
        }

        public ChessMan GetChessManAtPosition(int x, int y)
        {
            ChessMan res = null;

            if (IsLegalBoardPosition(x, y))
            {
                res = _pieces[x,y];
            }

            return res;
        }

        public bool IsSpaceEmpty(int xCoordinate, int yCoordinate)
        {
            return _pieces[xCoordinate, yCoordinate] == null;
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return xCoordinate >= 0 && yCoordinate >= 0 &&
                   xCoordinate < MaxBoardWidth && yCoordinate < MaxBoardHeight;
        }
    }
}
