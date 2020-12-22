using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Product;

namespace TableTime.DB
{
    public abstract class AbsDb<T>: IDB<string, IProduct, T>
    {
        protected abstract Dictionary<string, IProduct> Db { get; set; }

        abstract public void FillDb(string fileName = "Products.txt");

        abstract public IProduct[] Get(string key);

        abstract public IProduct[] GetAll();

        abstract public T Set(string key, IProduct value);

        abstract public T Update(string key, IProduct newValue);

        abstract public IProduct GetForNumber(int number);
    }
}
