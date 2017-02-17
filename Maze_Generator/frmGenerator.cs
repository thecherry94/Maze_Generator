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
    public partial class frmGenerator : Form
    {
        public frmGenerator()
        {
            InitializeComponent();
        }

        private void frmGenerator_Load(object sender, EventArgs e)
        {

        }

        public void setImage(Bitmap img)
        {
            pcbMaze.Image = img;
        }

        private void frmGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
