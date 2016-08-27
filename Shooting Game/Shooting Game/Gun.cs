using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Shooting_Game
{
    class Gun
    {
        private PictureBox gun;
        public static string NAME = "GUN";

        
        public PictureBox getGun
        { get { return gun; } }
        public Point Coordinate
        {
            set { gun.Location = value; }
        }
        public Gun()
        {
            gun = new PictureBox();
            gun.Image = Properties.Resources.ammo3;
            gun.SizeMode = PictureBoxSizeMode.StretchImage;
            gun.Size = new Size(25, 30);
        }

    }
}
