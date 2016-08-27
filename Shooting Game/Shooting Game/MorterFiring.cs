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
    class MorterFiring
    {
        private bool isPlayerAtDown;
        private ArrayList morters, splinters;

        private const int MOVE_AMMOUNT = 15;

        private Form1 canvas;

        SoundPlayer morterExplotion;
        SoundPlayer vehicleDamage;

        public Form1 setCanvas
        {
            set { canvas = value; }
        }
        public MorterFiring(bool isPlayerAtDown)
        {
            this.isPlayerAtDown = isPlayerAtDown;
            morters = new ArrayList();
            splinters = new ArrayList();
            morterExplotion = new SoundPlayer(Properties.Resources.morterExplotion2);
            vehicleDamage = new SoundPlayer(Properties.Resources.vehicleDamage);
        }

        public void fireMorter(Morter obj)
        {
            morters.Add(obj);
            canvas.Controls.Add(obj.getMorter);
        }

        public void updateMorters()
        {
            for (int i = 0; i < morters.Count; i++)
            {
                Morter tempMorter = (Morter)morters[i];

                tempMorter.explotionTime -= 10;

                if (tempMorter.explotionTime == 10)
                {
                    //Before Explotion Exploded Image Will be Shown
                    morterExplotion.Play();

                    tempMorter.explotion();

                    //expanding The Morters Into A Vast Area
                    Morter morter = new Morter();
                    morter.Coordinate = new Point(tempMorter.getMorter.Location.X - 70, tempMorter.getMorter.Location.Y);
                    morter.explotionTime = tempMorter.explotionTime;
                    morter.explotion();
                    fireMorter(morter);

                    morter = new Morter();
                    morter.Coordinate = new Point(tempMorter.getMorter.Location.X + 70, tempMorter.getMorter.Location.Y);
                    morter.explotionTime = tempMorter.explotionTime;
                    morter.explotion();
                    fireMorter(morter);
                }
                else if (tempMorter.explotionTime == 0)
                {
                    //tempMorter.explotion();
                    explode(tempMorter);
                    canvas.Controls.Remove(tempMorter.getMorter);
                    morters.Remove(tempMorter);
                }


                //If Player Is At Down, Morters Will Go Up
                if (isPlayerAtDown)
                    tempMorter.getMorter.Location = new Point(tempMorter.getMorter.Location.X, tempMorter.getMorter.Location.Y - MOVE_AMMOUNT);
                else
                    tempMorter.getMorter.Location = new Point(tempMorter.getMorter.Location.X, tempMorter.getMorter.Location.Y + MOVE_AMMOUNT);

                //if player is Hitted By Morters
                if(GameStatus.isPlayerHited(tempMorter.getMorter, tempMorter.getMorter.Location, isPlayerAtDown))
                {
                    explode(tempMorter);
                    canvas.Controls.Remove(tempMorter.getMorter);
                    morters.Remove(tempMorter);
                    vehicleDamage.Play();
                }

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
                        tempSplinter.getSplinter.Location = new Point(tempSplinter.getSplinter.Location.X + MOVE_AMMOUNT, tempSplinter.getSplinter.Location.Y);
                    else if (o.ToString() == "x--")
                        tempSplinter.getSplinter.Location = new Point(tempSplinter.getSplinter.Location.X - MOVE_AMMOUNT, tempSplinter.getSplinter.Location.Y);
                    else if (o.ToString() == "y++")
                        tempSplinter.getSplinter.Location = new Point(tempSplinter.getSplinter.Location.X, tempSplinter.getSplinter.Location.Y + MOVE_AMMOUNT);
                    else if (o.ToString() == "y--")
                        tempSplinter.getSplinter.Location = new Point(tempSplinter.getSplinter.Location.X, tempSplinter.getSplinter.Location.Y - MOVE_AMMOUNT);

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

                if (tempSplinter.destructionPoint == 0)
                {
                    canvas.Controls.Remove(tempSplinter.getSplinter);
                    splinters.Remove(tempSplinter);
                }
            }
        }

        private void explode(Morter tempMorter)
        {
            int i, j;

            if (isPlayerAtDown)
            { i = 0; j = 3; }
            else
            {
                i = 5; j = 8;
            }

            for ( ; i < j; i++)
            {
                Splinter splinter = new Splinter();
                splinter.setCoordinate = tempMorter.getMorter.Location;
                splinter.movement.Add(Splinter.movementProperties[i, 0]);
                splinter.movement.Add(Splinter.movementProperties[i, 1]);
                splinter.destructionPoint = 100;

                splinters.Add(splinter);

            }
        }
    }
}
