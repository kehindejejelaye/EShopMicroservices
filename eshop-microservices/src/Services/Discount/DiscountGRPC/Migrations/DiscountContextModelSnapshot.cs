﻿// <auto-generated />
using DiscountGRPC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiscountGRPC.Migrations
{
    [DbContext(typeof(DiscountContext))]
    partial class DiscountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("DiscountGRPC.Models.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 700,
                            Description = "Product 1 Desc",
                            ProductName = "Product 1"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 700,
                            Description = "Product 2 Desc",
                            ProductName = "Product 2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
