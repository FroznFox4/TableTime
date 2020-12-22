using System;
using System.Windows.Forms;
using TableTime.Generator;
using TableTime.Week;

namespace TableTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DefaultAbsGenerator<double> generator = new DefaultGenerator();
            IWeek<double> week = generator.GenerateWeek();
            Form weekForm = new WeekForm(week);
            weekForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
