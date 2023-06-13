namespace _03_Battleship.Command
{
    using Model;
    using MVVMCore;
    internal class ConfirmBattleCommand : BaseCommand
    {
       
        private Client client;

        public ConfirmBattleCommand(Client client)
        {
            this.client = client;
        }

        public override void Execute(object parameter)
        {
            this.client.SendConfirmBattle();
        }
    }
}
