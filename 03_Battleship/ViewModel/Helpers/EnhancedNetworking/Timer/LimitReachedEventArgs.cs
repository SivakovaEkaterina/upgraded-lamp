namespace _03_Battleship.EnhancedNetworking
{
    using System;

    public class LimitReachedEventArgs : EventArgs
    {
        public LimitReachedEventArgs()
        {
            this.Timestamp = DateTime.Now;
        }
        public DateTime Timestamp
        {
            get;
            private set;
        }
    }
}