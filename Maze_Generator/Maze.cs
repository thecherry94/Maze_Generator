using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator
{
    class Maze
    {
        private Cell[] cells;
        private int num_cells;
        private int cells_per_row_col;

        private int field_size;

        private float cell_size;

        private Bitmap maze_image;

        private Point cell_selector;

        private Pen penGrid;

        public Maze(int numCells, int fieldSize)
        {
            num_cells = numCells;
            field_size = fieldSize;
            cells_per_row_col = (int)Math.Sqrt(num_cells);
            cell_size = (float)(field_size - 1) / (float)cells_per_row_col;

            cell_selector = new Point(0, 0);

            maze_image = new Bitmap(field_size, field_size);

            cells = new Cell[num_cells];
            

            for (int i = 0; i < cells_per_row_col; i++)
            {
                for(int j = 0; j < cells_per_row_col; j++)
                {
                    cells[i * cells_per_row_col + j] = new Cell(i, j);
                }
            }

            

            penGrid = new Pen(Brushes.Black);
            penGrid.Width = 1;
                  
        }

        public void selector_moveLeft()
        {
            if(cell_selector.X > 0)
                cell_selector = new Point(cell_selector.X - 1, cell_selector.Y);
        }

        public void selector_moveRight()
        {
            if (cell_selector.X < cells_per_row_col - 1)
                cell_selector = new Point(cell_selector.X + 1, cell_selector.Y);
        }

        public void selector_moveUp()
        {
            if (cell_selector.Y < 0)
                cell_selector = new Point(cell_selector.X, cell_selector.Y - 1);
        }

        public void selector_moveDown()
        {
            if (cell_selector.Y < cells_per_row_col - 1)
                cell_selector = new Point(cell_selector.X, cell_selector.Y + 1);
        }

        public Cell selector_GetSelectedCell()
        {
            return cells[cell_selector.Y  * cells_per_row_col + cell_selector.X];
        }

        public bool[] has_unvisited_neighbors(Cell c)
        {
            bool[] retval = new bool[4];

            for (int i = 0; i < 4; i++)
                retval[i] = false;
            
            // Top
            if(c.Row - 1 >= 0)
                retval[0] = !cells[(c.Row - 1) * cells_per_row_col + c.Column].Visited;

            // Bottom
            if (c.Row + 1 < cells_per_row_col)
                retval[2] = !cells[(c.Row + 1) * cells_per_row_col + c.Column].Visited;
            
            // Left
            if (c.Column - 1 >= 0)
                retval[3] = !cells[c.Row * cells_per_row_col + c.Column - 1].Visited;

            // Right
            if (c.Column + 1 < cells_per_row_col)
                retval[1] = !cells[c.Row * cells_per_row_col + c.Column + 1].Visited;

            return retval;
        }

        public bool[] has_unvisited_neighbors(int x, int y)
        {
            bool[] retval = new bool[4];

            Cell c = cells[y * cells_per_row_col + x];

            for (int i = 0; i < 4; i++)
                retval[i] = false;

            if (c.Row - 1 >= 0)
                retval[0] = !cells[(c.Row - 1) * cells_per_row_col + c.Column].Visited;

            if (c.Row + 1 < cells_per_row_col)
                retval[1] = !cells[(c.Row + 1) * cells_per_row_col + c.Column].Visited;

            if (c.Column - 1 >= 0)
                retval[2] = !cells[c.Row * cells_per_row_col + c.Column - 1].Visited;

            if (c.Column + 1 < cells_per_row_col)
                retval[3] = !cells[c.Row * cells_per_row_col + c.Column + 1].Visited;

            return retval;
        }

        public void GenerateMaze(bool coloring)
        {
            Cell initalCell = selector_GetSelectedCell();
            initalCell.Visited = true;

            Cell currentCell = initalCell;

            Stack<Cell> visited = new Stack<Cell>();
          
            int num_visited = 1;

            Random rng = new Random();
            int i = 0;
            Color currentColor = Color.FromArgb(255, rng.Next(64, 196), rng.Next(64, 196), rng.Next(64, 196));

            while(num_visited < cells.Length)
            {
                bool[] neighbors = has_unvisited_neighbors(currentCell);

                if (neighbors[0] || neighbors[1] || neighbors[2] || neighbors[3])
                {
                    Cell chosenOne = null;

                    int rnd = rng.Next(0, 3);
                    while (!neighbors[rnd])
                        rnd = rng.Next(0, 4);

                    visited.Push(currentCell);
                    

                    switch(rnd)
                    {
                        case 0:
                            chosenOne = cells[(currentCell.Row - 1) * cells_per_row_col + currentCell.Column];

                            currentCell.TopWall = false;
                            chosenOne.BottomWall = false;
                            break;

                        case 1:
                            chosenOne = cells[currentCell.Row * cells_per_row_col + currentCell.Column + 1];

                            currentCell.RightWall = false;
                            chosenOne.LeftWall = false;
                            break;

                        case 2:
                            chosenOne = cells[(currentCell.Row + 1) * cells_per_row_col + currentCell.Column];

                            currentCell.BottomWall = false;
                            chosenOne.TopWall = false;
                            break;

                        case 3:
                            chosenOne = cells[currentCell.Row * cells_per_row_col + currentCell.Column - 1];

                            currentCell.LeftWall = false;
                            chosenOne.RightWall = false;                          
                            break;

                        default:
                            throw new Exception("wtf?");
                    }

                    chosenOne.Visited = true;
                    currentCell = chosenOne;

                    i++;
                    if (i % 100 == 0 && coloring)
                    {
                        currentColor = Color.FromArgb(255, rng.Next(64, 196), rng.Next(64, 196), rng.Next(64, 196));
                        i = 0;
                    }
                    if(coloring)
                        currentCell.Color = currentColor;

                    num_visited++;
                }
                else if(visited.Count > 0)
                {
                    currentCell = visited.Pop();
                }    
            }

            cells[cells_per_row_col * cells_per_row_col - 1].RightWall = false;

        }

        private bool unvisited_cells_left()
        {
            bool retval = false;

            foreach(Cell c in cells)
            {
                if (c.Visited)
                {
                    retval = true;
                    break;
                }
            }

            return retval;
        }


        public void Render()
        {
            using (Graphics g = Graphics.FromImage(maze_image))
            {
                g.Clear(Color.White);

                render_grid(g);
            }
        }

        private void render_grid(Graphics g)
        {
            foreach (Cell c in cells)
            {
                Brush fillBrush = new SolidBrush(c.Color);
                g.FillRectangle(fillBrush, new RectangleF(new PointF(cell_size * c.Column, cell_size * c.Row), new SizeF(cell_size, cell_size)));

                if (c.TopWall)
                    g.DrawLine(penGrid, new PointF(cell_size * c.Column, cell_size * c.Row), new PointF(cell_size * (1 + c.Column), cell_size * c.Row));

                if (c.RightWall)
                    g.DrawLine(penGrid, new PointF(cell_size * (1 + c.Column), cell_size * c.Row), new PointF(cell_size * (1 + c.Column), cell_size * (1 + c.Row)));

                if (c.BottomWall)
                    g.DrawLine(penGrid, new PointF(cell_size * c.Column, cell_size * (1 + c.Row)), new PointF(cell_size * (1 + c.Column), cell_size * (1 + c.Row)));

                if (c.LeftWall)
                    g.DrawLine(penGrid, new PointF(cell_size * c.Column, cell_size * c.Row), new PointF(cell_size * c.Column, cell_size * (1 + c.Row)));
            }
        }

        public void SaveImage()
        {
            Guid guid = Guid.NewGuid();

            Image.Save(guid.ToString() + ".bmp"); 
        }

        public Bitmap Image { get { return maze_image; } }
    }
}
