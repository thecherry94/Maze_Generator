namespace Maze_Generator
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCellAmount = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkColor = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Cells";
            // 
            // cbxCellAmount
            // 
            this.cbxCellAmount.FormattingEnabled = true;
            this.cbxCellAmount.Location = new System.Drawing.Point(114, 26);
            this.cbxCellAmount.Name = "cbxCellAmount";
            this.cbxCellAmount.Size = new System.Drawing.Size(121, 21);
            this.cbxCellAmount.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(15, 82);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(220, 53);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate Maze";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // chkColor
            // 
            this.chkColor.AutoSize = true;
            this.chkColor.Location = new System.Drawing.Point(114, 59);
            this.chkColor.Name = "chkColor";
            this.chkColor.Size = new System.Drawing.Size(64, 17);
            this.chkColor.TabIndex = 3;
            this.chkColor.Text = "Coloring";
            this.chkColor.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 149);
            this.Controls.Add(this.chkColor);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cbxCellAmount);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Maze Generator";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCellAmount;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chkColor;
    }
}

