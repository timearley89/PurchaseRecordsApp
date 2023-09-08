using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseRecords
{
    public partial class PointOfSale : Form
    {
        static void Main()
        {

            Application.Run(new PointOfSale());

        }
        DataStore Retail;
        public PointOfSale()
        {
            InitializeComponent();
            Retail = new DataStore();
        }
        private void PointOfSale_Load(object sender, EventArgs e)
        {
            if (Retail == null) { Retail = new DataStore(); }
            bindingSourceInventory.DataSource = Retail.GetInventory();
            dataGridViewInventory.AutoGenerateColumns = false;
            dataGridViewInventory.DataSource = bindingSourceInventory;

            bindingSourceInventory.ResetBindings(false);

            //great spot to deserialize retail from disk for autoload...
        }
        private void PointOfSale_Closed(object sender, EventArgs e)
        {
            //great spot to serialize retail to disk for autosave...
            Application.Exit();
        }
        private void PointOfSale_UpdateInventoryDisplay(object sender, EventArgs e)
        {
            foreach (InventoryItem item in Retail.GetInventory())
            {

            }
        }

        private void dataStoreBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNewInvItem_Click(object sender, EventArgs e)
        {
            AddInvItemMenu addItemForm = new AddInvItemMenu();
            DialogResult addResult = addItemForm.ShowDialog();
            if (addResult == DialogResult.OK)
            {
                this.Retail.AddInventoryItem(addItemForm.invItem.StockItem, addItemForm.invItem.Quantity);
            }
            dataGridViewInventory.AutoGenerateColumns = false;
            dataGridViewInventory.DataSource = bindingSourceInventory;
            bindingSourceInventory.ResetBindings(false);
            addItemForm.Dispose();
        }
    }
}
