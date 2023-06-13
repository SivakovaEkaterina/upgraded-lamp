namespace _03_Battleship.Model
{
    using System;

    [Serializable]
    public abstract class Marker
    {
        public Marker(Position position)
        {
            this.Position = position ?? throw new ArgumentNullException(nameof(position), "Значение не должно быть равно нулю");
        }
        public Position Position
        {
            get;
            private set;
        }
    }
}