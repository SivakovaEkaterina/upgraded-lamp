namespace _03_Battleship.ViewModel.ViewRepresenter
{
    using System;
    using Command;
    using Command.ViewChangingCommand;
    using Model;
    using MVVMCore;

    internal class BattleFieldViewModel : ViewRepresentingViewModel
    {
        private Client client;
        private bool modalVisible;
        private BattleFieldModalViewModel modal;
        private bool toolbarVisible;
        private bool opponentFieldVisible;
        public BattleFieldViewModel(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
            ViewShellViewModel viewShellVM = (ViewShellViewModel)viewShell;
            this.client = viewShellVM.Client;

            this.client.StopSendingLobbyRequests();
            this.ShipPositionsSent = false;

            this.ShipToPlace = new ShipToPlaceViewModel();

            this.UserBattleFieldArea = new BattleFieldAreaViewModel(10, 10);
            this.UserBattleFieldArea.SetSquareCommands(new AddShipPositionCommand(this, this.UserBattleFieldArea, this.client));
            this.UserBattleFieldArea.HighlightSquaresCommand = new HighlightSquaresCommand(this.UserBattleFieldArea, this);
            this.UserBattleFieldArea.EnableSquares();

            this.OpponentBattleFieldArea = new BattleFieldAreaViewModel(10, 10);
            SendMoveCommand sendMoveCommand = new SendMoveCommand(viewShellVM.Client, this.OpponentBattleFieldArea);
            this.OpponentBattleFieldArea.SetSquareCommands(sendMoveCommand);

            this.Toolbar = new ToolbarViewModel();
            this.ToolbarVisible = true;

            this.client.MoveRequestReceived += this.Client_MoveRequestReceived;
            this.client.OpponentMoveReceived += this.Client_OpponentMoveReceived;
            this.client.MoveReportReceived += this.Client_MoveReportReceived;
            this.client.GameLost += this.Client_GameLost;
            this.client.GameWon += this.Client_GameWon;
        }

        public ShipToPlaceViewModel ShipToPlace
        {
            get;
            set;
        }

        public bool ShipPositionsSent
        {
            get;
            set;
        }
        public BattleFieldAreaViewModel UserBattleFieldArea
        {
            get;
            private set;
        }

        public BattleFieldAreaViewModel OpponentBattleFieldArea
        {
            get;
            private set;
        }

        public bool OpponentFieldVisible
        {
            get
            {
                return this.opponentFieldVisible;
            }

            set
            {
                this.opponentFieldVisible = value;
                this.Notify();
            }
        }

        public ToolbarViewModel Toolbar
        {
            get;
            private set;
        }

        public bool ToolbarVisible
        {
            get
            {
                return this.toolbarVisible;
            }

            set
            {
                this.toolbarVisible = value;
                this.Notify();
            }
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

        public BattleFieldModalViewModel Modal
        {
            get
            {
                return this.modal;
            }

            set
            {
                this.modal = value;
                this.Notify();
            }
        }

        public SelectShipCommand SelectShipCommand => new SelectShipCommand(this);
        public RotateShipCommand RotateShipCommand => new RotateShipCommand(this);
        public ShowMainMenuCommand ShowMainMenuCommand => new ShowMainMenuCommand(this.ViewShell);
        public RandomPositionsCommand RandomPositionsCommand => new RandomPositionsCommand(this.UserBattleFieldArea, this, this.client);
        private void Client_MoveRequestReceived(object sender, EventArgs e)
        {
            this.OpponentBattleFieldArea.EnableSquares();
        }

        private void Client_OpponentMoveReceived(object sender, MoveReceivedEventArgs e)
        {
            this.UserBattleFieldArea.AddMarker(e.Marker);
        }

        private void Client_MoveReportReceived(object sender, MoveReceivedEventArgs e)
        {
            this.OpponentBattleFieldArea.AddMarker(e.Marker);
        }

        private void Client_GameWon(object sender, EventArgs e)
        {
            this.client.Close();
            this.Modal = new BattleFieldModalViewModel("Вы победили!");
            this.ModalVisible = true;
        }

        private void Client_GameLost(object sender, EventArgs e)
        {
            this.client.Close();
            this.Modal = new BattleFieldModalViewModel("Вы проиграли!");
            this.ModalVisible = true;
        }
    }
}
