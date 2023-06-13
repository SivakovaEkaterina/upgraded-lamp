namespace _03_Battleship.Command.ViewChangingCommand
{
    using Model;
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    internal class QuitServerModeCommand : ViewChangingCommand
    {
        private Server server;

        public QuitServerModeCommand(ViewShellBaseViewModel viewShell, Server server) : base(viewShell)
        {
            this.server = server;
        }

        public override void Execute(object parameter)
        {
            this.server.Shutdown();
            this.ViewShell.View = new MainMenuViewModel(this.ViewShell);
        }
    }
}
