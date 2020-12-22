using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Product;

namespace TableTime.DB
{
    public abstract class AbsDb : IDB<string, IProduct, DefaultDB>
    {
        protected abstract Dictionary<string, IProduct> Db { get; set; }

        abstract public void FillDb(string fileName = "Products.txt");

        abstract public IProduct[] Get(string key);

        abstract public IProduct[] GetAll();

        abstract public DefaultDB Set(string key, IProduct value);

        abstract public DefaultDB Update(string key, IProduct newValue);

        abstract public IProduct GetForNumber(int number);

        public abstract int CountKeys();
    }
}
