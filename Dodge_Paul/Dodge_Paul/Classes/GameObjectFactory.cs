﻿using Dodge_Paul.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Paul.Classes
{
    public class GameObjectFactory
    {
        private static Random rand = new Random(DateTime.Now.Millisecond);

        public static IGameObject NewPlayer(string Name, bool LocalPlayer)
        {
            Player player = new Player();
            player.Name = Name;
            player.LocalPlayer = LocalPlayer;

            // Position the player at the bottom of the screen, but horisontally in the middle
            player.Left = (Game.Instance.GameScreen.Width - player.Width) / 2;
            player.Top = (Game.Instance.GameScreen.Height - player.Height);
            
            return player;
        }

        public static IGameObject NewDrop()
        {
            Drop drop = new Drop();

            // Randomly pick a location in the top third of the screen
            drop.Top = rand.Next(0, (Game.Instance.GameScreen.Height / 3) - drop.Height);
            drop.Left = rand.Next(0, Game.Instance.GameScreen.Width - drop.Width);
            return drop;
        }
    }
}
