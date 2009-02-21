namespace Animaonline.Network
{
    using System;
    public class PortOpenEventArgs : EventArgs
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public PortOpenEventArgs() { }
        public PortOpenEventArgs(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
