namespace Animaonline.Network
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                if (PortScanner != null)
                {
                    PortScanner.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.portRangeFrom = new System.Windows.Forms.NumericUpDown();
            this.labelPortRange = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.portRangeTo = new System.Windows.Forms.NumericUpDown();
            this.labelHost = new System.Windows.Forms.Label();
            this.groupBoxScanProperties = new System.Windows.Forms.GroupBox();
            this.textBoxHostName = new System.Windows.Forms.TextBox();
            this.contextMenuHostName = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resolveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxGetServiceName = new System.Windows.Forms.CheckBox();
            this.checkBoxHideClosedPorts = new System.Windows.Forms.CheckBox();
            this.buttonStartScan = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.scanResultsView = new System.Windows.Forms.DataGridView();
            this.contextMenuScanResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveScanResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveScanResultsDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.portRangeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portRangeTo)).BeginInit();
            this.groupBoxScanProperties.SuspendLayout();
            this.contextMenuHostName.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scanResultsView)).BeginInit();
            this.contextMenuScanResults.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // portRangeFrom
            // 
            this.portRangeFrom.Location = new System.Drawing.Point(6, 74);
            this.portRangeFrom.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.portRangeFrom.Name = "portRangeFrom";
            this.portRangeFrom.Size = new System.Drawing.Size(115, 20);
            this.portRangeFrom.TabIndex = 3;
            // 
            // labelPortRange
            // 
            this.labelPortRange.AutoSize = true;
            this.labelPortRange.Location = new System.Drawing.Point(6, 57);
            this.labelPortRange.Name = "labelPortRange";
            this.labelPortRange.Size = new System.Drawing.Size(64, 13);
            this.labelPortRange.TabIndex = 2;
            this.labelPortRange.Text = "Port Range:";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(6, 98);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(23, 13);
            this.labelTo.TabIndex = 4;
            this.labelTo.Text = "To:";
            // 
            // portRangeTo
            // 
            this.portRangeTo.Location = new System.Drawing.Point(6, 115);
            this.portRangeTo.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.portRangeTo.Name = "portRangeTo";
            this.portRangeTo.Size = new System.Drawing.Size(115, 20);
            this.portRangeTo.TabIndex = 5;
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(6, 16);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(63, 13);
            this.labelHost.TabIndex = 0;
            this.labelHost.Text = "Host Name:";
            // 
            // groupBoxScanProperties
            // 
            this.groupBoxScanProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxScanProperties.Controls.Add(this.textBoxHostName);
            this.groupBoxScanProperties.Controls.Add(this.checkBoxGetServiceName);
            this.groupBoxScanProperties.Controls.Add(this.checkBoxHideClosedPorts);
            this.groupBoxScanProperties.Controls.Add(this.labelHost);
            this.groupBoxScanProperties.Controls.Add(this.portRangeTo);
            this.groupBoxScanProperties.Controls.Add(this.portRangeFrom);
            this.groupBoxScanProperties.Controls.Add(this.labelTo);
            this.groupBoxScanProperties.Controls.Add(this.labelPortRange);
            this.groupBoxScanProperties.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxScanProperties.Location = new System.Drawing.Point(665, 27);
            this.groupBoxScanProperties.Name = "groupBoxScanProperties";
            this.groupBoxScanProperties.Size = new System.Drawing.Size(130, 265);
            this.groupBoxScanProperties.TabIndex = 3;
            this.groupBoxScanProperties.TabStop = false;
            this.groupBoxScanProperties.Text = "Scan Properties";
            // 
            // textBoxHostName
            // 
            this.textBoxHostName.ContextMenuStrip = this.contextMenuHostName;
            this.textBoxHostName.Location = new System.Drawing.Point(6, 33);
            this.textBoxHostName.Name = "textBoxHostName";
            this.textBoxHostName.Size = new System.Drawing.Size(115, 20);
            this.textBoxHostName.TabIndex = 1;
            // 
            // contextMenuHostName
            // 
            this.contextMenuHostName.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resolveToolStripMenuItem});
            this.contextMenuHostName.Name = "contextMenuHostName";
            this.contextMenuHostName.Size = new System.Drawing.Size(124, 26);
            // 
            // resolveToolStripMenuItem
            // 
            this.resolveToolStripMenuItem.Name = "resolveToolStripMenuItem";
            this.resolveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.resolveToolStripMenuItem.Text = "&Resolve";
            this.resolveToolStripMenuItem.Click += new System.EventHandler(this.resolveToolStripMenuItem_Click);
            // 
            // checkBoxGetServiceName
            // 
            this.checkBoxGetServiceName.AutoSize = true;
            this.checkBoxGetServiceName.Checked = true;
            this.checkBoxGetServiceName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGetServiceName.Location = new System.Drawing.Point(6, 160);
            this.checkBoxGetServiceName.Name = "checkBoxGetServiceName";
            this.checkBoxGetServiceName.Size = new System.Drawing.Size(113, 17);
            this.checkBoxGetServiceName.TabIndex = 7;
            this.checkBoxGetServiceName.Text = "Get Service Name";
            this.checkBoxGetServiceName.UseVisualStyleBackColor = true;
            // 
            // checkBoxHideClosedPorts
            // 
            this.checkBoxHideClosedPorts.AutoSize = true;
            this.checkBoxHideClosedPorts.Checked = true;
            this.checkBoxHideClosedPorts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHideClosedPorts.Location = new System.Drawing.Point(6, 139);
            this.checkBoxHideClosedPorts.Name = "checkBoxHideClosedPorts";
            this.checkBoxHideClosedPorts.Size = new System.Drawing.Size(110, 17);
            this.checkBoxHideClosedPorts.TabIndex = 6;
            this.checkBoxHideClosedPorts.Text = "Hide Closed Ports";
            this.checkBoxHideClosedPorts.UseVisualStyleBackColor = true;
            this.checkBoxHideClosedPorts.CheckedChanged += new System.EventHandler(this.checkBoxHideClosedPortsCheckedChanged);
            // 
            // buttonStartScan
            // 
            this.buttonStartScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartScan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStartScan.Image = global::Animaonline.Network.Properties.Resources.StartScan;
            this.buttonStartScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStartScan.Location = new System.Drawing.Point(665, 298);
            this.buttonStartScan.Name = "buttonStartScan";
            this.buttonStartScan.Size = new System.Drawing.Size(130, 39);
            this.buttonStartScan.TabIndex = 4;
            this.buttonStartScan.Text = "Start Scan";
            this.buttonStartScan.UseVisualStyleBackColor = true;
            this.buttonStartScan.Click += new System.EventHandler(this.buttonStartScanClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 340);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(803, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(79, 17);
            this.statusLabel.Text = "<StatusLabel>";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 307);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(647, 30);
            this.progressBar.TabIndex = 1;
            // 
            // scanResultsView
            // 
            this.scanResultsView.AllowUserToAddRows = false;
            this.scanResultsView.AllowUserToDeleteRows = false;
            this.scanResultsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scanResultsView.BackgroundColor = System.Drawing.Color.White;
            this.scanResultsView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scanResultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scanResultsView.ColumnHeadersVisible = false;
            this.scanResultsView.ContextMenuStrip = this.contextMenuScanResults;
            this.scanResultsView.Location = new System.Drawing.Point(12, 31);
            this.scanResultsView.Name = "scanResultsView";
            this.scanResultsView.ReadOnly = true;
            this.scanResultsView.RowHeadersVisible = false;
            this.scanResultsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scanResultsView.Size = new System.Drawing.Size(647, 270);
            this.scanResultsView.TabIndex = 0;
            this.scanResultsView.VirtualMode = true;
            this.scanResultsView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.scanResultsViewDataError);
            // 
            // contextMenuScanResults
            // 
            this.contextMenuScanResults.Enabled = false;
            this.contextMenuScanResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveScanResultsToolStripMenuItem});
            this.contextMenuScanResults.Name = "contextMenuScanResults";
            this.contextMenuScanResults.Size = new System.Drawing.Size(174, 26);
            // 
            // saveScanResultsToolStripMenuItem
            // 
            this.saveScanResultsToolStripMenuItem.Enabled = false;
            this.saveScanResultsToolStripMenuItem.Name = "saveScanResultsToolStripMenuItem";
            this.saveScanResultsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveScanResultsToolStripMenuItem.Text = "&Save Scan Results";
            this.saveScanResultsToolStripMenuItem.Click += new System.EventHandler(this.saveScanResultsToolStripMenuItem_Click);
            // 
            // saveScanResultsDialog
            // 
            this.saveScanResultsDialog.DefaultExt = "xml";
            this.saveScanResultsDialog.Filter = "XML File|*.xml|All files|*.*";
            this.saveScanResultsDialog.Title = "Save Scan Results";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(803, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 362);
            this.Controls.Add(this.scanResultsView);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBoxScanProperties);
            this.Controls.Add(this.buttonStartScan);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(390, 260);
            this.Name = "GUI";
            this.Text = "GUI";
            ((System.ComponentModel.ISupportInitialize)(this.portRangeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portRangeTo)).EndInit();
            this.groupBoxScanProperties.ResumeLayout(false);
            this.groupBoxScanProperties.PerformLayout();
            this.contextMenuHostName.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scanResultsView)).EndInit();
            this.contextMenuScanResults.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown portRangeFrom;
        private System.Windows.Forms.Label labelPortRange;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.NumericUpDown portRangeTo;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.GroupBox groupBoxScanProperties;
        private System.Windows.Forms.CheckBox checkBoxHideClosedPorts;
        private System.Windows.Forms.Button buttonStartScan;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.CheckBox checkBoxGetServiceName;
        private System.Windows.Forms.DataGridView scanResultsView;
        private System.Windows.Forms.ContextMenuStrip contextMenuHostName;
        private System.Windows.Forms.ToolStripMenuItem resolveToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuScanResults;
        private System.Windows.Forms.ToolStripMenuItem saveScanResultsToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxHostName;
        private System.Windows.Forms.SaveFileDialog saveScanResultsDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

    }
}