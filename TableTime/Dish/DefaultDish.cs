using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TableTime.Product;

namespace TableTime.Dish
{
    public class DefaultDish : IDish<double>
    {
        public DefaultDish() { }
        public DefaultDish(string name) { Name = name; }
        public DefaultDish(params IProduct[] products)
        {
            if (products != null)
            {
                Products = products.ToList();
            }
        }
        public DefaultDish(string name, params IProduct[] products)
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

        public List<IProduct> Products { get; set; } = new List<IProduct>();
        public string Name { get; set; } = "";

        public string DishName()
        {
            string dishName = "";
            foreach(var el in Products)
            {
                dishName += el.Name.Substring(0, 2);
            }
            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;
            return myTI.ToTitleCase(dishName);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
