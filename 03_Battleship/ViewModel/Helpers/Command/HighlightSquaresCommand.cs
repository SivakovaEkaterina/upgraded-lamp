namespace _03_Battleship.Command
{
    using System;
    using Model;
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    internal class HighlightSquaresCommand : BaseCommand
    {

        private BattleFieldAreaViewModel battleFieldAreaViewModel;

        private BattleFieldViewModel battleFieldViewModel;

        public HighlightSquaresCommand(BattleFieldAreaViewModel battleFieldAreaViewModel, BattleFieldViewModel battleFieldViewModel)
        {
            this.battleFieldAreaViewModel = battleFieldAreaViewModel;
            this.battleFieldViewModel = battleFieldViewModel;
        }

        public override void Execute(object parameter)
        {
            if (this.battleFieldViewModel.ShipToPlace.ShipType == ShipType.Undefined)
            {
                return;
            }

            Position position = (Position)parameter;
            Ship ship;
            switch (this.battleFieldViewModel.ShipToPlace.ShipType)
            {
                case ShipType.Battleship:
                    ship = new Battleship(position);
                    break;
                case ShipType.Carrier:
                    ship = new Carrier(position);
                    break;
                case ShipType.Cruiser:
                    ship = new Cruiser(position);
                    break;
                case ShipType.Destroyer:
                    ship = new Destroyer(position);
                    break;
                case ShipType.Sub:
                    ship = new Sub(position);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(this.battleFieldViewModel.ShipToPlace.ShipType));
            }

            ship.Orientation = this.battleFieldViewModel.ShipToPlace.ShipOrientation;
            this.battleFieldViewModel.ShipToPlace.Ship = ship;
            this.battleFieldAreaViewModel.ClearHighlighted();
            bool validPosition = this.battleFieldAreaViewModel.HighlightSquares(ship);

            if (!validPosition)
            {
                this.battleFieldViewModel.ShipToPlace.ValidPosition = false;
            }
            else
            {
                this.battleFieldViewModel.ShipToPlace.ValidPosition = true;
            }
        }
    }
}
