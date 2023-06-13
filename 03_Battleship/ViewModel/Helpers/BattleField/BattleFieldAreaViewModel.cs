namespace _03_Battleship.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Command;
    using Model;
    using MVVMCore;

    internal class BattleFieldAreaViewModel : NotifyingViewModel
    {

        private HighlightSquaresCommand highlightSquaresCommand;

        public BattleFieldAreaViewModel(int width, int height, BaseCommand squareCommand = null)
        {
            this.Squares = new ObservableCollection<BFSquareViewModel>();
            this.Ships = new ObservableCollection<Ship>();
            this.Width = width;
            this.Height = height;

            for (int h = 0; h < width; h++)
            {
                for (int w = 0; w < height; w++)
                {
                    this.Squares.Add(new BFSquareViewModel(false, new Position(w, h), squareCommand));
                }
            }
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public ObservableCollection<BFSquareViewModel> Squares
        {
            get;
            private set;
        }

        public ObservableCollection<Ship> Ships
        {
            get;
            private set;
        }

        public HighlightSquaresCommand HighlightSquaresCommand
        {
            get
            {
                return this.highlightSquaresCommand;
            }

            set
            {
                this.highlightSquaresCommand = value;
                this.Notify();
            }
        }

        public void ClearHighlighted()
        {
            for (int i = 0; i < this.Squares.Count; i++)
            {
                this.Squares[i].HighlightedState = HighlightedState.NotHighlighted;
            }
        }

        public bool HighlightSquares(Ship shipToPlace)
        {
            Position controlPos;
            bool validShipPosition = true;
            List<BFSquareViewModel> squares = new List<BFSquareViewModel>();
            HighlightedState state = HighlightedState.Highlighted;

            for (int l = 0; l < shipToPlace.Length; l++)
            {
                if (shipToPlace.Orientation == Orientation.Horizontal)
                {
                    controlPos = new Position(shipToPlace.Position.X + l, shipToPlace.Position.Y);
                }
                else
                {
                    controlPos = new Position(shipToPlace.Position.X, shipToPlace.Position.Y + l);
                }

                try
                {
                    BFSquareViewModel square = this.Squares.First(s => s.Position.Equals(controlPos));
                    if (square.RealShipUnit)
                    {
                        validShipPosition = false;
                    }

                    squares.Add(square);
                }
                catch
                {
                    return false;
                }
            }

            if (!validShipPosition)
            {
                state = HighlightedState.HighlightedAsWrong;
            }

            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].HighlightedState = state;
            }

            if (state == HighlightedState.HighlightedAsWrong)
            {
                return false;
            }

            return true;
        }

        public void AddShip(Ship ship)
        {
            this.Ships.Add(ship);
            ShipMoverViewModel shipMover = new ShipMoverViewModel(ship, this.Squares, this.Height);
            shipMover.Start();
        }

        public void SetSquareCommands(BaseCommand squareCommand)
        {
            for (int i = 0; i < this.Squares.Count; i++)
            {
                this.Squares[i].SquareCommand = squareCommand;
            }
        }

        public void EnableSquares()
        {
            for (int i = 0; i < this.Squares.Count; i++)
            {
                this.Squares[i].Enabled = true;
            }
        }

        public void DisableSquares()
        {
            for (int i = 0; i < this.Squares.Count; i++)
            {
                this.Squares[i].Enabled = false;
            }
        }

        public void AddMarker(Marker marker)
        {
            BFSquareViewModel square = this.Squares.Where(s => s.Position.Equals(marker.Position)).First();
            if (marker is HitMarker)
            {
                square.State = SquareState.Hit;
            }
            else
            {
                square.State = SquareState.Missed;
            }
        }
    }
}
