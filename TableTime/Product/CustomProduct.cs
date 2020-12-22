using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Rules;

namespace TableTime.Product
{
    public class CustomProduct : ICustomProduct
    {
        public CustomProduct() { }

        public CustomProduct(
            string name, 
            double mass, 
            double kkal, 
            double protein, 
            double fats, 
            double carb)
        {
            Name = name;
            Mass = mass;
            Kkal = kkal;
            Protein = protein;
            Fats = fats;
            Carb = carb;
        }
        public CustomProduct(IProduct product, IRules rules) : this(product.Name, product.Mass, product.Kkal, product.Protein, product.Fats, product.Carb) 
        {
            Rules = rules;
        }

        public CustomProduct(IRules rules)
        {
            Rules = rules;
        }

        public string Name { get; set; } = "";
        public double Mass { get; set; } = 0.0;
        public double Kkal { get; set; } = 0.0;
        public double Protein { get; set; } = 0.0;
        public double Fats { get; set; } = 0.0;
        public double Carb { get; set; } = 0.0;
        public IRules Rules { get; set; } = new DefaultRules();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
