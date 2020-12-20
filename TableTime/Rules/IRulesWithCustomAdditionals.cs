using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTime.Rules
{
    public interface IRulesWithCustomAdditionals : IRules
    {
        double Coef<T>(params T[] param);
    }
}
