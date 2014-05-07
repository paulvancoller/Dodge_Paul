using Dodge_Paul.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Paul.Classes
{
    public abstract class GameObject : IGameObject
    {
        protected int width;
        protected int height;

        public string Name { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }

        public int Width 
        { 
            get 
            {
                return width;
            } 
        }

        public int Height 
        { 
            get
            {
                return height;
            } 
        }

        public abstract void Update();
        public abstract void Draw();
    }
}
