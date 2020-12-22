using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTime.DB
{
    abstract public class DefaultAbsDb: AbsDb<DefaultDB> 
    {
        
        public abstract int CountKeys();
    }
}
