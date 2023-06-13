namespace _03_Battleship.ViewModel.ViewRepresenter
{
    using _03_Battleship.EnhancedNetworking;
    using _03_Battleship.Model;
    using Command.ViewChangingCommand;
    using MVVMCore;

    internal class EnterServerIPViewModel : ViewRepresentingViewModel
    {
        public EnterServerIPViewModel(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
            ViewShellViewModel shell = (ViewShellViewModel)viewShell;
            shell.Client = new Client(new TcpConnection());
        }
        public ConnectToServerCommand ConnectToServerCommand => new ConnectToServerCommand(this.ViewShell);
    }
}
