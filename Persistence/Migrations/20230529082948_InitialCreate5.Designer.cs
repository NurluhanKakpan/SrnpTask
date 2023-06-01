﻿// <auto-generated />
using System.Collections.Generic;
using Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Core.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230529082948_InitialCreate5")]
    partial class InitialCreate5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "hstore");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.SrnpInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<int>("GovCode")
                        .HasColumnType("integer");

                    b.Property<string[]>("GrnzType")
                        .HasColumnType("text[]");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("Regex")
                        .HasColumnType("text");

                    b.Property<int>("Region")
                        .HasColumnType("integer");

                    b.Property<int>("Series")
                        .HasColumnType("integer");

                    b.Property<string[]>("SrnpCode")
                        .HasColumnType("text[]");

                    b.Property<Dictionary<string, string>>("SrnpTypeCode")
                        .HasColumnType("hstore");

                    b.Property<string[]>("TechCategory")
                        .HasColumnType("text[]");

                    b.Property<string[]>("TypePerson")
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.ToTable("SrnpInfos");
                });

            modelBuilder.Entity("Core.Domain.SrnpPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsSameLetter")
                        .HasColumnType("boolean");

                    b.Property<string[]>("Numbers")
                        .HasColumnType("text[]");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.Property<int>("PriceCategory")
                        .HasColumnType("integer");

                    b.Property<string>("PriceInMci")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SrnpPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
