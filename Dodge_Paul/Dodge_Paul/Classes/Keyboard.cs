using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Paul.Classes
{
    internal enum KeyCode : int
    {
        Left = 0x25,
        Right = 0x27, 
        Escape = 0x1B
    }

    internal static class Keyboard
    {
        private const int KeyPressed = 0x8000;

        public static bool IsKeyDown(KeyCode key)
        {
            return (GetKeyState((int)key) & KeyPressed) != 0;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
    }
}
