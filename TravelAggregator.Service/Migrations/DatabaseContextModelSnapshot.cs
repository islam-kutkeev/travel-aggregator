﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TravelAggregator.Service.Entities;

#nullable disable

namespace TravelAggregator.Service.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TravelAggregator.Service.Entities.Reservation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("company");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("TicketNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ticket_number");

                    b.Property<string>("UserIdentifier")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_identifier");

                    b.HasKey("Id");

                    b.ToTable("reservation");
                });
#pragma warning restore 612, 618
        }
    }
}
