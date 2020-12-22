using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Day;

namespace TableTime.Week
{
    public interface IWeek<T>: ICloneable
    {
        MyDictionary<string, IDay<T>> DayOfWeek { get; set; }
        object Clone();
    }
}
