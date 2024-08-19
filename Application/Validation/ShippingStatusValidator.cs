using System;
using Application.DTOs;

namespace Application.Validation
{
	public class ShippingStatusValidator : IValidator<ShippingStatusDto>
    {
        public void Validate(ShippingStatusDto shippingStatus)
        {
            if (string.IsNullOrEmpty(shippingStatus.Status))
                throw new Exception("The status field is required.");
        }
    }
}

