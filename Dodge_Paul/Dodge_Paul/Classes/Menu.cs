using Dodge_Paul.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Paul.Classes
{
    class Menu 
    {
        private int MenuSelection;     // 1 = New Game, 2 = Quit game
        private int MenuState;      // 0 = regular/pause menu, 1 = death menu

        public Menu()
        {
            MenuSelection = 1;
            MenuState = 0;
        }

        public void Update(ref int SelectedMenuItem)
        {
            switch (MenuState)
            {
                case 0:
                    KeysMenu1(ref SelectedMenuItem);
                    break;
                case 1:
                    KeysMenu2(ref SelectedMenuItem);
                    break;
            }
        }

        private void KeysMenu1(ref int SelectedMenuItem)
        {
            if (Keyboard.IsKeyDown(KeyCode.Down))
                if (MenuSelection < 2)
                    MenuSelection++;

            if (Keyboard.IsKeyDown(KeyCode.Up))
                if (MenuSelection > 1)
                    MenuSelection--;

            if (Keyboard.IsKeyDown(KeyCode.Enter))
                SelectedMenuItem = MenuSelection;
        }

        private void KeysMenu2(ref int SelectedMenuItem)
        {

        }

        public void Draw()
        {
            Image MenuImage = null;

            // Draw Menu
            switch (MenuState)
            {
                case 0:
                    MenuImage = GameResources.Instance.MainMenu1Image;
                    break;
                case 1:
                    MenuImage = GameResources.Instance.MainMenu2Image;
                    break;
            }

            ImageAttributes attr = new ImageAttributes();
            Bitmap TmpBitmap = new Bitmap(MenuImage);
            attr.SetColorKey(TmpBitmap.GetPixel(0, 0), TmpBitmap.GetPixel(0, 0));

            Rectangle MenuPlacement = new Rectangle(
                (Game.Instance.GameScreen.Width - MenuImage.Width) / 2,
                (Game.Instance.GameScreen.Height - MenuImage.Height) / 2,
                MenuImage.Width,
                MenuImage.Height);

            Game.Instance.Canvas.DrawImage(MenuImage, MenuPlacement, 0, 0, MenuImage.Width, MenuImage.Height, GraphicsUnit.Pixel, attr);


            // Draw selector
            Image PointerImage = GameResources.Instance.MainMenuPointerImage;
            Rectangle SelectorPlacement = new Rectangle(
                MenuPlacement.Left - PointerImage.Width - 10,
                MenuPlacement.Top + 90 + ((MenuSelection - 1) * 40),
                PointerImage.Width,
                PointerImage.Height);

            Game.Instance.Canvas.DrawImage(PointerImage, SelectorPlacement, 0, 0, PointerImage.Width, PointerImage.Height, GraphicsUnit.Pixel, attr);

        }
    }
}
