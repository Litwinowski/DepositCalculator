using DepositCalculator.Containers;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Web;

namespace DepositCalculator.Scheduler
{
    public class SynchronizeJob : IJob
    {
        private int resendingAttempts = 10;
        private int[] resendingIntervals = new int[] { 1, 2, 5, 10, 15, 30, 60, 120, 180, 360 };

        public void Execute(IJobExecutionContext context)
        {
            if (!new CalculatorsContainer().UpdateCalculatorsDatabase())
            {
                while (resendingAttempts > 0)
                {
                    Timer timer = new Timer(resendingIntervals[10 - resendingAttempts] * 60 * 1000);
                    timer.Elapsed += async (sender, e) => await HandleTimer();
                    resendingAttempts--;
                }

            }
        }

        public static Task HandleTimer()
        {
            new CalculatorsContainer().UpdateCalculatorsDatabase();
            return null;
        }
    }
}