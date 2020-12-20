using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Product;

namespace TableTime.Dish
{
    public interface IDish<T>
    {
        string Name { get; set; }
        List<ICustomProduct<T>> Products { get; set; }
        IProduct ConvertToProduct();
    }
}
