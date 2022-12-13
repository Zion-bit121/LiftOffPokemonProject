namespace LiftOffProjectBattleSimulator_Pokemon_Sim_
{
    public partial class Form1 : Form
    {
        private readonly int charSelected;
        Character player;
        Character enemy;
        Character bulbasaur = new Character("Bulbasaur", "Grass", 1, 100, 20, 40);
        Character charmander = new Character("Charmander", "Fire", 2, 100, 35, 25);
        Character squirtle = new Character("Squirtle", "Water", 3, 100, 30, 30);


        public Form1(int choice)
        {
            InitializeComponent();
            charSelected = choice;
        }
        //Player Name Label.
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Player side Panel.
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //Takes player selection and applies to battle.
            if (charSelected == 1)
            {
                player = bulbasaur;
                enemy = squirtle;
                pictureBox1.Image = Properties.Resources.bulbasaur__1_;
                pictureBox2.Image = Properties.Resources.squirtle;
            }
            else if (charSelected == 2)
            {
                player = squirtle;
                enemy = charmander;
                pictureBox1.Image = Properties.Resources.squirtle__1_;
                pictureBox2.Image = Properties.Resources.charmander;
            }
            else if (charSelected == 3)
            {
                player = charmander;
                enemy = bulbasaur;
                pictureBox1.Image = Properties.Resources.charmander__1_;
                pictureBox2.Image = Properties.Resources.bulbasaur;
            }

            //Sets player tags.
            PBHpBar.Maximum = Convert.ToInt32(player.hp);
            PBHpBar.Value = PBHpBar.Maximum;
            label1.Text = player.name;

            //Sets enemy tags.
            PBEnemyHpBar.Maximum = Convert.ToInt32(enemy.hp);
            PBEnemyHpBar.Value = PBEnemyHpBar.Maximum;
            label2.Text = enemy.name;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Attack1_Click(object sender, EventArgs e)
        {
            enemy.TakeDamage(10, 20, player.atk, player.type);
            if (enemy.hp > 0)
            {
                PBEnemyHpBar.Value = Convert.ToInt32(enemy.hp);
            }
            else
            {
                PBEnemyHpBar.Value = 0;
            }
            _ = timer1.Enabled == true;
            _ = Attack1.Enabled == false;
            _ = Attack2.Enabled == false;
            _ = button1.Enabled == false;
            _ = Exit.Enabled == false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            enemy.TakeDamage(20, 50, player.atk, player.type);
            if (enemy.hp > 0)
            {
                PBEnemyHpBar.Value = Convert.ToInt32(enemy.hp);
            }
            else
            {
                PBEnemyHpBar.Value = 0;
            }
            _ = timer1.Enabled == true;
            _ = Attack1.Enabled == false;
            _ = Attack2.Enabled == false;
            _ = button1.Enabled == false;
            _ = Exit.Enabled == false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ = timer1.Enabled == false;
            player.TakeDamage(10, 20, enemy.atk, enemy.type);
            if (player.hp > 0)
            {
                PBHpBar.Value = Convert.ToInt32(player.hp);
            }
            else
            {
                PBHpBar.Value = 0;
            }
            _ = Attack1.Enabled == true;
            _ = Attack2.Enabled == true;
            _ = button1.Enabled == true;
            _ = Exit.Enabled == true;
        }


    }

    public class Character
    {
        //Variables
        public string name;
        public string type;
        public int charNum;
        public double hp;
        public double atk;
        public double def;

        //Constructors
        public Character()
        {
            name = string.Empty;
            type = string.Empty;
            charNum = 0;
            hp = 0;
            atk = 0;
            def = 0;
        }

        public Character(string Name, string Type, int CharNum, double HP, double Atk, double Def)
        {
            name = Name;
            type = Type;
            charNum = CharNum;
            hp = HP;
            atk = Atk;
            def = Def;
        }

        public void TakeDamage(int damage, int accuracy, double enAtk, string enType)
        {
            Random rnd = new Random();
            int roll = rnd.Next(1, 101);
            double critMod = 1;
            double typeMod = 1;


            if (roll <= accuracy)
            {
                if (roll <= 5)
                {
                    critMod = 1.5;
                }

                // In future incorperate type matchups through character class.
                if ((type == "Grass" && enType == "Fire")
                    || (type == "Water" && enType == "Grass")
                    || (type == "Fire" && enType == "Water"))
                {
                    typeMod = 0.8;
                }
                else if ((type == "Grass" && enType == "Water")
                    || (type == "Water" && enType == "Fire")
                    || (type == "Fire" && enType == "Grass"))
                {
                    typeMod = 1.2;
                }
                hp -= (enAtk / def) * damage * critMod * typeMod;
            }

        }
    }

}