namespace _03_Battleship.ViewModel.ViewRepresenter
{
    using System;
    using System.Windows;
    using _03_Battleship.Model;
    using Command;
    using MVVMCore;

    internal class LobbyViewModel : ViewRepresentingViewModel
    {

        private ViewShellViewModel shell;

        private bool modalVisible;

        public LobbyViewModel(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
            this.shell = (ViewShellViewModel)this.ViewShell;
            this.BattleListVM = new BattleListViewModel(this.shell.Client);
            this.shell.Client.ChallengerFound += this.Client_ChallengerFound;
            this.shell.Client.InitiateBattleReceived += this.Client_InitiateBattleReceived;
            this.shell.Client.ConnectionLost += this.Client_ConnectionLost;
            this.shell.Client.OpponentDeclined += this.Client_OpponentDeclined;
            this.Modal = new BattleFieldModalViewModel(string.Empty);
        }

        public BattleFieldModalViewModel Modal
        {
            get;
            private set;
        }

        public bool ModalVisible
        {
            get
            {
                return this.modalVisible;
            }

            set
            {
                this.modalVisible = value;
                this.Notify();
            }
        }

        public BattleListViewModel BattleListVM
        {
            get;
            private set;
        }

        public NewGameCommand NewGameCommand => new NewGameCommand(this.shell.Client);

        private void Client_ConnectionLost(object sender, EventArgs e)
        {
            this.shell.Client.ConnectionLost -= this.Client_ConnectionLost;
            MessageBox.Show("Потеряно соединение с сервером.", "Потеря Соединения", MessageBoxButton.OK);
            this.shell.Client.Close();
            this.ViewShell.View = new MainMenuViewModel(this.ViewShell);
        }

        private void Client_InitiateBattleReceived(object sender, EventArgs e)
        {
            this.ViewShell.View = new BattleFieldViewModel(this.ViewShell);
        }

        private void Client_ChallengerFound(object sender, ChallengerFoundEventArgs e)
        {
            this.Modal.ButtonSetOK = false;
            this.Modal.ButtonSetYesNo = true;
            this.Modal.Text = $"Хотите принять вызов от \n{ e.ChallengerInfo.UserName} ?";
            this.Modal.ModalCommand = new ConfirmBattleCommand(this.shell.Client);
            this.Modal.AbortCommand = new DeclineChallengeCommand(this.shell.Client, this);
            this.ModalVisible = true;
        }

        private void Client_OpponentDeclined(object sender, EventArgs e)
        {
            this.Modal.ButtonSetOK = true;
            this.Modal.ButtonSetYesNo = false;
            this.Modal.Text = "Игрок не принял Ваш вызов";
            this.Modal.ModalCommand = new CloseLobbyModalCommand(this);
            this.ModalVisible = true;
        }
    }
}
