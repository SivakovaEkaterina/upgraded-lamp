namespace _03_Battleship.Command
{
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    internal class CloseLobbyModalCommand : BaseCommand
    {
        private LobbyViewModel lobby;

        public CloseLobbyModalCommand(LobbyViewModel lobby)
        {
            this.lobby = lobby;
        }

        public override void Execute(object parameter)
        {
            this.lobby.ModalVisible = false;
        }
    }
}
