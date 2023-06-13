namespace _03_Battleship.EnhancedNetworking
{
    using System;

    public class DisconnectedEventArgs : EventArgs
    {
        public DisconnectedEventArgs(IConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection), "Значение не должно быть равно нулю.");
        }

        public IConnection Connection
        {
            get;
            protected set;
        }
    }
}