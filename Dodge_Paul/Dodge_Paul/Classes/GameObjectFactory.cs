using Dodge_Paul.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Paul.Classes
{
    public class GameObjectFactory
    {
        public static IGameObject NewPlayer(string Name, bool LocalPlayer)
        {
            Player player = new Player();
            player.Name = Name;
            player.LocalPlayer = LocalPlayer;

            return player;
        }

        public static IGameObject NewDrop()
        {
            Drop drop = new Drop();

            return drop;
        }
    }
}
