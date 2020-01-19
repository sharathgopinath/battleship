using System;
using System.Collections.Generic;
using Application;
using Application.BattleShip;
using Application.BattleShip.Interfaces;
using Application.ViewModels;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class BoardServiceTests
    {
        private readonly IBattleShipService _sutBattleShipService;
        private readonly IBoardFactory _boardFactory;

        public BoardServiceTests()
        {
            _boardFactory = Substitute.For<IBoardFactory>();
            _sutBattleShipService = new BattleShipService(_boardFactory);
        }

        [Fact]
        public void NewGame_PlacesBattleShip()
        {
            var board = new Board { ProgressState = new ProgressState() };
            _boardFactory.GetBattleShipBoard().Returns(board);

            var newBoard = _sutBattleShipService.NewGame();

            Assert.False(string.IsNullOrWhiteSpace(newBoard.ShipCO));
        }

        [Fact]
        public void Attack_InvalidCoOrd_Exception()
        {
            var board = new Board { ProgressState = new ProgressState() };
            _boardFactory.GetBattleShipBoard().Returns(board);
            var vm = new GameProgressVM
            {
                ShipCO = "a1,b1,c1"
            };

            Assert.Throws<InvalidOperationException>(() => { _sutBattleShipService.Attack("abc", vm); });
        }

        [Fact]
        public void Attack_UpdatesProgress_When_Hits()
        {
            var board = new Board { ProgressState = new ProgressState() };
            _boardFactory.GetBattleShipBoard().Returns(board);
            var vm = new GameProgressVM
            {
                ShipCO = "a1,b1,c1",
                Hits = new List<string> { "a1" }
            };

            var updatedVM = _sutBattleShipService.Attack("b1", vm);

            Assert.True(updatedVM.Hits.Contains("b1"));
        }

        [Fact]
        public void Attack_UpdatesProgress_When_Misses()
        {
            var board = new Board { ProgressState = new ProgressState() };
            _boardFactory.GetBattleShipBoard().Returns(board);
            var vm = new GameProgressVM
            {
                ShipCO = "a1,b1,c1",
                Hits = new List<string> { "a1" },
                Misses = new List<string> { "b2" }
            };

            var updatedVM = _sutBattleShipService.Attack("a2", vm);

            Assert.True(updatedVM.Misses.Contains("a2"));
        }
    }
}
