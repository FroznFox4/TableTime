using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Product;
using TableTime.Rules;

namespace TableTime.Rules
{
    public class DefaultRules : IRules
    {

        public IProduct Сonsumption { get; set; }

        public DefaultRules()
        {
            Сonsumption = new DefaultProduct
            {
                Name = "Сonsumption",
                Carb = 0,
                Fats = 0,
                Kkal = 1000,
                Mass = 0,
                Protein = 0
            };
        }
    }
}
