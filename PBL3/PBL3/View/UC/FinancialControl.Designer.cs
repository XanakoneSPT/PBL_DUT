namespace PBL3.View.UC
{
    partial class FinancialControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.CharityInfoText = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.SearchBT = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.IDInsert = new System.Windows.Forms.TextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.CharityIDLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DescriptionrichTextBox = new System.Windows.Forms.RichTextBox();
            this.CharityDescriptionLable = new System.Windows.Forms.Label();
            this.DateInsert = new System.Windows.Forms.DateTimePicker();
            this.CharityDateTimeLabel = new System.Windows.Forms.Label();
            this.SpendingInsert = new System.Windows.Forms.TextBox();
            this.MoneyDonateLable = new System.Windows.Forms.Label();
            this.TotalMoneyInsert = new System.Windows.Forms.TextBox();
            this.CharityNameLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DonateBT = new System.Windows.Forms.Button();
            this.FinancialBT = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.CharityInfoText);
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Controls.Add(this.SearchBT);
            this.panel2.Controls.Add(this.SearchBox);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1244, 350);
            this.panel2.TabIndex = 78;
            // 
            // CharityInfoText
            // 
            this.CharityInfoText.AutoSize = true;
            this.CharityInfoText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityInfoText.Location = new System.Drawing.Point(10, 8);
            this.CharityInfoText.Name = "CharityInfoText";
            this.CharityInfoText.Size = new System.Drawing.Size(132, 22);
            this.CharityInfoText.TabIndex = 74;
            this.CharityInfoText.Text = "Financial\'s Info";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(10, 36);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1220, 302);
            this.dgv.TabIndex = 73;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            // 
            // SearchBT
            // 
            this.SearchBT.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBT.Location = new System.Drawing.Point(1160, 7);
            this.SearchBT.Name = "SearchBT";
            this.SearchBT.Size = new System.Drawing.Size(70, 24);
            this.SearchBT.TabIndex = 72;
            this.SearchBT.Text = "Search";
            this.SearchBT.UseVisualStyleBackColor = true;
            this.SearchBT.Click += new System.EventHandler(this.SearchBT_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(1043, 6);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(108, 25);
            this.SearchBox.TabIndex = 71;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(750, 80);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(79, 32);
            this.DeleteButton.TabIndex = 80;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(868, 80);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(85, 32);
            this.UpdateButton.TabIndex = 79;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // IDInsert
            // 
            this.IDInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDInsert.Location = new System.Drawing.Point(185, 16);
            this.IDInsert.Name = "IDInsert";
            this.IDInsert.ReadOnly = true;
            this.IDInsert.Size = new System.Drawing.Size(399, 28);
            this.IDInsert.TabIndex = 68;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.Location = new System.Drawing.Point(980, 80);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(94, 32);
            this.RefreshButton.TabIndex = 78;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(633, 80);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(82, 32);
            this.AddButton.TabIndex = 77;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CharityIDLabel
            // 
            this.CharityIDLabel.AutoSize = true;
            this.CharityIDLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityIDLabel.Location = new System.Drawing.Point(69, 19);
            this.CharityIDLabel.Name = "CharityIDLabel";
            this.CharityIDLabel.Size = new System.Drawing.Size(101, 20);
            this.CharityIDLabel.TabIndex = 64;
            this.CharityIDLabel.Text = "Financail ID:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.DescriptionrichTextBox);
            this.panel1.Controls.Add(this.CharityDescriptionLable);
            this.panel1.Location = new System.Drawing.Point(3, 512);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 210);
            this.panel1.TabIndex = 77;
            // 
            // DescriptionrichTextBox
            // 
            this.DescriptionrichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionrichTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.DescriptionrichTextBox.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionrichTextBox.Location = new System.Drawing.Point(10, 26);
            this.DescriptionrichTextBox.Name = "DescriptionrichTextBox";
            this.DescriptionrichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.DescriptionrichTextBox.Size = new System.Drawing.Size(1215, 173);
            this.DescriptionrichTextBox.TabIndex = 82;
            this.DescriptionrichTextBox.Text = "";
            // 
            // CharityDescriptionLable
            // 
            this.CharityDescriptionLable.AutoSize = true;
            this.CharityDescriptionLable.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityDescriptionLable.Location = new System.Drawing.Point(3, 3);
            this.CharityDescriptionLable.Name = "CharityDescriptionLable";
            this.CharityDescriptionLable.Size = new System.Drawing.Size(95, 19);
            this.CharityDescriptionLable.TabIndex = 81;
            this.CharityDescriptionLable.Text = "Description:";
            // 
            // DateInsert
            // 
            this.DateInsert.CustomFormat = "dd  MMMM  yyyy";
            this.DateInsert.Enabled = false;
            this.DateInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateInsert.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateInsert.Location = new System.Drawing.Point(750, 13);
            this.DateInsert.Name = "DateInsert";
            this.DateInsert.Size = new System.Drawing.Size(324, 28);
            this.DateInsert.TabIndex = 74;
            // 
            // CharityDateTimeLabel
            // 
            this.CharityDateTimeLabel.AutoSize = true;
            this.CharityDateTimeLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityDateTimeLabel.Location = new System.Drawing.Point(621, 19);
            this.CharityDateTimeLabel.Name = "CharityDateTimeLabel";
            this.CharityDateTimeLabel.Size = new System.Drawing.Size(94, 20);
            this.CharityDateTimeLabel.TabIndex = 73;
            this.CharityDateTimeLabel.Text = "Date Time :";
            // 
            // SpendingInsert
            // 
            this.SpendingInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpendingInsert.Location = new System.Drawing.Point(185, 104);
            this.SpendingInsert.Name = "SpendingInsert";
            this.SpendingInsert.Size = new System.Drawing.Size(399, 28);
            this.SpendingInsert.TabIndex = 76;
            // 
            // MoneyDonateLable
            // 
            this.MoneyDonateLable.AutoSize = true;
            this.MoneyDonateLable.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoneyDonateLable.Location = new System.Drawing.Point(48, 112);
            this.MoneyDonateLable.Name = "MoneyDonateLable";
            this.MoneyDonateLable.Size = new System.Drawing.Size(122, 20);
            this.MoneyDonateLable.TabIndex = 75;
            this.MoneyDonateLable.Text = "Spende Money:";
            // 
            // TotalMoneyInsert
            // 
            this.TotalMoneyInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalMoneyInsert.Location = new System.Drawing.Point(185, 63);
            this.TotalMoneyInsert.Name = "TotalMoneyInsert";
            this.TotalMoneyInsert.Size = new System.Drawing.Size(399, 28);
            this.TotalMoneyInsert.TabIndex = 66;
            // 
            // CharityNameLabel
            // 
            this.CharityNameLabel.AutoSize = true;
            this.CharityNameLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityNameLabel.Location = new System.Drawing.Point(64, 66);
            this.CharityNameLabel.Name = "CharityNameLabel";
            this.CharityNameLabel.Size = new System.Drawing.Size(106, 20);
            this.CharityNameLabel.TabIndex = 65;
            this.CharityNameLabel.Text = "Total Money:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.DonateBT);
            this.panel3.Controls.Add(this.FinancialBT);
            this.panel3.Controls.Add(this.DeleteButton);
            this.panel3.Controls.Add(this.UpdateButton);
            this.panel3.Controls.Add(this.IDInsert);
            this.panel3.Controls.Add(this.RefreshButton);
            this.panel3.Controls.Add(this.AddButton);
            this.panel3.Controls.Add(this.CharityIDLabel);
            this.panel3.Controls.Add(this.DateInsert);
            this.panel3.Controls.Add(this.CharityDateTimeLabel);
            this.panel3.Controls.Add(this.SpendingInsert);
            this.panel3.Controls.Add(this.MoneyDonateLable);
            this.panel3.Controls.Add(this.TotalMoneyInsert);
            this.panel3.Controls.Add(this.CharityNameLabel);
            this.panel3.Location = new System.Drawing.Point(3, 359);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1244, 147);
            this.panel3.TabIndex = 79;
            // 
            // DonateBT
            // 
            this.DonateBT.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonateBT.Location = new System.Drawing.Point(1110, 57);
            this.DonateBT.Name = "DonateBT";
            this.DonateBT.Size = new System.Drawing.Size(115, 32);
            this.DonateBT.TabIndex = 81;
            this.DonateBT.Text = "Donate";
            this.DonateBT.UseVisualStyleBackColor = true;
            this.DonateBT.Click += new System.EventHandler(this.DonateBT_Click);
            // 
            // FinancialBT
            // 
            this.FinancialBT.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinancialBT.Location = new System.Drawing.Point(1110, 12);
            this.FinancialBT.Name = "FinancialBT";
            this.FinancialBT.Size = new System.Drawing.Size(115, 32);
            this.FinancialBT.TabIndex = 82;
            this.FinancialBT.Text = "Financial";
            this.FinancialBT.UseVisualStyleBackColor = true;
            // 
            // FinancialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "FinancialControl";
            this.Size = new System.Drawing.Size(1250, 725);
            this.Load += new System.EventHandler(this.FinancialControl_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label CharityInfoText;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button SearchBT;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TextBox IDInsert;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label CharityIDLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox DescriptionrichTextBox;
        private System.Windows.Forms.Label CharityDescriptionLable;
        private System.Windows.Forms.DateTimePicker DateInsert;
        private System.Windows.Forms.Label CharityDateTimeLabel;
        private System.Windows.Forms.TextBox SpendingInsert;
        private System.Windows.Forms.Label MoneyDonateLable;
        private System.Windows.Forms.TextBox TotalMoneyInsert;
        private System.Windows.Forms.Label CharityNameLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button DonateBT;
        private System.Windows.Forms.Button FinancialBT;
    }
}
