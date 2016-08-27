using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Shooting_Game
{
    class Granade
    {

        private int movesBeforeExplotion = 100;

        private PictureBox granade;
        private Point coordinateToExplode;
        public static string NAME = "GRANADE";

        public Granade()
        {
            granade = new PictureBox();
            granade.Image = Properties.Resources.granade1;
            granade.Width = 20;
            granade.Height = 20;
            granade.SizeMode = PictureBoxSizeMode.StretchImage;
            
            
        }

        public Size setsize
        {
            set { granade.Size = value; }
        }

        public int explotionPoint
        {
            get { return movesBeforeExplotion; }
            set { movesBeforeExplotion = value; }
        }
        public Point explotion
        {
            get { return coordinateToExplode; }
            set { coordinateToExplode = value; }
        }

        public void getPrepared()
        {
            coordinateToExplode = new Point(granade.Location.X, granade.Location.Y + movesBeforeExplotion);
        }
        public Point setGranadeLocation
        {
            set { granade.Location = value; }
        }

        public PictureBox getGranade
        {
            get { return granade; }
            set { granade.Image = value.Image; }
        }

        public void explotionMode()
        {
            granade.Image = Properties.Resources.granadeExplotion;
            granade.Size = new Size(30, 30);
        }
    }
}
