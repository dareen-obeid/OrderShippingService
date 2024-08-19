using System;
using Domain.Models;
using Domain.RepositoriyInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderShippingRepository : IOrderShippingRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderShippingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderShipping> GetOrderShippingByIdAsync(int orderShippingId)
        {
            return await _context.OrderShippings
                                 .Include(os => os.ShippingStatus)
                                 .FirstOrDefaultAsync(os => os.OrderShippingId == orderShippingId && os.IsActive);
        }

        public async Task<IEnumerable<OrderShipping>> GetAllOrderShippingsAsync()
        {
            return await _context.OrderShippings
                                 .Where(os => os.IsActive)
                                 .Include(os => os.ShippingStatus)
                                 .ToListAsync();
        }

        public async Task CreateOrderShippingAsync(OrderShipping orderShipping)
        {
            orderShipping.LastUpdatedDate = DateTime.Now;
            _context.OrderShippings.Add(orderShipping);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderShippingAsync(OrderShipping orderShipping)
        {
            orderShipping.LastUpdatedDate = DateTime.Now;
            _context.OrderShippings.Update(orderShipping);
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateOrderShippingAsync(int orderShippingId)
        {
            var orderShipping = await GetOrderShippingByIdAsync(orderShippingId);
            if (orderShipping != null)
            {
                orderShipping.IsActive = false;
                orderShipping.CreateDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateShippingStatusAsync(ShippingStatus shippingStatus)
        {
            _context.ShippingStatuses.Add(shippingStatus);
            await _context.SaveChangesAsync();
        }

        public async Task<ShippingStatus> GetShippingStatusByIdAsync(int shippingStatusId)
        {
            return await _context.ShippingStatuses
                                 .FirstOrDefaultAsync(ss => ss.ShippingStatusId == shippingStatusId);
        }
    }
}