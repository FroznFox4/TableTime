using System;
using System.Windows.Forms;
using TableTime.Day;

namespace TableTime
{
    public partial class DayForm : Form
    {
        public IDay<double> Day { get; set; }
        public DayForm()
        {
            Day = new DefaultDay();
            InitializeComponent();
        }
        public DayForm(IDay<double> day)
        {
            Day = day;
            InitializeComponent();
        }
        
        private void ShowDish(int index)
        {
            Form dishForm = new DishForm(Day.Dishes[index]);
            dishForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowDish(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowDish(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowDish(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowDish(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowDish(3);
        }
    }
}
