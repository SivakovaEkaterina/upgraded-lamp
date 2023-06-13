namespace _03_Battleship.EnhancedNetworking
{
    public class TimedOutEventArgs : DisconnectedEventArgs
    {
        public TimedOutEventArgs(IConnection connection) : base(connection)
        {
        }
    }
}
