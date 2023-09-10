using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseRecords
{
    public partial class QuantityUpdateForm : Form
    {
        public QuantityUpdateForm()
        {
            InitializeComponent();
        }
        public QuantityUpdateForm(InventoryItem invItem)
        {
            this.myItem = invItem;
            InitializeComponent();
        }
        public InventoryItem? myItem;
        private void QuantityUpdateForm_Load(object sender, EventArgs e)
        {
            if (myItem == null) { myItem = new InventoryItem(new Item("Empty Item")); }
            myItem = (InventoryItem)myItem;
            txtQuantity.TextAlign = HorizontalAlignment.Center;
            txtQuantity.Text = ((InventoryItem)myItem).Quantity.ToString();
            lblItemNameDisplay.Text = ((InventoryItem)myItem).StockItemName.ToString();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            //Only allow numerical entry.
            string txtOut = "";
            foreach (char c in txtQuantity.Text)
            {
                if (c >= 48 && c <= 57) { txtOut += c; }
            }
            txtQuantity.Text = txtOut;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            InventoryItem tempItem = (myItem == null) ? new InventoryItem(new Item("Empty")) : (InventoryItem)myItem;
            tempItem.Quantity = Int32.Parse(txtQuantity.Text);
            myItem = tempItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
