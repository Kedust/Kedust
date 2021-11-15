using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace Kedust.UI.PrinterService.Triggers
{
    public class RetryPolicy : IRetryPolicy
    {
        public TimeSpan? NextRetryDelay(RetryContext retryContext) => new TimeSpan(0, 0, 3);
    }
}