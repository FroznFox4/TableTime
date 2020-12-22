using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Day;

namespace TableTime.Week
{
    public class DefaultWeek : IWeek<double>
    {
        public DefaultWeek() 
        {
            DayOfWeek = new MyDictionary<string, IDay<double>>();
        }

        private MyDictionary<string, IDay<double>> dayOfWeek;
        public MyDictionary<string, IDay<double>> DayOfWeek
        {
            get
            {
                return dayOfWeek;
            }
            set
            {
                dayOfWeek = value;
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
