namespace _03_Battleship.Command
{
    using Model;
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    internal class RotateShipCommand : BaseCommand
    {

        private BattleFieldViewModel battleFieldViewModel;
        public RotateShipCommand(BattleFieldViewModel battleFieldViewModel)
        {
            this.battleFieldViewModel = battleFieldViewModel;
        }

        public override void Execute(object parameter)
        {
            if (this.battleFieldViewModel.ShipToPlace.ShipOrientation == Orientation.Horizontal)
            {
                this.battleFieldViewModel.ShipToPlace.ShipOrientation = Orientation.Vertical;
            }
            else
            {
                this.battleFieldViewModel.ShipToPlace.ShipOrientation = Orientation.Horizontal;
            }
        }
    }
}
