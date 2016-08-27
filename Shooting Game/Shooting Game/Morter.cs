using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Shooting_Game
{
    class Morter
    {
        private PictureBox morter;
        private int movesBeforeExplotion = 200;
        public static string NAME = "MORTER";

        
        public Point Coordinate
        {
            set { morter.Location = value; }
        }

        public int explotionTime
        {
            get { return movesBeforeExplotion; }
            set { movesBeforeExplotion = value; }
        }

        public Size setSize
        {
            set { morter.Size = value; }
        }

        public PictureBox getMorter
        {
            get { return morter; }
            set { morter.Image = value.Image; }
        }

        public Morter()
        {
            morter = new PictureBox();
            morter.Size = new Size(30, 30);
            morter.Image = Properties.Resources.morter1;
            morter.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void explotion()
        {
            morter.Image = Properties.Resources.morterExplotion1;
            morter.Size = new Size(30, 30);
        }
    }
}
