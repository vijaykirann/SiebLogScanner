namespace AdvancedSiebelLogScanner
{
    partial class ErrorLogForm
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
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox9 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox10 = new MetroFramework.Controls.MetroTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox11 = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroLabel8
            // 
            this.metroLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel8.Location = new System.Drawing.Point(42, 9);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(89, 20);
            this.metroLabel8.TabIndex = 7;
            this.metroLabel8.Text = "Siebel Error";
            // 
            // metroTextBox9
            // 
            this.metroTextBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroTextBox9.Location = new System.Drawing.Point(167, 4);
            this.metroTextBox9.Margin = new System.Windows.Forms.Padding(4);
            this.metroTextBox9.MaxLength = 20;
            this.metroTextBox9.Name = "metroTextBox9";
            this.metroTextBox9.ReadOnly = true;
            this.metroTextBox9.Size = new System.Drawing.Size(164, 28);
            this.metroTextBox9.TabIndex = 6;
            // 
            // metroLabel9
            // 
            this.metroLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel9.Location = new System.Drawing.Point(42, 43);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(89, 20);
            this.metroLabel9.TabIndex = 9;
            this.metroLabel9.Text = "Description";
            // 
            // metroTextBox10
            // 
            this.metroTextBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroTextBox10.Location = new System.Drawing.Point(167, 38);
            this.metroTextBox10.Margin = new System.Windows.Forms.Padding(4);
            this.metroTextBox10.MaxLength = 200;
            this.metroTextBox10.Name = "metroTextBox10";
            this.metroTextBox10.ReadOnly = true;
            this.metroTextBox10.Size = new System.Drawing.Size(359, 28);
            this.metroTextBox10.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox1.Location = new System.Drawing.Point(580, 31);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 27);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Edit";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.BackColor = System.Drawing.Color.Black;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel10.Location = new System.Drawing.Point(564, 4);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(84, 20);
            this.metroLabel10.TabIndex = 11;
            this.metroLabel10.Text = "Resolution";
            // 
            // metroTextBox11
            // 
            this.metroTextBox11.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroTextBox11.Location = new System.Drawing.Point(689, 0);
            this.metroTextBox11.Margin = new System.Windows.Forms.Padding(4);
            this.metroTextBox11.MaxLength = 2000;
            this.metroTextBox11.Multiline = true;
            this.metroTextBox11.Name = "metroTextBox11";
            this.metroTextBox11.Size = new System.Drawing.Size(640, 72);
            this.metroTextBox11.TabIndex = 10;
            // 
            // ErrorLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1329, 72);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroTextBox11);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroTextBox10);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroTextBox9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ErrorLogForm";
            this.Text = "ErrorLogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox metroTextBox9;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox metroTextBox10;
        private System.Windows.Forms.CheckBox checkBox1;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox metroTextBox11;
    }
}