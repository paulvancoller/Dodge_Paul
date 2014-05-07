using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Paul.Classes
{
    public class Config
    {
        private static Config instance;

        private int playerCount;
        private int dropCount;
        private int dropMinSpeed;
        private int dropMaxSpeed;

        public static Config Instance
        {
            get
            {
                if (instance == null)
                    instance = new Config();

                return instance;
            }
        }

        public static void ClearInstance()
        {
            instance = null;
        }

        private Config()
        {
            playerCount = Properties.Settings.Default.PlayerCount;
            dropCount = Properties.Settings.Default.DropCount;
            dropMinSpeed = Properties.Settings.Default.DropMinSpeed;
            dropMaxSpeed = Properties.Settings.Default.DropMaxSpeed;
        }

        public int PlayerCount
        {
            get
            {
                return playerCount;
            }
            set
            {
                playerCount = value;
            }
        }

        public int DropCount
        {
            get
            {
                return dropCount;
            }
            set
            {
                dropCount = value;
            }
        }

        public int DropMinSpeed
        {
            get
            {
                return dropMinSpeed;
            }
            set
            {
                dropMinSpeed = value;
            }
        }

        public int DropMaxSpeed
        {
            get
            {
                return dropMaxSpeed;
            }
            set
            {
                dropMaxSpeed = value;
            }
        }

        public string AppStartupPath
        {
            get
            {
                return Application.StartupPath;
            }
        }
    }
}
