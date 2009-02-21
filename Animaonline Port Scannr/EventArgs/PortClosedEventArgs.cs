namespace Animaonline.Network
{
    using System;
    public class PortClosedEventArgs : EventArgs
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public PortClosedEventArgs() { }
        public PortClosedEventArgs(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
