using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7ProgrammingProject
{
    static class Program
    {
        // the instance of this game
        internal static Form minesweeperForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            minesweeperForm = new MinesweeperForm();
            MinesweeperGame.Initialize(minesweeperForm);
            Application.Run(minesweeperForm);
        }
    }
}
