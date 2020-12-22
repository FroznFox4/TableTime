using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Product;

namespace TableTime.DB
{
    public class DefaultDB : DefaultAbsDb
    {
        public DefaultDB(string fileName = "Products.txt") { FillDb(fileName); }

        protected override Dictionary<string, IProduct> Db { get; set; } = new Dictionary<string, IProduct>();

        public override int CountKeys() => Db.Count;

        public override void FillDb(string fileName)
        {
            using (StreamReader sr = new StreamReader(Path.GetFullPath(fileName), System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Replace("\t", " ");
                    line = line.Replace(".", ",");
                    List<string> simpleLine = line.Split(' ').ToList();
                    IProduct product = new DefaultProduct()
                    {
                        Name = simpleLine[0],
                        Kkal = Convert.ToDouble(simpleLine[2]),
                        Protein = Convert.ToDouble(simpleLine[5]),
                        Fats = Convert.ToDouble(simpleLine[8]),
                        Carb = Convert.ToDouble(simpleLine[11]),
                        Mass = 100.0
                    };
                    Set(product.Name, product);
                }
            }
        }

        public override IProduct[] Get(string key)
        {
            if (Db.ContainsKey(key) == true)
            {
                return new List<IProduct>() { Db[key] }.ToArray();
            }
            return new List<IProduct>() { }.ToArray();
        }

        public override IProduct[] GetAll()
        {
            return Db.Values.ToArray();
        }

        public override IProduct GetForNumber(int number)
        {
            return GetAll()[number];
        }

        public override DefaultDB Set(string key, IProduct value)
        {
            Db.Add(key, value);
            return this;
        }

        public override DefaultDB Update(string key, IProduct newValue)
        {
            Db[key] = newValue;
            return this;
        }
    }
}
