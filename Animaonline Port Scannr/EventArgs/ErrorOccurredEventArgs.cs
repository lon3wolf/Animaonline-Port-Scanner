namespace Animaonline.Network
{
    using System;
    public class ErrorOccurredEventArgs : EventArgs
    {
        public Exception Exception { get; set; }

        public ErrorOccurredEventArgs() { }
        public ErrorOccurredEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}
