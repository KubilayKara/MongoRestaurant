﻿// <auto-generated />
using Mango.Services.ProductsApi.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mango.Services.ProductApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220205205338_SeedProducts")]
    partial class SeedProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mango.Services.ProductsApi.DbContexts.Modals.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryName = "Kırtasite",
                            Description = "Kurşun Kalem",
                            ImageUrl = "",
                            Name = "Kalem",
                            Price = 5.0
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryName = "Kırtasite",
                            Description = "Pelikan",
                            ImageUrl = "",
                            Name = "Silgi",
                            Price = 4.0
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryName = "Kırtasite",
                            Description = "Harita Metod",
                            ImageUrl = "",
                            Name = "Defter",
                            Price = 4.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
