namespace PurchaseRecords
{
    partial class PointOfSale
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
            components = new System.ComponentModel.Container();
            btnAddNewInvItem = new Button();
            dataGridViewInventory = new DataGridView();
            colItemName = new DataGridViewTextBoxColumn();
            colItemPrice = new DataGridViewTextBoxColumn();
            colItemQuantity = new DataGridViewTextBoxColumn();
            bindingSourceInventory = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceInventory).BeginInit();
            SuspendLayout();
            // 
            // btnAddNewInvItem
            // 
            btnAddNewInvItem.Location = new Point(22, 385);
            btnAddNewInvItem.Name = "btnAddNewInvItem";
            btnAddNewInvItem.Size = new Size(157, 43);
            btnAddNewInvItem.TabIndex = 0;
            btnAddNewInvItem.Text = "Add New Inventory Item";
            btnAddNewInvItem.UseVisualStyleBackColor = true;
            btnAddNewInvItem.Click += btnAddNewInvItem_Click;
            // 
            // dataGridViewInventory
            // 
            dataGridViewInventory.AllowUserToAddRows = false;
            dataGridViewInventory.AllowUserToOrderColumns = true;
            dataGridViewInventory.AllowUserToResizeColumns = false;
            dataGridViewInventory.AllowUserToResizeRows = false;
            dataGridViewInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInventory.Columns.AddRange(new DataGridViewColumn[] { colItemName, colItemPrice, colItemQuantity });
            dataGridViewInventory.Location = new Point(22, 25);
            dataGridViewInventory.Name = "dataGridViewInventory";
            dataGridViewInventory.RowTemplate.Height = 25;
            dataGridViewInventory.Size = new Size(358, 343);
            dataGridViewInventory.TabIndex = 1;
            dataGridViewInventory.CellContentClick += dataGridViewInventory_CellContentClick;
            dataGridViewInventory.CellDoubleClick += dataGridViewInventory_CellDoubleClick;
            dataGridViewInventory.UserDeletedRow += dataGridViewInventory_RowDeleting;
            //dataGridViewInventory.UserDeletingRow += dataGridViewInventory_RowDeleting;
            // 
            // colItemName
            // 
            colItemName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colItemName.DataPropertyName = "StockItemName";
            colItemName.HeaderText = "Item Name";
            colItemName.Name = "colItemName";
            colItemName.ReadOnly = true;
            // 
            // colItemPrice
            // 
            colItemPrice.DataPropertyName = "Price";
            colItemPrice.HeaderText = "Price";
            colItemPrice.Name = "colItemPrice";
            colItemPrice.ReadOnly = true;
            colItemPrice.Width = 58;
            // 
            // colItemQuantity
            // 
            colItemQuantity.DataPropertyName = "Quantity";
            colItemQuantity.HeaderText = "Quantity";
            colItemQuantity.Name = "colItemQuantity";
            colItemQuantity.ReadOnly = true;
            colItemQuantity.Width = 78;
            // 
            // PointOfSale
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewInventory);
            Controls.Add(btnAddNewInvItem);
            Name = "PointOfSale";
            Text = "PointOfSale";
            FormClosed += PointOfSale_Closed;
            Load += PointOfSale_Load;
            Enter += PointOfSale_UpdateInventoryDisplay;
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceInventory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddNewInvItem;
        private DataGridView dataGridViewInventory;
        private BindingSource bindingSourceInventory;
        private DataGridViewTextBoxColumn colItemName;
        private DataGridViewTextBoxColumn colItemPrice;
        private DataGridViewTextBoxColumn colItemQuantity;
    }
}