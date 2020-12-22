using System;
using System.Windows.Forms;
using TableTime.Dish;

namespace TableTime
{
    public partial class DishForm : Form
    {
        private string Format = "Продукт: {0}  Ккал {1}, Белки {2}, Жиры {3}, Углеводы {4}, Масса {5}" + Environment.NewLine;

        public IDish<double> Dish { get; set; }
        public DishForm()
        {
            Dish = new DefaultDish();
            InitializeComponent();
        }

        public DishForm(IDish<double> dish)
        {
            Dish = dish;
            InitializeComponent();
            showDish();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDish()
        {
            textBox1.Text = "";
            textBox1.Text += string.Format("Блюдо: {0}" + Environment.NewLine, Dish.Name);
            foreach(var el in Dish.Products)
            {
                textBox1.Text += string.Format(Format, el.Name, el.Kkal, el.Protein, el.Fats, el.Carb, el.Mass);
            }
        }
    }
}
