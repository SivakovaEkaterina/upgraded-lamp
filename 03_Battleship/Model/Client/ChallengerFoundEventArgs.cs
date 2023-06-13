namespace _03_Battleship.Model
{
    using System;

    public class ChallengerFoundEventArgs : EventArgs
    {

        public ChallengerFoundEventArgs(ClientDummy challengerInfo)
        {
            this.ChallengerInfo = challengerInfo ?? throw new ArgumentNullException(nameof(challengerInfo), "Значение не должно быть равно нулю.");
        }

        public ClientDummy ChallengerInfo
        {
            get;
            private set;
        }
    }
}
