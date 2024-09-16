﻿using DiscountGRPC.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DiscountGRPC.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } 
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = 1, 
                    ProductName = "Product 1",
                    Description = "Product 1 Desc",
                    Amount = 700
                },
                new Coupon
                {
                    Id = 2,
                    ProductName = "Product 2",
                    Description = "Product 2 Desc",
                    Amount = 700
                }
                );
        }

    }
}
