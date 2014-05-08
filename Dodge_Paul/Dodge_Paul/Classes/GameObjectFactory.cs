using Dodge_Paul.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Paul.Classes
{
    public static class GameObjectFactory
    {
        public static IGameObject NewPlayer(string Name, int TeamNo, bool LocalPlayer)
        {
            Player player = new Player(Name, TeamNo, LocalPlayer);
            return player;
        }

        public static IGameObject NewDrop(int TeamNo)
        {
            Drop drop = new Drop(TeamNo);
            return drop;
        }
    }
}
