namespace _03_Battleship.ViewModel
{
    using System;
    using Model;
    using MVVMCore;

    internal class ShipToPlaceViewModel : NotifyingViewModel
    {
        private ShipType shipToPlaceType;
        private Ship ship;
        private Orientation shipOrientation;

        public ShipType ShipType
        {
            get
            {
                return this.shipToPlaceType;
            }

            set
            {
                this.shipToPlaceType = value;
                this.Notify(nameof(this.ShipText));
            }
        }

        public Ship Ship
        {
            get
            {
                return this.ship;
            }

            set
            {
                this.ship = value;
                this.Notify();
            }
        }

        public string ShipText
        {
            get
            {
                switch (this.ShipType)
                {
                    case ShipType.Undefined:
                        return "Ничего не выбрано.";
                    case ShipType.Carrier:
                        return "Авианосец";
                    case ShipType.Battleship:
                        return "Линкор";
                    case ShipType.Cruiser:
                        return "Крейсер";
                    case ShipType.Destroyer:
                        return "Эсминец";
                    case ShipType.Sub:
                        return "Катер";
                    default: throw new ArgumentOutOfRangeException(nameof(this.ShipType));
                }
            }
        }

        public Orientation ShipOrientation
        {
            get
            {
                return this.shipOrientation;
            }

            set
            {
                this.shipOrientation = value;
                this.Notify();
            }
        }

        public bool ValidPosition { get; set; }
    }
}
