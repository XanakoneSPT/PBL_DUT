namespace PBL3.View
{
    partial class NotifiactionControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.sortcbb = new System.Windows.Forms.ComboBox();
            this.SearchBT = new System.Windows.Forms.Button();
            this.ATbt = new System.Windows.Forms.Button();
            this.CTbt = new System.Windows.Forms.Button();
            this.DNbt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(494, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 32);
            this.label1.TabIndex = 93;
            this.label1.Text = "Announcement";
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(3, 162);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1244, 560);
            this.dgv.TabIndex = 94;
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            // 
            // sortcbb
            // 
            this.sortcbb.FormattingEnabled = true;
            this.sortcbb.Location = new System.Drawing.Point(923, 130);
            this.sortcbb.Name = "sortcbb";
            this.sortcbb.Size = new System.Drawing.Size(187, 24);
            this.sortcbb.TabIndex = 95;
            // 
            // SearchBT
            // 
            this.SearchBT.Location = new System.Drawing.Point(1116, 126);
            this.SearchBT.Name = "SearchBT";
            this.SearchBT.Size = new System.Drawing.Size(108, 30);
            this.SearchBT.TabIndex = 96;
            this.SearchBT.Text = "Search";
            this.SearchBT.UseVisualStyleBackColor = true;
            this.SearchBT.Click += new System.EventHandler(this.SearchBT_Click);
            // 
            // ATbt
            // 
            this.ATbt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ATbt.Location = new System.Drawing.Point(3, 123);
            this.ATbt.Name = "ATbt";
            this.ATbt.Size = new System.Drawing.Size(135, 39);
            this.ATbt.TabIndex = 97;
            this.ATbt.Text = "Activity";
            this.ATbt.UseVisualStyleBackColor = false;
            this.ATbt.Click += new System.EventHandler(this.ATbt_Click);
            // 
            // CTbt
            // 
            this.CTbt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CTbt.Location = new System.Drawing.Point(136, 123);
            this.CTbt.Name = "CTbt";
            this.CTbt.Size = new System.Drawing.Size(135, 39);
            this.CTbt.TabIndex = 97;
            this.CTbt.Text = "Charity";
            this.CTbt.UseVisualStyleBackColor = false;
            this.CTbt.Click += new System.EventHandler(this.CTbt_Click);
            // 
            // DNbt
            // 
            this.DNbt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DNbt.Location = new System.Drawing.Point(269, 123);
            this.DNbt.Name = "DNbt";
            this.DNbt.Size = new System.Drawing.Size(135, 39);
            this.DNbt.TabIndex = 97;
            this.DNbt.Text = "Donate";
            this.DNbt.UseVisualStyleBackColor = false;
            this.DNbt.Click += new System.EventHandler(this.DNbt_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 609);
            this.panel1.TabIndex = 98;
            // 
            // NotifiactionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.DNbt);
            this.Controls.Add(this.CTbt);
            this.Controls.Add(this.ATbt);
            this.Controls.Add(this.SearchBT);
            this.Controls.Add(this.sortcbb);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "NotifiactionControl";
            this.Size = new System.Drawing.Size(1250, 725);
            this.Load += new System.EventHandler(this.NotifiactionControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox sortcbb;
        private System.Windows.Forms.Button SearchBT;
        private System.Windows.Forms.Button ATbt;
        private System.Windows.Forms.Button CTbt;
        private System.Windows.Forms.Button DNbt;
        private System.Windows.Forms.Panel panel1;
    }
}
