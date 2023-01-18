using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LiftOffProjectBattleSimulator_Pokemon_Sim_
{
    public partial class BattleForm : Form
    {
        private readonly int charSelected;
        Character player;
        Character enemy;
        Character bulbasaur = new Character("Bulbasaur", "Grass", 1, 100, 20, 40, "Tackle", "Vine Whip");
        Character charmander = new Character("Charmander", "Fire", 2, 100, 35, 25, "Tackle", "Ember");
        Character squirtle = new Character("Squirtle", "Water", 3, 100, 30, 30, "Tackle", "Bubble");
        public string effective = "It's Super Effective.";
        public string notEffective = "It's not very Effective.";
        public string crit = "It's a Crital Hit.";
        public string staticText = "";
        public string missedAtk = "";
        public string enMissedAtk = "";

        public BattleForm(int choice)
        {
            InitializeComponent();
            charSelected = choice;
        }

        private void BattleForm_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            // Player selected Bulbasaur
            if (charSelected == 1)
            {
                player = bulbasaur;
                pictureBox2.Image = Properties.Resources.bulbasaur__1_;

                // 1/3 chance for disadvantage in battle
                if (rnd.Next(4) == 3)
                {
                    enemy = charmander;
                    pictureBox1.Image = Properties.Resources.charmander;
                }
                else
                {
                    enemy = squirtle;
                    pictureBox1.Image = Properties.Resources.squirtle;
                }

            }
            // Player selected Squirtle
            else if (charSelected == 2)
            {
                player = squirtle;
                pictureBox2.Image = Properties.Resources.squirtle__1_;

                // 1/3 chance for disadvantage in battle
                if (rnd.Next(4) == 3)
                {
                    enemy = bulbasaur;
                    pictureBox1.Image = Properties.Resources.bulbasaur;
                }
                else
                {
                    enemy = charmander;
                    pictureBox1.Image = Properties.Resources.charmander;
                }

            }
            // Player selected Charmander (best choice) \(>.<)/
            else if (charSelected == 3)
            {
                player = charmander;
                pictureBox2.Image = Properties.Resources.charmander__1_;

                // 1/3 chance for disadvantage in battle
                if (rnd.Next(4) == 3)
                {
                    enemy = squirtle;
                    pictureBox1.Image = Properties.Resources.squirtle;
                }
                else
                {
                    enemy = bulbasaur;
                    pictureBox1.Image = Properties.Resources.bulbasaur;
                }

            }

            //Sets player tags.
            progressBar1.Maximum = Convert.ToInt32(player.hp);
            progressBar1.Value = progressBar1.Maximum;
            label1.Text = player.name;
            button1.Text = player.moves[0];
            button2.Text = player.moves[1];
            button3.Text = "Defense Boost";
            textBox1.Text = $"A wild {enemy.name} appeared.";
            staticText = $"What will {player.name} do next?";
            missedAtk = $"{player.name} missed.";

            //Sets enemy tags.
            progressBar2.Maximum = Convert.ToInt32(enemy.hp);
            progressBar2.Value = progressBar2.Maximum;
            label2.Text = enemy.name;
            enMissedAtk = $"{enemy.name} missed.";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            textBox1.Text = $"{player.name} used {button1.Text}.";

            await Task.Delay(2000);

            enemy.TakeDamage(10, 90, player.atk, "Normal");
            if (enemy.hp > 0)
            {
                progressBar2.Value = Convert.ToInt32(enemy.hp);
            }
            else
            {
                progressBar2.Value = 0;
            }

            // Display info on panel
            if (enemy.critHit == true && enemy.typeAdv == 2)
            {
                textBox1.Text = crit;
                await Task.Delay(2000);
                textBox1.Text = effective;
                await Task.Delay(2000);
            }
            else if (enemy.critHit == true && enemy.typeAdv == 0)
            {
                textBox1.Text = crit;
                await Task.Delay(2000);
                textBox1.Text = notEffective;
                await Task.Delay(2000);
            }
            else if (enemy.typeAdv == 2)
            {
                textBox1.Text = effective;
                await Task.Delay(2000);
            }
            else if (enemy.typeAdv == 0)
            {
                textBox1.Text = notEffective;
                await Task.Delay(2000);
            }
            else if (enemy.hit == false)
            {
                textBox1.Text = missedAtk;
                await Task.Delay(2000);
            }

            await Task.Delay(2000);      // wait 2 second

            textBox1.Text = $"{enemy.name} used {enemy.moves[1]}.";

            await Task.Delay(2000);

            player.TakeDamage(15, 75, enemy.atk, enemy.type);
            if (player.hp > 0)
            {
                progressBar1.Value = Convert.ToInt32(player.hp);
            }
            else
            {
                progressBar1.Value = 0;
            }

            // Display info on panel
            if (player.critHit == true && player.typeAdv == 2)
            {
                textBox1.Text = crit;
                await Task.Delay(2000);
                textBox1.Text = effective;
                await Task.Delay(2000);
            }
            else if (player.critHit == true && player.typeAdv == 0)
            {
                textBox1.Text = crit;
                await Task.Delay(2000);
                textBox1.Text = notEffective;
                await Task.Delay(2000);
            }
            else if (player.typeAdv == 2)
            {
                textBox1.Text = effective;
                await Task.Delay(2000);
            }
            else if (player.typeAdv == 0)
            {
                textBox1.Text = notEffective;
                await Task.Delay(2000);
            }
            else if (player.hit == false)
            {
                textBox1.Text = enMissedAtk;
                await Task.Delay(2000);
            }

            // Checks for battle's end

            if (progressBar1.Value == 0)
            {
                textBox1.Text = $"{player.name} fainted.";

                await Task.Delay(2000);

                textBox1.Text = "You are out of usable Pokemon.";

                await Task.Delay(2000);

                textBox1.Text = $"You ran away to protect {player.name} from harm.";

                await Task.Delay(2000);

                StartForm1 start = new StartForm1();
                this.Hide();
                start.Show();
            }
            else if (progressBar2.Value == 0)
            {
                textBox1.Text = $"{enemy.name} fainted.";

                await Task.Delay(2000);

                textBox1.Text = $"{player.name} defeated {enemy.name}.";

                await Task.Delay(2000);

                textBox1.Text = $"Satisfied with your battle you and {player.name} return home.";

                await Task.Delay(2000);

                StartForm1 start = new StartForm1();
                this.Hide();
                start.Show();
            }

            textBox1.Text = staticText;

            _ = button1.Enabled = true;
            _ = button2.Enabled = true;
            _ = button3.Enabled = true;
            _ = button4.Enabled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            textBox1.Text = $"{player.name} used {button2.Text}.";

            await Task.Delay(2000);

            enemy.TakeDamage(20, 75, player.atk, player.type);
            if (enemy.hp > 0)
            {
                progressBar2.Value = Convert.ToInt32(enemy.hp);
            }
            else
            {
                progressBar2.Value = 0;
            }

            // Display info on panel
            if (enemy.critHit == true && enemy.typeAdv == 2)
            {
                textBox1.Text = crit;
                await Task.Delay(2000);
                textBox1.Text = effective;
                await Task.Delay(2000);
            }
            else if (enemy.critHit == true && enemy.typeAdv == 0)
            {
                textBox1.Text = crit;
                await Task.Delay(2000);
                textBox1.Text = notEffective;
                await Task.Delay(2000);
            }
            else if (enemy.typeAdv == 2)
            {
                textBox1.Text = effective;
                await Task.Delay(2000);
            }
            else if (enemy.typeAdv == 0)
            {
                textBox1.Text = notEffective;
                await Task.Delay(2000);
            }
            else if (enemy.hit == false)
            {
                textBox1.Text = missedAtk;
                await Task.Delay(2000);
            }

            await Task.Delay(2000);      // wait 2 second

            textBox1.Text = $"{enemy.name} used {enemy.moves[1]}.";

            await Task.Delay(2000);

            player.TakeDamage(15, 75, enemy.atk, enemy.type);
            if (player.hp > 0)
            {
                progressBar1.Value = Convert.ToInt32(player.hp);
            }
            else
            {
                progressBar1.Value = 0;
            }

            // Display info on panel
            if (player.critHit == true && player.typeAdv == 2)
            {
                textBox1.Text = crit;
                await Task.Delay(2000);
                textBox1.Text = effective;
                await Task.Delay(2000);
            }
            else if (player.critHit == true && player.typeAdv == 0)
            {
                textBox1.Text = crit;
                await Task.Delay(2000);
                textBox1.Text = notEffective;
                await Task.Delay(2000);
            }
            else if (player.typeAdv == 2)
            {
                textBox1.Text = effective;
                await Task.Delay(2000);
            }
            else if (player.typeAdv == 0)
            {
                textBox1.Text = notEffective;
                await Task.Delay(2000);
            }
            else if (player.hit == false)
            {
                textBox1.Text = enMissedAtk;
                await Task.Delay(2000);
            }

            // Checks for battle's end

            if (progressBar1.Value == 0)
            {
                textBox1.Text = $"{player.name} fainted.";

                await Task.Delay(2000);

                textBox1.Text = "You are out of usable Pokemon.";

                await Task.Delay(2000);

                textBox1.Text = $"You ran away to protect {player.name} from harm.";

                await Task.Delay(2000);

                StartForm1 start = new StartForm1();
                this.Hide();
                start.Show();
            }
            else if (progressBar2.Value == 0)
            {
                textBox1.Text = $"{enemy.name} fainted.";

                await Task.Delay(2000);

                textBox1.Text = $"{player.name} defeated {enemy.name}.";

                await Task.Delay(2000);

                textBox1.Text = $"Satisfied with your battle you and {player.name} return home.";

                await Task.Delay(2000);

                StartForm1 start = new StartForm1();
                this.Hide();
                start.Show();
            }

            textBox1.Text = staticText;

            _ = button1.Enabled = true;
            _ = button2.Enabled = true;
            _ = button3.Enabled = true;
            _ = button4.Enabled = true;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            _ = button1.Enabled = false;
            _ = button2.Enabled = false;
            _ = button3.Enabled = false;
            _ = button4.Enabled = false;

            textBox1.Text = $"{player.name} used a {button3.Text}.";

            await Task.Delay(2000);

            player.def += 50;

            await Task.Delay(2000);      // wait 2 second

            textBox1.Text = $"{enemy.name} used {enemy.moves[1]}.";

            await Task.Delay(2000);

            player.TakeDamage(15, 75, enemy.atk, enemy.type);
            if (player.hp > 0)
            {
                progressBar1.Value = Convert.ToInt32(player.hp);
            }
            else
            {
                progressBar1.Value = 0;
            }

            // Display info on panel
            if (player.critHit == true && player.typeAdv == 2)
            {
                textBox1.Text = crit;
                await Task.Delay(2000);
                textBox1.Text = effective;
            }
            else if (player.critHit == true && player.typeAdv == 0)
            {
                textBox1.Text = crit;
                await Task.Delay(2000);
                textBox1.Text = notEffective;
            }
            else if (player.typeAdv == 2)
            {
                textBox1.Text = effective;
            }
            else if (player.typeAdv == 0)
            {
                textBox1.Text = notEffective;
            }
            else if (player.hit == false)
            {
                textBox1.Text = enMissedAtk;
            }

            // Checks for battle's end

            if (progressBar1.Value == 0)
            {
                textBox1.Text = $"{player.name} fainted.";
                                
                await Task.Delay(2000);

                textBox1.Text = "You are out of usable Pokemon.";

                await Task.Delay(2000);

                textBox1.Text = $"You ran away to protect {player.name} from harm.";

                await Task.Delay(2000);

                StartForm1 start = new StartForm1();
                this.Hide();
                start.Show();
            }
            else if (progressBar2.Value == 0)
            {
                textBox1.Text = $"{enemy.name} fainted.";

                await Task.Delay(2000);

                textBox1.Text = $"{player.name} defeated {enemy.name}.";

                await Task.Delay(2000);

                textBox1.Text = $"Satisfied with your battle you and {player.name} return home.";

                await Task.Delay(2000);

                StartForm1 start = new StartForm1();
                this.Hide();
                start.Show();
            }

            textBox1.Text = staticText;
            
            _ = button1.Enabled = true;
            _ = button2.Enabled = true;
            _ = button3.Enabled = true;
            _ = button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StartForm1 start = new StartForm1();
            this.Hide();
            start.Show();
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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
        public bool hit = false;
        public bool critHit = false;
        public int typeAdv = 1;
        public List<string> moves = new List<string>();

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

        public Character(string Name, string Type, int CharNum, double HP, double Atk, double Def,string Att1,string Att2)
        {
            name = Name;
            type = Type;
            charNum = CharNum;
            hp = HP;
            atk = Atk;
            def = Def;
            moves.Add(Att1);
            moves.Add(Att2);
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
                    critHit = true;
                }

                if ((type == "Grass" && enType == "Fire")
                    || (type == "Water" && enType == "Grass")
                    || (type == "Fire" && enType == "Water"))
                {
                    typeMod = 1.2;
                    typeAdv = 2;
                }
                else if ((type == "Grass" && enType == "Water")
                    || (type == "Water" && enType == "Fire")
                    || (type == "Fire" && enType == "Grass"))
                {
                    typeMod = 0.8;
                    typeAdv = 0;
                }
                else
                {
                    typeMod = 1;
                    typeAdv = 1;
                }

                hp -= (enAtk / def) * damage * critMod * typeMod;
                hit = true;
            }
            else
            {
                hit = false;
            }

        }
    }
}
