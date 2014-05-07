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
        public Drop(int teamNo)
        {
            width = GameResources.Instance.DropImage.Width;
            height = GameResources.Instance.DropImage.Height;

            // Randomly pick a location in the top quarter of the screen
            this.top = Game.Instance.Randomizer.Next(0, (Game.Instance.GameScreen.Height / 4) - height);
            this.left = Game.Instance.Randomizer.Next(0, Game.Instance.GameScreen.Width - width);
            this.speed = Game.Instance.Randomizer.Next(Config.Instance.DropMinSpeed, Config.Instance.DropMaxSpeed);
            this.teamNo = teamNo;

        }

        public override void Update()
        {
            if (top > (Game.Instance.GameScreen.Height - height))
            {
                // Reset position back to top of screen
                top = Game.Instance.Randomizer.Next(0, (Game.Instance.GameScreen.Height / 4) - height);
                left = Game.Instance.Randomizer.Next(0, Game.Instance.GameScreen.Width - width);
                speed = Game.Instance.Randomizer.Next(Config.Instance.DropMinSpeed, Config.Instance.DropMaxSpeed);
            }
            else
            {
                top += speed;
            }

        }

        public override void Draw()
        {
            Bitmap DropImage = new Bitmap(GameResources.Instance.DropImage);

            ImageAttributes attr = new ImageAttributes();
            attr.SetColorKey(DropImage.GetPixel(0, 0), DropImage.GetPixel(0, 0));

            Game.Instance.Canvas.DrawImage(DropImage, new Rectangle(left, top, width, height), 0, 0, DropImage.Width, DropImage.Height, GraphicsUnit.Pixel, attr);
        }
    }
}
