using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Product;

namespace TableTime.Dish
{
    public class DefaultDish : IDish<double>
    {
        public DefaultDish() { }
        public DefaultDish(string name) { Name = name; }
        public DefaultDish(params ICustomProduct<double>[] products)
        {
            if (products != null)
            {
                Products = products.ToList();
            }
        }
        public DefaultDish(string name, params ICustomProduct<double>[] products)
        {
            if (products != null)
            {
                Products = products.ToList();
                Name = name;
            }
            else
            {
                Name = name;
            }
        }

        public List<ICustomProduct<double>> Products { get; set; } = new List<ICustomProduct<double>>();
        public string Name { get; set; } = "";

        public IProduct ConvertToProduct()
        {
            IProduct dish = new DefaultProduct();
            foreach(var el in Products)
            {
                dish.Carb += el.Carb;
                dish.Fats += el.Fats;
                dish.Kkal += el.Kkal;
                dish.Mass += el.Mass;
                dish.Protein += el.Protein;
                dish.Name = Name;
            }
            return dish;
        }
    }
}
