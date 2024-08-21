﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using back_app_sr.Infra.Context;

#nullable disable

namespace back_app_sr.Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("back_app_sr.Domain.Models.Deliver.DeliveryRegisterModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeliveryRegister");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Deliver.ExternalOrderItensModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DeliveryRegisterId")
                        .HasColumnType("uuid");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ExternalOrderItens");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Items.AdditionalModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Additionals");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Items.AllowedAdditionalsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AdditionalId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalId");

                    b.HasIndex("ItemId");

                    b.ToTable("AllowedAdditionals");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Items.ItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Items.ItemOrderAdditionalModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AdditionalId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemOrderAdditional");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Payment.PaymentModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Changevalue")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsChangeRequested")
                        .HasColumnType("boolean");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RegisterId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TabModelId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RegisterId");

                    b.HasIndex("TabModelId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.QuickSale.QuickSaleItemModel", b =>
                {
                    b.Property<Guid>("QuickSaleItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<Guid>("QuickSaleId")
                        .HasColumnType("uuid");

                    b.HasKey("QuickSaleItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("QuickSaleId");

                    b.ToTable("QuickSaleItems");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.QuickSale.QuickSaleModel", b =>
                {
                    b.Property<Guid>("QuickSaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("QuickSaleId");

                    b.ToTable("QuickSales");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Tab.OrderItemsTabModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("TabId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("OrdersItemsTab");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Tab.TabModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TableNumber")
                        .HasColumnType("integer");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Tab");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.UserModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Items.AllowedAdditionalsModel", b =>
                {
                    b.HasOne("back_app_sr.Domain.Models.Items.AdditionalModel", "AdditionalModel")
                        .WithMany()
                        .HasForeignKey("AdditionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_app_sr.Domain.Models.Items.ItemModel", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalModel");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Items.ItemOrderAdditionalModel", b =>
                {
                    b.HasOne("back_app_sr.Domain.Models.Items.AdditionalModel", "AdditionalModel")
                        .WithMany()
                        .HasForeignKey("AdditionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_app_sr.Domain.Models.Items.ItemModel", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalModel");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Payment.PaymentModel", b =>
                {
                    b.HasOne("back_app_sr.Domain.Models.Deliver.DeliveryRegisterModel", null)
                        .WithMany("Payments")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_app_sr.Domain.Models.Tab.TabModel", null)
                        .WithMany("Payments")
                        .HasForeignKey("TabModelId");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.QuickSale.QuickSaleItemModel", b =>
                {
                    b.HasOne("back_app_sr.Domain.Models.Items.ItemModel", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_app_sr.Domain.Models.QuickSale.QuickSaleModel", "QuickSaleModel")
                        .WithMany("QuickSaleItems")
                        .HasForeignKey("QuickSaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("QuickSaleModel");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Deliver.DeliveryRegisterModel", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.QuickSale.QuickSaleModel", b =>
                {
                    b.Navigation("QuickSaleItems");
                });

            modelBuilder.Entity("back_app_sr.Domain.Models.Tab.TabModel", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
