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
    public partial class Main_Page : Form
    {
        public Main_Page()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Help obj = new Help();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide();
            obj.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            About obj = new About();
            obj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Page_Load(object sender, EventArgs e)
        {

        }
    }
}
