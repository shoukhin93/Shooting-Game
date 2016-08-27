using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace Shooting_Game
{
    class gunFiring
    {
        private Form1 formToDraw;
        public ArrayList bullets;
        private bool isPlayerAtDown;

        private const int UPPER_BOUND_Y = -10;
        private const int LOWER_BOUND_Y = 470;

        private const int FIRING_SPEED = 20;

        SoundPlayer gunSound;
        SoundPlayer vehicleDamage;


        public Form1 mainForm
        {
            set { formToDraw = value; }
        }

        public gunFiring(bool isPlayerAtDown)
        {
            this.isPlayerAtDown = isPlayerAtDown;
            bullets = new ArrayList();
            gunSound = new SoundPlayer(Properties.Resources.gun1);
            vehicleDamage = new SoundPlayer(Properties.Resources.vehicleDamage);
        }

        public void addBullets(PictureBox p)
        {
            bullets.Add(p);
            formToDraw.Controls.Add(p);
            gunSound.Stop();
            gunSound.Play();
        }


        public void updateBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                PictureBox p = (PictureBox)bullets[i];
                //if The Player is down Player, Bullet Will Go Up
                if (isPlayerAtDown)
                    p.Location = new Point(p.Location.X, p.Location.Y - FIRING_SPEED);
                else
                    p.Location = new Point(p.Location.X, p.Location.Y + FIRING_SPEED);

                formToDraw.Controls.Add(p);

                if (p.Location.Y < UPPER_BOUND_Y || p.Location.Y > LOWER_BOUND_Y)
                {
                    bullets.Remove(p);
                    formToDraw.Controls.Remove(p);
                }
                //If Player Hitted By Player
                if (GameStatus.isPlayerHited(p, p.Location, isPlayerAtDown))
                {
                    bullets.Remove(p);
                    formToDraw.Controls.Remove(p);
                    vehicleDamage.Play();
                }
            }


        }
    }
}
