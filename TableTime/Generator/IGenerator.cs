using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Day;
using TableTime.Dish;
using TableTime.Week;

namespace TableTime.Generator
{
    public interface IGenerator<Dish, Day, Week>
    {
        Dish GenerateDish();
        Day GenerateDay();
        Week GenerateWeek();
    }
}
