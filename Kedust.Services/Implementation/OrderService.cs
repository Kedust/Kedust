using System;
using System.Collections.Generic;
using System.Threading;
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
            var order = _mapper.Map<Data.Domain.Order>(saveOrder);
            order.TimeOrderPlaced = DateTime.Now;
            var orderEntity = await _orderRepo.Insert(order);
            return orderEntity.Id;
        }

        public async Task<OrderForPrinting> GetByIdForPrinting(int id, CancellationToken token)
        {
            await MarkPrinting(id, token);
            return _mapper.Map<OrderForPrinting>(await _orderRepo.GetById(id, order => order
                .Include(o => o.Table)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Choice)));
        }
        public async Task<List<OrderForPrinting>> GetAllForPrinting(CancellationToken token)
        {
            return _mapper.Map<List<OrderForPrinting>>(await _orderRepo.GetAllForPrinting(token, order => order
                .Include(o => o.Table)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Choice)));
        }

        private async Task MarkPrinting(int id, CancellationToken token)
        {
            var order = await _orderRepo.GetById(id);
            if (order.Status > OrderStatus.New)
                throw new Exception("Order not printable");
            order.Status = OrderStatus.Printing;
            await _orderRepo.Update(order);
        }

        public async Task MarkPrinted(int id, CancellationToken token)
        {
            var order = await _orderRepo.GetById(id);
            order.Status = OrderStatus.Completed;
            await _orderRepo.Update(order);
        }

        public async Task<List<OrderForPrinting>> GetAll(DateTime from, DateTime till, CancellationToken token)
        {
            return _mapper.Map<List<OrderForPrinting>>(await _orderRepo.GetAll(from, till, token, order => order
                .Include(o => o.Table)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Choice)));
        }
    }
}