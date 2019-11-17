﻿// <auto-generated />
using System;
using IAmThereApi.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IAmThereApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IAmThereApi.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaSize");

                    b.Property<Guid>("GroupId");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .IsUnique();

                    b.ToTable("PlaceLocation");
                });

            modelBuilder.Entity("IAmThereApi.Models.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatorId");

                    b.Property<string>("GroupName")
                        .IsRequired();

                    b.Property<int>("PlaceLocationId");

                    b.HasKey("GroupId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("IAmThereApi.Models.LastKnownLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("LastKnownLocation");
                });

            modelBuilder.Entity("IAmThereApi.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<float>("Latitude");

                    b.Property<string>("LocationDefinitionMode")
                        .IsRequired();

                    b.Property<float>("Longitude");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("IAmThereApi.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("UserId");

                    b.HasAlternateKey("Email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("IAmThereApi.Models.UserGroup", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("GroupId");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("IAmThereApi.Models.Area", b =>
                {
                    b.HasOne("IAmThereApi.Models.Group", "Group")
                        .WithOne("Area")
                        .HasForeignKey("IAmThereApi.Models.Area", "GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IAmThereApi.Models.Group", b =>
                {
                    b.HasOne("IAmThereApi.Models.User", "Creator")
                        .WithMany("CreatedGroups")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IAmThereApi.Models.LastKnownLocation", b =>
                {
                    b.HasOne("IAmThereApi.Models.User")
                        .WithOne("LastKnownLocation")
                        .HasForeignKey("IAmThereApi.Models.LastKnownLocation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IAmThereApi.Models.Location", b =>
                {
                    b.HasOne("IAmThereApi.Models.User", "User")
                        .WithMany("Locations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IAmThereApi.Models.UserGroup", b =>
                {
                    b.HasOne("IAmThereApi.Models.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IAmThereApi.Models.User", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
