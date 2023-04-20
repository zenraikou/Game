﻿// <auto-generated />
using System;
using Game.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Game.API.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Game.API.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Element")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = new Guid("64e7c953-87cb-4ec0-9adc-a6aa145a099b"),
                            Description = "A dagger crafted from the tooth of a Pure Silver Dragon.",
                            Element = 4,
                            Name = "Dagon",
                            Price = 0.99m,
                            Timestamp = new DateTime(2023, 4, 20, 7, 40, 23, 623, DateTimeKind.Utc).AddTicks(6103),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("f9447fa9-2d85-4a78-bcc3-c4b4f28d1e6e"),
                            Description = "A sword crafted from the talon of a Pure Silver Dragon.",
                            Element = 4,
                            Name = "Yasha",
                            Price = 1.99m,
                            Timestamp = new DateTime(2023, 4, 20, 7, 40, 23, 623, DateTimeKind.Utc).AddTicks(6127),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("53f528af-1f82-4e37-9876-7f25cf2f7481"),
                            Description = "A bow crafted from the wing of a Pure Silver Dragon.",
                            Element = 4,
                            Name = "Buriza",
                            Price = 2.99m,
                            Timestamp = new DateTime(2023, 4, 20, 7, 40, 23, 623, DateTimeKind.Utc).AddTicks(6135),
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("c2f90f2b-8568-4fb6-8c2c-7488a00b7681"),
                            Description = "A shield crafted from the scales of a Pure Silver Dragon.",
                            Element = 4,
                            Name = "Vanguard",
                            Price = 3.99m,
                            Timestamp = new DateTime(2023, 4, 20, 7, 40, 23, 623, DateTimeKind.Utc).AddTicks(6140),
                            Type = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
