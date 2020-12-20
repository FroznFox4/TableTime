using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTime.Product
{
    public interface IProduct
    {
        string Name { get; set; }
        double Mass { get; set; }
        double Kkal { get; set; }
        double Protein { get; set; }
        double Fats { get; set; }
        double Carb { get; set; }
    }
}
