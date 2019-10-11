using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Quartzmin
{
    public static class DemoScheduler
    {
        public static async Task<IScheduler> Create(bool start = true)
        {
            var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            if (start)
                await scheduler.Start();

            return scheduler;
        }

        public class DummyJob : IJob
        {
            private static readonly Random Random = new Random();

            public async Task Execute(IJobExecutionContext context)
            {
                Debug.WriteLine("DummyJob > " + DateTime.Now);

                await Task.Delay(TimeSpan.FromSeconds(Random.Next(1, 20)));

                if (Random.Next(2) == 0)
                    throw new Exception("Fatal error example!");
            }
        }

        [DisallowConcurrentExecution, PersistJobDataAfterExecution]
        public class DisallowConcurrentJob : IJob
        {
            private static readonly Random Random = new Random();

            public async Task Execute(IJobExecutionContext context)
            {
                Debug.WriteLine("DisallowConcurrentJob > " + DateTime.Now);

                context.JobDetail.JobDataMap.Put("LastExecuted", DateTime.Now);

                await Task.Delay(TimeSpan.FromSeconds(Random.Next(1, 5)));

                if (Random.Next(4) == 0)
                    throw new Exception("Fatal error example!");
            }
        }
    }
}
