using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
	public class ShippingStatus
	{
        [Key]
        public int ShippingStatusId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }


        public ICollection<OrderShipping> OrderShippings { get; set; }

    }
}

