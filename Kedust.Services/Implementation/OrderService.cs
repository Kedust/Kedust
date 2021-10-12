using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kedust.Data.Dal;
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
            var order = _mapper.Map<Data.Domain.Order>(saveOrder);
            order.TimeOrderPlaced = DateTime.Now;
            var orderEntity = await _orderRepo.Insert(order);
            return orderEntity.Id;
        }

        public async Task<OrderForPrinting> GetById(int id, CancellationToken token)
        {
            return _mapper.Map<OrderForPrinting>(await _orderRepo.GetById(id, order => order
                .Include(o => o.Table)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Choice)));
        }
    }
}