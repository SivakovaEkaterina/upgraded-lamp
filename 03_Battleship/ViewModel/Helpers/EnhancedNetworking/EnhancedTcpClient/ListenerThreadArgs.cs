namespace _03_Battleship.EnhancedNetworking
{
    public class ListenerThreadArgs : NetworkingThreadArgs
    {
        public ListenerThreadArgs(int pollDelay = 200) : base(pollDelay)
        {
        }
    }
}