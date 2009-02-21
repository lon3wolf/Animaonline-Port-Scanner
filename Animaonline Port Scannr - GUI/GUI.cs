using System;
using System.ComponentModel;
using System.Data;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Reflection;

namespace Animaonline.Network
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            try
            {
                Text = Application.ProductName + " - 1.1.3.0";
            }
            catch { }
            PortScanner = new Animaonline.Network.PortScannr();
            SubscribeToEvents();
#if DEBUG
            textBoxHostName.Text = "localhost";
#endif
            statusLabel.Text = string.Empty;
            portRangeFrom.Value = 0;
            portRangeTo.Value = 100;
            saveScanResultsDialog.InitialDirectory = Application.StartupPath;
            SetStatus(" - " + Application.ProductName + " - Started");
        }

        private void InitializeDataTable()
        {
            ScanResultsTable = new DataTable();
            ScanResultsTable.Locale = new System.Globalization.CultureInfo("en-US");
            ScanResultsTable.TableName = "ScanResults";
            ScanResultsTable.Columns.Add("Host", typeof(string));
            ScanResultsTable.Columns.Add("Port", typeof(int));
            ScanResultsTable.Columns.Add("State", typeof(string));
            ScanResultsTable.Columns.Add("Service", typeof(string));
            ScanResultsTable.Columns.Add("Timestamp", typeof(string));
        }

        private void SubscribeToEvents()
        {
            UnsubscribeFromEvents();
            PortScanner.PortOpen += new EventHandler<Animaonline.Network.PortOpenEventArgs>(OnPortOpen);
            PortScanner.PortClosed += new EventHandler<Animaonline.Network.PortClosedEventArgs>(OnPortClosed);
            PortScanner.ScanCompleted += new EventHandler<Animaonline.Network.ScanCompletedEventArgs>(OnScanCompleted);
            PortScanner.ErrorOccurred += new EventHandler<Animaonline.Network.ErrorOccurredEventArgs>(OnErrorOccurred);
        }

        private void UnsubscribeFromEvents()
        {
            try
            {
                PortScanner.PortOpen -= new EventHandler<Animaonline.Network.PortOpenEventArgs>(OnPortOpen);
                PortScanner.PortClosed -= new EventHandler<Animaonline.Network.PortClosedEventArgs>(OnPortClosed);
                PortScanner.ScanCompleted -= new EventHandler<Animaonline.Network.ScanCompletedEventArgs>(OnScanCompleted);
                PortScanner.ErrorOccurred -= new EventHandler<Animaonline.Network.ErrorOccurredEventArgs>(OnErrorOccurred);
            }
            catch { }
        }

        private void SetStatus(string status)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke((MethodInvoker)delegate
                {
                    statusLabel.Text = status;
                });
            }
            else
            {
                statusLabel.Text = status;
            }
        }

        private Animaonline.Network.PortScannr PortScanner;

        private bool ScanningInProgress = false;

        private DataTable ScanResultsTable { get; set; }

        void IncrementProgressBar()
        {
            try
            {
                SetStatus(string.Format(" - [Scanning: {0}:{1}] [Ports Left:{2}] - [{3}% Complete]", PortScanner.Host, progressBar.Value, progressBar.Maximum - progressBar.Value, Math.Round((decimal)(progressBar.Value - progressBar.Minimum) / (decimal)(progressBar.Maximum - progressBar.Minimum) * 100, 0)));
            }
            catch { }

            if (progressBar.Value < progressBar.Maximum)
            {
                if (progressBar.InvokeRequired)
                {
                    progressBar.Invoke((MethodInvoker)delegate
                    {
                        try
                        {
                            progressBar.Value += 1;
                        }
                        catch { }
                    });
                }
                else
                {
                    progressBar.Value += 1;
                }
            }
        }

        void OnPortOpen(object sender, Animaonline.Network.PortOpenEventArgs e)
        {
            DataRow openPortRow = ScanResultsTable.NewRow();

            openPortRow["Host"] = e.Host;
            openPortRow["Port"] = e.Port;
            openPortRow["State"] = "Open";
            openPortRow["Timestamp"] = DateTime.Now.ToString();
            if (checkBoxGetServiceName.Checked)
            {
                openPortRow["Service"] = Animaonline.Network.PortScannr.GetServiceName(e.Port);
            }
            try
            {
                scanResultsView.Invoke((MethodInvoker)delegate
                {
                    ScanResultsTable.Rows.Add(openPortRow);
                });
            }
            catch { }
            finally
            {
                if (scanResultsView.InvokeRequired)
                {
                    scanResultsView.Invoke((MethodInvoker)delegate
                    {
                        scanResultsView.Update();
                    });
                }
                else
                {
                    scanResultsView.Update();
                }
            }
            IncrementProgressBar();
        }

        void OnPortClosed(object sender, Animaonline.Network.PortClosedEventArgs e)
        {
            if (!checkBoxHideClosedPorts.Checked)
            {
                DataRow closedPortRow = ScanResultsTable.NewRow();
                closedPortRow["Host"] = e.Host;
                closedPortRow["Port"] = e.Port;
                closedPortRow["State"] = "Closed";
                closedPortRow["Timestamp"] = DateTime.Now.ToString();

                if (checkBoxGetServiceName.Checked)
                {
                    closedPortRow["Service"] = Animaonline.Network.PortScannr.GetServiceName(e.Port);
                }
                try
                {
                    scanResultsView.Invoke((MethodInvoker)delegate
                    {
                        ScanResultsTable.Rows.Add(closedPortRow);
                    });
                }
                catch { }
                finally
                {
                    if (scanResultsView.InvokeRequired)
                    {
                        scanResultsView.Invoke((MethodInvoker)delegate
                        {
                            scanResultsView.Update();
                            //scanResultsView.Refresh();
                        });
                    }
                    else
                    {
                        scanResultsView.Update();
                        //scanResultsView.Refresh();
                    }
                }
            }
            IncrementProgressBar();
        }

        void OnScanCompleted(object sender, Animaonline.Network.ScanCompletedEventArgs e)
        {
            ScanningInProgress = false;
            UnsubscribeFromEvents();
            SetStatus(" - [Scan Completed] [Time elapsed:" + e.Elapsed + "]");
            PortScanner = null;
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    progressBar.Value = progressBar.Minimum;
                    textBoxHostName.Enabled = true;
                    portRangeFrom.Enabled = true;
                    portRangeTo.Enabled = true;
                    checkBoxHideClosedPorts.Enabled = true;
                    checkBoxGetServiceName.Enabled = true;
                    contextMenuScanResults.Enabled = true;
                    buttonStartScan.Enabled = true;
                    buttonStartScan.Image = Properties.Resources.StartScan;
                    buttonStartScan.Text = "Start Scan";
                });
            }
            else
            {
                progressBar.Value = progressBar.Minimum;
                textBoxHostName.Enabled = true;
                portRangeFrom.Enabled = true;
                portRangeTo.Enabled = true;
                checkBoxHideClosedPorts.Enabled = true;
                checkBoxGetServiceName.Enabled = true;
                buttonStartScan.Enabled = true;
                buttonStartScan.Image = Properties.Resources.StartScan;
                buttonStartScan.Text = "Start Scan";
            }
        }

        void OnErrorOccurred(object sender, Animaonline.Network.ErrorOccurredEventArgs e)
        {
            if (e.Exception is SocketException)
            {
                if (((System.Net.Sockets.SocketException)(e.Exception)).ErrorCode != 10061 & ((System.Net.Sockets.SocketException)(e.Exception)).ErrorCode != 10049)
                {
                    SetStatus(e.Exception.Message);
                }
            }
        }

        public static Thread ScannrThread { get; set; }
        private void ScanAsync()
        {
            ScannrThread = new Thread(new ThreadStart(Scan));
            ScannrThread.Priority = ThreadPriority.Highest;
            ScannrThread.Start();
        }

        private void Scan()
        {
            PortScanner.Start();
        }

        private bool CheckReadyToScan()
        {
            if (portRangeFrom.Value == portRangeTo.Value | portRangeFrom.Value > portRangeTo.Value)
            {
                MessageBox.Show(String.Format("Invalid Port Range [{0}-{1}]", portRangeFrom.Value, portRangeTo.Value), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (!string.IsNullOrEmpty(textBoxHostName.Text))
                {
                    try
                    {
                        Dns.GetHostEntry(textBoxHostName.Text);
                        return true;
                    }
                    catch (Exception ResolveHostException)
                    {
                        MessageBox.Show(ResolveHostException.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("'Host Name' cannot be left blank", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
        }

        private void buttonStartScanClick(object sender, EventArgs e)
        {
            if (ScanningInProgress)
            {
                try
                {
                    PortScanner.Cancel();
                    ScannrThread.Abort();
                    ScannrThread = null;
                }
                catch { }
                finally
                {
                    ScannrThread = null;
                }
            }
            else
            {
                if (CheckReadyToScan())
                {
                    ScanningInProgress = true;
                    buttonStartScan.Image = Properties.Resources.StopScan;
                    buttonStartScan.Text = "Stop Scan";

                    SetStatus(" - [Scanning...]");
                    textBoxHostName.Enabled = false;
                    portRangeFrom.Enabled = false;
                    portRangeTo.Enabled = false;
                    checkBoxHideClosedPorts.Enabled = false;
                    checkBoxGetServiceName.Enabled = false;
                    contextMenuScanResults.Enabled = false;

                    progressBar.Minimum = (int)portRangeFrom.Value;
                    progressBar.Maximum = (int)portRangeTo.Value;
                    progressBar.Value = progressBar.Minimum;

                    InitializeDataTable();
                    scanResultsView.DataSource = ScanResultsTable;
                    foreach (DataGridViewColumn column in scanResultsView.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    PortScanner = new Animaonline.Network.PortScannr(textBoxHostName.Text, (int)portRangeFrom.Value, (int)portRangeTo.Value);
                    SubscribeToEvents();
                    ScanAsync();
                }
            }
        }

        private void resolveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] addressList = System.Net.Dns.GetHostEntry(textBoxHostName.Text).AddressList;
                if (addressList.Length > 1)
                {
                    using (SelectAddressForm sADF = new SelectAddressForm(addressList))
                    {
                        sADF.OnComplete += new EventHandler<OnCompleteEventArgs>(sADF_OnComplete);
                        sADF.ShowDialog();
                        sADF.OnComplete -= new EventHandler<OnCompleteEventArgs>(sADF_OnComplete);
                    }
                }
                else
                {
                    textBoxHostName.Text = addressList[0].ToString();
                }
            }
            catch (Exception resolveHostNameException)
            {
                MessageBox.Show(resolveHostNameException.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sADF_OnComplete(object sender, OnCompleteEventArgs e)
        {
            textBoxHostName.Text = e.Address.ToString();
        }

        private void scanResultsViewDataError(object sender, DataGridViewDataErrorEventArgs e)
        {/*DO NOTHING*/}


        private void checkBoxHideClosedPortsCheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxHideClosedPorts.Checked)
            {
                if (MessageBox.Show("This will decrease the performance\r\nDo you want to continue?", "Port Scannr", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    checkBoxHideClosedPorts.Checked = true;
                }
            }
        }

        private void saveScanResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveScanResultsDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(saveScanResultsDialog.FileName))
                {
                    try
                    {
                        ScanResultsTable.WriteXml(saveScanResultsDialog.FileName);
                    }
                    catch (Exception saveScanResultsException)
                    {
                        MessageBox.Show(saveScanResultsException.Message, "Scan results could not be saved!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #region Main Menu

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveScanResultsDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(saveScanResultsDialog.FileName))
                {
                    try
                    {
                        ScanResultsTable.WriteXml(saveScanResultsDialog.FileName);
                    }
                    catch (Exception saveScanResultsException)
                    {
                        MessageBox.Show(saveScanResultsException.Message, "Scan results could not be saved!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PRINT DataTable
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NotImplemented");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form1 = new Form()
            {
                FormBorderStyle = FormBorderStyle.None,
                BackgroundImage = Properties.Resources.Logo,
                Size = Properties.Resources.Logo.Size,
                ShowIcon = false,
                ShowInTaskbar = false
            };
            form1.Click += new EventHandler(form1_Click);
            form1.ShowDialog();
            //MessageBox.Show("NotImplemented");
        }

        void form1_Click(object sender, EventArgs e)
        {
            ((Form)sender).Close();
        }
        #endregion
    }
}
