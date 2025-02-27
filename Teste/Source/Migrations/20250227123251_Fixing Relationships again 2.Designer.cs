﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Source.Entities;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ParaLancheDbContext))]
    [Migration("20250227123251_Fixing Relationships again 2")]
    partial class FixingRelationshipsagain2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Server.Source.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InvitedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvitedByUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.Drink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ml")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.FinalOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("FinalOrder");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MealId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("MealId1");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderId1");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FinalOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderedDrinkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderedMealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FinalOrderId");

                    b.HasIndex("OrderedDrinkId");

                    b.HasIndex("OrderedMealId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Server.Source.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DrinkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DrinkId");

                    b.HasIndex("MealId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Server.Source.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Server.Source.Entities.ApplicationUser", "InvitedBy")
                        .WithMany("InvitedUsers")
                        .HasForeignKey("InvitedByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("InvitedBy");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.FinalOrder", b =>
                {
                    b.HasOne("Server.Source.Entities.ApplicationUser", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.Ingredient", b =>
                {
                    b.HasOne("Server.Source.Entities.Orders.Meal", null)
                        .WithMany("Additional")
                        .HasForeignKey("MealId");

                    b.HasOne("Server.Source.Entities.Orders.Meal", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("MealId1");

                    b.HasOne("Server.Source.Entities.Orders.Order", null)
                        .WithMany("Additional")
                        .HasForeignKey("OrderId");

                    b.HasOne("Server.Source.Entities.Orders.Order", null)
                        .WithMany("RemovedIngredients")
                        .HasForeignKey("OrderId1");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.Order", b =>
                {
                    b.HasOne("Server.Source.Entities.Orders.FinalOrder", null)
                        .WithMany("Orders")
                        .HasForeignKey("FinalOrderId");

                    b.HasOne("Server.Source.Entities.Orders.Drink", "OrderedDrink")
                        .WithMany()
                        .HasForeignKey("OrderedDrinkId");

                    b.HasOne("Server.Source.Entities.Orders.Meal", "OrderedMeal")
                        .WithMany()
                        .HasForeignKey("OrderedMealId");

                    b.Navigation("OrderedDrink");

                    b.Navigation("OrderedMeal");
                });

            modelBuilder.Entity("Server.Source.Entities.Review", b =>
                {
                    b.HasOne("Server.Source.Entities.Orders.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkId");

                    b.HasOne("Server.Source.Entities.Orders.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId");

                    b.HasOne("Server.Source.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("Meal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.Source.Entities.ApplicationUser", b =>
                {
                    b.Navigation("InvitedUsers");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.FinalOrder", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.Meal", b =>
                {
                    b.Navigation("Additional");

                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Server.Source.Entities.Orders.Order", b =>
                {
                    b.Navigation("Additional");

                    b.Navigation("RemovedIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
