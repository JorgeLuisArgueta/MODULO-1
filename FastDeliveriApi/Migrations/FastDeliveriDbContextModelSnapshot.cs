﻿// <auto-generated />
using FastDeliveriApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FastDeliveriApi.Migrations
{
    [DbContext(typeof(FastDeliveriDbContext))]
    partial class FastDeliveriDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FastDeliveriApi.Entity.Custumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("text")
                        .HasColumnName("PhomeNumberCustumer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("custumers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Morazan",
                            Email = "JorgeArgueta@univo.edu.sv",
                            Name = "Jorge Argueta",
                            PhoneNumber = "7889-9639",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Address = "Morazan",
                            Email = "JavieraRamirez@univo.edu.sv",
                            Name = "Javier Ramirez",
                            PhoneNumber = "7999-9639",
                            Status = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
