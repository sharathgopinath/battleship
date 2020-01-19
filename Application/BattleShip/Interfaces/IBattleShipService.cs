using Application.ViewModels;

namespace Application.BattleShip.Interfaces
{
    public interface IBattleShipService
    {
        GameProgressVM NewGame();
        GameProgressVM Attack(string coOrd, GameProgressVM gameProgressVM);
    }
}
