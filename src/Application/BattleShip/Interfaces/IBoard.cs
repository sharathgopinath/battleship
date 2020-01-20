using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BattleShip.Interfaces
{
    public interface IBoard
    {
        string ShipCO { get; set; }
        void PlaceShip();
        bool ValidateCoOrdinate(string coOrd);
    }
}
