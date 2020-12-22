using TableTime.Day;
using TableTime.Dish;
using TableTime.Week;

namespace TableTime.Generator
{
    public abstract class DefaultAbsGenerator<T> : IGenerator<T, IDish<T>, IDay<T>, IWeek<T>>
    {
        public abstract IDay<T> GenerateDay();
        public abstract IDish<T> GenerateDish();
        public abstract IWeek<T> GenerateWeek();
    }
}
