namespace _03_Battleship.Command.ViewChangingCommand
{
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    internal class ShowEnterServerIPCommand : ViewChangingCommand
    {
        public ShowEnterServerIPCommand(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }
        public override void Execute(object parameter)
        {
            this.ViewShell.View = new EnterServerIPViewModel((ViewShellViewModel)this.ViewShell);
        }
    }
}
