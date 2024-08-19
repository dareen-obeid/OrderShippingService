using System;
using Domain.Models;

namespace Domain.RepositoriyInterfaces
{
    public interface IOrderShippingRepository
    {
        Task<OrderShipping> GetOrderShippingByIdAsync(int orderShippingId);
        Task<IEnumerable<OrderShipping>> GetAllOrderShippingsAsync();
        Task CreateOrderShippingAsync(OrderShipping orderShipping);
        Task UpdateOrderShippingAsync(OrderShipping orderShipping);
        Task DeactivateOrderShippingAsync(int orderShippingId);
        Task CreateShippingStatusAsync(ShippingStatus shippingStatus);
        Task<ShippingStatus> GetShippingStatusByIdAsync(int shippingStatusId);

    }

}

