namespace _03_Battleship.Model
{
    using System;

    
    [Serializable]
    public class MissedMarker : Marker
    {
        public MissedMarker(Position position) : base(position)
        {
        }
    }
}