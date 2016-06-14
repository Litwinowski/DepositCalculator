namespace WebDepositCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calculators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CalculatorName = c.String(),
                        InterestRate = c.Double(nullable: false),
                        MinDepositAmount = c.Double(nullable: false),
                        MaxDepositAmount = c.Double(nullable: false),
                        MinDurationInMonths = c.Int(nullable: false),
                        MaxDurationInMonths = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Calculators");
        }
    }
}
