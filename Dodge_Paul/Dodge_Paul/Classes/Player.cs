using Dodge_Paul.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Paul.Classes
{
    public class Player : GameObject
    {
        public bool LocalPlayer { get; set; }

        private int lives;

        public Player(string name, int teamNo, bool localPlayer)
        {
            width = GameResources.Instance.PlayerImage.Width;
            height = GameResources.Instance.PlayerImage.Height;
            
            // Position the player at the bottom of the screen, but horisontally in the middle
            left = (Game.Instance.GameScreen.Width - width) / 2;
            top = (Game.Instance.GameScreen.Height - height);

            this.lives = 1;
            this.speed = Config.Instance.PlayerSpeed;
            this.name = name;
            this.teamNo = teamNo;
            this.LocalPlayer = LocalPlayer;
        }

        public override void Update()
        {
            if ((Keyboard.IsKeyDown(KeyCode.Left)) && (left > 0))
                left -= speed;

            if ((Keyboard.IsKeyDown(KeyCode.Right)) && (left < (Game.Instance.GameScreen.Width - width)))
                left += speed;

            // Check shift for speed
            if ((Keyboard.IsKeyDown(KeyCode.Left)) && ((Keyboard.IsKeyDown(KeyCode.LeftShift)) || (Keyboard.IsKeyDown(KeyCode.RightShift))) && (left > 0))
                left -= speed;

            if ((Keyboard.IsKeyDown(KeyCode.Right)) && ((Keyboard.IsKeyDown(KeyCode.LeftShift)) || (Keyboard.IsKeyDown(KeyCode.RightShift))) && (left < (Game.Instance.GameScreen.Width - width)))
                left += speed;

            // Check for collisions
            if (Game.Instance.DetectCollision(this, true))
            {
                this.lives--;

                if (!IsAlive())
                    Game.Instance.GameOver();
            }
        }

        public override void Draw()
        {
            Bitmap PlayerImage = new Bitmap(GameResources.Instance.PlayerImage);
            
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorKey(PlayerImage.GetPixel(0, 0), PlayerImage.GetPixel(0, 0));

            Game.Instance.Canvas.DrawImage(PlayerImage, new Rectangle(left, top, width, height), 0, 0, PlayerImage.Width, PlayerImage.Height, GraphicsUnit.Pixel, attr);
        }

        public bool IsAlive()
        {
            return (lives > 0);
        }


    }
}
