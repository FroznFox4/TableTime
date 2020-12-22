    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Product;

namespace TableTime.Rules
{
    public interface IRules
    {
        IProduct Сonsumption { get; set; }
    }
}
