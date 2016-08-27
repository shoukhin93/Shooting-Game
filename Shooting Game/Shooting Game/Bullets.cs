using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Shooting_Game
{
    class Bullets
    {
        private PictureBox bullet;
        public Bullets()
        {
            bullet = new PictureBox();
            bullet.Width = 10;
            bullet.Height = 10;
            bullet.Image = Properties.Resources.bullet11;
            bullet.BackColor = Color.Transparent;
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public Point setBulletLocation
        {
            set { bullet.Location = value; }
        }

        public PictureBox getBullets
        {
            get { return bullet; }
        }
    }
}
