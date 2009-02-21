using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections.ObjectModel;

namespace Animaonline.Network
{
    public partial class SelectAddressForm : Form
    {
        public SelectAddressForm()
        {
            InitializeComponent();
        }

        public SelectAddressForm(IPAddress[] addressList)
        {
            InitializeComponent();
            AddressList = new Collection<IPAddress>(addressList);
        }

        public event EventHandler<OnCompleteEventArgs> OnComplete;

        private Collection<IPAddress> AddressList { get; set; }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (OnComplete != null)
            {
                OnComplete(this, new OnCompleteEventArgs((IPAddress)comboBoxAddressList.SelectedItem));
            }
            this.Close();
        }

        private void SelectAddressForm_Load(object sender, EventArgs e)
        {
            foreach (IPAddress address in AddressList)
            {
                comboBoxAddressList.Items.Add(address);
            }
            comboBoxAddressList.SelectedIndex = 0;
        }
    }

    public class OnCompleteEventArgs : EventArgs
    {
        public OnCompleteEventArgs(IPAddress address)
        {
            Address = address;
        }

        public IPAddress Address { get; set; }
    }
}
