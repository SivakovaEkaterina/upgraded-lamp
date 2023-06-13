namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;

    public class MessageReceiver
    { 
        private NetworkStream networkStream;
        private Thread messageReceiverThread;
        private MessageReceiverThreadArgs messageReceiverThreadArgs;
        private BinaryFormatter formatter;

        public MessageReceiver(NetworkStream networkStream)
        {
            this.networkStream = networkStream ?? throw new ArgumentNullException(nameof(networkStream), "Значение не должно быть равно нулю.");
            this.messageReceiverThreadArgs = new MessageReceiverThreadArgs();
            this.messageReceiverThread = new Thread(this.Worker);
            this.formatter = new BinaryFormatter();
        }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public void Start()
        {
            if (this.messageReceiverThread.ThreadState == ThreadState.Unstarted)
            {
                this.messageReceiverThread.Start(this.messageReceiverThreadArgs);
            }
        }

        protected virtual void FireMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            this.MessageReceived?.Invoke(sender, args);
        }

        private void Worker(object data)
        {
            MessageReceiverThreadArgs args = (MessageReceiverThreadArgs)data;

            while (!args.Stop)
            {
                MessageContainer messageContainer = (MessageContainer)this.formatter.Deserialize(this.networkStream);
                this.FireMessageReceived(this, new MessageReceivedEventArgs(messageContainer.Content));
            }
        }
    }
}
