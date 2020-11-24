using ProjectHomesLocalApp.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHomesLocalApp
{
    public partial class Form1 : Form
    {
        private string userInputOne;
        private string userInputTwo;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userInputOne = "";
            userInputTwo = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            userInputOne = textBox1.Text;
            userInputTwo = textBox2.Text;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 1;

            //create new
            HomesCommander cmder = new HomesCommander(userInputOne, userInputTwo, progressBar1);

            cmder.doProcessing();

            progressBar1.Value = 50;

            richTextBox1.Text = cmder.getResults();
            cmder = null;
            progressBar1.Value = 100;
        }
    }
}
