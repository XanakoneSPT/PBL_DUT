namespace PBL3.View
{
    partial class ActivityControl
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
            this.CharityInfoText = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ActivityLocationInsert = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ActivityIDInsert = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.CharityIDLabel = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.Button();
            this.IDSearchBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ActivityDescriptionrichTextBox = new System.Windows.Forms.RichTextBox();
            this.CharityDescriptionLable = new System.Windows.Forms.Label();
            this.CharityLocationLabel = new System.Windows.Forms.Label();
            this.CharityDateTimeLabel = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ActivityNameInsert = new System.Windows.Forms.TextBox();
            this.CharityNameLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ActivityTimeInsert = new System.Windows.Forms.DateTimePicker();
            this.ActivityDateInsert = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CharityInfoText
            // 
            this.CharityInfoText.AutoSize = true;
            this.CharityInfoText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityInfoText.Location = new System.Drawing.Point(10, 8);
            this.CharityInfoText.Name = "CharityInfoText";
            this.CharityInfoText.Size = new System.Drawing.Size(124, 22);
            this.CharityInfoText.TabIndex = 74;
            this.CharityInfoText.Text = "Activities Info";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(1069, 57);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(85, 32);
            this.DeleteButton.TabIndex = 80;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ActivityLocationInsert
            // 
            this.ActivityLocationInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityLocationInsert.Location = new System.Drawing.Point(649, 78);
            this.ActivityLocationInsert.Name = "ActivityLocationInsert";
            this.ActivityLocationInsert.Size = new System.Drawing.Size(320, 28);
            this.ActivityLocationInsert.TabIndex = 67;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(1069, 104);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(85, 32);
            this.UpdateButton.TabIndex = 79;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ActivityIDInsert
            // 
            this.ActivityIDInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityIDInsert.Location = new System.Drawing.Point(172, 10);
            this.ActivityIDInsert.Name = "ActivityIDInsert";
            this.ActivityIDInsert.ReadOnly = true;
            this.ActivityIDInsert.Size = new System.Drawing.Size(304, 28);
            this.ActivityIDInsert.TabIndex = 68;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(1069, 13);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(85, 32);
            this.AddButton.TabIndex = 77;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CharityIDLabel
            // 
            this.CharityIDLabel.AutoSize = true;
            this.CharityIDLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityIDLabel.Location = new System.Drawing.Point(56, 13);
            this.CharityIDLabel.Name = "CharityIDLabel";
            this.CharityIDLabel.Size = new System.Drawing.Size(93, 20);
            this.CharityIDLabel.TabIndex = 64;
            this.CharityIDLabel.Text = "Activity ID:";
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
            // IDSearchBox
            // 
            this.IDSearchBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDSearchBox.Location = new System.Drawing.Point(1043, 6);
            this.IDSearchBox.Name = "IDSearchBox";
            this.IDSearchBox.Size = new System.Drawing.Size(108, 25);
            this.IDSearchBox.TabIndex = 71;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.ActivityDescriptionrichTextBox);
            this.panel1.Controls.Add(this.CharityDescriptionLable);
            this.panel1.Location = new System.Drawing.Point(3, 512);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 210);
            this.panel1.TabIndex = 77;
            // 
            // ActivityDescriptionrichTextBox
            // 
            this.ActivityDescriptionrichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActivityDescriptionrichTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ActivityDescriptionrichTextBox.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityDescriptionrichTextBox.Location = new System.Drawing.Point(10, 26);
            this.ActivityDescriptionrichTextBox.Name = "ActivityDescriptionrichTextBox";
            this.ActivityDescriptionrichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.ActivityDescriptionrichTextBox.Size = new System.Drawing.Size(1215, 173);
            this.ActivityDescriptionrichTextBox.TabIndex = 82;
            this.ActivityDescriptionrichTextBox.Text = "";
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
            // CharityLocationLabel
            // 
            this.CharityLocationLabel.AutoSize = true;
            this.CharityLocationLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityLocationLabel.Location = new System.Drawing.Point(555, 81);
            this.CharityLocationLabel.Name = "CharityLocationLabel";
            this.CharityLocationLabel.Size = new System.Drawing.Size(76, 20);
            this.CharityLocationLabel.TabIndex = 69;
            this.CharityLocationLabel.Text = "Location:";
            // 
            // CharityDateTimeLabel
            // 
            this.CharityDateTimeLabel.AutoSize = true;
            this.CharityDateTimeLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityDateTimeLabel.Location = new System.Drawing.Point(537, 13);
            this.CharityDateTimeLabel.Name = "CharityDateTimeLabel";
            this.CharityDateTimeLabel.Size = new System.Drawing.Size(94, 20);
            this.CharityDateTimeLabel.TabIndex = 73;
            this.CharityDateTimeLabel.Text = "Date Time :";
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
            this.dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentDoubleClick);
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // ActivityNameInsert
            // 
            this.ActivityNameInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityNameInsert.Location = new System.Drawing.Point(172, 76);
            this.ActivityNameInsert.Name = "ActivityNameInsert";
            this.ActivityNameInsert.Size = new System.Drawing.Size(304, 28);
            this.ActivityNameInsert.TabIndex = 66;
            // 
            // CharityNameLabel
            // 
            this.CharityNameLabel.AutoSize = true;
            this.CharityNameLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharityNameLabel.Location = new System.Drawing.Point(22, 79);
            this.CharityNameLabel.Name = "CharityNameLabel";
            this.CharityNameLabel.Size = new System.Drawing.Size(117, 20);
            this.CharityNameLabel.TabIndex = 65;
            this.CharityNameLabel.Text = "Activity Name:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.ActivityTimeInsert);
            this.panel3.Controls.Add(this.ActivityDateInsert);
            this.panel3.Controls.Add(this.DeleteButton);
            this.panel3.Controls.Add(this.ActivityLocationInsert);
            this.panel3.Controls.Add(this.UpdateButton);
            this.panel3.Controls.Add(this.ActivityIDInsert);
            this.panel3.Controls.Add(this.AddButton);
            this.panel3.Controls.Add(this.CharityIDLabel);
            this.panel3.Controls.Add(this.CharityLocationLabel);
            this.panel3.Controls.Add(this.CharityDateTimeLabel);
            this.panel3.Controls.Add(this.ActivityNameInsert);
            this.panel3.Controls.Add(this.CharityNameLabel);
            this.panel3.Location = new System.Drawing.Point(3, 364);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1244, 145);
            this.panel3.TabIndex = 79;
            // 
            // ActivityTimeInsert
            // 
            this.ActivityTimeInsert.CustomFormat = "HH:mm";
            this.ActivityTimeInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityTimeInsert.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ActivityTimeInsert.Location = new System.Drawing.Point(870, 13);
            this.ActivityTimeInsert.Name = "ActivityTimeInsert";
            this.ActivityTimeInsert.ShowUpDown = true;
            this.ActivityTimeInsert.Size = new System.Drawing.Size(99, 28);
            this.ActivityTimeInsert.TabIndex = 81;
            // 
            // ActivityDateInsert
            // 
            this.ActivityDateInsert.CustomFormat = "dd MMM yyyy";
            this.ActivityDateInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityDateInsert.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ActivityDateInsert.Location = new System.Drawing.Point(649, 13);
            this.ActivityDateInsert.Name = "ActivityDateInsert";
            this.ActivityDateInsert.Size = new System.Drawing.Size(215, 28);
            this.ActivityDateInsert.TabIndex = 82;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.CharityInfoText);
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Controls.Add(this.SearchBox);
            this.panel2.Controls.Add(this.IDSearchBox);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1244, 355);
            this.panel2.TabIndex = 78;
            // 
            // ActivityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "ActivityControl";
            this.Size = new System.Drawing.Size(1250, 725);
            this.Load += new System.EventHandler(this.ActivityControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CharityInfoText;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox ActivityLocationInsert;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TextBox ActivityIDInsert;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label CharityIDLabel;
        private System.Windows.Forms.Button SearchBox;
        private System.Windows.Forms.TextBox IDSearchBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox ActivityDescriptionrichTextBox;
        private System.Windows.Forms.Label CharityDescriptionLable;
        private System.Windows.Forms.Label CharityLocationLabel;
        private System.Windows.Forms.Label CharityDateTimeLabel;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox ActivityNameInsert;
        private System.Windows.Forms.Label CharityNameLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker ActivityTimeInsert;
        private System.Windows.Forms.DateTimePicker ActivityDateInsert;
    }
}
