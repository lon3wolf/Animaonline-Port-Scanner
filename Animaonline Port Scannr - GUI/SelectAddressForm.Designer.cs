namespace Animaonline.Network
{
    partial class SelectAddressForm
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
            this.comboBoxAddressList = new System.Windows.Forms.ComboBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxAddressList
            // 
            this.comboBoxAddressList.FormattingEnabled = true;
            this.comboBoxAddressList.Location = new System.Drawing.Point(7, 21);
            this.comboBoxAddressList.Name = "comboBoxAddressList";
            this.comboBoxAddressList.Size = new System.Drawing.Size(208, 21);
            this.comboBoxAddressList.TabIndex = 0;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(4, 5);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(48, 13);
            this.labelAddress.TabIndex = 1;
            this.labelAddress.Text = "Address:";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(221, 21);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 21);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // SelectAddressForm
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 54);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.comboBoxAddressList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectAddressForm";
            this.Text = "Select Address";
            this.Load += new System.EventHandler(this.SelectAddressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAddressList;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Button buttonAccept;
    }
}