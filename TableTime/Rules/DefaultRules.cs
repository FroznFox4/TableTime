using TableTime.Product;

namespace TableTime.Rules
{
    public class DefaultRules : IRules
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
    }
}
