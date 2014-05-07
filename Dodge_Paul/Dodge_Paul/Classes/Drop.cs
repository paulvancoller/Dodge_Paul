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
    public class Drop : GameObject
    {
        public Drop()
        {
            width = GameResources.Instance.DropImage.Width;
            height = GameResources.Instance.DropImage.Height;

            // Randomly pick a location in the top quarter of the screen
            Top = Game.Instance.Randomizer.Next(0, (Game.Instance.GameScreen.Height / 4) - Height);
            Left = Game.Instance.Randomizer.Next(0, Game.Instance.GameScreen.Width - Width);
            Speed = Game.Instance.Randomizer.Next(Config.Instance.DropMinSpeed, Config.Instance.DropMaxSpeed);
        }

        public override void Update()
        {
            if (Top > (Game.Instance.GameScreen.Height - Height))
            {
                // Reset position back to top of screen
                Top = Game.Instance.Randomizer.Next(0, (Game.Instance.GameScreen.Height / 4) - Height);
                Left = Game.Instance.Randomizer.Next(0, Game.Instance.GameScreen.Width - Width);
                Speed = Game.Instance.Randomizer.Next(Config.Instance.DropMinSpeed, Config.Instance.DropMaxSpeed);
            }
            else
            {
                Top += Speed;
            }

        }

        public override void Draw()
        {
            Bitmap DropImage = new Bitmap(GameResources.Instance.DropImage);

            ImageAttributes attr = new ImageAttributes();
            attr.SetColorKey(DropImage.GetPixel(0, 0), DropImage.GetPixel(0, 0));

            Game.Instance.Canvas.DrawImage(DropImage, new Rectangle(Left, Top, Width, Height), 0, 0, DropImage.Width, DropImage.Height, GraphicsUnit.Pixel, attr);
        }
    }
}
