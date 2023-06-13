namespace _03_Battleship.Command
{
    using System;
    using Model;
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    internal class RandomPositionsCommand : BaseCommand
    {
        private BattleFieldAreaViewModel battleFieldAreaViewModel;
        private BattleFieldViewModel battleFieldViewModel;
        private AddShipPositionCommand addShipPositionCommand;

        public RandomPositionsCommand(BattleFieldAreaViewModel battleFieldAreaViewModel, BattleFieldViewModel battleFieldViewModel, Client client)
        {
            this.battleFieldAreaViewModel = battleFieldAreaViewModel;
            this.battleFieldViewModel = battleFieldViewModel;
            this.addShipPositionCommand = new AddShipPositionCommand(this.battleFieldViewModel, this.battleFieldAreaViewModel, client);
        }

        public override void Execute(object parameter)
        {
            ShipType[] shipTypes = new ShipType[]
            {
                ShipType.Battleship,
                ShipType.Carrier,
                ShipType.Cruiser,
                ShipType.Destroyer,
                ShipType.Sub
            };

            Random rand = new Random();

            for (int i = 0; i < shipTypes.Length; i++)
            {
                Position randPosition = new Position(0, 0);
                this.battleFieldViewModel.ShipToPlace.ValidPosition = false;

                while (!this.battleFieldViewModel.ShipToPlace.ValidPosition)
                {
                    int x = rand.Next(0, this.battleFieldAreaViewModel.Width);
                    int y = rand.Next(0, this.battleFieldAreaViewModel.Height);
                    randPosition = new Position(x, y);
                    Array orientations = Enum.GetValues(typeof(Orientation));
                    Orientation randOrientation = (Orientation)orientations.GetValue(rand.Next(orientations.Length));
                    this.battleFieldViewModel.ShipToPlace.ShipOrientation = randOrientation;
                    this.battleFieldViewModel.ShipToPlace.ShipType = shipTypes[i];
                    HighlightSquaresCommand cmd = new HighlightSquaresCommand(this.battleFieldAreaViewModel, this.battleFieldViewModel);
                    cmd.Execute(randPosition);
                }

                this.addShipPositionCommand.Execute(randPosition);
            }
        }
    }
}
