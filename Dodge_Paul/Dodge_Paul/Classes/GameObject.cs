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
        protected int left;
        protected int top;
        protected string name { get; set; }
        protected int speed;
        protected int teamNo;

        public abstract void Update();
        public abstract void Draw();

        public int Left()
        {
            return left;
        }

        public int Top()
        {
            return top;
        }

        public int Right()
        {
            return left + width;
        }

        public int Bottom()
        {
            return top + height;
        }

        public string Name()
        {
            return name;
        }

        public int TeamNo()
        {
            return teamNo;
        }
    }
}
