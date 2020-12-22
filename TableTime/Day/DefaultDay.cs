using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Dish;
using TableTime.Product;
using TableTime.Rules;

namespace TableTime.Day
{
    public class DefaultDay : IDay<double>
    {
        public List<IDish<double>> Dishes { get; set; } = new List<IDish<double>>();

        private IProduct consumption;
        public IProduct Сonsumption
        {
            get
            {
                return consumption;
            }
            set
            {
                consumption = value;
            }
        }

        public DefaultDay() { }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
