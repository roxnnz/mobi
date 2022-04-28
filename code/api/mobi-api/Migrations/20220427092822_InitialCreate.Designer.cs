﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mobi_api.Services;

#nullable disable

namespace mobi_api.Migrations
{
    [DbContext(typeof(MobiConsumerContext))]
    [Migration("20220427092822_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("mobi_api.DAO.ProductEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StoreEntityStoreId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StoreId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId");

                    b.HasIndex("StoreEntityStoreId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("mobi_api.DAO.StoreEntity", b =>
                {
                    b.Property<Guid>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreName")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSite")
                        .HasColumnType("TEXT");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("mobi_api.DAO.ProductEntity", b =>
                {
                    b.HasOne("mobi_api.DAO.StoreEntity", null)
                        .WithMany("Products")
                        .HasForeignKey("StoreEntityStoreId");
                });

            modelBuilder.Entity("mobi_api.DAO.StoreEntity", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
