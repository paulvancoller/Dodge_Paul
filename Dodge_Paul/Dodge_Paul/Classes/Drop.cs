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
            width = 82;
            height = 182;
        }

        public override void Update()
        {
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
