using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

[assembly: CLSCompliant(true)]
namespace Animaonline.Network
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PortScannr : IDisposable
    {
        public PortScannr() { OnCancel += new EventHandler<CancelEventArgs>(PortScannrOnCancel); }
        public PortScannr(string host, int portFrom, int portTo)
        {
            OnCancel += new EventHandler<CancelEventArgs>(PortScannrOnCancel);
            Host = host;
            PortFrom = portFrom;
            PortTo = portTo;
        }

        public string Host { get; set; }
        public int PortFrom { get; set; }
        public int PortTo { get; set; }

        private Stopwatch ScanStopwatch = new Stopwatch();
        private event EventHandler<CancelEventArgs> OnCancel;
        private bool cancel;

        private WaitCallback starterWaitCallback;

        public void Start()
        {
            ScanStopwatch.Start();
            starterWaitCallback = new WaitCallback(StarterCallbackMethod);
            try
            {
                ThreadPool.QueueUserWorkItem(starterWaitCallback, 0);
            }
            catch (ApplicationException queueWorkItemException)
            {
                if (ErrorOccurred != null)
                {
                    ErrorOccurred(this, new ErrorOccurredEventArgs(queueWorkItemException));
                }
            }
        }

        private WaitCallback wcb;
        public void StarterCallbackMethod(object state)
        {
            wcb = new WaitCallback(CallbackMethod);
            try
            {
                for (int i = PortFrom; i < PortTo + 1; i++)
                {
                    ThreadPool.QueueUserWorkItem(wcb, i);
                }
            }
            catch (ApplicationException ScannrException)
            {
                if (ErrorOccurred != null)
                {
                    ErrorOccurred(this, new ErrorOccurredEventArgs(ScannrException));
                }
            }
        }

        public void Cancel()
        {
            if (OnCancel != null)
            {
                OnCancel(this, new CancelEventArgs(true));
            }
        }

        private void PortScannrOnCancel(object sender, CancelEventArgs e)
        {
            cancel = e.Cancel;
        }

        private Socket scannerSocket;

        public void CallbackMethod(object state)
        {
            if (!cancel)
            {
                IPAddress HostAddress;
                PortState returnValue = PortState.Closed;

                HostAddress = Dns.GetHostEntry(Host).AddressList[0];


                IPEndPoint targetEP = new IPEndPoint(HostAddress, (int)state);

                scannerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    scannerSocket.Connect(targetEP);
                    if (scannerSocket.Connected)
                    {
                        returnValue = PortState.Open;
                        scannerSocket.Close();
                    }
                    else
                    {
                        returnValue = PortState.Closed;
                    }
                }
                catch (SocketException socketException)
                {
                    if (ErrorOccurred != null)
                    {
                        ErrorOccurred(this, new ErrorOccurredEventArgs(socketException));
                        returnValue = PortState.Closed;
                    }
                }
                finally
                {
                    if (returnValue == PortState.Open)
                    {
                        if (PortOpen != null)
                        {
                            PortOpen(this, new PortOpenEventArgs(Host, (int)state));
                        }
                    }
                    else
                    {
                        if (PortClosed != null)
                        {
                            PortClosed(this, new PortClosedEventArgs(Host, (int)state));
                        }
                    }
                    if ((int)state == PortTo - 1)
                    {
                        if (ScanCompleted != null)
                        {
                            ScanStopwatch.Stop();
                            ScanCompleted(this, new ScanCompletedEventArgs(ScanStopwatch.Elapsed));
                            ScanStopwatch.Reset();
                        }
                    }
                }
            }
            else
            {
                if (ScanCompleted != null)
                {
                    ScanStopwatch.Stop();
                    ScanCompleted(this, new ScanCompletedEventArgs(ScanStopwatch.Elapsed));
                    ScanStopwatch.Reset();
                    wcb = null;
                    try
                    {
                        scannerSocket.Close();
                        scannerSocket.Disconnect(false);
                    }
                    catch { }
                    scannerSocket = null;
                    starterWaitCallback = null;
                    return;
                }
            }
        }

        public static string GetServiceName(int port)
        {
            try
            {
                return ConfigurationSettings.AppSettings["Port" + port];
            }
            catch (KeyNotFoundException)
            {
                return "Unknown";
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool doDispose)
        {
            if (doDispose)
            {
                try
                {
                    scannerSocket.Close();
                    scannerSocket.Disconnect(false);
                }
                catch { }
                finally
                {
                    scannerSocket = null;
                }
            }
        }

        #endregion
    }
}
