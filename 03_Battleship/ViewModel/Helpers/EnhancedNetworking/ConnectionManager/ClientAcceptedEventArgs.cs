namespace _03_Battleship.EnhancedNetworking
{
    using System;

    public class ClientAcceptedEventArgs : EventArgs
    {
        public ClientAcceptedEventArgs(IConnection connection)
        {
            this.Connection = connection;
        }
        public IConnection Connection
        {
            get;
            private set;
        }
    }
}