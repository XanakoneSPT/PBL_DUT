namespace PBL3.View
{
    partial class StatisticsControl
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
            this.moneytotalLB = new System.Windows.Forms.Label();
            this.childrenTotalLB = new System.Windows.Forms.Label();
            this.stafftotalLB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.TotalSatffpanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.donatetotalLB = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ChildrenBT = new System.Windows.Forms.Button();
            this.SearchBT = new System.Windows.Forms.Button();
            this.sortcbb = new System.Windows.Forms.ComboBox();
            this.StaffBT = new System.Windows.Forms.Button();
            this.MoneyBT = new System.Windows.Forms.Button();
            this.DonateBT = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.TotalSatffpanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // moneytotalLB
            // 
            this.moneytotalLB.AutoSize = true;
            this.moneytotalLB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.moneytotalLB.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneytotalLB.Location = new System.Drawing.Point(44, 42);
            this.moneytotalLB.Name = "moneytotalLB";
            this.moneytotalLB.Size = new System.Drawing.Size(138, 25);
            this.moneytotalLB.TabIndex = 84;
            this.moneytotalLB.Text = "Total Money";
            // 
            // childrenTotalLB
            // 
            this.childrenTotalLB.AutoSize = true;
            this.childrenTotalLB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.childrenTotalLB.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.childrenTotalLB.Location = new System.Drawing.Point(38, 42);
            this.childrenTotalLB.Name = "childrenTotalLB";
            this.childrenTotalLB.Size = new System.Drawing.Size(149, 25);
            this.childrenTotalLB.TabIndex = 83;
            this.childrenTotalLB.Text = "Total children";
            // 
            // stafftotalLB
            // 
            this.stafftotalLB.AutoSize = true;
            this.stafftotalLB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.stafftotalLB.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stafftotalLB.Location = new System.Drawing.Point(37, 42);
            this.stafftotalLB.Name = "stafftotalLB";
            this.stafftotalLB.Size = new System.Drawing.Size(117, 25);
            this.stafftotalLB.TabIndex = 82;
            this.stafftotalLB.Text = "Total Staff";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 32);
            this.label1.TabIndex = 92;
            this.label1.Text = "Statistics:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Location = new System.Drawing.Point(3, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 570);
            this.panel1.TabIndex = 93;
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(3, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1238, 567);
            this.dgv.TabIndex = 0;
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            // 
            // TotalSatffpanel
            // 
            this.TotalSatffpanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TotalSatffpanel.Controls.Add(this.stafftotalLB);
            this.TotalSatffpanel.Controls.Add(this.label3);
            this.TotalSatffpanel.Location = new System.Drawing.Point(419, 9);
            this.TotalSatffpanel.Name = "TotalSatffpanel";
            this.TotalSatffpanel.Size = new System.Drawing.Size(217, 80);
            this.TotalSatffpanel.TabIndex = 94;
            this.TotalSatffpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AddBorderToPanel_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 22);
            this.label3.TabIndex = 92;
            this.label3.Text = "Satff";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.childrenTotalLB);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(179, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 80);
            this.panel3.TabIndex = 94;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.AddBorderToPanel_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 22);
            this.label6.TabIndex = 92;
            this.label6.Text = "Children";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel5.Controls.Add(this.moneytotalLB);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(658, 9);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(217, 80);
            this.panel5.TabIndex = 94;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.AddBorderToPanel_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 22);
            this.label7.TabIndex = 92;
            this.label7.Text = "Money";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.donatetotalLB);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(899, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 80);
            this.panel2.TabIndex = 94;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.AddBorderToPanel_Paint);
            // 
            // donatetotalLB
            // 
            this.donatetotalLB.AutoSize = true;
            this.donatetotalLB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.donatetotalLB.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donatetotalLB.Location = new System.Drawing.Point(35, 42);
            this.donatetotalLB.Name = "donatetotalLB";
            this.donatetotalLB.Size = new System.Drawing.Size(161, 25);
            this.donatetotalLB.TabIndex = 84;
            this.donatetotalLB.Text = "Donate Money";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 22);
            this.label8.TabIndex = 92;
            this.label8.Text = "Donate";
            // 
            // ChildrenBT
            // 
            this.ChildrenBT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ChildrenBT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChildrenBT.Location = new System.Drawing.Point(2, 113);
            this.ChildrenBT.Name = "ChildrenBT";
            this.ChildrenBT.Size = new System.Drawing.Size(135, 39);
            this.ChildrenBT.TabIndex = 102;
            this.ChildrenBT.Text = "Children";
            this.ChildrenBT.UseVisualStyleBackColor = false;
            this.ChildrenBT.Click += new System.EventHandler(this.ChildrenBT_Click);
            // 
            // SearchBT
            // 
            this.SearchBT.Location = new System.Drawing.Point(1115, 118);
            this.SearchBT.Name = "SearchBT";
            this.SearchBT.Size = new System.Drawing.Size(108, 30);
            this.SearchBT.TabIndex = 99;
            this.SearchBT.Text = "Search";
            this.SearchBT.UseVisualStyleBackColor = true;
            this.SearchBT.Click += new System.EventHandler(this.SearchBT_Click);
            // 
            // sortcbb
            // 
            this.sortcbb.FormattingEnabled = true;
            this.sortcbb.Location = new System.Drawing.Point(922, 120);
            this.sortcbb.Name = "sortcbb";
            this.sortcbb.Size = new System.Drawing.Size(187, 24);
            this.sortcbb.TabIndex = 98;
            // 
            // StaffBT
            // 
            this.StaffBT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StaffBT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffBT.Location = new System.Drawing.Point(143, 113);
            this.StaffBT.Name = "StaffBT";
            this.StaffBT.Size = new System.Drawing.Size(135, 39);
            this.StaffBT.TabIndex = 102;
            this.StaffBT.Text = "Staff";
            this.StaffBT.UseVisualStyleBackColor = false;
            this.StaffBT.Click += new System.EventHandler(this.StaffBT_Click);
            // 
            // MoneyBT
            // 
            this.MoneyBT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MoneyBT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoneyBT.Location = new System.Drawing.Point(284, 113);
            this.MoneyBT.Name = "MoneyBT";
            this.MoneyBT.Size = new System.Drawing.Size(135, 39);
            this.MoneyBT.TabIndex = 102;
            this.MoneyBT.Text = "Money";
            this.MoneyBT.UseVisualStyleBackColor = false;
            this.MoneyBT.Click += new System.EventHandler(this.MoneyBT_Click);
            // 
            // DonateBT
            // 
            this.DonateBT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DonateBT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonateBT.Location = new System.Drawing.Point(426, 113);
            this.DonateBT.Name = "DonateBT";
            this.DonateBT.Size = new System.Drawing.Size(135, 39);
            this.DonateBT.TabIndex = 102;
            this.DonateBT.Text = "Donate";
            this.DonateBT.UseVisualStyleBackColor = false;
            this.DonateBT.Click += new System.EventHandler(this.DonateBT_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Location = new System.Drawing.Point(0, 108);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1250, 617);
            this.panel4.TabIndex = 99;
            // 
            // StatisticsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.DonateBT);
            this.Controls.Add(this.MoneyBT);
            this.Controls.Add(this.StaffBT);
            this.Controls.Add(this.ChildrenBT);
            this.Controls.Add(this.SearchBT);
            this.Controls.Add(this.sortcbb);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.TotalSatffpanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Name = "StatisticsControl";
            this.Size = new System.Drawing.Size(1250, 725);
            this.Load += new System.EventHandler(this.StatisticsControl_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.TotalSatffpanel.ResumeLayout(false);
            this.TotalSatffpanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label moneytotalLB;
        private System.Windows.Forms.Label childrenTotalLB;
        private System.Windows.Forms.Label stafftotalLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TotalSatffpanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label donatetotalLB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button ChildrenBT;
        private System.Windows.Forms.Button SearchBT;
        private System.Windows.Forms.ComboBox sortcbb;
        private System.Windows.Forms.Button StaffBT;
        private System.Windows.Forms.Button MoneyBT;
        private System.Windows.Forms.Button DonateBT;
        private System.Windows.Forms.Panel panel4;
    }
}
