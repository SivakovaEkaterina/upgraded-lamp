namespace _03_Battleship.Command.ViewChangingCommand
{
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    internal class ShowMainMenuCommand : ViewChangingCommand
    {
        public ShowMainMenuCommand(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }
        public override void Execute(object parameter)
        {
            this.ViewShell.View = new MainMenuViewModel(this.ViewShell);
        }
    }
}
