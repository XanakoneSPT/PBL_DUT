namespace PBL3.View
{
    partial class VolunteerControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.VolunteerDataGridView = new System.Windows.Forms.DataGridView();
            this.StaffInfoText = new System.Windows.Forms.Label();
            this.StaffResetButton = new System.Windows.Forms.Button();
            this.VolunteerIDInsert = new System.Windows.Forms.TextBox();
            this.VolunteerPositionInsert = new System.Windows.Forms.ComboBox();
            this.VolunteerGenderInsertBox = new System.Windows.Forms.ComboBox();
            this.StaffIDLabel = new System.Windows.Forms.Label();
            this.VolunteerDateOfBirthInsert = new System.Windows.Forms.DateTimePicker();
            this.StaffNameLabel = new System.Windows.Forms.Label();
            this.StaffUpdateButton = new System.Windows.Forms.Button();
            this.VolunteerFirstNameInsert = new System.Windows.Forms.TextBox();
            this.StaffDeleteButton = new System.Windows.Forms.Button();
            this.StaffLastNameLabel = new System.Windows.Forms.Label();
            this.StaffAddButton = new System.Windows.Forms.Button();
            this.VolunteerLastNameInsert = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.StaffGenderLabel = new System.Windows.Forms.Label();
            this.StaffAgeLabel = new System.Windows.Forms.Label();
            this.VolunteerAddressInsert = new System.Windows.Forms.TextBox();
            this.VolunteerAgeInsert = new System.Windows.Forms.TextBox();
            this.StaffAddressLabel = new System.Windows.Forms.Label();
            this.StaffDateOfBirthLabel = new System.Windows.Forms.Label();
            this.VolunteerPhoneNumberInsert = new System.Windows.Forms.TextBox();
            this.StaffEmailLabel = new System.Windows.Forms.Label();
            this.StaffPhoneNumberLabel = new System.Windows.Forms.Label();
            this.VolunteerEmailInsert = new System.Windows.Forms.TextBox();
            this.VolunteerIDSearchBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.VolunteerDateStartInsert = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.VolunteerDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VolunteerDataGridView
            // 
            this.VolunteerDataGridView.AllowUserToAddRows = false;
            this.VolunteerDataGridView.AllowUserToDeleteRows = false;
            this.VolunteerDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.NullValue = null;
            this.VolunteerDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.VolunteerDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolunteerDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.VolunteerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VolunteerDataGridView.Location = new System.Drawing.Point(17, 40);
            this.VolunteerDataGridView.Name = "VolunteerDataGridView";
            this.VolunteerDataGridView.ReadOnly = true;
            this.VolunteerDataGridView.RowHeadersWidth = 51;
            this.VolunteerDataGridView.RowTemplate.Height = 24;
            this.VolunteerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VolunteerDataGridView.Size = new System.Drawing.Size(1206, 396);
            this.VolunteerDataGridView.TabIndex = 1;
            this.VolunteerDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VolunteerDataGridView_CellContentClick);
            // 
            // StaffInfoText
            // 
            this.StaffInfoText.AutoSize = true;
            this.StaffInfoText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffInfoText.Location = new System.Drawing.Point(12, 11);
            this.StaffInfoText.Name = "StaffInfoText";
            this.StaffInfoText.Size = new System.Drawing.Size(132, 22);
            this.StaffInfoText.TabIndex = 0;
            this.StaffInfoText.Text = "Volunteer\'s Info";
            // 
            // StaffResetButton
            // 
            this.StaffResetButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffResetButton.Location = new System.Drawing.Point(1121, 165);
            this.StaffResetButton.Name = "StaffResetButton";
            this.StaffResetButton.Size = new System.Drawing.Size(94, 34);
            this.StaffResetButton.TabIndex = 53;
            this.StaffResetButton.Text = "Reset";
            this.StaffResetButton.UseVisualStyleBackColor = true;
            this.StaffResetButton.Click += new System.EventHandler(this.VolunteerResetButton_Click);
            // 
            // VolunteerIDInsert
            // 
            this.VolunteerIDInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerIDInsert.Location = new System.Drawing.Point(150, 13);
            this.VolunteerIDInsert.Name = "VolunteerIDInsert";
            this.VolunteerIDInsert.ReadOnly = true;
            this.VolunteerIDInsert.Size = new System.Drawing.Size(347, 28);
            this.VolunteerIDInsert.TabIndex = 38;
            // 
            // VolunteerPositionInsert
            // 
            this.VolunteerPositionInsert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VolunteerPositionInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerPositionInsert.FormattingEnabled = true;
            this.VolunteerPositionInsert.Items.AddRange(new object[] {
            "Childcare Worker",
            "Educator/Teacher",
            "Healthcare Provider"});
            this.VolunteerPositionInsert.Location = new System.Drawing.Point(150, 133);
            this.VolunteerPositionInsert.Name = "VolunteerPositionInsert";
            this.VolunteerPositionInsert.Size = new System.Drawing.Size(347, 28);
            this.VolunteerPositionInsert.TabIndex = 52;
            // 
            // VolunteerGenderInsertBox
            // 
            this.VolunteerGenderInsertBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VolunteerGenderInsertBox.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerGenderInsertBox.FormattingEnabled = true;
            this.VolunteerGenderInsertBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.VolunteerGenderInsertBox.Location = new System.Drawing.Point(150, 175);
            this.VolunteerGenderInsertBox.Name = "VolunteerGenderInsertBox";
            this.VolunteerGenderInsertBox.Size = new System.Drawing.Size(347, 28);
            this.VolunteerGenderInsertBox.TabIndex = 52;
            // 
            // StaffIDLabel
            // 
            this.StaffIDLabel.AutoSize = true;
            this.StaffIDLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffIDLabel.Location = new System.Drawing.Point(13, 20);
            this.StaffIDLabel.Name = "StaffIDLabel";
            this.StaffIDLabel.Size = new System.Drawing.Size(105, 20);
            this.StaffIDLabel.TabIndex = 30;
            this.StaffIDLabel.Text = "Volunteer ID:";
            // 
            // VolunteerDateOfBirthInsert
            // 
            this.VolunteerDateOfBirthInsert.CustomFormat = "dd MMM yyyy";
            this.VolunteerDateOfBirthInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerDateOfBirthInsert.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.VolunteerDateOfBirthInsert.Location = new System.Drawing.Point(732, 20);
            this.VolunteerDateOfBirthInsert.Name = "VolunteerDateOfBirthInsert";
            this.VolunteerDateOfBirthInsert.Size = new System.Drawing.Size(369, 28);
            this.VolunteerDateOfBirthInsert.TabIndex = 51;
            // 
            // StaffNameLabel
            // 
            this.StaffNameLabel.AutoSize = true;
            this.StaffNameLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffNameLabel.Location = new System.Drawing.Point(29, 57);
            this.StaffNameLabel.Name = "StaffNameLabel";
            this.StaffNameLabel.Size = new System.Drawing.Size(89, 20);
            this.StaffNameLabel.TabIndex = 31;
            this.StaffNameLabel.Text = "First name:";
            // 
            // StaffUpdateButton
            // 
            this.StaffUpdateButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffUpdateButton.Location = new System.Drawing.Point(1121, 124);
            this.StaffUpdateButton.Name = "StaffUpdateButton";
            this.StaffUpdateButton.Size = new System.Drawing.Size(94, 34);
            this.StaffUpdateButton.TabIndex = 50;
            this.StaffUpdateButton.Text = "Update";
            this.StaffUpdateButton.UseVisualStyleBackColor = true;
            this.StaffUpdateButton.Click += new System.EventHandler(this.VolunteerUpdateButton_Click);
            // 
            // VolunteerFirstNameInsert
            // 
            this.VolunteerFirstNameInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerFirstNameInsert.Location = new System.Drawing.Point(150, 51);
            this.VolunteerFirstNameInsert.Name = "VolunteerFirstNameInsert";
            this.VolunteerFirstNameInsert.Size = new System.Drawing.Size(347, 28);
            this.VolunteerFirstNameInsert.TabIndex = 32;
            // 
            // StaffDeleteButton
            // 
            this.StaffDeleteButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffDeleteButton.Location = new System.Drawing.Point(1121, 84);
            this.StaffDeleteButton.Name = "StaffDeleteButton";
            this.StaffDeleteButton.Size = new System.Drawing.Size(94, 34);
            this.StaffDeleteButton.TabIndex = 49;
            this.StaffDeleteButton.Text = "Delete";
            this.StaffDeleteButton.UseVisualStyleBackColor = true;
            this.StaffDeleteButton.Click += new System.EventHandler(this.VolunteerDeleteButton_Click);
            // 
            // StaffLastNameLabel
            // 
            this.StaffLastNameLabel.AutoSize = true;
            this.StaffLastNameLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffLastNameLabel.Location = new System.Drawing.Point(25, 95);
            this.StaffLastNameLabel.Name = "StaffLastNameLabel";
            this.StaffLastNameLabel.Size = new System.Drawing.Size(93, 20);
            this.StaffLastNameLabel.TabIndex = 33;
            this.StaffLastNameLabel.Text = "Last  name:";
            // 
            // StaffAddButton
            // 
            this.StaffAddButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffAddButton.Location = new System.Drawing.Point(1121, 39);
            this.StaffAddButton.Name = "StaffAddButton";
            this.StaffAddButton.Size = new System.Drawing.Size(94, 34);
            this.StaffAddButton.TabIndex = 48;
            this.StaffAddButton.Text = "Add";
            this.StaffAddButton.UseVisualStyleBackColor = true;
            this.StaffAddButton.Click += new System.EventHandler(this.VolunteerAddButton_Click);
            // 
            // VolunteerLastNameInsert
            // 
            this.VolunteerLastNameInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerLastNameInsert.Location = new System.Drawing.Point(150, 89);
            this.VolunteerLastNameInsert.Name = "VolunteerLastNameInsert";
            this.VolunteerLastNameInsert.Size = new System.Drawing.Size(347, 28);
            this.VolunteerLastNameInsert.TabIndex = 34;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(1145, 10);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 27);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionLabel.Location = new System.Drawing.Point(51, 138);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(71, 20);
            this.PositionLabel.TabIndex = 35;
            this.PositionLabel.Text = "Position:";
            // 
            // StaffGenderLabel
            // 
            this.StaffGenderLabel.AutoSize = true;
            this.StaffGenderLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffGenderLabel.Location = new System.Drawing.Point(51, 180);
            this.StaffGenderLabel.Name = "StaffGenderLabel";
            this.StaffGenderLabel.Size = new System.Drawing.Size(66, 20);
            this.StaffGenderLabel.TabIndex = 35;
            this.StaffGenderLabel.Text = "Gender:";
            // 
            // StaffAgeLabel
            // 
            this.StaffAgeLabel.AutoSize = true;
            this.StaffAgeLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffAgeLabel.Location = new System.Drawing.Point(80, 221);
            this.StaffAgeLabel.Name = "StaffAgeLabel";
            this.StaffAgeLabel.Size = new System.Drawing.Size(41, 20);
            this.StaffAgeLabel.TabIndex = 36;
            this.StaffAgeLabel.Text = "Age:";
            // 
            // VolunteerAddressInsert
            // 
            this.VolunteerAddressInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerAddressInsert.Location = new System.Drawing.Point(732, 130);
            this.VolunteerAddressInsert.Name = "VolunteerAddressInsert";
            this.VolunteerAddressInsert.Size = new System.Drawing.Size(369, 28);
            this.VolunteerAddressInsert.TabIndex = 45;
            // 
            // VolunteerAgeInsert
            // 
            this.VolunteerAgeInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerAgeInsert.Location = new System.Drawing.Point(150, 215);
            this.VolunteerAgeInsert.Name = "VolunteerAgeInsert";
            this.VolunteerAgeInsert.ReadOnly = true;
            this.VolunteerAgeInsert.Size = new System.Drawing.Size(347, 28);
            this.VolunteerAgeInsert.TabIndex = 37;
            // 
            // StaffAddressLabel
            // 
            this.StaffAddressLabel.AutoSize = true;
            this.StaffAddressLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffAddressLabel.Location = new System.Drawing.Point(635, 133);
            this.StaffAddressLabel.Name = "StaffAddressLabel";
            this.StaffAddressLabel.Size = new System.Drawing.Size(71, 20);
            this.StaffAddressLabel.TabIndex = 44;
            this.StaffAddressLabel.Text = "Address:";
            // 
            // StaffDateOfBirthLabel
            // 
            this.StaffDateOfBirthLabel.AutoSize = true;
            this.StaffDateOfBirthLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffDateOfBirthLabel.Location = new System.Drawing.Point(602, 22);
            this.StaffDateOfBirthLabel.Name = "StaffDateOfBirthLabel";
            this.StaffDateOfBirthLabel.Size = new System.Drawing.Size(110, 20);
            this.StaffDateOfBirthLabel.TabIndex = 39;
            this.StaffDateOfBirthLabel.Text = "Date of birth :";
            // 
            // VolunteerPhoneNumberInsert
            // 
            this.VolunteerPhoneNumberInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerPhoneNumberInsert.Location = new System.Drawing.Point(732, 92);
            this.VolunteerPhoneNumberInsert.Name = "VolunteerPhoneNumberInsert";
            this.VolunteerPhoneNumberInsert.Size = new System.Drawing.Size(369, 28);
            this.VolunteerPhoneNumberInsert.TabIndex = 43;
            // 
            // StaffEmailLabel
            // 
            this.StaffEmailLabel.AutoSize = true;
            this.StaffEmailLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffEmailLabel.Location = new System.Drawing.Point(659, 60);
            this.StaffEmailLabel.Name = "StaffEmailLabel";
            this.StaffEmailLabel.Size = new System.Drawing.Size(54, 20);
            this.StaffEmailLabel.TabIndex = 40;
            this.StaffEmailLabel.Text = "Email:";
            // 
            // StaffPhoneNumberLabel
            // 
            this.StaffPhoneNumberLabel.AutoSize = true;
            this.StaffPhoneNumberLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffPhoneNumberLabel.Location = new System.Drawing.Point(574, 98);
            this.StaffPhoneNumberLabel.Name = "StaffPhoneNumberLabel";
            this.StaffPhoneNumberLabel.Size = new System.Drawing.Size(123, 20);
            this.StaffPhoneNumberLabel.TabIndex = 42;
            this.StaffPhoneNumberLabel.Text = "Phone Number:";
            // 
            // VolunteerEmailInsert
            // 
            this.VolunteerEmailInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerEmailInsert.Location = new System.Drawing.Point(732, 54);
            this.VolunteerEmailInsert.Name = "VolunteerEmailInsert";
            this.VolunteerEmailInsert.Size = new System.Drawing.Size(369, 28);
            this.VolunteerEmailInsert.TabIndex = 41;
            // 
            // VolunteerIDSearchBox
            // 
            this.VolunteerIDSearchBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerIDSearchBox.Location = new System.Drawing.Point(1031, 10);
            this.VolunteerIDSearchBox.Name = "VolunteerIDSearchBox";
            this.VolunteerIDSearchBox.Size = new System.Drawing.Size(108, 25);
            this.VolunteerIDSearchBox.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.StaffResetButton);
            this.panel2.Controls.Add(this.VolunteerIDInsert);
            this.panel2.Controls.Add(this.VolunteerPositionInsert);
            this.panel2.Controls.Add(this.VolunteerGenderInsertBox);
            this.panel2.Controls.Add(this.StaffIDLabel);
            this.panel2.Controls.Add(this.VolunteerDateStartInsert);
            this.panel2.Controls.Add(this.VolunteerDateOfBirthInsert);
            this.panel2.Controls.Add(this.StaffNameLabel);
            this.panel2.Controls.Add(this.StaffUpdateButton);
            this.panel2.Controls.Add(this.VolunteerFirstNameInsert);
            this.panel2.Controls.Add(this.StaffDeleteButton);
            this.panel2.Controls.Add(this.StaffLastNameLabel);
            this.panel2.Controls.Add(this.StaffAddButton);
            this.panel2.Controls.Add(this.VolunteerLastNameInsert);
            this.panel2.Controls.Add(this.PositionLabel);
            this.panel2.Controls.Add(this.StaffGenderLabel);
            this.panel2.Controls.Add(this.StaffAgeLabel);
            this.panel2.Controls.Add(this.VolunteerAddressInsert);
            this.panel2.Controls.Add(this.VolunteerAgeInsert);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.StaffAddressLabel);
            this.panel2.Controls.Add(this.StaffDateOfBirthLabel);
            this.panel2.Controls.Add(this.VolunteerPhoneNumberInsert);
            this.panel2.Controls.Add(this.StaffEmailLabel);
            this.panel2.Controls.Add(this.StaffPhoneNumberLabel);
            this.panel2.Controls.Add(this.VolunteerEmailInsert);
            this.panel2.Location = new System.Drawing.Point(5, 461);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1241, 261);
            this.panel2.TabIndex = 5;
            // 
            // VolunteerDateStartInsert
            // 
            this.VolunteerDateStartInsert.CustomFormat = "dd MMM yyyy";
            this.VolunteerDateStartInsert.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolunteerDateStartInsert.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.VolunteerDateStartInsert.Location = new System.Drawing.Point(732, 166);
            this.VolunteerDateStartInsert.Name = "VolunteerDateStartInsert";
            this.VolunteerDateStartInsert.Size = new System.Drawing.Size(369, 28);
            this.VolunteerDateStartInsert.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(535, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Date Start Volunteer :";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.VolunteerDataGridView);
            this.panel1.Controls.Add(this.VolunteerIDSearchBox);
            this.panel1.Controls.Add(this.StaffInfoText);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1241, 452);
            this.panel1.TabIndex = 4;
            // 
            // VolunteerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "VolunteerControl";
            this.Size = new System.Drawing.Size(1250, 725);
            this.Load += new System.EventHandler(this.VolunteerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VolunteerDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView VolunteerDataGridView;
        private System.Windows.Forms.Label StaffInfoText;
        private System.Windows.Forms.Button StaffResetButton;
        private System.Windows.Forms.TextBox VolunteerIDInsert;
        private System.Windows.Forms.ComboBox VolunteerPositionInsert;
        private System.Windows.Forms.ComboBox VolunteerGenderInsertBox;
        private System.Windows.Forms.Label StaffIDLabel;
        private System.Windows.Forms.DateTimePicker VolunteerDateOfBirthInsert;
        private System.Windows.Forms.Label StaffNameLabel;
        private System.Windows.Forms.Button StaffUpdateButton;
        private System.Windows.Forms.TextBox VolunteerFirstNameInsert;
        private System.Windows.Forms.Button StaffDeleteButton;
        private System.Windows.Forms.Label StaffLastNameLabel;
        private System.Windows.Forms.Button StaffAddButton;
        private System.Windows.Forms.TextBox VolunteerLastNameInsert;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.Label StaffGenderLabel;
        private System.Windows.Forms.Label StaffAgeLabel;
        private System.Windows.Forms.TextBox VolunteerAddressInsert;
        private System.Windows.Forms.TextBox VolunteerAgeInsert;
        private System.Windows.Forms.Label StaffAddressLabel;
        private System.Windows.Forms.Label StaffDateOfBirthLabel;
        private System.Windows.Forms.TextBox VolunteerPhoneNumberInsert;
        private System.Windows.Forms.Label StaffEmailLabel;
        private System.Windows.Forms.Label StaffPhoneNumberLabel;
        private System.Windows.Forms.TextBox VolunteerEmailInsert;
        private System.Windows.Forms.TextBox VolunteerIDSearchBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker VolunteerDateStartInsert;
        private System.Windows.Forms.Label label1;
    }
}
