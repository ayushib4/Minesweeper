using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lesson7ProgrammingProject
{
    class MinesweeperBoard
    {
        // private variables
        private MinesweeperCell[,] minesweeperCells;

        // properties
        public int Columns { get; set; }
        public int Rows { get; set; }
        public int NumberMines { get; set; } 

        // constructor
        public MinesweeperBoard(int numRows, int numCols)
        {
            Rows = numRows;
            Columns = numCols;
            NumberMines = (numRows * numCols) / 10;
            minesweeperCells = new MinesweeperCell [numRows, numCols];
        }

        private void PlaceMines()
        {
            var random = new Random();
            var remainingMines = NumberMines;

            while (remainingMines > 0)
            {
                int i = random.Next(Rows);
                int j = random.Next(Columns);

                if (!minesweeperCells[i, j].HasMine)
                {
                    minesweeperCells[i, j].InsertMine();
                    remainingMines--;
                    
                    // the following lines of code incrememnt numadjacent for each of the cells adjacent to a mine
                    NumAdjacentSetter(i - 1, j - 1);
                    NumAdjacentSetter(i - 1, j);
                    NumAdjacentSetter(i - 1, j + 1);
                    NumAdjacentSetter(i, j - 1);
                    NumAdjacentSetter(i, j + 1);
                    NumAdjacentSetter(i + 1, j - 1);
                    NumAdjacentSetter(i + 1, j);
                    NumAdjacentSetter(i + 1, j + 1);
                }
            }
        }

        public void NumAdjacentSetter(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < Rows && j < Columns && !minesweeperCells[i,j].HasMine)
            {
                minesweeperCells[i, j].NumAdjacent++;

            }
        }


        // initalize method
        public void Initialize()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    this.minesweeperCells[i, j] = new MinesweeperCell(i, j);
                }
            }

            PlaceMines();


        }

        // click game method
        public void Click(int row, int col)
        {
            MinesweeperGame.GetButton(row, col);
            if (WinnerChecker())
            {
                MessageBox.Show("You Won!");
            }    
            if (minesweeperCells[row, col].HasMine)
            {

                EndGame(row, col);
            }
            else
            {
                Reveal(row, col);
            }
        }

        // Reveal game method
        public void Reveal(int i, int j)
        {
            // checks if i and j are within the bounds
            if (i >= 0 && j >= 0 && i < Rows && j < Columns)
            {
                Button b = MinesweeperGame.GetButton(i, j);
                b.FlatStyle = FlatStyle.Flat;
                MinesweeperCell cell = minesweeperCells[i, j];
                if (cell.Revealed)
                {
                    return;
                }
                else
                {
                    cell.Revealed = true;
                    b.Enabled = false;
                    b.Text = cell.NumAdjacent.ToString();
                    switch (cell.NumAdjacent)
                    {
                        case 0:
                            b.Text = "";
                            b.BackColor = Color.SkyBlue;
                            break;
                        case 1:
                            b.BackColor = Color.HotPink;
                            break;
                        case 2:
                            b.BackColor = Color.Plum;
                            break;
                        case 3:
                            b.BackColor = Color.Gold;
                            break;
                        case 4:
                            b.BackColor = Color.Turquoise;
                            break;
                        default:
                            b.BackColor = Color.White;
                            break;
                    }

                    if (cell.NumAdjacent == 0)
                    {
                        Reveal(i - 1, j - 1);
                        Reveal(i - 1, j);
                        Reveal(i - 1, j + 1);
                        Reveal(i, j - 1);
                        Reveal(i, j + 1);
                        Reveal(i + 1, j - 1);
                        Reveal(i + 1, j);
                        Reveal(i + 1, j + 1);
                    }
                }
            }
            else
            {
                return;
            }
        }

        // end game method
        private void EndGame(int iPos, int jPos)
        {
            Button b = MinesweeperGame.GetButton(iPos, jPos);
            b.BackgroundImage = Properties.Resources.FlowerBomb;
            b.BackgroundImageLayout = ImageLayout.Stretch;
            b.BackColor = Color.MistyRose;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    b = MinesweeperGame.GetButton(i, j);
                    b.Enabled = false;
                    if (minesweeperCells[i, j].HasMine)
                    {
                        if ((i != iPos) && (j != jPos))
                        {
                            b.BackgroundImage = Properties.Resources.FlowerBomb;
                            b.BackgroundImageLayout = ImageLayout.Stretch;
                            b.BackColor = Color.Pink;
                        }
                    }
                }

            }
            MessageBox.Show("Game Over!");
        }

        private Boolean WinnerChecker()
        {
            int numCellsLeft = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Button b = MinesweeperGame.GetButton(i, j);
                    if (b.Enabled == false)
                    {
                        numCellsLeft++;
                    }
                }
            }
            if (numCellsLeft == NumberMines)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

/*
 * 
                    // left

                    if ((i - 1) >= 0)
                    {
                        minesweeperCells[i - 1, j].NumAdjacent++;
                    }

                    // right 

                    if ((i + 1) < Rows)
                    {
                        minesweeperCells[i + 1, j].NumAdjacent++;
                    }

                    // top

                    if ((j + 1) < Columns)
                    {
                        minesweeperCells[i, j + 1].NumAdjacent++;
                    }

                    // bottom

                    if ((j - 1) >= 0)
                    {
                        minesweeperCells[i, j - 1].NumAdjacent++;
                    }

                    // top left

                    if ((i - 1) >= 0 && (j + 1) < Columns)
                    {
                        minesweeperCells[i - 1, j + 1].NumAdjacent++;
                    }

                    // bottom left

                    if ((i - 1) >= 0 && (j - 1) >= 0)
                    {
                        minesweeperCells[i - 1, j - 1].NumAdjacent++;
                    }

                    // top right

                    if ((i + 1) < Rows && (j + 1) < Columns)
                    {
                        minesweeperCells[i + 1, j + 1].NumAdjacent++;
                    }

                    // top left

                    if ((i + 1) < Rows && (j - 1) >= 0)
                    {
                        minesweeperCells[i + 1, j - 1].NumAdjacent++;
                    }
*/