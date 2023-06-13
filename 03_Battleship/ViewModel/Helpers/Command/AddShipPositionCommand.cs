namespace _03_Battleship.Command
{
    using System;
    using System.Linq;
    using Model;
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    internal class AddShipPositionCommand : BaseCommand
    {
        private BattleFieldViewModel battleFieldViewModel;
        private BattleFieldAreaViewModel battleFieldArea;
        private Client client;

        public AddShipPositionCommand(BattleFieldViewModel battleFieldViewModel, BattleFieldAreaViewModel battleFieldArea, Client client)
        {
            this.battleFieldViewModel = battleFieldViewModel;
            this.battleFieldArea = battleFieldArea;
            this.client = client;
        }

        public override void Execute(object parameter)
        {
            if (this.battleFieldArea.Ships.Count < 5 && this.battleFieldViewModel.ShipToPlace.ValidPosition)
            {
                switch (this.battleFieldViewModel.ShipToPlace.ShipType)
                {
                    case ShipType.Carrier:
                        this.battleFieldViewModel.Toolbar.CarrierEnabled = false;
                        break;
                    case ShipType.Battleship:
                        this.battleFieldViewModel.Toolbar.BattleshipEnabled = false;
                        break;
                    case ShipType.Cruiser:
                        this.battleFieldViewModel.Toolbar.CruiserEnabled = false;
                        break;
                    case ShipType.Destroyer:
                        this.battleFieldViewModel.Toolbar.DestroyerEnabled = false;
                        break;
                    case ShipType.Sub:
                        this.battleFieldViewModel.Toolbar.SubEnabled = false;
                        break;
                    case ShipType.Undefined:
                        return;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(this.battleFieldViewModel.ShipToPlace.ShipType));
                }

                Ship ship = this.battleFieldViewModel.ShipToPlace.Ship;
                this.battleFieldArea.AddShip(ship);
                this.battleFieldViewModel.Toolbar.RandomPositionsEnabled = false;
                this.battleFieldViewModel.ShipToPlace.ShipType = ShipType.Undefined;
                this.battleFieldArea.ClearHighlighted();

                if (this.battleFieldArea.Ships.Count == 5)
                {
                    this.client.SendShipPositions(this.battleFieldArea.Ships.ToList());
                    this.battleFieldViewModel.UserBattleFieldArea.DisableSquares();
                    this.battleFieldViewModel.OpponentFieldVisible = true;
                    this.battleFieldViewModel.ToolbarVisible = false;
                }
            }
        }
    }
}
