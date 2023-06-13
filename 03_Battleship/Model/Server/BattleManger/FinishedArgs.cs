namespace _03_Battleship.Model
{
    using System;

    public class FinishedArgs : EventArgs
    {
        public FinishedArgs(Battle battle, Competitor winner, Competitor loser)
        {
            this.Battle = battle ?? throw new ArgumentNullException(nameof(battle), "Значение не должно быть равно нулю.");
            this.Winner = winner ?? throw new ArgumentNullException(nameof(winner), "Значение не должно быть равно нулю.");
            this.Loser = loser ?? throw new ArgumentNullException(nameof(winner), "Значение не должно быть равно нулю.");
        }

        public Battle Battle
        {
            get;
            private set;
        }

        public Competitor Winner
        {
            get;
            private set;
        }

        public Competitor Loser
        {
            get;
            private set;
        }
    }
}