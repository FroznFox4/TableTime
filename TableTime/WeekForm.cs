using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableTime.Generator;
using TableTime.Week;

namespace TableTime
{
    public partial class WeekForm : Form
    {
        public IWeek<double> Week { get; set; }
        private List<string> NameDays { get; set; } = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public WeekForm()
        {
            Week = new DefaultWeek();
            InitializeComponent();
        }

        public WeekForm(IWeek<double> week)
        {
            Week = week;
            InitializeComponent();
        }

        private void ShowDay(int index)
        {
            Form dayForm = new DayForm(Week.DayOfWeek[NameDays[index]]);
            dayForm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowDay(0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var generator = new DefaultGenerator();
            Week = generator.GenerateWeek();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowDay(1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowDay(2);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowDay(3);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowDay(4);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowDay(5);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowDay(6);

        }
    }
}
