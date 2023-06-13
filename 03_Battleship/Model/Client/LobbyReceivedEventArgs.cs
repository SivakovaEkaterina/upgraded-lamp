namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;

    public class LobbyReceivedEventArgs : EventArgs
    {

        public LobbyReceivedEventArgs(List<ClientDummy> clientDummies)
        {
            this.ClientDummies = clientDummies ?? throw new ArgumentNullException(nameof(clientDummies), "Значение не должно быть равно нулю");
        }

       
        public List<ClientDummy> ClientDummies
        {
            get;
            private set;
        }
    }
}