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
            try
            {
                //read through datastore and serialize, write to file, close filestream, return

                //using Json works, but requires that everything be a public property, so no fields, and no partial protection or private properties.
                //Need to write a custom serialization method and deserialization method that doesn't have this limitation, especially if
                //we're going to store CC data for customers.
                
                FileStream fStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                
                
                JsonSerializer.Serialize(fStream, dataStore, JsonSerializerOptions.Default);
                
                fStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving File: " + ex.Message);
                return false;
            }
            
        }
        private DataStore ReadFromFile(string filePath)
        {
            try
            {
                //create new datastore, populate it with deserialized data, close filestream, return datastore
                FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                DataStore? tempstore = (DataStore?)JsonSerializer.Deserialize(fStream, typeof(DataStore), JsonSerializerOptions.Default);
                
                fStream.Close();
                return tempstore == null ? new DataStore() : (DataStore)tempstore;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Opening File: " + ex.Message);
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
                this.Retail.AddInventoryItem(newItem.StockItem, newItem.Quantity);
            }
            //dataGridViewInventory.AutoGenerateColumns = false;
            //dataGridViewInventory.DataSource = bindingSourceInventory;
            //bindingSourceInventory.ResetBindings(false);
            PointOfSale_UpdateInventoryDisplay(sender, e);
            addItemForm.Dispose();
        }
    }
}
