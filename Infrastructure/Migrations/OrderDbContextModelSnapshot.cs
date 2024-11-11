﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid[]>("AutomobilesId")
                        .HasColumnType("uuid[]");

                    b.Property<bool>("Cancellation")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("CustomerID")
                        .HasColumnType("uuid");

                    b.Property<int>("Discount")
                        .HasColumnType("integer");

                    b.Property<bool>("IssuedToClient")
                        .HasColumnType("boolean");

                    b.Property<bool>("PaymentConfirmation")
                        .HasColumnType("boolean");

                    b.Property<int>("TotalSum")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders", "OrderManagment");
                });
#pragma warning restore 612, 618
        }
    }
}
