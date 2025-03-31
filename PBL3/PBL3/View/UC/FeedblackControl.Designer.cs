namespace PBL3.View.UC
{
    partial class FeedblackControl
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
            this.IDText = new System.Windows.Forms.TextBox();
            this.SendBT = new System.Windows.Forms.Button();
            this.CharityIDLabel = new System.Windows.Forms.Label();
            this.CharityDateTimeLabel = new System.Windows.Forms.Label();
            this.ContactInfoTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CharityNameLabel = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FeedbackTime = new System.Windows.Forms.DateTimePicker();
            this.FeedbackDate = new System.Windows.Forms.DateTimePicker();
            this.DELETE = new System.Windows.Forms.Button();
            this.UPDATE = new System.Windows.Forms.Button();
            this.UserIDTxt = new System.Windows.Forms.TextBox();
            this.UserIDLB = new System.Windows.Forms.Label();
            this.TopicTxt = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sortccb = new System.Windows.Forms.ComboBox();
            this.SearchBT = new System.Windows.Forms.Button();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.CharityDescriptionLable = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDText
            // 
            this.IDText.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.IDText.Location = new System.Drawing.Point(222, 21);
            this.IDText.Name = "IDText";
            this.IDText.ReadOnly = true;
            this.IDText.Size = new System.Drawing.Size(294, 29);
            this.IDText.TabIndex = 68;
            // 
            // SendBT
            // 
            this.SendBT.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.SendBT.Location = new System.Drawing.Point(1069, 13);
            this.SendBT.Name = "SendBT";
            this.SendBT.Size = new System.Drawing.Size(85, 32);
            this.SendBT.TabIndex = 77;
            this.SendBT.Text = "Send";
            this.SendBT.UseVisualStyleBackColor = true;
            this.SendBT.Click += new System.EventHandler(this.SendBT_Click);
            // 
            // CharityIDLabel
            // 
            this.CharityIDLabel.AutoSize = true;
            this.CharityIDLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CharityIDLabel.Location = new System.Drawing.Point(164, 24);
            this.CharityIDLabel.Name = "CharityIDLabel";
            this.CharityIDLabel.Size = new System.Drawing.Size(33, 21);
            this.CharityIDLabel.TabIndex = 64;
            this.CharityIDLabel.Text = "ID:";
            // 
            // CharityDateTimeLabel
            // 
            this.CharityDateTimeLabel.AutoSize = true;
            this.CharityDateTimeLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CharityDateTimeLabel.Location = new System.Drawing.Point(641, 75);
            this.CharityDateTimeLabel.Name = "CharityDateTimeLabel";
            this.CharityDateTimeLabel.Size = new System.Drawing.Size(53, 21);
            this.CharityDateTimeLabel.TabIndex = 73;
            this.CharityDateTimeLabel.Text = "Date :";
            // 
            // ContactInfoTxt
            // 
            this.ContactInfoTxt.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.ContactInfoTxt.Location = new System.Drawing.Point(729, 28);
            this.ContactInfoTxt.Name = "ContactInfoTxt";
            this.ContactInfoTxt.Size = new System.Drawing.Size(294, 29);
            this.ContactInfoTxt.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.label1.Location = new System.Drawing.Point(597, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 65;
            this.label1.Text = "Contact Info:";
            // 
            // CharityNameLabel
            // 
            this.CharityNameLabel.AutoSize = true;
            this.CharityNameLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CharityNameLabel.Location = new System.Drawing.Point(133, 68);
            this.CharityNameLabel.Name = "CharityNameLabel";
            this.CharityNameLabel.Size = new System.Drawing.Size(58, 21);
            this.CharityNameLabel.TabIndex = 65;
            this.CharityNameLabel.Text = "Topic:";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.title.Location = new System.Drawing.Point(10, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(86, 22);
            this.title.TabIndex = 74;
            this.title.Text = "Feedback";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.FeedbackTime);
            this.panel3.Controls.Add(this.FeedbackDate);
            this.panel3.Controls.Add(this.DELETE);
            this.panel3.Controls.Add(this.UPDATE);
            this.panel3.Controls.Add(this.IDText);
            this.panel3.Controls.Add(this.SendBT);
            this.panel3.Controls.Add(this.CharityIDLabel);
            this.panel3.Controls.Add(this.CharityDateTimeLabel);
            this.panel3.Controls.Add(this.ContactInfoTxt);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.UserIDTxt);
            this.panel3.Controls.Add(this.UserIDLB);
            this.panel3.Controls.Add(this.TopicTxt);
            this.panel3.Controls.Add(this.CharityNameLabel);
            this.panel3.Location = new System.Drawing.Point(3, 364);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1244, 154);
            this.panel3.TabIndex = 88;
            // 
            // FeedbackTime
            // 
            this.FeedbackTime.CustomFormat = "HH:mm";
            this.FeedbackTime.Enabled = false;
            this.FeedbackTime.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.FeedbackTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FeedbackTime.Location = new System.Drawing.Point(910, 72);
            this.FeedbackTime.Name = "FeedbackTime";
            this.FeedbackTime.ShowUpDown = true;
            this.FeedbackTime.Size = new System.Drawing.Size(113, 29);
            this.FeedbackTime.TabIndex = 82;
            // 
            // FeedbackDate
            // 
            this.FeedbackDate.CustomFormat = "dd MMM yyyy";
            this.FeedbackDate.Enabled = false;
            this.FeedbackDate.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.FeedbackDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FeedbackDate.Location = new System.Drawing.Point(729, 72);
            this.FeedbackDate.Name = "FeedbackDate";
            this.FeedbackDate.Size = new System.Drawing.Size(175, 29);
            this.FeedbackDate.TabIndex = 82;
            // 
            // DELETE
            // 
            this.DELETE.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.DELETE.Location = new System.Drawing.Point(1069, 57);
            this.DELETE.Name = "DELETE";
            this.DELETE.Size = new System.Drawing.Size(85, 32);
            this.DELETE.TabIndex = 80;
            this.DELETE.Text = "Delete";
            this.DELETE.UseVisualStyleBackColor = true;
            this.DELETE.Click += new System.EventHandler(this.DELETE_Click);
            // 
            // UPDATE
            // 
            this.UPDATE.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.UPDATE.Location = new System.Drawing.Point(1069, 104);
            this.UPDATE.Name = "UPDATE";
            this.UPDATE.Size = new System.Drawing.Size(85, 32);
            this.UPDATE.TabIndex = 79;
            this.UPDATE.Text = "Update";
            this.UPDATE.UseVisualStyleBackColor = true;
            this.UPDATE.Click += new System.EventHandler(this.UPDATE_Click);
            // 
            // UserIDTxt
            // 
            this.UserIDTxt.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.UserIDTxt.Location = new System.Drawing.Point(222, 106);
            this.UserIDTxt.Name = "UserIDTxt";
            this.UserIDTxt.Size = new System.Drawing.Size(294, 29);
            this.UserIDTxt.TabIndex = 66;
            // 
            // UserIDLB
            // 
            this.UserIDLB.AutoSize = true;
            this.UserIDLB.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.UserIDLB.Location = new System.Drawing.Point(133, 110);
            this.UserIDLB.Name = "UserIDLB";
            this.UserIDLB.Size = new System.Drawing.Size(68, 21);
            this.UserIDLB.TabIndex = 65;
            this.UserIDLB.Text = "UserID:";
            // 
            // TopicTxt
            // 
            this.TopicTxt.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.TopicTxt.Location = new System.Drawing.Point(222, 64);
            this.TopicTxt.Name = "TopicTxt";
            this.TopicTxt.Size = new System.Drawing.Size(294, 29);
            this.TopicTxt.TabIndex = 66;
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
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            // 
            // SearchText
            // 
            this.SearchText.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.SearchText.Location = new System.Drawing.Point(1043, 6);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(108, 25);
            this.SearchText.TabIndex = 71;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.sortccb);
            this.panel2.Controls.Add(this.title);
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Controls.Add(this.SearchBT);
            this.panel2.Controls.Add(this.SearchText);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1244, 355);
            this.panel2.TabIndex = 87;
            // 
            // sortccb
            // 
            this.sortccb.FormattingEnabled = true;
            this.sortccb.Location = new System.Drawing.Point(903, 7);
            this.sortccb.Name = "sortccb";
            this.sortccb.Size = new System.Drawing.Size(134, 24);
            this.sortccb.TabIndex = 75;
            this.sortccb.SelectedIndexChanged += new System.EventHandler(this.sortccb_SelectedIndexChanged);
            // 
            // SearchBT
            // 
            this.SearchBT.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.SearchBT.Location = new System.Drawing.Point(1160, 7);
            this.SearchBT.Name = "SearchBT";
            this.SearchBT.Size = new System.Drawing.Size(70, 24);
            this.SearchBT.TabIndex = 72;
            this.SearchBT.Text = "Search";
            this.SearchBT.UseVisualStyleBackColor = true;
            this.SearchBT.Click += new System.EventHandler(this.SearchBT_Click);
            // 
            // DescriptionText
            // 
            this.DescriptionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionText.BackColor = System.Drawing.SystemColors.HighlightText;
            this.DescriptionText.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.DescriptionText.Location = new System.Drawing.Point(10, 26);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.DescriptionText.Size = new System.Drawing.Size(1215, 161);
            this.DescriptionText.TabIndex = 82;
            this.DescriptionText.Text = "";
            // 
            // CharityDescriptionLable
            // 
            this.CharityDescriptionLable.AutoSize = true;
            this.CharityDescriptionLable.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.CharityDescriptionLable.Location = new System.Drawing.Point(3, 3);
            this.CharityDescriptionLable.Name = "CharityDescriptionLable";
            this.CharityDescriptionLable.Size = new System.Drawing.Size(74, 19);
            this.CharityDescriptionLable.TabIndex = 81;
            this.CharityDescriptionLable.Text = "Message:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.DescriptionText);
            this.panel1.Controls.Add(this.CharityDescriptionLable);
            this.panel1.Location = new System.Drawing.Point(3, 524);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 198);
            this.panel1.TabIndex = 86;
            // 
            // FeedblackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FeedblackControl";
            this.Size = new System.Drawing.Size(1250, 725);
            this.Load += new System.EventHandler(this.FeedblackControl1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox IDText;
        private System.Windows.Forms.Button SendBT;
        private System.Windows.Forms.Label CharityIDLabel;
        private System.Windows.Forms.Label CharityDateTimeLabel;
        private System.Windows.Forms.TextBox ContactInfoTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CharityNameLabel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker FeedbackDate;
        private System.Windows.Forms.Button DELETE;
        private System.Windows.Forms.Button UPDATE;
        private System.Windows.Forms.TextBox TopicTxt;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SearchBT;
        private System.Windows.Forms.RichTextBox DescriptionText;
        private System.Windows.Forms.Label CharityDescriptionLable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker FeedbackTime;
        private System.Windows.Forms.TextBox UserIDTxt;
        private System.Windows.Forms.Label UserIDLB;
        private System.Windows.Forms.ComboBox sortccb;
    }
}
