using System.Collections.Generic;
using TableTime.Day;

namespace TableTime.Week
{
    public class DefaultWeek : IWeek<double>
    {
        public DefaultWeek() { }
        public DefaultWeek(Dictionary<string, IDay<double>> dayOfWeek)
        {
            DayOfWeek = dayOfWeek;
        }
        public Dictionary<string, IDay<double>> DayOfWeek { get; set; } = new MyDictionary<string, IDay<double>>();
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
