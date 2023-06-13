namespace _03_Battleship.Model
{
    using System;

    [Serializable]
    public class HitMarker : Marker
    {
        public HitMarker(Position position) : base(position) { }
    }
}