using TableTime.Day;
using TableTime.Dish;
using TableTime.Week;

namespace TableTime.Generator
{
    public interface IGenerator<T, Dish, Day, Week> 
        where Dish: IDish<T> 
        where Day: IDay<T>
        where Week: IWeek<T>
    {
        Dish GenerateDish();
        Day GenerateDay();
        Week GenerateWeek();
    }
}
