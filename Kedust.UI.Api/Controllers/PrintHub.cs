using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Kedust.UI.Api.Controllers
{
    public class PrintHub : Hub
    {
        public Task JoinRoom(string eventId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, eventId);
        }

        public Task LeaveRoom(string eventId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, eventId);
        }


        public Task UpdatedCanOrder()
        {
            return Clients.All.SendAsync("updatedCanOrder");
        }
    }

    public interface IPrintSignal
    {
        Task NotifyNewOrder(int orderId, CancellationToken token);
        Task UpdatedCanOrder(CancellationToken token);
    }

    public class PrintSignal : IPrintSignal
    {
        private readonly IHubContext<PrintHub> _printHub;
        public PrintSignal(IHubContext<PrintHub> printHub) => _printHub = printHub;

        public async Task NotifyNewOrder(int orderId, CancellationToken token)
            => await _printHub.Clients.All.SendAsync("NotifyNewOrder", orderId, token);

        public async Task UpdatedCanOrder(CancellationToken token)
            => await _printHub.Clients.All.SendAsync("updatedCanOrder", token);
    }
}