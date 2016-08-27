using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Shooting_Game
{
    class Splinter
    {
        public static string[,] movementProperties = { { "x--", "y--" }, { "x","y--"}, {"x++","y--"}, {"x--","y"}, {"x++","y"}, {"x--","y++"}, 
                                                     {"x", "y++"}, {"x++", "y++"}, };
        private PictureBox splinter;
        private int movesBeforeDestruction = 50;

        public ArrayList movement;

        public PictureBox getSplinter
        {
            get { return splinter; }
        }
        public int destructionPoint
        {
            get { return movesBeforeDestruction; }
            set { movesBeforeDestruction = value; }
        }
        public Point setCoordinate
        {
            set { splinter.Location = value; }
        }
       

        public Splinter()
        {
            splinter = new PictureBox();
            splinter.Image = Properties.Resources.splinter1;
            splinter.Size = new Size(10, 10);
            splinter.SizeMode = PictureBoxSizeMode.StretchImage;

            movement = new ArrayList();

        }

       
    }
}
