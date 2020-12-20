﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTime.Dish;
using TableTime.Product;
using TableTime.Rules;

namespace TableTime.Day
{
    public class CustomDay : IDay<double>
    {
        private int countDay = 0;
        public int CountDay 
        { 
            get 
            {
                return countDay;
            }
            set 
            {
                if (value < 7)
                    countDay = value;
                else
                    countDay = value % 7;
            } 
        }

        private IRulesWithCustomAdditionals rules;
        public IRulesWithCustomAdditionals Rules {
            get
            {
                return rules;
            }
            set
            {
                rules = value;
                Сonsumption = rules.Сonsumption;
            }
        }
        public List<IDish<double>> Products { get; set; } = new List<IDish<double>>();

        private IProduct consumption;
        public IProduct Сonsumption
        {
            get
            {
                return consumption;
            }
            set
            {
                consumption = value;
            }
        }

        public CustomDay()
        {
            Rules = new DefaultRules();
        }
        public CustomDay(IRulesWithCustomAdditionals rules)
        {
            Rules = rules;

        }
    }
}