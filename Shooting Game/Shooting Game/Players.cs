using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Shooting_Game
{

    class Players
    {
        private const int MOVEMENT = 20;

        private Form1 mainForm;
        private bool playerAtDown;
        private Point cordinates;
        private Point fireCoordinate;
        private gunFiring gunFiring;
        private GranadeFiring granadeFiring;
        private MorterFiring morterFiring;
        private PictureBox playerCaracter;
        private MovementControl movementControl;

        private int life = 100;
        private int gun = 0;
        private int granade = 0;
        private int morter = 0;

        //Getters Setters
        public int getLife
        {
            get { return life; }
            set { life = value; }
        }
        public int getGun
        {
            get { return gun; }
            set { gun = value; }
        }
        public int getGranade
        {
            get { return granade; }
            set { granade = value; }
        }
        public int getMorter
        {
            get { return morter; }
            set { morter = value; }
        }
        public Point PlayerLocation
        {
            get { return cordinates; }
            set { cordinates = value; }
        }
        public bool isPlayerAtDown
        {
            set { playerAtDown = value; }
            get { return playerAtDown; }
        }
        public PictureBox getPlayerCharacter
        {
            get { return playerCaracter; }
        }
        public int movementAmmount
        {
            get { return MOVEMENT; }
        }

        //Constructor
        public Players(Form1 obj)
        {
            mainForm = obj;
        }

        public void getPlayerReady()
        {
            playerCaracter = new PictureBox();
            playerCaracter.Location = cordinates;
            playerCaracter.SizeMode = PictureBoxSizeMode.StretchImage;
            playerCaracter.Width = 35;
            playerCaracter.Height = 50;

            if (playerAtDown)
                playerCaracter.Image = Properties.Resources.player21;
            else
                playerCaracter.Image = Properties.Resources.player11;

            mainForm.Controls.Add(playerCaracter);

            //ability to fire Bullets
            gunFiring = new gunFiring(playerAtDown);
            gunFiring.mainForm = mainForm;

            //Ability to throw granades
            granadeFiring = new GranadeFiring(playerAtDown);
            granadeFiring.setCanvas = mainForm;

            //Ability to fire Morter
            morterFiring = new MorterFiring(playerAtDown);
            morterFiring.setCanvas = mainForm;

            //Setting Player's fire Coordinate
            fireCoordinate = new Point(cordinates.X + (playerCaracter.Width / 2), cordinates.Y + (playerCaracter.Height / 2));

            //Player Movement Control
            movementControl = new MovementControl(this);

        }
        public void moveLeft()
        {
            if (movementControl.availableLeftMove())
            {
                cordinates.X -= MOVEMENT;
                playerCaracter.Location = cordinates;
            }
            
        }
        public void moveRight()
        {
            if (movementControl.availableRightMove())
            {
                cordinates.X += MOVEMENT;
                playerCaracter.Location = cordinates;
            }
            
        }

        public bool availableGun()
        {
            if (gun > 0)
                return true;
            return false;
        }
        public bool availableGranade()
        {
            if (granade > 0)
                return true;
            return false;
        }
        public bool availableMorter()
        {
            if (morter > 0)
                return true;
            return false;
        }

        public void moveUp()
        {
            if (movementControl.availaveUpMove())
            {
                cordinates.Y -= MOVEMENT;
                playerCaracter.Location = cordinates;
            }
            
        }
        public void moveDown()
        {
            if (movementControl.availableDownMove())
            {
                cordinates.Y += MOVEMENT;
                playerCaracter.Location = cordinates;
            }
            
        }

        public void update()
        {
            firingUpdate();
            // statusUpdate();
        }

        public void fireGranade()
        {
            Granade granade = new Granade();
            fireCoordinate = new Point(cordinates.X + ((playerCaracter.Width / 2) - (granade.getGranade.Width / 2)), cordinates.Y + ((playerCaracter.Height / 2) - (granade.getGranade.Height / 2))); //coordinate to fire from player
            granade.setGranadeLocation = fireCoordinate;
            granade.getPrepared();
            granadeFiring.fireGranade(granade);

            getGranade--;
        }

        public void fireGun()
        {

            Bullets bullets = new Bullets();
            fireCoordinate = new Point(cordinates.X + ((playerCaracter.Width / 2) - (bullets.getBullets.Width / 2)), cordinates.Y + ((playerCaracter.Height / 2) - (bullets.getBullets.Height / 2))); //coordinate to fire from player
            bullets.setBulletLocation = fireCoordinate;
            gunFiring.addBullets(bullets.getBullets);

            getGun--;
        }

       

        public void fireMorter()
        {
            Morter morter = new Morter();
            fireCoordinate = new Point(cordinates.X + ((playerCaracter.Width / 2) - (morter.getMorter.Width / 2)), cordinates.Y + ((playerCaracter.Height / 2) - (morter.getMorter.Height / 2))); //coordinate to fire from player
            morter.Coordinate = fireCoordinate;
            morterFiring.fireMorter(morter);

            getMorter--;

        }

        private void firingUpdate()
        {
            //updating fire Coordinate
            fireCoordinate = new Point(cordinates.X + (playerCaracter.Width / 2), cordinates.Y + (playerCaracter.Height / 2));

            //updating fire elements
            gunFiring.updateBullets();
            granadeFiring.updateGranades();
            morterFiring.updateMorters();


        }
    }
}
