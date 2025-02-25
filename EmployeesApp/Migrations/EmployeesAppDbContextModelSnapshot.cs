﻿// <auto-generated />
using System;
using EmployeesApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeesApp.Migrations
{
    [DbContext(typeof(EmployeesAppDbContext))]
    partial class EmployeesAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeesApp.Models.Domain.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnnualLeaveDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("ContractDuration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DaysOfPaidLeave")
                        .HasColumnType("int");

                    b.Property<int?>("DaysOff")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsContractPermanent")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6338ed5-4ea1-4ceb-9bd6-f7675817f046"),
                            AnnualLeaveDays = 15,
                            ContractDuration = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DaysOfPaidLeave = 10,
                            DaysOff = 5,
                            Department = "IT",
                            EmployeeImageUrl = "https://cdn10.picryl.com/photo/2014/09/25/jp-henderson-staff-photo-with-american-flag-in-background-4ef34f-1024.jpg",
                            Gender = "M",
                            IsContractPermanent = true,
                            Name = "Ivan",
                            StartDateOfEmployment = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Horvat"
                        },
                        new
                        {
                            Id = new Guid("c828772b-96db-42ad-9fca-b62ae4f9720a"),
                            AnnualLeaveDays = 20,
                            ContractDuration = new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DaysOfPaidLeave = 15,
                            DaysOff = 3,
                            Department = "HR",
                            EmployeeImageUrl = "https://i.stack.imgur.com/Dm7uG.jpg",
                            Gender = "F",
                            IsContractPermanent = false,
                            Name = "Jana",
                            StartDateOfEmployment = new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Janić"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
