using Quartz;
using Quartz.Impl;

namespace AirportScheduler
{
    public class AirportLoaderScheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<AirportLoader>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("airportsLoader", "externalResorces")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
