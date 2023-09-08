namespace PurchaseRecords
{
    partial class AddInvItemMenu
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
            txtItemName = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            lblItemName = new Label();
            lblItemPrice = new Label();
            lblItemQuantity = new Label();
            btnAdd = new Button();
            btnCancel = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(21, 65);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(182, 23);
            txtItemName.TabIndex = 0;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(21, 137);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(182, 23);
            txtPrice.TabIndex = 1;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(21, 212);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(182, 23);
            txtQuantity.TabIndex = 2;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Location = new Point(21, 37);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(66, 15);
            lblItemName.TabIndex = 3;
            lblItemName.Text = "Item Name";
            // 
            // lblItemPrice
            // 
            lblItemPrice.AutoSize = true;
            lblItemPrice.Location = new Point(21, 109);
            lblItemPrice.Name = "lblItemPrice";
            lblItemPrice.Size = new Size(60, 15);
            lblItemPrice.TabIndex = 4;
            lblItemPrice.Text = "Item Price";
            // 
            // lblItemQuantity
            // 
            lblItemQuantity.AutoSize = true;
            lblItemQuantity.Location = new Point(21, 184);
            lblItemQuantity.Name = "lblItemQuantity";
            lblItemQuantity.Size = new Size(80, 15);
            lblItemQuantity.TabIndex = 5;
            lblItemQuantity.Text = "Item Quantity";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(21, 270);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 48);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(128, 270);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 48);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(21, 344);
            lblError.Name = "lblError";
            lblError.Size = new Size(193, 17);
            lblError.TabIndex = 8;
            lblError.Text = "Please ensure all info is correct!";
            // 
            // AddInvItemMenu
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(230, 370);
            Controls.Add(lblError);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(lblItemQuantity);
            Controls.Add(lblItemPrice);
            Controls.Add(lblItemName);
            Controls.Add(txtQuantity);
            Controls.Add(txtPrice);
            Controls.Add(txtItemName);
            Name = "AddInvItemMenu";
            Text = "Add New Item";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtItemName;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private Label lblItemName;
        private Label lblItemPrice;
        private Label lblItemQuantity;
        private Button btnAdd;
        private Button btnCancel;
        private Label lblError;
    }
}