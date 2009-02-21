namespace Animaonline.Network
{
    using System;
    public class CancelEventArgs : EventArgs
    {
        public CancelEventArgs() { }

        public CancelEventArgs(bool cancel)
        {
            Cancel = cancel;
        }

        public bool Cancel { get; set; }
    }
}
