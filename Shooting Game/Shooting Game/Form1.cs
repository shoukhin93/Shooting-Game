using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooting_Game
{
    public partial class Form1 : Form
    {
        private const int PLAYER_1_INITIAL_X = 340;
        private const int PLAYER_1_INITIAL_Y = 0;
        private const int PLAYER_2_INITIAL_X = 340;
        private const int PLAYER_2_INITIAL_Y = 420;

        Players player1, player2;
        Weapons playerWeapons;

        private static bool closingFlag;
        public Form1()
        {
            InitializeComponent();
            initialize();
            test();
        }

        private void test()
        {

        }




        private void initialize()
        {
            player1 = new Players(this);
            player1.isPlayerAtDown = false;
            player1.PlayerLocation = new Point(PLAYER_1_INITIAL_X, PLAYER_1_INITIAL_Y);
            player1.getPlayerReady();
            GameStatus.playerAtUp = player1;


            player2 = new Players(this);
            player2.isPlayerAtDown = true;
            player2.PlayerLocation = new Point(PLAYER_2_INITIAL_X, PLAYER_2_INITIAL_Y);
            player2.getPlayerReady();
            GameStatus.playerAtDown = player2;

            GameStatus.canvas = this;

            playerWeapons = new Weapons(this);
            playerWeapons.update();

            //label
            gameStatus.Visible = false;
            playAgain.Visible = false;
            close.Visible = false;

            closingFlag = false;
        }



        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKeys(e);
        }

        private void pressedKeys(KeyEventArgs e)
        {
            //Player 2 Control
            if (e.KeyCode == Keys.Right)
            {
                player2.moveRight();
            }
            else if (e.KeyCode == Keys.Left)
            {
                player2.moveLeft();
            }
            else if (e.KeyCode == Keys.Up)
            {
                player2.moveUp();
            }
            else if (e.KeyCode == Keys.Down)
            {
                player2.moveDown();
            }
            else if (e.KeyCode == Keys.NumPad0)
            {
                if (player2.availableGun())
                player2.fireGun();
            }
            else if (e.KeyCode == Keys.NumPad1)
            {
                if (player2.availableGranade())
                player2.fireGranade();
            }
            else if (e.KeyCode == Keys.NumPad2)
            {
                if (player2.availableMorter())
                player2.fireMorter();
            }

            //Player 1 Control
            if (e.KeyCode == Keys.D)
            {
                player1.moveRight();
            }
            else if (e.KeyCode == Keys.A)
            {
                player1.moveLeft();
            }
            else if (e.KeyCode == Keys.W)
            {
                player1.moveUp();
            }
            else if (e.KeyCode == Keys.S)
            {
                player1.moveDown();
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (player1.availableGun())
                player1.fireGun();
            }
            else if (e.KeyCode == Keys.G)
            {
                if (player1.availableGranade())
                player1.fireGranade();
            }
            else if (e.KeyCode == Keys.F)
            {
                if (player1.availableMorter())
                player1.fireMorter();
            }
        }

        int counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            player1.update();
            player2.update();
            GameStatus.update(player1, player2);

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void timer2_Tick(object sender, EventArgs e)
        {
            playerWeapons.chechkIfWeaponTouched(player1);
            playerWeapons.chechkIfWeaponTouched(player2);

            counter++;
            if (counter % 60 == 0)
            {
                playerWeapons.update();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            closingFlag = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide(); 
            obj.ShowDialog();
            this.Close();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closingFlag == true)
                Application.Exit();
            else
            {

                if ((MessageBox.Show("Do U Really Want To Quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == DialogResult.Yes)
                {
                    closingFlag = true;
                    Application.Exit();
                }
                else
                    e.Cancel = true;
            }
        }
    }
}
