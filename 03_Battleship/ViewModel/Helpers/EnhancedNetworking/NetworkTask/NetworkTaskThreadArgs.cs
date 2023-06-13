namespace _03_Battleship.EnhancedNetworking
{
    public class NetworkTaskThreadArgs : NetworkingThreadArgs
    {
        public NetworkTaskThreadArgs(int pollDelay) : base(pollDelay)
        {
        }

        public object NetworkTaskParameter
        {
            get;
            set;
        }
    }
}
