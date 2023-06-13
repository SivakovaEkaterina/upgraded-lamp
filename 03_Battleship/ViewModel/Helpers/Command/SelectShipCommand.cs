namespace _03_Battleship.Command
{
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    internal class SelectShipCommand : BaseCommand
    {
        private BattleFieldViewModel battleFieldViewModel;

        public SelectShipCommand(BattleFieldViewModel battleFieldViewModel)
        {
            this.battleFieldViewModel = battleFieldViewModel;
        }
        public override void Execute(object parameter)
        {
            ShipType type = (ShipType)parameter;
            this.battleFieldViewModel.ShipToPlace.ShipType = type;
        }
    }
}
