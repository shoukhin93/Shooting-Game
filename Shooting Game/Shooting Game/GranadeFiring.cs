using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.Media;

namespace Shooting_Game
{
    class GranadeFiring
    {
        private const int movementAmmount = 20;

        private bool isPlayerAtDown;
        private ArrayList granades, splinters;

        Form1 canvas;

        SoundPlayer granadeExplotion;
        SoundPlayer vehicleDamage;

        public Form1 setCanvas
        {
            set { canvas = value; }
        }
        public GranadeFiring(bool isPlayerAtDown)
        {
            this.isPlayerAtDown = isPlayerAtDown;
            granades = new ArrayList();
            splinters = new ArrayList();
            granadeExplotion = new SoundPlayer(Properties.Resources.granadeExplotion1);
            vehicleDamage = new SoundPlayer(Properties.Resources.vehicleDamage);
        }

        public void fireGranade(Granade obj)
        {
            granades.Add(obj);
            canvas.Controls.Add(obj.getGranade);
        }

        //Updates Granade Activity
        public void updateGranades()
        {
            
            for (int i = 0; i < granades.Count; i++)
            {
                Granade temp = (Granade)granades[i];

                //Explotion Time Decreasing
                temp.explotionPoint -= 10;

                if (temp.explotionPoint == 10)
                {
                    temp.explotionMode();
                    granadeExplotion.Play();
                }
                else if (temp.explotionPoint == 0)
                {
                    explode(temp);
                    canvas.Controls.Remove(temp.getGranade);
                    granades.Remove(temp);
                }

                //If Player is At down, Granades Will Move Up
                if (isPlayerAtDown)
                    temp.getGranade.Location = new Point(temp.getGranade.Location.X, temp.getGranade.Location.Y - movementAmmount);
                else
                    temp.getGranade.Location = new Point(temp.getGranade.Location.X, temp.getGranade.Location.Y + movementAmmount);

                
            }

            updateSplinters();
        }

        //update Splinters
        private void updateSplinters()
        {
            for (int i = 0; i < splinters.Count; i++)
            {
                Splinter tempSplinter = (Splinter)splinters[i];

                foreach (object o in tempSplinter.movement)
                {
                    if (o.ToString() == "x++")
                        tempSplinter.getSplinter.Location = new Point(tempSplinter.getSplinter.Location.X + movementAmmount, tempSplinter.getSplinter.Location.Y);
                    else if (o.ToString() == "x--")
                        tempSplinter.getSplinter.Location = new Point(tempSplinter.getSplinter.Location.X - movementAmmount, tempSplinter.getSplinter.Location.Y);
                    else if (o.ToString() == "y++")
                        tempSplinter.getSplinter.Location = new Point(tempSplinter.getSplinter.Location.X, tempSplinter.getSplinter.Location.Y + movementAmmount);
                    else if (o.ToString() == "y--")
                        tempSplinter.getSplinter.Location = new Point(tempSplinter.getSplinter.Location.X, tempSplinter.getSplinter.Location.Y - movementAmmount);

                }
                canvas.Controls.Add(tempSplinter.getSplinter);

                //if player is Hitted By splinters
                if(GameStatus.isPlayerHited(tempSplinter.getSplinter,tempSplinter.getSplinter.Location, isPlayerAtDown))
                {
                    canvas.Controls.Remove(tempSplinter.getSplinter);
                    splinters.Remove(tempSplinter);
                    vehicleDamage.Play();
                }

                tempSplinter.destructionPoint -= 10;

                if(tempSplinter.destructionPoint == 0)
                {
                    canvas.Controls.Remove(tempSplinter.getSplinter);
                    splinters.Remove(tempSplinter);
                }
            }
        }

        private void explode(Granade explodedGranade)
        {
            for (int i = 0; i < 8; i++)
            {
                Splinter splinter = new Splinter();
                splinter.setCoordinate = explodedGranade.getGranade.Location;
                splinter.movement.Add(Splinter.movementProperties[i, 0]);
                splinter.movement.Add(Splinter.movementProperties[i, 1]);

                splinters.Add(splinter);

            }


        }
    }
}
