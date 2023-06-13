namespace _03_Battleship.Model
{
    using System;
    using EnhancedNetworking;


    internal class SendLobbyRequestTask : NetworkTask
    {

        public SendLobbyRequestTask(IConnection connection, int intervalTime = 1000) : base(connection, intervalTime)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection), "Значение не должно быть равно нулю");
        }

        protected override void Execute(object parameter)
        {
            this.Connection.SendMessage(new Message(MessageType.LobbyRequest));
        }
    }
}
