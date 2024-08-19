using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<OrderShipping> OrderShippings { get; set; }
        public DbSet<ShippingStatus> ShippingStatuses { get; set; }
    }
	
}

