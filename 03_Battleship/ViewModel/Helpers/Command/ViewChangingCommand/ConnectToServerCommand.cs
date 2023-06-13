namespace _03_Battleship.Command.ViewChangingCommand
{

    using System.Net;
    using System.Windows;
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    internal class ConnectToServerCommand : ViewChangingCommand
    {
        public ConnectToServerCommand(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }

        public override void Execute(object parameter)
        {
            ViewShellViewModel shell = (ViewShellViewModel)this.ViewShell;
            string ip = (string)parameter;

            try
            {
                shell.Client.ServerIP = IPAddress.Parse(ip);
                shell.Client.Connect();
            }
            catch
            {
                MessageBox.Show("Не удалось найти IP адресс или сервер отклчон!", "Не удалось подключиться!.", MessageBoxButton.OK);
                shell.View = new MainMenuViewModel(shell);
                return;
            }

            shell.View = new LobbyViewModel(shell);
        }
    }
}
