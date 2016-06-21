using DepositCalculator.Containers;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepositCalculator.Scheduler
{
    public class UpdateDBJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            new CalculatorsContainer().UpdateCalculatorsDatabase();
        }
    }
}