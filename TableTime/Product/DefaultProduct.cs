using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Product;

namespace TableTime.Product
{


    public class DefaultProduct : IProduct
    {
        public DefaultProduct()
        {
            Name = "";
            Mass = 0.0;
            Kkal = 0.0;
            Protein = 0.0;
            Fats = 0.0;
            Carb = 0.0;
        }

        public DefaultProduct(string name, double mass, double kkal, double protein, double fats, double carb)
        {
            Name = name;
            Mass = mass;
            Kkal = kkal;
            Protein = protein;
            Fats = fats;
            Carb = carb;
        }

        public string Name { get; set; }
        public double Mass { get; set; }
        public double Kkal { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carb { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
