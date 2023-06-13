namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class MessageHandler
    {
        public static void Send(object message, EnhancedTcpClient enhancedTcpClient)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "Значение не должно быть равно нулю.");
            }

            if (enhancedTcpClient == null)
            {
                throw new ArgumentNullException(nameof(enhancedTcpClient), "Значение не должно быть равно нулю.");
            }

            enhancedTcpClient.Write(Serialize(new MessageContainer(message)));
        }

        public static object Read(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                try
                {
                    MessageContainer messageContainer = (MessageContainer)formatter.Deserialize(memoryStream);
                    return messageContainer.Content;
                }
                catch
                {
                    throw;
                }
            }
        }

        private static byte[] Serialize(MessageContainer message)
        {
            byte[] serialized;
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                formatter.Serialize(memoryStream, message);
                serialized = memoryStream.GetBuffer();
                return serialized;
            }
        }
    }
}