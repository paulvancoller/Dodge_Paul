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
            Form GameForm = new Form() { WindowState = FormWindowState.Maximized, FormBorderStyle = System.Windows.Forms.FormBorderStyle.None, BackColor = Color.Black, Text = "Dodge", MaximizeBox = false, MinimizeBox = false, ControlBox = false };
            GameForm.Show();

            //Game loop
            while (!Quit)
            {

                Thread.Sleep(20);
                if (Keyboard.IsKeyDown(KeyCode.Escape))
                    Quit = true;

                Application.DoEvents();
            }


            // Cleanup game objects
            GameForm = null;
        }
    }
}
