using Dodge_Paul.Forms;
using Dodge_Paul.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Paul.Classes
{
    public class Game
    {
        private static Game instance;

        public GameForm GameScreen;
        public Graphics Canvas;
        public Random Randomizer;

        private bool paused = true;
        private bool gameValid = false;
        private Menu GameMenu;
        private Bitmap BackBuffer;
        private List<IGameObject> GameObjects;

        public static Game Instance
        {
            get
            {
                if (instance == null)
                    instance = new Game();

                return instance;
            }
        }
        
        public static void ClearInstance()
        {
            instance = null;
        }

        private Game()
        {
            GameObjects = new List<IGameObject>();
            GameMenu = new Menu();
            GameScreen = new GameForm();
            GameScreen.Show();
            Cursor.Hide();

            BackBuffer = new Bitmap(GameScreen.Width, GameScreen.Height);
            Canvas = Graphics.FromImage(BackBuffer);

            Randomizer = new Random(DateTime.Now.Millisecond);
        }
        
        ~Game()
        {
            GameObjects.Clear();

            Config.ClearInstance();
            GameResources.ClearInstance();

            Randomizer = null;
            GameObjects = null;
            GameMenu = null;
            BackBuffer = null;
            GameScreen = null;
        }

        private void NewGame()
        { 
            // Delete old objects
            GameObjects.Clear();

            // Create new objects
            for (int i = 0; i < Config.Instance.PlayerCount; i++)
                GameObjects.Add(GameObjectFactory.NewPlayer("Player " + (i + 1), 1, (i == 0)));

            for (int i = 0; i < Config.Instance.DropCount; i++)
                GameObjects.Add(GameObjectFactory.NewDrop(2));

            gameValid = true;
            paused = false;
        }

        private void CheckInputs(ref bool Quit)
        {
            if ((Keyboard.IsKeyDown(KeyCode.Escape)) && (gameValid))
            {
                paused = !paused;
                Thread.Sleep(100);
            }
        }

        public void Update(ref bool Quit)
        {
            // This updates the game objects based on their own logic and keyboard inputs

            // Game specific updates
            CheckInputs(ref Quit);

            // Allow each game object to update
            if (paused)
            {
                // Menu
                int SelectedMenuItem = 0;
                GameMenu.Update(ref SelectedMenuItem);

                // Handle game specific events (Quit, Start new game, etc)
                switch (SelectedMenuItem)
                {
                    case 1:
                        NewGame();
                        break;
                    case 2:
                        Quit = true;
                        break;
                }
            }
            else
            {
                // Game
                if (!Quit)
                {
                    foreach (IGameObject item in GameObjects)
                        item.Update();
                }
            }

        }

        public void Draw()
        {
            // Draw background
            Canvas.DrawImage(GameResources.Instance.BackgroundImage, new Rectangle(0, 0, GameScreen.Width, GameScreen.Height));

            // Draw objects
            if (gameValid)
            {
                foreach (IGameObject item in GameObjects)
                    item.Draw();
            }

            // Draw Menu
            if (paused)
                GameMenu.Draw();

            // Flip buffers
            GameScreen.picCanvas.Image = BackBuffer;
        }

        public bool DetectCollision(IGameObject Source, bool IgnoreSameTeam)
        {
            bool retVal = false;

            Parallel.ForEach(GameObjects, testItem =>
                {
                    if (!retVal)        // Skip if a collision has been detected
                    {
                        if ((testItem != Source) && ((testItem.TeamNo() != Source.TeamNo()) || (!IgnoreSameTeam)))
                        {
                            bool Touching = true;

                            if (testItem.Right() < Source.Left())
                                Touching = false;

                            if (testItem.Left() > Source.Right())
                                Touching = false;

                            if (testItem.Bottom() < Source.Top())
                                Touching = false;

                            if (testItem.Top() > Source.Bottom())
                                Touching = false;

                            if (Touching)
                                retVal = true;
                        }
                    }
                });

            return retVal;
        }

        public void GameOver()
        {
            gameValid = false;
            paused = true;
            GameMenu.MenuState = 1;
        }
    }


}
