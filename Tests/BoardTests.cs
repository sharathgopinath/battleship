using Application.BattleShip;
using Application.BattleShip.Interfaces;
using Xunit;

namespace Tests
{
    public class BoardTests
    {
        private readonly IBoard _board;
        public BoardTests()
        {
            _board = new Board();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("z1")]
        [InlineData("z0")]
        [InlineData("jbkjb")]
        [InlineData("0000")]
        [InlineData("a100")]
        [InlineData("a0")]
        public void InvalidCoOrdinates(string coOrd)
        {
            var isValid = _board.ValidateCoOrdinate(coOrd);

            Assert.False(isValid);
        }

        [Theory]
        [InlineData("a1")]
        [InlineData("a10")]
        [InlineData("j1")]
        [InlineData("j10")]
        [InlineData("c4")]
        public void ValidCoOrdinates(string coOrd)
        {
            var isValid = _board.ValidateCoOrdinate(coOrd);

            Assert.True(isValid);
        }
    }
}
