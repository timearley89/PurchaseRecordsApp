namespace PurchaseRecords
{
    partial class QuantityUpdateForm
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
            btnSubmit = new Button();
            btnCancel = new Button();
            lblItemName = new Label();
            lblItemNameDisplay = new Label();
            lblQty = new Label();
            txtQuantity = new TextBox();
            SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(12, 75);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(110, 33);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(137, 75);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 33);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Location = new Point(12, 9);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(72, 15);
            lblItemName.TabIndex = 4;
            lblItemName.Text = "Item Name: ";
            // 
            // lblItemNameDisplay
            // 
            lblItemNameDisplay.AutoSize = true;
            lblItemNameDisplay.Location = new Point(109, 9);
            lblItemNameDisplay.Name = "lblItemNameDisplay";
            lblItemNameDisplay.Size = new Size(39, 15);
            lblItemNameDisplay.TabIndex = 3;
            lblItemNameDisplay.Text = "Name";
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Location = new Point(12, 39);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(56, 15);
            lblQty.TabIndex = 5;
            lblQty.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(109, 36);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(138, 23);
            txtQuantity.TabIndex = 0;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // QuantityUpdateForm
            // 
            AcceptButton = btnSubmit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(261, 120);
            Controls.Add(txtQuantity);
            Controls.Add(lblQty);
            Controls.Add(lblItemNameDisplay);
            Controls.Add(lblItemName);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Name = "QuantityUpdateForm";
            Text = "Update Quantity";
            Load += QuantityUpdateForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSubmit;
        private Button btnCancel;
        private Label lblItemName;
        private Label lblItemNameDisplay;
        private Label lblQty;
        private TextBox txtQuantity;
    }
}