using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Paul.Interfaces
{
    public interface IGameObject
    {
        void Update();
        void Draw();

        int Left();
        int Right();
        int Top();
        int Bottom();
        string Name();
        int TeamNo();
    }
}
