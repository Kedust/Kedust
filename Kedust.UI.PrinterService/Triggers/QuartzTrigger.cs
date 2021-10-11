using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace Kedust.UI.PrinterService.Triggers
{
    public class QuartzTrigger
    {
        private readonly Config _config;
        
        public QuartzTrigger(Config config)
        {
            _config = config;
        }
        
        private static IScheduler _scheduler;

        public async void Start(CancellationToken token)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = await schedulerFactory.GetScheduler(token);
            await _scheduler.Start(token);
            JobDetailImpl jobDetail = new JobDetailImpl("Job1", "Group1", typeof(CronJob));
            CronTriggerImpl trigger = new CronTriggerImpl("Trigger1", "Group1", "0 * * * * ? *"); // http://www.cronmaker.com/
            await _scheduler.ScheduleJob(jobDetail, trigger, token);
            token.WaitHandle.WaitOne();
        }
        
        private class CronJob: IJob
        {
            public Task Execute(IJobExecutionContext context)
            {
                Console.WriteLine("In MyJob class");
                return Task.CompletedTask;
            }
        }
    }
}