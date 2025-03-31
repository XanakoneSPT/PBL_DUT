namespace PBL3.View
{
    partial class ProfileControl
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
            this.welcome = new System.Windows.Forms.Label();
            this.AddressInsert = new System.Windows.Forms.RichTextBox();
            this.CustomerIDInsert = new System.Windows.Forms.TextBox();
            this.CustomerGenderInsertBox = new System.Windows.Forms.ComboBox();
            this.CustomerIDLabel = new System.Windows.Forms.Label();
            this.CustomerDateOfBirthInsert = new System.Windows.Forms.DateTimePicker();
            this.StaffNameLabel = new System.Windows.Forms.Label();
            this.SaveUpdateButton = new System.Windows.Forms.Button();
            this.CustomerFirstNameInsert = new System.Windows.Forms.TextBox();
            this.StaffLastNameLabel = new System.Windows.Forms.Label();
            this.CustomerLastNameInsert = new System.Windows.Forms.TextBox();
            this.StaffGenderLabel = new System.Windows.Forms.Label();
            this.StaffAgeLabel = new System.Windows.Forms.Label();
            this.CustomerAgeInsert = new System.Windows.Forms.TextBox();
            this.StaffAddressLabel = new System.Windows.Forms.Label();
            this.StaffDateOfBirthLabel = new System.Windows.Forms.Label();
            this.CustomerPhoneNumberInsert = new System.Windows.Forms.TextBox();
            this.StaffEmailLabel = new System.Windows.Forms.Label();
            this.StaffPhoneNumberLabel = new System.Windows.Forms.Label();
            this.CustomerEmailInsert = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.welcome);
            this.panel2.Controls.Add(this.AddressInsert);
            this.panel2.Controls.Add(this.CustomerIDInsert);
            this.panel2.Controls.Add(this.CustomerGenderInsertBox);
            this.panel2.Controls.Add(this.CustomerIDLabel);
            this.panel2.Controls.Add(this.CustomerDateOfBirthInsert);
            this.panel2.Controls.Add(this.StaffNameLabel);
            this.panel2.Controls.Add(this.SaveUpdateButton);
            this.panel2.Controls.Add(this.CustomerFirstNameInsert);
            this.panel2.Controls.Add(this.StaffLastNameLabel);
            this.panel2.Controls.Add(this.CustomerLastNameInsert);
            this.panel2.Controls.Add(this.StaffGenderLabel);
            this.panel2.Controls.Add(this.StaffAgeLabel);
            this.panel2.Controls.Add(this.CustomerAgeInsert);
            this.panel2.Controls.Add(this.StaffAddressLabel);
            this.panel2.Controls.Add(this.StaffDateOfBirthLabel);
            this.panel2.Controls.Add(this.CustomerPhoneNumberInsert);
            this.panel2.Controls.Add(this.StaffEmailLabel);
            this.panel2.Controls.Add(this.StaffPhoneNumberLabel);
            this.panel2.Controls.Add(this.CustomerEmailInsert);
            this.panel2.Location = new System.Drawing.Point(5, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1245, 719);
            this.panel2.TabIndex = 5;
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.welcome.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.Location = new System.Drawing.Point(480, 25);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(171, 46);
            this.welcome.TabIndex = 54;
            this.welcome.Text = "Welcome";
            // 
            // AddressInsert
            // 
            this.AddressInsert.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressInsert.Location = new System.Drawing.Point(753, 222);
            this.AddressInsert.Name = "AddressInsert";
            this.AddressInsert.Size = new System.Drawing.Size(364, 199);
            this.AddressInsert.TabIndex = 53;
            this.AddressInsert.Text = "";
            // 
            // CustomerIDInsert
            // 
            this.CustomerIDInsert.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CustomerIDInsert.Location = new System.Drawing.Point(193, 152);
            this.CustomerIDInsert.Name = "CustomerIDInsert";
            this.CustomerIDInsert.ReadOnly = true;
            this.CustomerIDInsert.Size = new System.Drawing.Size(369, 28);
            this.CustomerIDInsert.TabIndex = 38;
            // 
            // CustomerGenderInsertBox
            // 
            this.CustomerGenderInsertBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomerGenderInsertBox.Enabled = false;
            this.CustomerGenderInsertBox.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CustomerGenderInsertBox.FormattingEnabled = true;
            this.CustomerGenderInsertBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.CustomerGenderInsertBox.Location = new System.Drawing.Point(193, 367);
            this.CustomerGenderInsertBox.Name = "CustomerGenderInsertBox";
            this.CustomerGenderInsertBox.Size = new System.Drawing.Size(369, 30);
            this.CustomerGenderInsertBox.TabIndex = 52;
            // 
            // CustomerIDLabel
            // 
            this.CustomerIDLabel.AutoSize = true;
            this.CustomerIDLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CustomerIDLabel.Location = new System.Drawing.Point(57, 155);
            this.CustomerIDLabel.Name = "CustomerIDLabel";
            this.CustomerIDLabel.Size = new System.Drawing.Size(118, 24);
            this.CustomerIDLabel.TabIndex = 30;
            this.CustomerIDLabel.Text = "Customer ID:";
            // 
            // CustomerDateOfBirthInsert
            // 
            this.CustomerDateOfBirthInsert.CustomFormat = "dd MMM yyyy";
            this.CustomerDateOfBirthInsert.Enabled = false;
            this.CustomerDateOfBirthInsert.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CustomerDateOfBirthInsert.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CustomerDateOfBirthInsert.Location = new System.Drawing.Point(193, 532);
            this.CustomerDateOfBirthInsert.Name = "CustomerDateOfBirthInsert";
            this.CustomerDateOfBirthInsert.Size = new System.Drawing.Size(369, 28);
            this.CustomerDateOfBirthInsert.TabIndex = 51;
            // 
            // StaffNameLabel
            // 
            this.StaffNameLabel.AutoSize = true;
            this.StaffNameLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.StaffNameLabel.Location = new System.Drawing.Point(72, 222);
            this.StaffNameLabel.Name = "StaffNameLabel";
            this.StaffNameLabel.Size = new System.Drawing.Size(103, 24);
            this.StaffNameLabel.TabIndex = 31;
            this.StaffNameLabel.Text = "First name:";
            // 
            // SaveUpdateButton
            // 
            this.SaveUpdateButton.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.SaveUpdateButton.Location = new System.Drawing.Point(1023, 455);
            this.SaveUpdateButton.Name = "SaveUpdateButton";
            this.SaveUpdateButton.Size = new System.Drawing.Size(94, 34);
            this.SaveUpdateButton.TabIndex = 50;
            this.SaveUpdateButton.Text = "Save";
            this.SaveUpdateButton.UseVisualStyleBackColor = true;
            this.SaveUpdateButton.Click += new System.EventHandler(this.StaffUpdateButton_Click);
            // 
            // CustomerFirstNameInsert
            // 
            this.CustomerFirstNameInsert.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CustomerFirstNameInsert.Location = new System.Drawing.Point(193, 216);
            this.CustomerFirstNameInsert.Name = "CustomerFirstNameInsert";
            this.CustomerFirstNameInsert.ReadOnly = true;
            this.CustomerFirstNameInsert.Size = new System.Drawing.Size(369, 28);
            this.CustomerFirstNameInsert.TabIndex = 32;
            // 
            // StaffLastNameLabel
            // 
            this.StaffLastNameLabel.AutoSize = true;
            this.StaffLastNameLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.StaffLastNameLabel.Location = new System.Drawing.Point(68, 294);
            this.StaffLastNameLabel.Name = "StaffLastNameLabel";
            this.StaffLastNameLabel.Size = new System.Drawing.Size(106, 24);
            this.StaffLastNameLabel.TabIndex = 33;
            this.StaffLastNameLabel.Text = "Last  name:";
            // 
            // CustomerLastNameInsert
            // 
            this.CustomerLastNameInsert.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CustomerLastNameInsert.Location = new System.Drawing.Point(193, 288);
            this.CustomerLastNameInsert.Name = "CustomerLastNameInsert";
            this.CustomerLastNameInsert.ReadOnly = true;
            this.CustomerLastNameInsert.Size = new System.Drawing.Size(369, 28);
            this.CustomerLastNameInsert.TabIndex = 34;
            // 
            // StaffGenderLabel
            // 
            this.StaffGenderLabel.AutoSize = true;
            this.StaffGenderLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.StaffGenderLabel.Location = new System.Drawing.Point(94, 372);
            this.StaffGenderLabel.Name = "StaffGenderLabel";
            this.StaffGenderLabel.Size = new System.Drawing.Size(79, 24);
            this.StaffGenderLabel.TabIndex = 35;
            this.StaffGenderLabel.Text = "Gender:";
            // 
            // StaffAgeLabel
            // 
            this.StaffAgeLabel.AutoSize = true;
            this.StaffAgeLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.StaffAgeLabel.Location = new System.Drawing.Point(123, 455);
            this.StaffAgeLabel.Name = "StaffAgeLabel";
            this.StaffAgeLabel.Size = new System.Drawing.Size(50, 24);
            this.StaffAgeLabel.TabIndex = 36;
            this.StaffAgeLabel.Text = "Age:";
            // 
            // CustomerAgeInsert
            // 
            this.CustomerAgeInsert.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CustomerAgeInsert.Location = new System.Drawing.Point(193, 449);
            this.CustomerAgeInsert.Name = "CustomerAgeInsert";
            this.CustomerAgeInsert.ReadOnly = true;
            this.CustomerAgeInsert.Size = new System.Drawing.Size(369, 28);
            this.CustomerAgeInsert.TabIndex = 37;
            // 
            // StaffAddressLabel
            // 
            this.StaffAddressLabel.AutoSize = true;
            this.StaffAddressLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.StaffAddressLabel.Location = new System.Drawing.Point(652, 215);
            this.StaffAddressLabel.Name = "StaffAddressLabel";
            this.StaffAddressLabel.Size = new System.Drawing.Size(85, 24);
            this.StaffAddressLabel.TabIndex = 44;
            this.StaffAddressLabel.Text = "Address:";
            // 
            // StaffDateOfBirthLabel
            // 
            this.StaffDateOfBirthLabel.AutoSize = true;
            this.StaffDateOfBirthLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.StaffDateOfBirthLabel.Location = new System.Drawing.Point(63, 534);
            this.StaffDateOfBirthLabel.Name = "StaffDateOfBirthLabel";
            this.StaffDateOfBirthLabel.Size = new System.Drawing.Size(119, 24);
            this.StaffDateOfBirthLabel.TabIndex = 39;
            this.StaffDateOfBirthLabel.Text = "Date of birth :";
            // 
            // CustomerPhoneNumberInsert
            // 
            this.CustomerPhoneNumberInsert.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CustomerPhoneNumberInsert.Location = new System.Drawing.Point(753, 149);
            this.CustomerPhoneNumberInsert.Name = "CustomerPhoneNumberInsert";
            this.CustomerPhoneNumberInsert.Size = new System.Drawing.Size(369, 28);
            this.CustomerPhoneNumberInsert.TabIndex = 43;
            // 
            // StaffEmailLabel
            // 
            this.StaffEmailLabel.AutoSize = true;
            this.StaffEmailLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.StaffEmailLabel.Location = new System.Drawing.Point(120, 608);
            this.StaffEmailLabel.Name = "StaffEmailLabel";
            this.StaffEmailLabel.Size = new System.Drawing.Size(62, 24);
            this.StaffEmailLabel.TabIndex = 40;
            this.StaffEmailLabel.Text = "Email:";
            // 
            // StaffPhoneNumberLabel
            // 
            this.StaffPhoneNumberLabel.AutoSize = true;
            this.StaffPhoneNumberLabel.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.StaffPhoneNumberLabel.Location = new System.Drawing.Point(595, 155);
            this.StaffPhoneNumberLabel.Name = "StaffPhoneNumberLabel";
            this.StaffPhoneNumberLabel.Size = new System.Drawing.Size(145, 24);
            this.StaffPhoneNumberLabel.TabIndex = 42;
            this.StaffPhoneNumberLabel.Text = "Phone Number:";
            // 
            // CustomerEmailInsert
            // 
            this.CustomerEmailInsert.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.CustomerEmailInsert.Location = new System.Drawing.Point(193, 602);
            this.CustomerEmailInsert.Name = "CustomerEmailInsert";
            this.CustomerEmailInsert.Size = new System.Drawing.Size(369, 28);
            this.CustomerEmailInsert.TabIndex = 41;
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(1250, 725);
            this.Load += new System.EventHandler(this.ProfileControl_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox CustomerIDInsert;
        private System.Windows.Forms.ComboBox CustomerGenderInsertBox;
        private System.Windows.Forms.Label CustomerIDLabel;
        private System.Windows.Forms.DateTimePicker CustomerDateOfBirthInsert;
        private System.Windows.Forms.Label StaffNameLabel;
        private System.Windows.Forms.Button SaveUpdateButton;
        private System.Windows.Forms.TextBox CustomerFirstNameInsert;
        private System.Windows.Forms.Label StaffLastNameLabel;
        private System.Windows.Forms.TextBox CustomerLastNameInsert;
        private System.Windows.Forms.Label StaffGenderLabel;
        private System.Windows.Forms.Label StaffAgeLabel;
        private System.Windows.Forms.TextBox CustomerAgeInsert;
        private System.Windows.Forms.Label StaffAddressLabel;
        private System.Windows.Forms.Label StaffDateOfBirthLabel;
        private System.Windows.Forms.TextBox CustomerPhoneNumberInsert;
        private System.Windows.Forms.Label StaffEmailLabel;
        private System.Windows.Forms.Label StaffPhoneNumberLabel;
        private System.Windows.Forms.TextBox CustomerEmailInsert;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.RichTextBox AddressInsert;
    }
}
