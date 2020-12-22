using System;
using System.Collections.Generic;
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
