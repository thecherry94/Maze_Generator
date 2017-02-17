using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_Generator
{
    public partial class frmMain : Form
    {
        private Maze maze;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            int max_cells_sqrt = 200;
            for(int i = 10; i <= max_cells_sqrt; i++)         
                cbxCellAmount.Items.Add(i*i);

            cbxCellAmount.SelectedIndex = cbxCellAmount.Items.Count - 1;
            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int cell_amount = (int)cbxCellAmount.SelectedItem;
            maze = new Maze(cell_amount, 780);
            maze.GenerateMaze(chkColor.Checked);
            maze.Render();
            maze.SaveImage();

            using (frmGenerator frm = new frmGenerator())
            {
                frm.setImage(maze.Image);
                frm.ShowDialog();
            }       
        }
    }
}
