﻿// <auto-generated />
using EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameWork.Migrations
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

            modelBuilder.Entity("EntityFrameWork.Department", b =>
                {
                    b.Property<int>("deptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("deptName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("deptId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EntityFrameWork.Employee", b =>
                {
                    b.Property<int>("empId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("empLoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("empId");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
