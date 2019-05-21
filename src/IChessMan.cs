namespace SolarWinds.MSP.Chess
{
    public interface IChessMan
    {
        bool IsValidMove(MovementType movType, int newXCoord, int newYCoord);
    }
}
