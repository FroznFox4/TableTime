using System;
using System.Collections.Generic;
using TableTime.Day;

namespace TableTime.Week
{
    public interface IWeek<T>: ICloneable
    {
        Dictionary<string, IDay<T>> DayOfWeek { get; set; }
        object Clone();
    }
}
