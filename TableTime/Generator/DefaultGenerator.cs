using System;
using System.Collections.Generic;
using System.Linq;
using TableTime.Day;
using TableTime.DB;
using TableTime.Dish;
using TableTime.Product;
using TableTime.Rules;
using TableTime.Week;

namespace TableTime.Generator
{
    public class DefaultGenerator : DefaultAbsGenerator<double>
    {
        private AbsDb db = new DefaultDB();
        private void SetDb(AbsDb value)
        {
            value.FillDb();
        }
        private IRules Rules { get; set; } = new DefaultRules();
        private Random random { get; set; } = new Random();
        private IProduct product { get; set; } = new DefaultProduct();
        private IDish<double> Dish { get; set; } = new DefaultDish();
        private IDay<double> Day { get; set; } = new DefaultDay();
        private IWeek<double> Week { get; set; } = new DefaultWeek();
        public DefaultGenerator() { }
        public DefaultGenerator(AbsDb db)
        {
            SetDb(db);
        }
        public DefaultGenerator(IRules rules)
        {
            Rules = rules;
        }
        public DefaultGenerator(AbsDb db, IRules rules)
        {
            SetDb(db);
            Rules = rules;
        }
        public DefaultGenerator(IProduct product)
        {
            this.product = product;
        }
        public DefaultGenerator(AbsDb db, IRules rules, Random random, IProduct product) : this(db, rules)
        {
            this.random = random;
            this.product = product;
        }
        public DefaultGenerator(IRules rules, Random random) : this(rules)
        {
            this.random = random;
        }
        public DefaultGenerator(IRules rules, Random random, IProduct product) : this(rules, random)
        {
            this.product = product;
        }
        private IProduct RewriteProduct(IProduct newProduct)
        {
            IProduct curProduct = (IProduct)product.Clone();
            curProduct.Name = newProduct.Name;
            curProduct.Fats = newProduct.Fats;
            curProduct.Kkal = newProduct.Kkal;
            curProduct.Carb = newProduct.Carb;
            curProduct.Protein = newProduct.Protein;
            curProduct.Mass = newProduct.Mass;
            return curProduct;
        }
        private IDish<double> ClearDish(IDish<double> dish)
        {
            var newDish = (IDish<double>) dish.Clone();
            newDish.Name = "";
            newDish.Products.Clear();
            return newDish;
        }
        public override IDish<double> GenerateDish()
        {
            int maxValueOfProducts = db.CountKeys();
            int countProducts = 0;
            if (maxValueOfProducts > 7)
                countProducts = random.Next(5, 7);
            else if (maxValueOfProducts > 5)
                countProducts = random.Next(5, maxValueOfProducts);
            else 
                throw new Exception("Insufficient data in the database");
            IDish<double> finalDish = Dish;
            finalDish = ClearDish(finalDish);
            for(var i = 0; i < countProducts; i++)
            {
                int productNumber = random.Next(0, maxValueOfProducts);
                IProduct curProduct = RewriteProduct(db.GetForNumber(productNumber));
                if (curProduct.Kkal + finalDish.Products.Sum( x=> x.Kkal) <= Rules.Сonsumption.Kkal)
                {
                    finalDish.Products.Add(curProduct);
                }
            }
            var coef = finalDish.Products.Sum( x => x.Kkal);
            if (coef < Rules.Сonsumption.Kkal)
            {
                List<IProduct> tempList = new List<IProduct>();
                foreach(var el in finalDish.Products)
                {
                    if (coef + el.Kkal <= Rules.Сonsumption.Kkal)
                    {
                        tempList.Add(el);
                    }
                }
                if (tempList.Count == 0)
                {
                    var minProduct = finalDish.Products.Min(x => x.Kkal);
                    var index = finalDish.Products.FindIndex( x => x.Kkal == minProduct);
                    finalDish.Products[index].Mass += 100;
                    finalDish.Products[index].Kkal = finalDish.Products[index].Kkal * 2;
                }
                else if (tempList.Count == 1)
                {
                    var index = finalDish.Products.FindIndex(x => x.Name == tempList[0].Name);
                    while (finalDish.Products.Sum(x => x.Kkal) + tempList[0].Kkal <= Rules.Сonsumption.Kkal)
                    {
                        finalDish.Products[index].Mass += 100;
                        finalDish.Products[index].Kkal += tempList[0].Kkal;
                    }
                }
                else
                {

                    while (tempList.Count != 0)
                    {
                        var twoTempList = new List<string>();
                        foreach (var el in tempList)
                        {
                            if (finalDish.Products.Sum(x => x.Kkal) + el.Kkal >= Rules.Сonsumption.Kkal)
                            {
                                twoTempList.Add(el.Name);
                            }
                        }
                        foreach (var el in twoTempList)
                            tempList.RemoveAt(tempList.FindIndex(x => x.Name == el));
                        if (tempList.Count == 0) 
                            break;
                        var maxProduct = tempList.Max(product => product.Kkal);
                        var maxKkalProductIndex = tempList.FindIndex(x => x.Kkal == maxProduct);
                        var index = finalDish.Products.FindIndex(x => x.Name == tempList[maxKkalProductIndex].Name);
                        while (finalDish.Products.Sum(x => x.Kkal) + tempList[maxKkalProductIndex].Kkal <= Rules.Сonsumption.Kkal)
                        {
                            finalDish.Products[index].Mass += 100;
                            finalDish.Products[index].Kkal += tempList[maxKkalProductIndex].Kkal;

                            //finalDish.Products[index].Kkal = finalDish.Products[index].Kkal * (finalDish.Products[index].Mass / 100);
                        }
                        tempList.RemoveAt(maxKkalProductIndex);
                    }
                }
            }
            return finalDish;
        }

        private IDay<double> ClearDay(IDay<double> day)
        {
            var tempDay = (IDay<double>)day.Clone();
            tempDay.Dishes.Clear();
            return tempDay;
        }

        public override IDay<double> GenerateDay()
        {
            IDay<double> tempDay = new DefaultDay();
            tempDay = ClearDay(tempDay);
            for (var i = 0; i < 5; i ++)
            {
                var dish = GenerateDish();
                tempDay.Dishes.Add(dish);
                tempDay.Dishes[i].Name = dish.DishName();
            }
            return tempDay;

        }

        public override IWeek<double> GenerateWeek()
        {
            var tempWeek = (IWeek<double>) Week.Clone();
            tempWeek.DayOfWeek.Clear();
            List<string> nameDays = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            foreach(var el in nameDays)
            {
                tempWeek.DayOfWeek.Add(el, GenerateDay());
            }
            return tempWeek;
        }
    }
}
