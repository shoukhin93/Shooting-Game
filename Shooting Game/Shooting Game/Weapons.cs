using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace Shooting_Game
{
    class Weapons
    {
        private Form1 canvas;
        private static Random random1;
        private ArrayList weapons, weaponNames;

        private const int LOWEST_BOUND_X = 0;
        private const int HIGHEST_BOUND_X = 690;
        private const int LOWEST_BOUND_Y = 0;
        private const int HIGHEST_BOUND_Y = 440;
        public Weapons(Form1 canvas)
        {
            this.canvas = canvas;

            random1 = new Random();
            weapons = new ArrayList();
            weaponNames = new ArrayList();


        }

        private void generateGranade()
        {
            Granade granade = new Granade();


            granade.setGranadeLocation = new Point(random1.Next(LOWEST_BOUND_X, HIGHEST_BOUND_X), random1.Next(LOWEST_BOUND_Y, HIGHEST_BOUND_Y));
            granade.getGranade.Image = Properties.Resources.granadePlayer;
            granade.setsize = new Size(30, 30);
            granade.getPrepared();
            canvas.Controls.Add(granade.getGranade);
            weapons.Add(granade.getGranade);
            weaponNames.Add(Granade.NAME);
        }

        private void generateMorter()
        {
            Morter morter = new Morter();


            morter.Coordinate = new Point(random1.Next(LOWEST_BOUND_X, HIGHEST_BOUND_X), random1.Next(LOWEST_BOUND_Y, HIGHEST_BOUND_Y));
            morter.getMorter.Image = Properties.Resources.morterPlayer1;
            morter.setSize = new Size(30, 30);
            canvas.Controls.Add(morter.getMorter);
            weapons.Add(morter.getMorter);
            weaponNames.Add(Morter.NAME);
        }
        private void generateGun()
        {
            Gun gun = new Gun();

            gun.Coordinate = new Point(random1.Next(LOWEST_BOUND_X, HIGHEST_BOUND_X), random1.Next(LOWEST_BOUND_Y, HIGHEST_BOUND_Y));

            canvas.Controls.Add(gun.getGun);
            weapons.Add(gun.getGun);
            weaponNames.Add(Gun.NAME);
        }

        public void update()
        {
            

            //Removing Remaining Weapons in Display
            for (int i = 0; i < weapons.Count; i++)
            {
                PictureBox temp = (PictureBox)weapons[i];
                canvas.Controls.Remove(temp);

            }
            weapons.Clear();
            weaponNames.Clear();

            //Generating New Weapons
            for (int i = 0; i < 6; i++)
            {
                int num;
                num = random1.Next(1, 4);

                switch (num)
                {
                    case 1: generateGun();
                        break;
                    case 2: generateGranade();
                        break;
                    case 3: generateMorter();
                        break;
                }

            }
        }



        public void chechkIfWeaponTouched(Players player)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                PictureBox temp = (PictureBox)weapons[i];                
                if (GameStatus.isWeaponTouched(weaponNames[i].ToString(), temp, temp.Location, player.isPlayerAtDown))
                {
                    canvas.Controls.Remove(temp);
                    weapons.Remove(weapons[i]);
                    weaponNames.Remove(weaponNames[i]);
                }
            }
        }
    }
}
