namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;

    public class ShipPositionsReceivedEventArgs : EventArgs
    {
        public ShipPositionsReceivedEventArgs(List<Ship> ships)
        {
            this.Ships = ships ?? throw new ArgumentNullException("Значение не должно быть равно нулю.");
        }

        public List<Ship> Ships
        {
            get;
            private set;
        }
    }
}