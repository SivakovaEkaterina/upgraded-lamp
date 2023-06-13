namespace _03_Battleship.ViewModel
{
    using System;
    using MVVMCore;
    internal class BFSquareViewModel : NotifyingViewModel
    {
        private bool shipUnit;
        private bool enabled;
        private SquareState squareState;
        private BaseCommand squareCommand;
        private BaseCommand mouseOverCommand;
        private HighlightedState highlightedState;

        public BFSquareViewModel(bool shipUnit, Position position, BaseCommand squareCommand)
        {
            this.Position = position ?? throw new ArgumentNullException(nameof(position), "Значение не должно быть равно нулю.");
            this.FakeShipUnit = shipUnit;
            this.State = SquareState.Undamaged;
            this.SquareCommand = squareCommand;
        }

        public bool FakeShipUnit
        {
            get
            {
                return this.shipUnit;
            }

            set
            {
                this.shipUnit = value;
                this.Notify();
            }
        }

        public SquareState State
        {
            get
            {
                return this.squareState;
            }

            set
            {
                this.squareState = value;
                this.Notify();
            }
        }

        public Position Position
        {
            get;
            private set;
        }

        public HighlightedState HighlightedState
        {
            get
            {
                return this.highlightedState;
            }

            set
            {
                this.highlightedState = value;
                this.Notify();
            }
        }

        public BaseCommand SquareCommand
        {
            get
            {
                return this.squareCommand;
            }

            set
            {
                this.squareCommand = value;
                this.Notify();
            }
        }

        public BaseCommand MouseOverCommand
        {
            get
            {
                return this.mouseOverCommand;
            }

            set
            {
                this.mouseOverCommand = value;
                this.Notify();
            }
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }

            set
            {
                this.enabled = value;
                this.Notify();
            }
        }

        public bool RealShipUnit
        {
            get;
            internal set;
        }
    }
}
