namespace Maze_Generator
{
    partial class frmGenerator
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
            this.pcbMaze = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMaze)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbMaze
            // 
            this.pcbMaze.BackColor = System.Drawing.Color.White;
            this.pcbMaze.Location = new System.Drawing.Point(12, 12);
            this.pcbMaze.Name = "pcbMaze";
            this.pcbMaze.Size = new System.Drawing.Size(780, 780);
            this.pcbMaze.TabIndex = 0;
            this.pcbMaze.TabStop = false;
            // 
            // frmGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 810);
            this.Controls.Add(this.pcbMaze);
            this.Name = "frmGenerator";
            this.Text = "Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGenerator_FormClosed);
            this.Load += new System.EventHandler(this.frmGenerator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMaze)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbMaze;
    }
}