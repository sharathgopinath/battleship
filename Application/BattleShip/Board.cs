using Application.BattleShip.Interfaces;
using System;
using System.Linq;

namespace Application.BattleShip
{
    public class Board : IBoard
    {
        public string ShipCO { get; set; }
        public ProgressState ProgressState { get; set; }

        private char[] colId = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
        private const int ShipSize = 3;

        public void PlaceShip()
        {
            var random = new Random();
            var shipOrientation = random.Next(1, 2);

            var colIndex = 0;
            var rowIndex = 1;
            if (shipOrientation == (int)ShipOrientation.Horizontal)
            {
                colIndex = random.Next(0, 6);
                rowIndex = random.Next(1, 10);
            }
            else
            {
                colIndex = random.Next(0, 9);
                rowIndex = random.Next(1, 7);
            }

            ShipCO = GetShipCoOrdinates((ShipOrientation)shipOrientation, rowIndex, colIndex);
        }

        private string GetShipCoOrdinates(ShipOrientation shipOrientation, int rowIndex, int colIndex)
        {
            var i = 1;
            var shipCo = string.Empty;
            while (i <= ShipSize)
            {
                shipCo += $"{colId[colIndex]}{rowIndex}";
                if (shipOrientation == ShipOrientation.Horizontal)
                    colIndex++;
                else
                    rowIndex++;

                i++;
            }

            return shipCo;
        }

        public bool ValidateCoOrdinate(string coOrd)
        {
            if (string.IsNullOrWhiteSpace(coOrd) || coOrd.Length < 2 || coOrd.Length > 3)
                return false;

            if (!colId.Contains(coOrd[0])) return false;

            var rowIndex = 0;
            if (!int.TryParse(coOrd[1].ToString(), out rowIndex)) return false;

            if (rowIndex < 1 || rowIndex > 10) return false;

            return true;
        }
    }

    public enum ShipOrientation
    {
        Horizontal=1,
        Vertical
    }
}
