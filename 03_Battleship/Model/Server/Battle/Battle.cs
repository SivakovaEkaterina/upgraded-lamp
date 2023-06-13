namespace _03_Battleship.Model
{
    using System;
    using EnhancedNetworking;

    public class Battle
    {
        public Battle(IConnection competitorA, IConnection competitorB)
        {
            if (competitorA == null)
            {
                throw new ArgumentNullException(nameof(competitorA), "Значение не должно быть равно нулю.");
            }

            if (competitorB == null)
            {
                throw new ArgumentNullException(nameof(competitorB), "Значение не должно быть равно нулю.");
            }

            this.CompetitorA = new Competitor(competitorA);
            this.CompetitorB = new Competitor(competitorB);

            this.CompetitorA.ShipPositionsReceived += this.Competitor_ShipPositionsReceived;
            this.CompetitorB.ShipPositionsReceived += this.Competitor_ShipPositionsReceived;

            this.CompetitorA.LeftGame += this.Competitor_LeftGame;
            this.CompetitorB.LeftGame += this.Competitor_LeftGame;

                this.CompetitorA.SendInitiateBattle();
                this.CompetitorB.SendInitiateBattle();
          
         
        }

        public event EventHandler<FinishedArgs> Finished;

        public Competitor CompetitorA
        {
            get;
            private set;
        }

        public Competitor CompetitorB
        {
            get;
            private set;
        }

        protected virtual void FireFinished(object sender, FinishedArgs args)
        {
            this.CompetitorA.Connection.Close();
            this.CompetitorB.Connection.Close();

            if (this.Finished != null)
            {
                this.Finished(sender, args);
            }
        }

        private void Competitor_ShipPositionsReceived(object sender, ShipPositionsReceivedEventArgs args)
        {
            Competitor competitor = (Competitor)sender;
            competitor.BattleField.Ships = args.Ships;
            competitor.ShipPositionsReceived -= this.Competitor_ShipPositionsReceived;
            competitor.PositionsReady = true;

            if (this.CompetitorB.PositionsReady && this.CompetitorA.PositionsReady)
            {
                this.InitiateShooting();
            }
        }

        private void InitiateShooting()
        {
            this.CompetitorA.SendMoveRequest();
            this.CompetitorA.MoveReceived += this.Competitor_MoveReceived;
        }

        private void Competitor_MoveReceived(object sender, MoveReceivedEventArgs args)
        {
            Competitor competitor = (Competitor)sender;
            Competitor opponent = this.Opponent(competitor);

          
            competitor.MoveReceived -= this.Competitor_MoveReceived;

            Marker marker;
            bool validMove;

            validMove = opponent.BattleField.AddMarker(args.Move, out marker);

            if (!validMove)
            {
               
                opponent.SendGameWon();
                competitor.Connection.Close();
                this.FireFinished(this, new FinishedArgs(this, opponent, competitor));
                return;
            }

            competitor.SendMoveReport(marker);
            opponent.SendOpponentsMove(marker);

            if (opponent.BattleField.Ships.Count == 0)
            {
               
                competitor.SendGameWon();
                opponent.SendGameLost();
                this.FireFinished(this, new FinishedArgs(this, competitor, opponent));
            }
            else
            {
                opponent.SendMoveRequest();
                opponent.MoveReceived += this.Competitor_MoveReceived;
            }
        }

        private void Competitor_LeftGame(object sender, EventArgs e)
        {
            Competitor quitter = (Competitor)sender;
            quitter.LeftGame -= this.Competitor_LeftGame;
            Competitor other = this.Opponent(quitter);
            other.SendGameWon();
            this.FireFinished(this, new FinishedArgs(this, other, quitter));
        }

        private Competitor Opponent(Competitor competitor)
        {
            if (competitor == this.CompetitorA)
            {
                return this.CompetitorB;
            }

            return this.CompetitorA;
        }
    }
}