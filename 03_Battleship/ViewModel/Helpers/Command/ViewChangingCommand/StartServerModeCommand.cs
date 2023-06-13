namespace _03_Battleship.Command.ViewChangingCommand
{
    using System.Windows;
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    internal class StartServerModeCommand : ViewChangingCommand
    {
        public StartServerModeCommand(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }

        public override void Execute(object parameter)
        {
            try
            {
                this.ViewShell.View = new ServerModeViewModel(this.ViewShell);
            }
            catch
            {
                MessageBox.Show("НЕ УДАЛОСЬ ЗАПУСТИТЬ СЕРВЕР. Будьте внимательны Вы можете иметь только один сервекр на 1 компьютере.", "Ошибка!", MessageBoxButton.OK);
                this.ViewShell.View = new MainMenuViewModel(this.ViewShell);
            }
        }
    }
}
