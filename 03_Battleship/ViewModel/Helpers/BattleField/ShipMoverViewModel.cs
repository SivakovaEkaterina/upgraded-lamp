namespace _03_Battleship.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using Model;
    using MVVMCore;

    internal class ShipMoverViewModel : NotifyingViewModel
    {
        private const int Delay = 100;
        private Thread shipMoverThread;
        private Ship ship;
        private ObservableCollection<BFSquareViewModel> squares;
        private int maxHeight;

        public ShipMoverViewModel(Ship ship, ObservableCollection<BFSquareViewModel> squares, int maxHeight)
        {
            this.shipMoverThread = new Thread(this.Worker);
            this.ship = ship ?? throw new ArgumentNullException(nameof(ship), "Значение не должно быть равно нулю.");
            this.squares = squares ?? throw new ArgumentNullException(nameof(squares), "Значение не должно быть равно нулю.");
            this.maxHeight = maxHeight;
        }

        public void Start()
        {
            if (this.shipMoverThread.ThreadState == ThreadState.Unstarted)
            {
                this.shipMoverThread.Start();
            }
        }

        private void Worker()
        {
            bool removePrevious = false;

            for (int i = 0; i < this.ship.Length; i++)
            {
                Position squarePosition;

                if (this.ship.Orientation == Orientation.Horizontal)
                {
                    squarePosition = new Position(this.ship.Position.X + i, this.ship.Position.Y);
                }
                else
                {
                    squarePosition = new Position(this.ship.Position.X, this.ship.Position.Y + i);
                }

                this.squares.Where(square => square.Position.Equals(squarePosition)).First().RealShipUnit = true;

                for (int y = this.maxHeight - 1; y >= squarePosition.Y; y--)
                {
                    if (removePrevious && y != this.maxHeight - 1)
                    {
                        this.squares.Where(s => s.Position.Equals(new Position(squarePosition.X, y + 1))).First().FakeShipUnit = false;
                    }

                    BFSquareViewModel square = this.squares.Where(s => s.Position.Equals(new Position(squarePosition.X, y))).First();

                    if (!square.FakeShipUnit)
                    {
                        removePrevious = true;
                        square.FakeShipUnit = true;
                    }
                    else
                    {
                        removePrevious = false;
                    }

                    Thread.Sleep(Delay);
                }

                this.squares.Where(square => square.Position.Equals(squarePosition)).First().FakeShipUnit = true;
            }
        }
    }
}
