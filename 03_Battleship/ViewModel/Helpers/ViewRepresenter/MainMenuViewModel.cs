namespace _03_Battleship.ViewModel.ViewRepresenter
{
    using Command.ViewChangingCommand;
    using MVVMCore;

    internal class MainMenuViewModel : ViewRepresentingViewModel
    {
        public MainMenuViewModel(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }
        public StartServerModeCommand StartServerModeCommand => new StartServerModeCommand(this.ViewShell);
        public ShowEnterServerIPCommand ShowEnterServerIPCommand => new ShowEnterServerIPCommand(this.ViewShell);
    }
}
