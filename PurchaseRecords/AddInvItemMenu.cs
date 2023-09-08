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
    public partial class AddInvItemMenu : Form
    {
        public InventoryItem invItem;
        public AddInvItemMenu()
        {
            InitializeComponent();
            lblError.Visible = false;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            //only allow numerical integer entry into txtQuantity
            char[] chars = txtQuantity.Text.ToLower().ToCharArray();
            string output = "";
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= 48 && chars[i] <= 57)
                {
                    output += chars[i];
                }
            }
            txtQuantity.Text = output;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            //only allow numerical integer or decimal point entry into txtPrice
            char[] chars = txtPrice.Text.ToLower().ToCharArray();
            string output = "";
            for (int i = 0; i < chars.Length; i++)
            {
                if ((chars[i] >= 48 && chars[i] <= 57) || chars[i] == 46)
                {
                    output += chars[i];
                }
            }
            txtPrice.Text = output;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {
                lblError.Visible = false;
                invItem = new InventoryItem(new Item(txtItemName.Text, Convert.ToDecimal(txtPrice.Text)), Convert.ToInt32(txtQuantity.Text));
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
