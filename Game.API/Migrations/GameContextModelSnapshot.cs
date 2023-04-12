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

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Element")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1ebc725c-b1ec-43a4-8be8-a700a17b769d"),
                            Category = 0,
                            Description = "A dagger crafted from the tooth of a Pure Silver Dragon.",
                            Element = 4,
                            Name = "Dagon",
                            Price = 0.99m,
                            Timestamp = new DateTime(2023, 4, 12, 8, 22, 25, 753, DateTimeKind.Utc).AddTicks(6224)
                        },
                        new
                        {
                            Id = new Guid("9334aa54-06f3-4f0e-a708-39cdd532bbe0"),
                            Category = 1,
                            Description = "A sword crafted from the talon of a Pure Silver Dragon.",
                            Element = 4,
                            Name = "Yasha",
                            Price = 1.99m,
                            Timestamp = new DateTime(2023, 4, 12, 8, 22, 25, 753, DateTimeKind.Utc).AddTicks(6243)
                        },
                        new
                        {
                            Id = new Guid("b85f4500-d4e1-4a86-8c9a-495725d00d7d"),
                            Category = 2,
                            Description = "A bow crafted from the wing of a Pure Silver Dragon.",
                            Element = 4,
                            Name = "Buriza",
                            Price = 2.99m,
                            Timestamp = new DateTime(2023, 4, 12, 8, 22, 25, 753, DateTimeKind.Utc).AddTicks(6302)
                        },
                        new
                        {
                            Id = new Guid("69739a03-4441-4e51-a2dd-a611848ffbe3"),
                            Category = 3,
                            Description = "A shield crafted from the scales of a Pure Silver Dragon.",
                            Element = 4,
                            Name = "Vanguard",
                            Price = 3.99m,
                            Timestamp = new DateTime(2023, 4, 12, 8, 22, 25, 753, DateTimeKind.Utc).AddTicks(6307)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
