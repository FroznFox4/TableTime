using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Product;
using TableTime.Rules;

namespace TableTime.Rules
{
    public class DefaultRules : IRulesWithCustomAdditionals
    {

        public IProduct Сonsumption { get; set; }

        public DefaultRules()
        {
            Сonsumption = new DefaultProduct
            {
                Name = "Сonsumption",
                Carb = 0,
                Fats = 0,
                Kkal = 1000,
                Mass = 0,
                Protein = 0
            };
        }


        public double Coef<T>(params T[] coef)
        {
            try 
            {
                var tempList = new List<double>();
                foreach (var el in coef)
                    tempList.Add(Convert.ToDouble(coef));
                return tempList.Average();
            }
            catch
            {
                Console.WriteLine(string.Format("WARNIN: Type for this rules is invalid"));
                var tempList = new List<int>();
                foreach (var el in coef)
                    tempList.Add(el.ToString().GetHashCode());
                return tempList.Average();
            }
        }
    }
}
