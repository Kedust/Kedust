using System;
using System.Threading;
using System.Threading.Tasks;
using Kedust.Services.DTO;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Quartz.Spi;

namespace Kedust.UI.PrinterService.Triggers
{
    public class QuartzTrigger
    {
        private readonly IMyJobFactory _jobFactory;

        public QuartzTrigger(IMyJobFactory jobFactory)
        {
            _jobFactory = jobFactory;
        }

        private static IScheduler _scheduler;

        public async Task Start(CancellationToken token)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = await schedulerFactory.GetScheduler(token);
            _scheduler.JobFactory = _jobFactory;

            await _scheduler.Start(token);
            JobDetailImpl jobDetail = new JobDetailImpl("Job1", "Group1", typeof(PrintAllOrderJob));
            CronTriggerImpl
                trigger = new CronTriggerImpl("Trigger1", "Group1", "0 0/1 * 1/1 * ? *"); // http://www.cronmaker.com/
            await _scheduler.ScheduleJob(jobDetail, trigger, token);
            token.WaitHandle.WaitOne();
        }
    }

    public interface IPrintAllOrderJob : IJob
    {
    }

    public class PrintAllOrderJob : IPrintAllOrderJob
    {
        private readonly IOrderServiceClient _orderServiceClient;
        private readonly PrintService _printService;
        private readonly Config _config;

        public PrintAllOrderJob(IOrderServiceClient orderServiceClient, Config config, PrintService printService)
        {
            _orderServiceClient = orderServiceClient;
            _config = config;
            _printService = printService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var orders = await _orderServiceClient.GetAllOrders(context.CancellationToken);

                foreach (var order in orders)
                {
                    OrderForPrinting markedOrder =
                        await _orderServiceClient.GetOrder(order.Id, context.CancellationToken);
                    await _printService.PrintOrderTicket(markedOrder, _config);
                    await _orderServiceClient.SetPrinted(markedOrder.Id, context.CancellationToken);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public interface IMyJobFactory : IJobFactory
    {
    }

    public class MyJobFactory : IMyJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MyJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
            => _serviceProvider.GetService(bundle.JobDetail.JobType) as IJob;

        public void ReturnJob(IJob job)
        {
        }
    }
}