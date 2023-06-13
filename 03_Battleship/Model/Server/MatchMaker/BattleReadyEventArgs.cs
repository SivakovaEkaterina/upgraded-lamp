namespace _03_Battleship.Model
{
    using System;
    using EnhancedNetworking;

    public class BattleReadyEventArgs : EventArgs
    {

        public BattleReadyEventArgs(IConnection competitorA, IConnection competitorB)
        {
            this.CompetitorA = competitorA ?? throw new ArgumentNullException(nameof(competitorA), "Значение не должно быть равно нулю.");
            this.CompetitorB = competitorB ?? throw new ArgumentNullException(nameof(competitorB), "Значение не должно быть равно нулю.");
        }

        public IConnection CompetitorA
        {
            get;
            private set;
        }

        public IConnection CompetitorB
        {
            get;
            private set;
        }
    }
}