using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDepositCalculator.Models
{
    public class Calculator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string CalculatorName { get; set; }

        public double InterestRate { get; set; }

        public double MinDepositAmount { get; set; }

        public double MaxDepositAmount { get; set; }

        public int MinDurationInMonths { get; set; }

        public int MaxDurationInMonths { get; set; }
    }
}