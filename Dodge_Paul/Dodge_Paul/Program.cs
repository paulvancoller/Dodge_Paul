using Dodge_Paul.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Paul
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialise Game Objects
            bool Quit = false;

            // Game loop
            while (!Quit)
            {

                Game.Instance.Update(ref Quit);

                if (!Quit)
                    Game.Instance.Draw();

                Application.DoEvents();
                Thread.Sleep(5);
            }

            // Cleanup
            Game.ClearInstance();
        }
    }
}
