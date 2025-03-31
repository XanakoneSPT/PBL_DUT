namespace PBL3.View
{
    partial class EquipmentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.EquipmentRefreshButton = new System.Windows.Forms.Button();
            this.EquipmentIDInsert = new System.Windows.Forms.TextBox();
            this.EquipmentIDLabel = new System.Windows.Forms.Label();
            this.EquipmentNameLabel = new System.Windows.Forms.Label();
            this.EquipmentUpdateButton = new System.Windows.Forms.Button();
            this.EquipmentNameInsert = new System.Windows.Forms.TextBox();
            this.EquipmentDeleteButton = new System.Windows.Forms.Button();
            this.EquipmentAmountLabel = new System.Windows.Forms.Label();
            this.EquipmentAddButton = new System.Windows.Forms.Button();
            this.EquipmentAmountInsert = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.EquipmetnInfoText = new System.Windows.Forms.Label();
            this.EquipmentIDSearchBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.EquipmentRefreshButton);
            this.panel4.Controls.Add(this.EquipmentIDInsert);
            this.panel4.Controls.Add(this.EquipmentIDLabel);
            this.panel4.Controls.Add(this.EquipmentNameLabel);
            this.panel4.Controls.Add(this.EquipmentUpdateButton);
            this.panel4.Controls.Add(this.EquipmentNameInsert);
            this.panel4.Controls.Add(this.EquipmentDeleteButton);
            this.panel4.Controls.Add(this.EquipmentAmountLabel);
            this.panel4.Controls.Add(this.EquipmentAddButton);
            this.panel4.Controls.Add(this.EquipmentAmountInsert);
            this.panel4.Location = new System.Drawing.Point(3, 523);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1228, 189);
            this.panel4.TabIndex = 72;
            // 
            // EquipmentRefreshButton
            // 
            this.EquipmentRefreshButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentRefreshButton.Location = new System.Drawing.Point(797, 121);
            this.EquipmentRefreshButton.Name = "EquipmentRefreshButton";
            this.EquipmentRefreshButton.Size = new System.Drawing.Size(94, 34);
            this.EquipmentRefreshButton.TabIndex = 68;
            this.EquipmentRefreshButton.Text = "Refresh";
            this.EquipmentRefreshButton.UseVisualStyleBackColor = true;
            this.EquipmentRefreshButton.Click += new System.EventHandler(this.EquipmentRefreshButton_Click);
            // 
            // EquipmentIDInsert
            // 
            this.EquipmentIDInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentIDInsert.Location = new System.Drawing.Point(250, 23);
            this.EquipmentIDInsert.Name = "EquipmentIDInsert";
            this.EquipmentIDInsert.ReadOnly = true;
            this.EquipmentIDInsert.Size = new System.Drawing.Size(262, 28);
            this.EquipmentIDInsert.TabIndex = 63;
            // 
            // EquipmentIDLabel
            // 
            this.EquipmentIDLabel.AutoSize = true;
            this.EquipmentIDLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentIDLabel.Location = new System.Drawing.Point(106, 27);
            this.EquipmentIDLabel.Name = "EquipmentIDLabel";
            this.EquipmentIDLabel.Size = new System.Drawing.Size(115, 20);
            this.EquipmentIDLabel.TabIndex = 57;
            this.EquipmentIDLabel.Text = "Equipment ID:";
            // 
            // EquipmentNameLabel
            // 
            this.EquipmentNameLabel.AutoSize = true;
            this.EquipmentNameLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentNameLabel.Location = new System.Drawing.Point(76, 65);
            this.EquipmentNameLabel.Name = "EquipmentNameLabel";
            this.EquipmentNameLabel.Size = new System.Drawing.Size(139, 20);
            this.EquipmentNameLabel.TabIndex = 58;
            this.EquipmentNameLabel.Text = "Equipment Name:";
            // 
            // EquipmentUpdateButton
            // 
            this.EquipmentUpdateButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentUpdateButton.Location = new System.Drawing.Point(658, 121);
            this.EquipmentUpdateButton.Name = "EquipmentUpdateButton";
            this.EquipmentUpdateButton.Size = new System.Drawing.Size(94, 34);
            this.EquipmentUpdateButton.TabIndex = 66;
            this.EquipmentUpdateButton.Text = "Update";
            this.EquipmentUpdateButton.UseVisualStyleBackColor = true;
            this.EquipmentUpdateButton.Click += new System.EventHandler(this.EquipmentUpdateButton_Click);
            // 
            // EquipmentNameInsert
            // 
            this.EquipmentNameInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentNameInsert.Location = new System.Drawing.Point(250, 61);
            this.EquipmentNameInsert.Name = "EquipmentNameInsert";
            this.EquipmentNameInsert.Size = new System.Drawing.Size(262, 28);
            this.EquipmentNameInsert.TabIndex = 59;
            // 
            // EquipmentDeleteButton
            // 
            this.EquipmentDeleteButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentDeleteButton.Location = new System.Drawing.Point(509, 121);
            this.EquipmentDeleteButton.Name = "EquipmentDeleteButton";
            this.EquipmentDeleteButton.Size = new System.Drawing.Size(94, 34);
            this.EquipmentDeleteButton.TabIndex = 65;
            this.EquipmentDeleteButton.Text = "Delete";
            this.EquipmentDeleteButton.UseVisualStyleBackColor = true;
            this.EquipmentDeleteButton.Click += new System.EventHandler(this.EquipmentDeleteButton_Click);
            // 
            // EquipmentAmountLabel
            // 
            this.EquipmentAmountLabel.AutoSize = true;
            this.EquipmentAmountLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentAmountLabel.Location = new System.Drawing.Point(640, 27);
            this.EquipmentAmountLabel.Name = "EquipmentAmountLabel";
            this.EquipmentAmountLabel.Size = new System.Drawing.Size(71, 20);
            this.EquipmentAmountLabel.TabIndex = 60;
            this.EquipmentAmountLabel.Text = "Amount:";
            // 
            // EquipmentAddButton
            // 
            this.EquipmentAddButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentAddButton.Location = new System.Drawing.Point(371, 121);
            this.EquipmentAddButton.Name = "EquipmentAddButton";
            this.EquipmentAddButton.Size = new System.Drawing.Size(94, 34);
            this.EquipmentAddButton.TabIndex = 64;
            this.EquipmentAddButton.Text = "Add";
            this.EquipmentAddButton.UseVisualStyleBackColor = true;
            this.EquipmentAddButton.Click += new System.EventHandler(this.EquipmentAddButton_Click);
            // 
            // EquipmentAmountInsert
            // 
            this.EquipmentAmountInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentAmountInsert.Location = new System.Drawing.Point(727, 27);
            this.EquipmentAmountInsert.Name = "EquipmentAmountInsert";
            this.EquipmentAmountInsert.Size = new System.Drawing.Size(267, 28);
            this.EquipmentAmountInsert.TabIndex = 61;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.SearchButton);
            this.panel3.Controls.Add(this.dgv);
            this.panel3.Controls.Add(this.EquipmetnInfoText);
            this.panel3.Controls.Add(this.EquipmentIDSearchBox);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1228, 514);
            this.panel3.TabIndex = 71;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(1151, 14);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(70, 24);
            this.SearchButton.TabIndex = 70;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.NullValue = null;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(10, 44);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1215, 458);
            this.dgv.TabIndex = 1;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentDataGridView_CellContentClick);
            this.dgv.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EquipmentDataGridView_CellMouseDown);
            // 
            // EquipmetnInfoText
            // 
            this.EquipmetnInfoText.AutoSize = true;
            this.EquipmetnInfoText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmetnInfoText.Location = new System.Drawing.Point(5, 7);
            this.EquipmetnInfoText.Name = "EquipmetnInfoText";
            this.EquipmetnInfoText.Size = new System.Drawing.Size(142, 22);
            this.EquipmetnInfoText.TabIndex = 54;
            this.EquipmetnInfoText.Text = "Equipment\'s Info";
            // 
            // EquipmentIDSearchBox
            // 
            this.EquipmentIDSearchBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentIDSearchBox.Location = new System.Drawing.Point(1037, 14);
            this.EquipmentIDSearchBox.Name = "EquipmentIDSearchBox";
            this.EquipmentIDSearchBox.Size = new System.Drawing.Size(108, 25);
            this.EquipmentIDSearchBox.TabIndex = 56;
            this.EquipmentIDSearchBox.TextChanged += new System.EventHandler(this.EquipmentIDSearchBox_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 52);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.EquipmentDeleteButton_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.EquipmentRefreshButton_Click);
            // 
            // EquipmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "EquipmentControl";
            this.Size = new System.Drawing.Size(1250, 725);
            this.Load += new System.EventHandler(this.EquipmentControl_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button EquipmentRefreshButton;
        private System.Windows.Forms.TextBox EquipmentIDInsert;
        private System.Windows.Forms.Label EquipmentIDLabel;
        private System.Windows.Forms.Label EquipmentNameLabel;
        private System.Windows.Forms.Button EquipmentUpdateButton;
        private System.Windows.Forms.TextBox EquipmentNameInsert;
        private System.Windows.Forms.Button EquipmentDeleteButton;
        private System.Windows.Forms.Label EquipmentAmountLabel;
        private System.Windows.Forms.Button EquipmentAddButton;
        private System.Windows.Forms.TextBox EquipmentAmountInsert;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label EquipmetnInfoText;
        private System.Windows.Forms.TextBox EquipmentIDSearchBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}
