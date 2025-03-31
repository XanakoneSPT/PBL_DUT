namespace PBL3.View
{
    partial class AdoptionControl
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
            this.SortStatusCombobox = new System.Windows.Forms.ComboBox();
            this.SortLB = new System.Windows.Forms.Label();
            this.InfoText = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.SearchBox = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ComboboxSatatus = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DELETE = new System.Windows.Forms.Button();
            this.ChildIDText = new System.Windows.Forms.TextBox();
            this.UPDATE = new System.Windows.Forms.Button();
            this.AdoptionActivityIDText = new System.Windows.Forms.TextBox();
            this.AdoptionListBT = new System.Windows.Forms.Button();
            this.ChildrenListBT = new System.Windows.Forms.Button();
            this.SendBT = new System.Windows.Forms.Button();
            this.ADD = new System.Windows.Forms.Button();
            this.CharityIDLabel = new System.Windows.Forms.Label();
            this.CharityLocationLabel = new System.Windows.Forms.Label();
            this.StatusLB = new System.Windows.Forms.Label();
            this.CharityDateTimeLabel = new System.Windows.Forms.Label();
            this.AdopterContactInfoText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AdopterNameText = new System.Windows.Forms.TextBox();
            this.CharityNameLabel = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.CharityDescriptionLable = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.SortStatusCombobox);
            this.panel2.Controls.Add(this.SortLB);
            this.panel2.Controls.Add(this.InfoText);
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Controls.Add(this.SearchBox);
            this.panel2.Controls.Add(this.SearchText);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1244, 355);
            this.panel2.TabIndex = 81;
            // 
            // SortStatusCombobox
            // 
            this.SortStatusCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortStatusCombobox.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortStatusCombobox.FormattingEnabled = true;
            this.SortStatusCombobox.Location = new System.Drawing.Point(901, 6);
            this.SortStatusCombobox.Name = "SortStatusCombobox";
            this.SortStatusCombobox.Size = new System.Drawing.Size(122, 23);
            this.SortStatusCombobox.TabIndex = 76;
            this.SortStatusCombobox.SelectedIndexChanged += new System.EventHandler(this.SortStatusCombobox_SelectedIndexChanged);
            // 
            // SortLB
            // 
            this.SortLB.AutoSize = true;
            this.SortLB.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortLB.Location = new System.Drawing.Point(855, 8);
            this.SortLB.Name = "SortLB";
            this.SortLB.Size = new System.Drawing.Size(38, 19);
            this.SortLB.TabIndex = 75;
            this.SortLB.Text = "Sort";
            // 
            // InfoText
            // 
            this.InfoText.AutoSize = true;
            this.InfoText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoText.Location = new System.Drawing.Point(10, 8);
            this.InfoText.Name = "InfoText";
            this.InfoText.Size = new System.Drawing.Size(132, 22);
            this.InfoText.TabIndex = 74;
            this.InfoText.Text = "Adoption\'s Info";
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
            this.dgv.Size = new System.Drawing.Size(1220, 307);
            this.dgv.TabIndex = 73;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_ADOPTION_CellClick);
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(1160, 7);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(70, 24);
            this.SearchBox.TabIndex = 72;
            this.SearchBox.Text = "Search";
            this.SearchBox.UseVisualStyleBackColor = true;
            this.SearchBox.Click += new System.EventHandler(this.SearchBox_Click);
            // 
            // SearchText
            // 
            this.SearchText.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchText.Location = new System.Drawing.Point(1043, 6);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(108, 25);
            this.SearchText.TabIndex = 71;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.ComboboxSatatus);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.DELETE);
            this.panel3.Controls.Add(this.ChildIDText);
            this.panel3.Controls.Add(this.UPDATE);
            this.panel3.Controls.Add(this.AdoptionActivityIDText);
            this.panel3.Controls.Add(this.AdoptionListBT);
            this.panel3.Controls.Add(this.ChildrenListBT);
            this.panel3.Controls.Add(this.SendBT);
            this.panel3.Controls.Add(this.ADD);
            this.panel3.Controls.Add(this.CharityIDLabel);
            this.panel3.Controls.Add(this.CharityLocationLabel);
            this.panel3.Controls.Add(this.StatusLB);
            this.panel3.Controls.Add(this.CharityDateTimeLabel);
            this.panel3.Controls.Add(this.AdopterContactInfoText);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.AdopterNameText);
            this.panel3.Controls.Add(this.CharityNameLabel);
            this.panel3.Location = new System.Drawing.Point(3, 364);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1244, 145);
            this.panel3.TabIndex = 82;
            // 
            // ComboboxSatatus
            // 
            this.ComboboxSatatus.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboboxSatatus.FormattingEnabled = true;
            this.ComboboxSatatus.Location = new System.Drawing.Point(691, 102);
            this.ComboboxSatatus.Name = "ComboboxSatatus";
            this.ComboboxSatatus.Size = new System.Drawing.Size(320, 28);
            this.ComboboxSatatus.TabIndex = 83;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd  MMM  yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(691, 53);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(320, 28);
            this.dateTimePicker1.TabIndex = 82;
            // 
            // DELETE
            // 
            this.DELETE.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DELETE.Location = new System.Drawing.Point(1043, 51);
            this.DELETE.Name = "DELETE";
            this.DELETE.Size = new System.Drawing.Size(85, 32);
            this.DELETE.TabIndex = 80;
            this.DELETE.Text = "Delete";
            this.DELETE.UseVisualStyleBackColor = true;
            this.DELETE.Click += new System.EventHandler(this.DELETE_Click);
            // 
            // ChildIDText
            // 
            this.ChildIDText.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChildIDText.Location = new System.Drawing.Point(691, 11);
            this.ChildIDText.Name = "ChildIDText";
            this.ChildIDText.Size = new System.Drawing.Size(320, 28);
            this.ChildIDText.TabIndex = 67;
            // 
            // UPDATE
            // 
            this.UPDATE.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UPDATE.Location = new System.Drawing.Point(1043, 94);
            this.UPDATE.Name = "UPDATE";
            this.UPDATE.Size = new System.Drawing.Size(85, 32);
            this.UPDATE.TabIndex = 79;
            this.UPDATE.Text = "Update";
            this.UPDATE.UseVisualStyleBackColor = true;
            this.UPDATE.Click += new System.EventHandler(this.UPDATE_Click);
            // 
            // AdoptionActivityIDText
            // 
            this.AdoptionActivityIDText.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdoptionActivityIDText.Location = new System.Drawing.Point(222, 10);
            this.AdoptionActivityIDText.Name = "AdoptionActivityIDText";
            this.AdoptionActivityIDText.ReadOnly = true;
            this.AdoptionActivityIDText.Size = new System.Drawing.Size(294, 28);
            this.AdoptionActivityIDText.TabIndex = 68;
            // 
            // AdoptionListBT
            // 
            this.AdoptionListBT.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdoptionListBT.Location = new System.Drawing.Point(1134, 94);
            this.AdoptionListBT.Name = "AdoptionListBT";
            this.AdoptionListBT.Size = new System.Drawing.Size(96, 32);
            this.AdoptionListBT.TabIndex = 77;
            this.AdoptionListBT.Text = "Adoption list";
            this.AdoptionListBT.UseVisualStyleBackColor = true;
            this.AdoptionListBT.Visible = false;
            this.AdoptionListBT.Click += new System.EventHandler(this.AdoptionListBT_Click);
            // 
            // ChildrenListBT
            // 
            this.ChildrenListBT.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChildrenListBT.Location = new System.Drawing.Point(1131, 53);
            this.ChildrenListBT.Name = "ChildrenListBT";
            this.ChildrenListBT.Size = new System.Drawing.Size(99, 32);
            this.ChildrenListBT.TabIndex = 77;
            this.ChildrenListBT.Text = "Children list";
            this.ChildrenListBT.UseVisualStyleBackColor = true;
            this.ChildrenListBT.Visible = false;
            this.ChildrenListBT.Click += new System.EventHandler(this.ChildrenListBT_Click);
            // 
            // SendBT
            // 
            this.SendBT.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBT.Location = new System.Drawing.Point(1131, 8);
            this.SendBT.Name = "SendBT";
            this.SendBT.Size = new System.Drawing.Size(99, 32);
            this.SendBT.TabIndex = 77;
            this.SendBT.Text = "Send";
            this.SendBT.UseVisualStyleBackColor = true;
            this.SendBT.Visible = false;
            this.SendBT.Click += new System.EventHandler(this.SendBT_Click);
            // 
            // ADD
            // 
            this.ADD.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADD.Location = new System.Drawing.Point(1043, 8);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(85, 32);
            this.ADD.TabIndex = 77;
            this.ADD.Text = "Add";
            this.ADD.UseVisualStyleBackColor = true;
            this.ADD.Click += new System.EventHandler(this.ADD_Click);
            // 
            // CharityIDLabel
            // 
            this.CharityIDLabel.AutoSize = true;
            this.CharityIDLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityIDLabel.Location = new System.Drawing.Point(31, 14);
            this.CharityIDLabel.Name = "CharityIDLabel";
            this.CharityIDLabel.Size = new System.Drawing.Size(154, 20);
            this.CharityIDLabel.TabIndex = 64;
            this.CharityIDLabel.Text = "AdoptionActivityID:";
            // 
            // CharityLocationLabel
            // 
            this.CharityLocationLabel.AutoSize = true;
            this.CharityLocationLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityLocationLabel.Location = new System.Drawing.Point(586, 15);
            this.CharityLocationLabel.Name = "CharityLocationLabel";
            this.CharityLocationLabel.Size = new System.Drawing.Size(70, 20);
            this.CharityLocationLabel.TabIndex = 69;
            this.CharityLocationLabel.Text = "ChildID:";
            // 
            // StatusLB
            // 
            this.StatusLB.AutoSize = true;
            this.StatusLB.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLB.Location = new System.Drawing.Point(591, 100);
            this.StatusLB.Name = "StatusLB";
            this.StatusLB.Size = new System.Drawing.Size(62, 20);
            this.StatusLB.TabIndex = 73;
            this.StatusLB.Text = "Status :";
            // 
            // CharityDateTimeLabel
            // 
            this.CharityDateTimeLabel.AutoSize = true;
            this.CharityDateTimeLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityDateTimeLabel.Location = new System.Drawing.Point(603, 56);
            this.CharityDateTimeLabel.Name = "CharityDateTimeLabel";
            this.CharityDateTimeLabel.Size = new System.Drawing.Size(52, 20);
            this.CharityDateTimeLabel.TabIndex = 73;
            this.CharityDateTimeLabel.Text = "Date :";
            // 
            // AdopterContactInfoText
            // 
            this.AdopterContactInfoText.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdopterContactInfoText.Location = new System.Drawing.Point(222, 96);
            this.AdopterContactInfoText.Name = "AdopterContactInfoText";
            this.AdopterContactInfoText.Size = new System.Drawing.Size(294, 28);
            this.AdopterContactInfoText.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "AdopterContactInfo:";
            // 
            // AdopterNameText
            // 
            this.AdopterNameText.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdopterNameText.Location = new System.Drawing.Point(222, 53);
            this.AdopterNameText.Name = "AdopterNameText";
            this.AdopterNameText.Size = new System.Drawing.Size(294, 28);
            this.AdopterNameText.TabIndex = 66;
            // 
            // CharityNameLabel
            // 
            this.CharityNameLabel.AutoSize = true;
            this.CharityNameLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityNameLabel.Location = new System.Drawing.Point(58, 56);
            this.CharityNameLabel.Name = "CharityNameLabel";
            this.CharityNameLabel.Size = new System.Drawing.Size(119, 20);
            this.CharityNameLabel.TabIndex = 65;
            this.CharityNameLabel.Text = "Adopter Name:";
            // 
            // DescriptionText
            // 
            this.DescriptionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionText.BackColor = System.Drawing.SystemColors.HighlightText;
            this.DescriptionText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(10, 26);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.DescriptionText.Size = new System.Drawing.Size(1215, 173);
            this.DescriptionText.TabIndex = 82;
            this.DescriptionText.Text = "";
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.DescriptionText);
            this.panel1.Controls.Add(this.CharityDescriptionLable);
            this.panel1.Location = new System.Drawing.Point(3, 512);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 210);
            this.panel1.TabIndex = 80;
            // 
            // AdoptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "AdoptionControl";
            this.Size = new System.Drawing.Size(1250, 725);
            this.Load += new System.EventHandler(this.AdtoptionControl_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label InfoText;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button SearchBox;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button DELETE;
        private System.Windows.Forms.TextBox ChildIDText;
        private System.Windows.Forms.Button UPDATE;
        private System.Windows.Forms.TextBox AdoptionActivityIDText;
        private System.Windows.Forms.Button ADD;
        private System.Windows.Forms.Label CharityIDLabel;
        private System.Windows.Forms.Label CharityLocationLabel;
        private System.Windows.Forms.Label CharityDateTimeLabel;
        private System.Windows.Forms.TextBox AdopterNameText;
        private System.Windows.Forms.Label CharityNameLabel;
        private System.Windows.Forms.RichTextBox DescriptionText;
        private System.Windows.Forms.Label CharityDescriptionLable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox SortStatusCombobox;
        private System.Windows.Forms.Label SortLB;
        private System.Windows.Forms.TextBox AdopterContactInfoText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboboxSatatus;
        private System.Windows.Forms.Label StatusLB;
        private System.Windows.Forms.Button SendBT;
        private System.Windows.Forms.Button AdoptionListBT;
        private System.Windows.Forms.Button ChildrenListBT;
    }
}
