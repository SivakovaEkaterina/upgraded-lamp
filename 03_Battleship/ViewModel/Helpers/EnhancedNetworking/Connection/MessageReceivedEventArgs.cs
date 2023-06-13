namespace _03_Battleship.EnhancedNetworking
{
    using System;

    public class MessageReceivedEventArgs : EventArgs
    {
        public MessageReceivedEventArgs(object message)
        {
            this.Message = message ?? throw new ArgumentNullException(nameof(message), "Значение не должно быть равно нулю");
        }
        public MessageReceivedEventArgs(object message, IConnection connection)
        {
            this.Message = message ?? throw new ArgumentNullException(nameof(message), "Значение не должно быть равно нулю");
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection), "Значение не должно быть равно нулю");
        }

    
        public IConnection Connection
        {
            get;
            private set;
        }

      
        public object Message
        {
            get;
            private set;
        }
    }
}