namespace Animaonline.Network
{
    using System;
    public class ScanCompletedEventArgs : EventArgs
    {
        public TimeSpan Elapsed { get; set; }

        public ScanCompletedEventArgs() { }
        public ScanCompletedEventArgs(TimeSpan elapsed)
        {
            Elapsed = elapsed;
        }
    }
}
