using System;
using Application.DTOs;

namespace Application.Validation
{
	public class OrderShippingValidator : IValidator<OrderShippingDto>
    {
        public void Validate(OrderShippingDto orderShipping)
        {
            if (orderShipping == null)
                throw new Exception("OrderShipping cannot be null.");
            if (orderShipping.OrderId <= 0)
                throw new Exception("Order ID must be valid.");
            if (!orderShipping.IsActive)
                throw new Exception("OrderShipping must be active.");
        }
    }
}

