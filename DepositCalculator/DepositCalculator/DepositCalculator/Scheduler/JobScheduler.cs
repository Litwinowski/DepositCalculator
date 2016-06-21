using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepositCalculator.Scheduler
{
    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<SynchronizeJob>().Build();
            //ITrigger trigger = TriggerBuilder.Create().WithDailyTimeIntervalSchedule(s => s.StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))).Build();
            ITrigger trigger = TriggerBuilder.Create().WithSimpleSchedule(s => s.WithIntervalInSeconds(30).RepeatForever()).Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}