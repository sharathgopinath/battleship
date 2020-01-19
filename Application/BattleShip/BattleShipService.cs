using Application.BattleShip.Interfaces;
using Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Application
{
    public class BattleShipService : IBattleShipService
    {
        private readonly IBoardFactory _boardFactory;

        public BattleShipService(IBoardFactory boardFactory)
        {
            _boardFactory = boardFactory;
        }

        public GameProgressVM NewGame()
        {
            var board = _boardFactory.GetBattleShipBoard();
            board.PlaceShip();

            var gameProgressVM = new GameProgressVM
            {
                ShipCO = board.ShipCO,
                Hits = new List<string>(),
                Misses = new List<string>()
            };

            return gameProgressVM;
        }

        public GameProgressVM Attack(string coOrd, GameProgressVM gameProgressVM)
        {
            coOrd = coOrd.ToLower();
            var board = _boardFactory.GetBattleShipBoard();

            if (!board.ValidateCoOrdinate(coOrd))
                throw new InvalidOperationException("Invalid Co-Ordinate.");

            gameProgressVM.Hits = gameProgressVM.Hits ?? new List<string>();
            gameProgressVM.Misses = gameProgressVM.Misses ?? new List<string>();

            if (gameProgressVM.ShipCO.Contains(coOrd))
            {
                if (!gameProgressVM.Hits.Contains(coOrd))
                    gameProgressVM.Hits.Add(coOrd);
            }
            else
            {
                if (!gameProgressVM.Misses.Contains(coOrd))
                    gameProgressVM.Misses.Add(coOrd);
            }

            return gameProgressVM;
        }
    }
}
