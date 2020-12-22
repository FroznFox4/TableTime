﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Rules;

namespace TableTime.Product
{
    public interface ICustomProduct: IProduct
    {
        IRules Rules { get; set; }
    }
}
