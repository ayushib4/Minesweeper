using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7ProgrammingProject
{
    class MinesweeperCell
    {
        // properties
        public int Row { get; set; }
        public int Column { get; set; }
        public Boolean HasMine { get; set; }
        public int NumAdjacent { get; set; }
        public Boolean Revealed { get; set; }
        public Boolean Flagged { get; set; }

        // constructor
        public MinesweeperCell(int i, int j)
        {
            this.Row = i;
            this.Column = j;
            this.HasMine = false;
            this.NumAdjacent = 0;
            this.Revealed = false;
            this.Flagged = false;
        }
        
        public void InsertMine()
        {
            HasMine = true;
        }

    }
}
