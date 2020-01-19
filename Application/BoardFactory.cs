using Application.BattleShip;
using Application.BattleShip.Interfaces;

namespace Application
{
    public class BoardFactory : IBoardFactory
    {
        public IBoard GetBattleShipBoard()
        {
            return new Board { ProgressState = new ProgressState() };
        }
    }
}
