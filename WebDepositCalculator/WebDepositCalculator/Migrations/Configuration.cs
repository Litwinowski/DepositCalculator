namespace WebDepositCalculator.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebDepositCalculator.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebDepositCalculator.Models.WebDepositCalculatorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebDepositCalculator.Models.WebDepositCalculatorContext context)
        {
            context.Calculators.AddOrUpdate(c => c.ID,
                new Calculator() { ID = 1, CalculatorName = "Test Deposit Calculator 1", InterestRate = 3.95, MinDepositAmount = 10000, MaxDepositAmount = 50000, MinDurationInMonths = 6, MaxDurationInMonths = 60},
                new Calculator() { ID = 2, CalculatorName = "Test2 Deposit Calculator 1", InterestRate = 1.95, MinDepositAmount = 1000, MaxDepositAmount = 5000, MinDurationInMonths = 6, MaxDurationInMonths = 12}
            );
        }
    }
}
