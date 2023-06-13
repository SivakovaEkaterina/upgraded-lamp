namespace _03_Battleship.EnhancedNetworking
{
    using System;

    public class DataReceivedEventArgs : EventArgs
    {
        public DataReceivedEventArgs(byte[] rawData)
        {
            this.RawData = rawData;
        }

        public byte[] RawData
        {
            get;
            set;
        }
        public string Text
        {
            get
            {
                return System.Text.Encoding.UTF8.GetString(this.RawData);
            }
        }
    }
}