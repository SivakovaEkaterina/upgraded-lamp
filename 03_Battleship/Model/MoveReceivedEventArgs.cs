namespace _03_Battleship.Model
{
    using System;

    public class MoveReceivedEventArgs : EventArgs
    {
        public MoveReceivedEventArgs(Position position)
        {
            this.Move = position ?? throw new ArgumentNullException(nameof(position), "Значение не должно быть равно нулю.");
        }


        public MoveReceivedEventArgs(Marker marker)
        {
            this.Marker = marker ?? throw new ArgumentNullException(nameof(marker), "Значение не должно быть равно нулю.");
        }


        public Marker Marker
        {
            get;
            private set;
        }

        public Position Move
        {
            get;
            private set;
        }
    }
}