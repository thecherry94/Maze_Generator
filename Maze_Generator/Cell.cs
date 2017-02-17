using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator
{
    class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public bool[] Walls { get; private set; }

        public Color Color { get; set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;

            Walls = new bool[4];
            for (int i = 0; i < 4; i++)
                Walls[i] = true;

            Visited = false;
        }

        public void setWall(int wall, bool value)
        {   
            if(wall >= 0 && wall < 4)
                Walls[wall] = value;
        }

        public bool TopWall { get { return Walls[0]; } set { Walls[0] = value; } }
        public bool RightWall { get { return Walls[1]; } set { Walls[1] = value; } }
        public bool BottomWall { get { return Walls[2]; } set { Walls[2] = value; } }
        public bool LeftWall { get { return Walls[3]; } set { Walls[3] = value; } }

        public bool Visited { get; set; }
    }
}
