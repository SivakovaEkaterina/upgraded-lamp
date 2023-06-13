namespace _03_Battleship.Command
{
    using System;
    using System.Linq;
    using Model;
    using MVVMCore;
    using ViewModel;

    internal class SendMoveCommand : BaseCommand
    {
        private Client client;

        private BattleFieldAreaViewModel battleFieldAreaViewModel;

        public SendMoveCommand(Client client, BattleFieldAreaViewModel battleFieldAreaViewModel)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client), "Значение не должно быть равно нулю.");
            this.battleFieldAreaViewModel = battleFieldAreaViewModel ?? throw new ArgumentNullException(nameof(battleFieldAreaViewModel), "Значение не должно быть равно нулю.");
        }

        public override void Execute(object parameter)
        {
            Position position = (Position)parameter;

            if (this.battleFieldAreaViewModel.Squares.Where(s => s.Position.Equals(position)).First().State == SquareState.Undamaged)
            {
                this.client.SendMove(position);
                this.battleFieldAreaViewModel.DisableSquares();
            }
        }
    }
}
