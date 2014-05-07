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
        Up = 0x26,
        Right = 0x27,
        Down = 0x28,
        Escape = 0x1B,
        Enter = 0x0D,
        LeftShift = 0xA0,
        RightShift = 0xA1
    }

    internal static class Keyboard
    {
        private const int KeyPressed = 0x8000;
        private const int KeyUp = 0x0101;
        private const int KeyPreviouslyDown = 0x0001;

        public static bool IsKeyDown(KeyCode key)
        {
            return (GetAsyncKeyState((int)key) & KeyPressed) != 0;
        }

        public static bool IsKeyPressed(KeyCode key)
        {
            return (IsKeyDown(key) && (GetAsyncKeyState((int)key) & KeyPreviouslyDown) == 0);
        }

        public static bool IsKeyUp(KeyCode key)
        {
            return (GetAsyncKeyState((int)key) & KeyUp) != 0;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int key);
    }
}
