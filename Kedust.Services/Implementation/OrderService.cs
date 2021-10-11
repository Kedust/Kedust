using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AutoMapper;
using Kedust.Data.Dal;
using Kedust.Data.Domain;
using Kedust.Services.DTO;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepo _orderRepo;

        public OrderService(IMapper mapper, IOrderRepo orderRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
        }


        public async Task<int> Save(OrderForSaving saveOrder)
        {
            var orderEntity = await _orderRepo.Insert(_mapper.Map<Data.Domain.Order>(saveOrder));
            return orderEntity.Id;
        }

        public async Task<IEnumerable<OrderForPrinting>> PatchByStatus(OrderStatus status, OrderStatus newStatus)
        {
            var orders = await _orderRepo.GetByStatus(status);
            orders.ForEach(o => o.Status = newStatus);
            await _orderRepo.BulkUpdate(orders);
            return _mapper.Map<IEnumerable<OrderForPrinting>>(orders);
        }
    }
}