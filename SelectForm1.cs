namespace LiftOffProjectBattleSimulator_Pokemon_Sim_
{
    public partial class SelectForm1 : Form
    {
        int charSelected = 0;
        public SelectForm1()
        {
            InitializeComponent();
        }

        // Bulbasaur image
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CharChanged(1);
        }

        // Squirtle image
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CharChanged(2);
        }

        // Charmander image (the greatest pokemon of all time)
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CharChanged(3);
        }

        // Selection box color changing
        public void CharChanged(int newChar)
        {
            charSelected = newChar;
            if (charSelected == 1) //Bulbasaur selected
            {
                pictureBox1.BackColor = Color.LightGreen;
                pictureBox2.BackColor = Color.White;
                pictureBox3.BackColor = Color.White;
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                pictureBox2.BorderStyle = BorderStyle.FixedSingle;
                pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (charSelected == 2) //Squirtle selected
            {
                pictureBox2.BackColor = Color.LightBlue;
                pictureBox3.BackColor = Color.White;
                pictureBox1.BackColor = Color.White;
                pictureBox2.BorderStyle = BorderStyle.Fixed3D;
                pictureBox3.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (charSelected == 3) // Charmander selected (the best choice)
            {
                pictureBox3.BackColor = Color.LightCoral;
                pictureBox1.BackColor = Color.White;
                pictureBox2.BackColor = Color.White;
                pictureBox3.BorderStyle = BorderStyle.Fixed3D;
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                pictureBox2.BorderStyle = BorderStyle.FixedSingle;

            }
        }

        private void SelectForm1_Load(object sender, EventArgs e)
        {

        }

        // Start button.
        private void button1_Click(object sender, EventArgs e)
        {
            if (charSelected == 0)
            {
                MessageBox.Show("Please choose your pokemon before starting the battle.");
            }
            else
            {
                Form1 battle;
                this.Hide();
                battle = new(charSelected);
                battle.Show();
            }
        }
    }
}
