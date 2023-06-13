namespace _03_Battleship.Model
{
    using System;

    [Serializable]
    public class ClientDummy
    {
        public ClientDummy(string userName, string ipAdress, bool inGame, int id)
        {
            this.UserName = userName;
            this.IPAddress = ipAdress ?? throw new ArgumentNullException("Значение не должно быть равно нулю");
            this.InGame = inGame;
            this.Id = id;
        }

        public string UserName{get;private set;}
        public string IPAddress{get;private set;}
        public bool InGame{get;private set;}
        public int Id{get;set;}
    }
}
