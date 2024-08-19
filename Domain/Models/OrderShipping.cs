using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	public class OrderShipping
	{
        [Key]
        public int OrderShippingId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("ShippingStatus")]
        public int ShippingStatusId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public ShippingStatus ShippingStatus { get; set; }
    }
}

