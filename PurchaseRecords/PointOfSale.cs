using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PurchaseRecords
{
    /*
     * Need to add:
     * -Delete Items
     * -Check when adding item for existing item of same name (if found, update price and quantity)
     * -Update item sorting as already set after adding new item
     * -Add more InventoryItem properties, like Barcode#, ItemID, Brand(enum?), ItemType, etc
     * -Build a purchasing system to integrate customerrecords(probably need to change main form to a new one and use 'PointOfSale' as inventory manager)
     */
    public partial class PointOfSale : Form
    {
        static void Main()
        {

            Application.Run(new PointOfSale());

        }
        public DataStore Retail { get; set; }
        string defaultFilePath = "RetailStore.bin";
        public PointOfSale()
        {
            InitializeComponent();
            this.Retail = new DataStore();
        }
        private void PointOfSale_Load(object sender, EventArgs e)
        {
            this.Retail = ReadFromFile(defaultFilePath);

            PointOfSale_UpdateInventoryDisplay(sender, e);
            //great spot to deserialize retail from disk for autoload...

        }
        private void PointOfSale_Closed(object sender, EventArgs e)
        {
            //great spot to serialize retail to disk for autosave...
            bool WriteStatus = WriteToFile(defaultFilePath, this.Retail);
            Application.Exit();
        }
        private bool WriteToFile(string filePath, DataStore dataStore)
        {
            FileStream fStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            try
            {
                //read through datastore and serialize, write to file, close filestream, return

                //using Json works, but requires that everything be a public property, so no fields, and no partial protection or private properties.
                //Need to write a custom serialization method and deserialization method that doesn't have this limitation, especially if
                //we're going to store CC data for customers.




                JsonSerializer.Serialize(fStream, dataStore, JsonSerializerOptions.Default);

                fStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving File: " + ex.Message);
                fStream.Close();
                return false;
            }

        }
        private DataStore ReadFromFile(string filePath)
        {
            FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                //create new datastore, populate it with deserialized data, close filestream, return datastore

                DataStore? tempstore = (DataStore?)JsonSerializer.Deserialize(fStream, typeof(DataStore), JsonSerializerOptions.Default);

                fStream.Close();
                return tempstore == null ? new DataStore() : (DataStore)tempstore;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Opening File: " + ex.Message);
                fStream.Close();
                return new DataStore();
            }
        }
        private void PointOfSale_UpdateInventoryDisplay(object sender, EventArgs e)
        {
            dataGridViewInventory.Rows.Clear();
            foreach (InventoryItem item in Retail.GetInventory())
            {
                dataGridViewInventory.Rows.Add(item.StockItem.Name, item.Price, item.Quantity);
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
                InventoryItem newItem = addItemForm.invItem;
                bool itemFound = false; //check through inventory for an item matching the same name. If found, update price and quantity. If not, add new item.
                for (int i = 0; i < this.Retail.Inventory.Count; i++)
                {
                    if (this.Retail.Inventory[i].StockItemName == newItem.StockItemName)
                    {
                        this.Retail.Inventory[i] = newItem;
                        itemFound = true;
                        break;
                    }
                }
                if (!itemFound)
                {
                    this.Retail.AddInventoryItem(newItem.StockItem, newItem.Quantity);
                }
            }

            PointOfSale_UpdateInventoryDisplay(sender, e);
            addItemForm.Dispose();
        }

        private void dataGridViewInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridViewInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if quantity is doubleclicked, open a quantity update form.
            if (dataGridViewInventory.Columns[e.ColumnIndex].HeaderText == "Quantity")
            {
                string? itemName = dataGridViewInventory.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (itemName != null) { MessageBox.Show("Null cell value from dblclick method"); PointOfSale_UpdateInventoryDisplay(sender, e); return; }
                int itemIndex = -1;
                for (int i = 0; i < this.Retail.Inventory.Count; i++)
                {
                    if (this.Retail.Inventory[i].StockItemName == itemName)
                    {
                        itemIndex = i;
                        break;
                    }
                }
                InventoryItem itemToEdit = this.Retail.Inventory[itemIndex];
                QuantityUpdateForm qtyForm = new QuantityUpdateForm(itemToEdit);
                DialogResult editResult = qtyForm.ShowDialog();
                if (editResult == DialogResult.OK && qtyForm.myItem != null) { this.Retail.Inventory[e.RowIndex] = (InventoryItem)qtyForm.myItem; }
                PointOfSale_UpdateInventoryDisplay(sender, e);
            }
        }
        private void dataGridViewInventory_RowDeleting(object sender, DataGridViewRowEventArgs e)
        {
            string? itemName = e.Row.Cells[0].Value.ToString();
            if (itemName == null) { MessageBox.Show("Null value from cell in deletion method"); PointOfSale_UpdateInventoryDisplay(sender, e); return; }
            int itemIndex = -1;
            for (int i = 0; i < this.Retail.Inventory.Count; i++)
            {
                if (this.Retail.Inventory[i].StockItemName == itemName)
                {
                    itemIndex = i;
                    break;
                }
            }
            if (itemIndex >= 0 && itemIndex < this.Retail.Inventory.Count)
            {
                this.Retail.Inventory.RemoveAt(itemIndex);
            }
            PointOfSale_UpdateInventoryDisplay(sender, e);
        }

        
    }
}
