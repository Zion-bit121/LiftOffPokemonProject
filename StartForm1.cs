namespace LiftOffProjectBattleSimulator_Pokemon_Sim_
{
    public partial class StartForm1 : Form
    {
        public StartForm1()
        {
            InitializeComponent();
        }
        //Exit Button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Start Button
        private void button1_Click(object sender, EventArgs e)
        {
            SelectForm1 select = new SelectForm1();
            this.Hide();
            select.Show();
        }

        private void StartForm1_Load(object sender, EventArgs e)
        {

        }
    }
}
