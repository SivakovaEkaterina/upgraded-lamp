namespace _03_Battleship.Model
{
    public abstract class ThreadArgs
    {
        public ThreadArgs()
        {
            this.PollDelay = 200;
            this.Stop = false;
        }

        public ThreadArgs(int pollDelay)
        {
            this.PollDelay = pollDelay;
            this.Stop = false;
        }

        public bool Stop
        {
            get;
            set;
        }

        public int PollDelay
        {
            get;
            private set;
        }
    }
}