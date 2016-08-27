using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Shooting_Game
{
    class GameStatus
    {
        public static Players playerAtUp;
        public static Players playerAtDown;
        public static bool gameOver = false;
        public static Form1 canvas;

        public static void update(Players playerUp, Players playerDown)
        {
            playerAtUp = playerUp;
            playerAtDown = playerDown;

            updateLifesAndWeapons();
            checkLife();
        }

        private static void checkLife()
        {
            if(playerAtDown.getLife <= 0)
            {
                canvas.timer1.Stop();
                canvas.timer2.Stop();                
                canvas.gameStatus.Text += "\nPlayer 2 Dead!";
                canvas.gameStatus.Visible = true;
            }
            else if(playerAtUp.getLife <= 0)
            {
                canvas.timer1.Stop();
                canvas.timer2.Stop();
                canvas.gameStatus.Text += "\nPlayer 1 Dead!";
                canvas.gameStatus.Visible = true;
                canvas.playAgain.Visible = true;
                canvas.close.Visible = true;
            }
        }

        private static void updateLifesAndWeapons()
        {
            //player At Down Update
            canvas.playerAtDownLifeLbl.Text = playerAtDown.getLife.ToString();
            canvas.playerAtDownGunLbl.Text = playerAtDown.getGun.ToString();
            canvas.playerAtDownGranadeLbl.Text = playerAtDown.getGranade.ToString();
            canvas.playerAtDownMorterLbl.Text = playerAtDown.getMorter.ToString();

            //Player At Up Update
            canvas.playerAtUpLifeLbl.Text = playerAtUp.getLife.ToString();
            canvas.playerAtUpGunLbl.Text = playerAtUp.getGun.ToString();
            canvas.playerAtUpGranadeLbl.Text = playerAtUp.getGranade.ToString();
            canvas.playerAtUpMorterLbl.Text = playerAtUp.getMorter.ToString();
        }

        //if Player Hitted By Any Items
    
        public static bool isPlayerHited(PictureBox hitter, Point location, bool isPlayerAtdown)
        {
            //Hitter Item Four Corners
            Point hitterLeftUpperCorner = new Point(location.X, location.Y);
            Point hitterRightUpperCorner = new Point(location.X + hitter.Width, location.Y);
            Point hitterLeftDownCorner = new Point(location.X, location.Y + hitter.Height);
            Point hitterRightDownCorner = new Point(location.X + hitter.Width, location.Y + hitter.Height);

            //conditions to check if player at down is hitted
            if (!isPlayerAtdown)
            {

                Point playerLeftUpperCorner = new Point(playerAtDown.PlayerLocation.X, playerAtDown.PlayerLocation.Y);
                Point playerRightUpperCorner = new Point(playerAtDown.PlayerLocation.X + playerAtDown.getPlayerCharacter.Width, playerAtDown.PlayerLocation.Y);
                Point playerLeftDownCorner = new Point(playerAtDown.PlayerLocation.X, playerAtDown.PlayerLocation.Y + playerAtDown.getPlayerCharacter.Height);
                Point playerRightDownCorner = new Point(playerAtDown.PlayerLocation.X + playerAtDown.getPlayerCharacter.Width, playerAtDown.PlayerLocation.Y + playerAtDown.getPlayerCharacter.Height);

                //Hit From Up
                if ((hitterLeftDownCorner.X >= playerLeftDownCorner.X && hitterLeftDownCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftDownCorner.Y >= playerLeftUpperCorner.Y && hitterLeftDownCorner.Y <= playerLeftDownCorner.Y))
                {
                    playerAtDown.getLife -= 5;
                    return true;
                }
                //Hit From Down
                else if ((hitterLeftUpperCorner.X >= playerLeftDownCorner.X && hitterLeftUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftUpperCorner.Y >= playerLeftUpperCorner.Y && hitterLeftUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    playerAtDown.getLife -= 5;
                    return true;
                }
                //Hit From Left
                else if ((hitterRightUpperCorner.X >= playerLeftDownCorner.X && hitterRightUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterRightUpperCorner.Y >= playerLeftUpperCorner.Y && hitterRightUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    playerAtDown.getLife -= 5;
                    return true;
                }
                //Hit From Right
                else if ((hitterLeftUpperCorner.X >= playerLeftDownCorner.X && hitterLeftUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftUpperCorner.Y >= playerLeftUpperCorner.Y && hitterLeftUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    playerAtDown.getLife -= 5;
                    return true;
                }

            }

                //If Player At Up Is Hitted
            else
            {
                Point playerLeftUpperCorner = new Point(playerAtUp.PlayerLocation.X, playerAtUp.PlayerLocation.Y);
                Point playerRightUpperCorner = new Point(playerAtUp.PlayerLocation.X + playerAtUp.getPlayerCharacter.Width, playerAtUp.PlayerLocation.Y);
                Point playerLeftDownCorner = new Point(playerAtUp.PlayerLocation.X, playerAtUp.PlayerLocation.Y + playerAtUp.getPlayerCharacter.Height);
                Point playerRightDownCorner = new Point(playerAtUp.PlayerLocation.X + playerAtUp.getPlayerCharacter.Width, playerAtUp.PlayerLocation.Y + playerAtUp.getPlayerCharacter.Height);

                //Hit From Up
                if ((hitterLeftDownCorner.X >= playerLeftDownCorner.X && hitterLeftDownCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftDownCorner.Y >= playerLeftUpperCorner.Y && hitterLeftDownCorner.Y <= playerLeftDownCorner.Y))
                {
                    playerAtUp.getLife -= 5;
                    return true;
                }
                //Hit From Down
                else if ((hitterLeftUpperCorner.X >= playerLeftDownCorner.X && hitterLeftUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftUpperCorner.Y >= playerLeftUpperCorner.Y && hitterLeftUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    playerAtUp.getLife -= 5;
                    return true;
                }
                //Hit From Left
                else if ((hitterRightUpperCorner.X >= playerLeftDownCorner.X && hitterRightUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterRightUpperCorner.Y >= playerLeftUpperCorner.Y && hitterRightUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    playerAtUp.getLife -= 5;
                    return true;
                }
                //Hit From Right
                else if ((hitterLeftUpperCorner.X >= playerLeftDownCorner.X && hitterLeftUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftUpperCorner.Y >= playerLeftUpperCorner.Y && hitterLeftUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    playerAtUp.getLife -= 5;
                    return true;
                }

            }
            return false;
        }
    
        private static void increseWeapon(Players player, string name)
        {
            if(name == Granade.NAME)
            {
                player.getGranade++;
            }
            else if(name == Gun.NAME)
            {
                player.getGun += 30;
            }
            else if(name == Morter.NAME)
            {
                player.getMorter++;
            }
        }
        public static bool isWeaponTouched(string name, PictureBox weapon, Point location, bool isPlayerAtdown)
        {
            //Hitter Item Four Corners
            Point hitterLeftUpperCorner = new Point(location.X, location.Y);
            Point hitterRightUpperCorner = new Point(location.X + weapon.Width, location.Y);
            Point hitterLeftDownCorner = new Point(location.X, location.Y + weapon.Height);
            Point hitterRightDownCorner = new Point(location.X + weapon.Width, location.Y + weapon.Height);

            //conditions to check if player at down is hitted
            if (isPlayerAtdown)
            {

                Point playerLeftUpperCorner = new Point(playerAtDown.PlayerLocation.X, playerAtDown.PlayerLocation.Y);
                Point playerRightUpperCorner = new Point(playerAtDown.PlayerLocation.X + playerAtDown.getPlayerCharacter.Width, playerAtDown.PlayerLocation.Y);
                Point playerLeftDownCorner = new Point(playerAtDown.PlayerLocation.X, playerAtDown.PlayerLocation.Y + playerAtDown.getPlayerCharacter.Height);
                Point playerRightDownCorner = new Point(playerAtDown.PlayerLocation.X + playerAtDown.getPlayerCharacter.Width, playerAtDown.PlayerLocation.Y + playerAtDown.getPlayerCharacter.Height);

                //Hit From Up
                if ((hitterLeftDownCorner.X >= playerLeftDownCorner.X && hitterLeftDownCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftDownCorner.Y >= playerLeftUpperCorner.Y && hitterLeftDownCorner.Y <= playerLeftDownCorner.Y))
                {
                    increseWeapon(playerAtDown, name);
                    return true;
                }
                //Hit From Down
                else if ((hitterLeftUpperCorner.X >= playerLeftDownCorner.X && hitterLeftUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftUpperCorner.Y >= playerLeftUpperCorner.Y && hitterLeftUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    increseWeapon(playerAtDown, name);
                    return true;
                }
                //Hit From Left
                else if ((hitterRightUpperCorner.X >= playerLeftDownCorner.X && hitterRightUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterRightUpperCorner.Y >= playerLeftUpperCorner.Y && hitterRightUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    increseWeapon(playerAtDown, name);
                    return true;
                }
                //Hit From Right
                else if ((hitterLeftUpperCorner.X >= playerLeftDownCorner.X && hitterLeftUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftUpperCorner.Y >= playerLeftUpperCorner.Y && hitterLeftUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    increseWeapon(playerAtDown, name);
                    return true;
                }

            }

                //If Player At Up Is Hitted
            else
            {
                Point playerLeftUpperCorner = new Point(playerAtUp.PlayerLocation.X, playerAtUp.PlayerLocation.Y);
                Point playerRightUpperCorner = new Point(playerAtUp.PlayerLocation.X + playerAtUp.getPlayerCharacter.Width, playerAtUp.PlayerLocation.Y);
                Point playerLeftDownCorner = new Point(playerAtUp.PlayerLocation.X, playerAtUp.PlayerLocation.Y + playerAtUp.getPlayerCharacter.Height);
                Point playerRightDownCorner = new Point(playerAtUp.PlayerLocation.X + playerAtUp.getPlayerCharacter.Width, playerAtUp.PlayerLocation.Y + playerAtUp.getPlayerCharacter.Height);

                //Hit From Up
                if ((hitterLeftDownCorner.X >= playerLeftDownCorner.X && hitterLeftDownCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftDownCorner.Y >= playerLeftUpperCorner.Y && hitterLeftDownCorner.Y <= playerLeftDownCorner.Y))
                {
                    increseWeapon(playerAtUp, name);
                    return true;
                }
                //Hit From Down
                else if ((hitterLeftUpperCorner.X >= playerLeftDownCorner.X && hitterLeftUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftUpperCorner.Y >= playerLeftUpperCorner.Y && hitterLeftUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    increseWeapon(playerAtUp, name);
                    return true;
                }
                //Hit From Left
                else if ((hitterRightUpperCorner.X >= playerLeftDownCorner.X && hitterRightUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterRightUpperCorner.Y >= playerLeftUpperCorner.Y && hitterRightUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    increseWeapon(playerAtUp, name);
                    return true;
                }
                //Hit From Right
                else if ((hitterLeftUpperCorner.X >= playerLeftDownCorner.X && hitterLeftUpperCorner.X <= playerRightDownCorner.X)
                    && (hitterLeftUpperCorner.Y >= playerLeftUpperCorner.Y && hitterLeftUpperCorner.Y <= playerLeftDownCorner.Y))
                {
                    increseWeapon(playerAtUp, name);
                    return true;
                }

            }
            return false;
        }
    }

}
