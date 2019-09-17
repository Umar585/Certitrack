﻿// <auto-generated />
using System;
using Certitrack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Certitrack.Migrations
{
    [DbContext(typeof(CertitrackContext))]
    [Migration("20190917204723_staging")]
    partial class staging
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Certitrack.Models.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CertificateNo")
                        .HasColumnName("certificate_no")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime>("DateIssued")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DATE_issued")
                        .HasColumnType("date")
                        .HasDefaultValueSql("(CONVERT([date],getdate()))");

                    b.Property<DateTime?>("DateRedeemed")
                        .HasColumnName("DATE_redeemed")
                        .HasColumnType("date");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnName("expiry_DATE")
                        .HasColumnType("date");

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id");

                    b.ToTable("certificate");
                });

            modelBuilder.Entity("Certitrack.Models.CertificateLink", b =>
                {
                    b.Property<int>("CertificateId")
                        .HasColumnName("certificate_id");

                    b.Property<int?>("ChannelId")
                        .HasColumnName("channel_id");

                    b.Property<int?>("CustomerId")
                        .HasColumnName("customer_id");

                    b.Property<int?>("PromotionId")
                        .HasColumnName("promotion_id");

                    b.Property<int?>("StaffId")
                        .HasColumnName("staff_id");

                    b.HasKey("CertificateId");

                    b.HasIndex("ChannelId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PromotionId");

                    b.HasIndex("StaffId");

                    b.ToTable("certificate_link");
                });

            modelBuilder.Entity("Certitrack.Models.Channel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChannelName")
                        .IsRequired()
                        .HasColumnName("channel")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("channel");
                });

            modelBuilder.Entity("Certitrack.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Certitrack.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnName("customer_id");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Certitrack.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CertificateId")
                        .HasColumnName("certificate_id");

                    b.Property<int>("OrderId")
                        .HasColumnName("order_id");

                    b.HasKey("Id");

                    b.HasIndex("CertificateId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_item");
                });

            modelBuilder.Entity("Certitrack.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Discount")
                        .HasColumnName("discount");

                    b.HasKey("Id");

                    b.ToTable("promotion");
                });

            modelBuilder.Entity("Certitrack.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Certitrack.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("staff");
                });

            modelBuilder.Entity("Certitrack.Models.StaffLink", b =>
                {
                    b.Property<int>("StaffId")
                        .HasColumnName("staff_id");

                    b.Property<int>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<int>("StaffTypeId")
                        .HasColumnName("staff_type_id");

                    b.HasKey("StaffId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StaffTypeId");

                    b.ToTable("staff_link");
                });

            modelBuilder.Entity("Certitrack.Models.StaffType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type")
                        .HasMaxLength(45)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("staff_type");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Certitrack.Models.CertificateLink", b =>
                {
                    b.HasOne("Certitrack.Models.Certificate", "Certificate")
                        .WithOne("CertificateLink")
                        .HasForeignKey("Certitrack.Models.CertificateLink", "CertificateId")
                        .HasConstraintName("FK_certificate_cLink");

                    b.HasOne("Certitrack.Models.Channel", "Channel")
                        .WithMany("CertificateLink")
                        .HasForeignKey("ChannelId")
                        .HasConstraintName("FK_channel_cLink")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Certitrack.Models.Customer", "Customer")
                        .WithMany("CertificateLink")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_customer_cLink");

                    b.HasOne("Certitrack.Models.Promotion", "Promotion")
                        .WithMany("CertificateLink")
                        .HasForeignKey("PromotionId")
                        .HasConstraintName("FK_promotion_cLink");

                    b.HasOne("Certitrack.Models.Staff", "Staff")
                        .WithMany("CertificateLink")
                        .HasForeignKey("StaffId")
                        .HasConstraintName("FK_staff_cLink");
                });

            modelBuilder.Entity("Certitrack.Models.Order", b =>
                {
                    b.HasOne("Certitrack.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_customer_order")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Certitrack.Models.OrderItem", b =>
                {
                    b.HasOne("Certitrack.Models.Certificate", "Certificate")
                        .WithMany("OrderItem")
                        .HasForeignKey("CertificateId")
                        .HasConstraintName("FK_certificate_oItem")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Certitrack.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_order_oItem")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Certitrack.Models.StaffLink", b =>
                {
                    b.HasOne("Certitrack.Models.Role", "Role")
                        .WithMany("StaffLink")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_role_sLink");

                    b.HasOne("Certitrack.Models.Staff", "Staff")
                        .WithOne("StaffLink")
                        .HasForeignKey("Certitrack.Models.StaffLink", "StaffId")
                        .HasConstraintName("FK_staff_sLink");

                    b.HasOne("Certitrack.Models.StaffType", "StaffType")
                        .WithMany("StaffLink")
                        .HasForeignKey("StaffTypeId")
                        .HasConstraintName("FK_staff_type_sLink")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Certitrack.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Certitrack.Models.Staff")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Certitrack.Models.Staff")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Certitrack.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Certitrack.Models.Staff")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Certitrack.Models.Staff")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
