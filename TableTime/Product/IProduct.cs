using System;

namespace TableTime.Product
{
    public interface IProduct: ICloneable
    {
        string Name { get; set; }
        double Mass { get; set; }
        double Kkal { get; set; }
        double Protein { get; set; }
        double Fats { get; set; }
        double Carb { get; set; }
        object Clone();
    }
}
