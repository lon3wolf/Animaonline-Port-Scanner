using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

[assembly: CLSCompliant(true)]
namespace Animaonline.Network
{
    static class Program
    {
        [STAThreadAttribute()]
        static void Main(string[] args)
        {
            try
            {
                PortScannrVersion = "1.1.3.0";//Application.ProductVersion;
                
            }
            catch { }
            try
            {
                if (args[0].ToUpper() == "NOGUI")
                {
                    RunConsole();
                }
                else
                {
                    if (args[0].ToUpper() != "NOGUI")
                    {
                        try
                        {
                            switch (args[3].ToUpper())
                            {
                                case "Y":
                                    HideClosedPorts = true;
                                    break;
                                case "N":
                                    HideClosedPorts = false;
                                    break;
                                default:
                                    HideClosedPorts = false;
                                    break;
                            }
                        }
                        catch
                        {
                            Animaonline.WindowsApi.Kernel32.ShowConsole();
                            for (int i = 0; i < args.Length; i++)
                            {
                                Console.WriteLine("args[" + i + "]:" + args[i]);
                                Console.WriteLine("Incorrect usage!\r\n\r\nCorrect Usage Example\r\nargs[0]=TargetHostName\r\nargs[1]=PortRangeFrom\r\nargs[2]=PortRangeTo\r\nargs[3]=HideClosedPorts(Y/N)\r\n\r\nPress any key to continue...");
                                Console.ReadLine();
                                return;
                            }
                        }
                        StartScan(args[0], int.Parse(args[1]), int.Parse(args[2]));
                    }
                    else
                    {
                        ShowGUI();
                    }
                }
            }
            catch
            {
                ShowGUI();
            }
        }

        static void ShowGUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new GUI());
        }

        static string PortScannrVersion = string.Empty;
        static bool KeepAlive = true;
        static PortScannr PortScanner;
        static bool ScanningInProgress;
        static bool HideClosedPorts;
        static int portFrom;
        static int portTo;
        static void RunConsole()
        {
            Animaonline.WindowsApi.Kernel32.ShowConsole();
            Console.Title = "Animaonline Port Scannr - " + PortScannrVersion;
            string targetHost;
            portFrom = 0;
            portTo = 0;

            HideClosedPorts = false;
            while (KeepAlive)
            {
                Console.Write("Target Host:");
                targetHost = Console.ReadLine();
                Console.Write("Port Range From:");
                portFrom = int.Parse(Console.ReadLine());
                Console.Write("Port Range To:");
                portTo = int.Parse(Console.ReadLine());
                Console.Write("Hide Closed Ports (y/n):");
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        HideClosedPorts = true;
                        break;
                    case "N":
                        HideClosedPorts = false;
                        break;
                    default:
                        HideClosedPorts = false;
                        break;
                }
                PortScanner = new PortScannr(targetHost, portFrom, portTo);
                ScanningInProgress = true;
                SubscribeToEvents();
                PortScanner.Start();
                Application.DoEvents();
                while (ScanningInProgress)
                {

                }
                UnsubscribeFromEvents();
            }
            Animaonline.WindowsApi.Kernel32.CloseConsole();
        }

        static void StartScan(string Host, int PortFrom, int PortTo)
        {
            Animaonline.WindowsApi.Kernel32.ShowConsole();
            Console.Title = "Animaonline Port Scannr - " + PortScannrVersion;

            portFrom = PortFrom;
            portTo = PortTo;

            PortScanner = new PortScannr(Host, portFrom, portTo);
            ScanningInProgress = true;
            SubscribeToEvents();
            PortScanner.Start();
            Application.DoEvents();

            while (ScanningInProgress)
            {

            }
            UnsubscribeFromEvents();
            Console.WriteLine("Scan Completed... Press any key to continue");
            Console.ReadLine();
        }

        static void SubscribeToEvents()
        {
            UnsubscribeFromEvents();
            PortScanner.PortOpen += new EventHandler<PortOpenEventArgs>(OnPortOpen);
            PortScanner.PortClosed += new EventHandler<PortClosedEventArgs>(OnPortClosed);
            PortScanner.ScanCompleted += new EventHandler<ScanCompletedEventArgs>(OnScanCompleted);
            PortScanner.ErrorOccurred += new EventHandler<ErrorOccurredEventArgs>(OnErrorOccurred);
        }

        static void OnPortOpen(object sender, PortOpenEventArgs e)
        {
            Console.Title = "Animaonline Port Scannr - " + PortScannrVersion + string.Format(" - Scanning Port {0}/{1} ({2}%)", e.Port, portTo, Math.Round((decimal)100 / portTo * e.Port));
            Console.WriteLine(e.Host + ":" + e.Port + " is OPEN - Service Name:" + PortScannr.GetServiceName(e.Port));
        }

        static void OnPortClosed(object sender, PortClosedEventArgs e)
        {
            Console.Title = "Animaonline Port Scannr - " + PortScannrVersion + string.Format(" - Scanning Port {0}/{1} ({2}%)", e.Port, portTo, Math.Round((decimal)100 / portTo * e.Port));
            if (!HideClosedPorts)
            {
                Console.WriteLine(e.Host + ":" + e.Port + " is CLOSED - Service Name:" + PortScannr.GetServiceName(e.Port));
            }
        }

        static void OnScanCompleted(object sender, ScanCompletedEventArgs e)
        {
            Console.Title = "Animaonline Port Scannr - " + PortScannrVersion + " - Scan Completed...";
            ScanningInProgress = false;
        }

        static void OnErrorOccurred(object sender, ErrorOccurredEventArgs e)
        {
            // Console.WriteLine(e.Exception.Message);
        }

        static void UnsubscribeFromEvents()
        {
            PortScanner.PortOpen -= new EventHandler<Animaonline.Network.PortOpenEventArgs>(OnPortOpen);
            PortScanner.PortClosed -= new EventHandler<Animaonline.Network.PortClosedEventArgs>(OnPortClosed);
            PortScanner.ScanCompleted -= new EventHandler<Animaonline.Network.ScanCompletedEventArgs>(OnScanCompleted);
            PortScanner.ErrorOccurred -= new EventHandler<Animaonline.Network.ErrorOccurredEventArgs>(OnErrorOccurred);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Animaonline.Network.GUI.ScannrThread.Abort();
            }
            catch { }
            finally
            {
                Animaonline.Network.GUI.ScannrThread = null;
            }
        }
    }
}
