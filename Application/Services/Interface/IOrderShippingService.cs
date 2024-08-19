using System;
using Application.DTOs;

namespace Application.Services.Interface
{
    public interface IOrderShippingService
    {
        Task<OrderShippingDto> GetOrderShippingByIdAsync(int orderShippingId);
        Task<IEnumerable<OrderShippingDto>> GetAllOrderShippingsAsync();
        Task CreateOrderShippingAsync(OrderShippingDto orderShippingDto);
        Task UpdateOrderShippingAsync(OrderShippingDto orderShippingDto);
        Task DeactivateOrderShippingAsync(int orderShippingId);
        Task CreateShippingStatusAsync(ShippingStatusDto shippingStatusDto);
    }

}

