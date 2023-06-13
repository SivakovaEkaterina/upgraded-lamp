namespace _03_Battleship
{
    using System;

    public abstract class NetworkingThreadArgs
    {
        public NetworkingThreadArgs(int pollDelay = 200)
        {
            if (pollDelay <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pollDelay), "Значение не должно быть равно нулю.");
            }

            this.PollDelay = pollDelay;
            this.Stop = false;
        }

        public int PollDelay
        {
            get;
            set;
        }

        public bool Stop
        {
            get;
            set;
        }
    }
}
