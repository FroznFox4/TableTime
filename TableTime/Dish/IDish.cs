using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Product;

namespace TableTime.Dish
{
    public interface IDish<T>: ICloneable
    {
        string Name { get; set; }
        List<IProduct> Products { get; set; }
        string DishName();
        object Clone();
    }
}
