﻿// <auto-generated />
using EntityFrameWorkTask18;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameWorkTask18.Migrations
{
    [DbContext(typeof(ContextClass))]
    partial class ContextClassModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("EntityFrameWorkTask18.OrderDetail", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("orderDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("orderQuantity")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<decimal>("productPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("orderId");

                    b.HasIndex("productId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("EntityFrameWorkTask18.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("productPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("productStock")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("EntityFrameWorkTask18.OrderDetail", b =>
                {
                    b.HasOne("EntityFrameWorkTask18.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EntityFrameWorkTask18.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
