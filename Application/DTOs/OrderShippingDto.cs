using System;
namespace Application.DTOs
{
	public class OrderShippingDto
	{
        public int OrderShippingId { get; set; }
        public int OrderId { get; set; }
        public ShippingStatusDto ShippingStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

