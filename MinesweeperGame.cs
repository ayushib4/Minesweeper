using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7ProgrammingProject
{
    public static class MinesweeperGame
    {
        // public class constants
        internal const int ROWS = 10;
        internal const int COLS = 16;
        internal const int BUTTON_SIZE = 25;

        // private class variables
        private static Form form;
        private static Button[,] buttons;

        private static MinesweeperBoard board = new MinesweeperBoard(ROWS, COLS);

        // initializes form buttons and sets form width and height
        public static void Initialize(Form f)
        {
            // set up the form
            MinesweeperGame.form = f;
            int titleHeight = f.Height - f.ClientRectangle.Height;
            f.Size = new Size(BUTTON_SIZE * COLS + COLS,
                              BUTTON_SIZE * ROWS + ROWS + titleHeight);

            // create the buttons on the form
            buttons = new Button[ROWS, COLS];
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    // create a new button control
                    Button b = new Button();
                    buttons[i, j] = b;
                    b.Width = BUTTON_SIZE;
                    b.Height = BUTTON_SIZE;
                    b.Top = i * BUTTON_SIZE;
                    b.Left = j * BUTTON_SIZE;
                    b.Text = String.Empty;
                    b.Name = i + "_" + j;
                    b.FlatStyle = FlatStyle.Popup;
                    b.Click += new EventHandler(MinesweeperGame.Click);

                    // add the button control to the form
                    f.Controls.Add(b);
                }
            }

            // TODO: call student-authored method to initialize game
            //   MinesweeperBoard.Initialize();
            board.Initialize();

        }

        // event handler for all minesweeper button click events
        private static void Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int index = b.Name.IndexOf("_");
            int i = int.Parse(b.Name.Substring(0, index));
            int j = int.Parse(b.Name.Substring(index + 1));
            
            // TODO: call student-authored method to handle button event
            //   MinesweeperBoard.Click(i, j);
            board.Click(i, j);
            
        }

        // retrieve a button control at row "i" and column "j"
        public static Button GetButton(int i, int j)
        {
            if (i < 0 || i >= ROWS)
            {
                throw new ArgumentException("row index out of range");
            }
            if (j < 0 || j >= COLS)
            {
                throw new ArgumentException("column index out of range");
            }
            return buttons[i, j];
        }

    }
}
