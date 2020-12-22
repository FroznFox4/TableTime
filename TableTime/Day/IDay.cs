using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Dish;
using TableTime.Product;
using TableTime.Rules;

namespace TableTime.Day
{
    public interface IDay<T>: IRules, ICloneable
    {
        IRulesWithCustomAdditionals Rules { get; set; }
        List<IDish<T>> Dishes { get; set; }
        int CountDay { get; set; }

        object Clone();
    }
}
