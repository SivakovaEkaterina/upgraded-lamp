namespace _03_Battleship.EnhancedNetworking
{

    public class ConnectionManagerThreadArgs : NetworkingThreadArgs
    { 
        public ConnectionManagerThreadArgs(int pollDelay = 200) : base(pollDelay)
        {
        }
    }
}
