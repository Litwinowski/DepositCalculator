using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepositCalculator.Models
{
    public class Calculator
    {
        public int ID { get; set; }

        public string CalculatorName { get; set; }

        public double InterestRate { get; set; }

        public double MinDepositAmount { get; set; }

        public double MaxDepositAmount { get; set; }

        public int MinDurationInMonths { get; set; }

        public int MaxDurationInMonths { get; set; }
    }
}