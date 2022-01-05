﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using facturator_api.Models.Context;

namespace facturator_api.Migrations
{
    [DbContext(typeof(FacturatorDbContext))]
    [Migration("20220105144053_Client_Vendor_Login_First_Try")]
    partial class Client_Vendor_Login_First_Try
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("facturator_api.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BillId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("facturator_api.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VendorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("VendorId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("facturator_api.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientUniqueCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VendorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("facturator_api.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<int>("VendorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("facturator_api.Models.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Iban")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("facturator_api.Models.Article", b =>
                {
                    b.HasOne("facturator_api.Models.Bill", null)
                        .WithMany("Articles")
                        .HasForeignKey("BillId");
                });

            modelBuilder.Entity("facturator_api.Models.Bill", b =>
                {
                    b.HasOne("facturator_api.Models.Client", "Client")
                        .WithMany("Bills")
                        .HasForeignKey("ClientId");

                    b.HasOne("facturator_api.Models.Vendor", "Vendor")
                        .WithMany("Bills")
                        .HasForeignKey("VendorId");

                    b.Navigation("Client");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("facturator_api.Models.Client", b =>
                {
                    b.HasOne("facturator_api.Models.Vendor", null)
                        .WithMany("Clients")
                        .HasForeignKey("VendorId");
                });

            modelBuilder.Entity("facturator_api.Models.Login", b =>
                {
                    b.HasOne("facturator_api.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("facturator_api.Models.Bill", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("facturator_api.Models.Client", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("facturator_api.Models.Vendor", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
