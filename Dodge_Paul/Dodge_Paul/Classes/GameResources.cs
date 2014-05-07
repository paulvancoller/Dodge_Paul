using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Paul.Classes
{
    public class GameResources
    {
        private static GameResources instance;

        private Image backgroundImage;
        private Image mainMenu1Image;
        private Image mainMenu2Image;
        private Image mainMenuPointerImage;
        private Image playerImage;
        private Image dropImage;

        public static GameResources Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameResources();

                return instance;
            }
        }

        public static void ClearInstance()
        {
            instance = null;
        }
        
        private GameResources()
        {
            backgroundImage = new Bitmap(Application.StartupPath + "\\Graphics\\back.bmp");
            mainMenu1Image = new Bitmap(Application.StartupPath + "\\Graphics\\menu1.bmp");
            mainMenu2Image = new Bitmap(Application.StartupPath + "\\Graphics\\menu2.bmp");
            mainMenuPointerImage = new Bitmap(Application.StartupPath + "\\Graphics\\menupointer.bmp");
            playerImage = new Bitmap(Application.StartupPath + "\\Graphics\\player.bmp");
            dropImage = new Bitmap(Application.StartupPath + "\\Graphics\\raindrop.bmp");
        }

        ~GameResources()
        {
            backgroundImage = null;
            mainMenu1Image = null;
            mainMenu2Image = null;
            mainMenuPointerImage = null;
            playerImage = null;
            dropImage = null;
        }

        public Image BackgroundImage { get { return backgroundImage; } }
        public Image MainMenu1Image { get { return mainMenu1Image; } }
        public Image MainMenu2Image { get { return mainMenu2Image; } }
        public Image MainMenuPointerImage { get { return mainMenuPointerImage; } }
        public Image PlayerImage { get { return playerImage; } }
        public Image DropImage { get { return dropImage; } }
    }
}
