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

        public Player()
        {
            width = 82;
            height = 182;
            lives = 1;
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
            Bitmap PlayerImage = new Bitmap(GameResources.Instance.PlayerImage);
            
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorKey(PlayerImage.GetPixel(0, 0), PlayerImage.GetPixel(0, 0));

            Game.Instance.Canvas.DrawImage(PlayerImage, new Rectangle(Left, Top, Width, Height), 0, 0, PlayerImage.Width, PlayerImage.Height, GraphicsUnit.Pixel, attr);
        }

        public bool IsAlive()
        {
            return (lives > 0);
        }
    }
}
