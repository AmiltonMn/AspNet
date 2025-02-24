﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Entities;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ParaLancheDbContext))]
    partial class ParaLancheDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Server.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InvitedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("InvitedByUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Server.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Server.Entities.ApplicationUser", "InvitedBy")
                        .WithMany("InvitedUsers")
                        .HasForeignKey("InvitedByUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("InvitedBy");
                });

            modelBuilder.Entity("Server.Entities.ApplicationUser", b =>
                {
                    b.Navigation("InvitedUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
