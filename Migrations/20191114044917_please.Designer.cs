﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fa19projectgroup16.DAL;

namespace fa19projectgroup16.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191114044917_please")]
    partial class please
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("fa19projectgroup16.Dispute", b =>
                {
                    b.Property<int>("DisputeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CorrectAmount");

                    b.Property<string>("CustomerComment");

                    b.Property<string>("ManagerComment");

                    b.Property<int>("Status");

                    b.Property<int?>("TransactionID");

                    b.HasKey("DisputeID");

                    b.HasIndex("TransactionID");

                    b.ToTable("Disputes");
                });

            modelBuilder.Entity("fa19projectgroup16.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .IsRequired();

                    b.Property<int>("AccountNumber");

                    b.Property<int>("AccountType");

                    b.Property<string>("AppUserId");

                    b.Property<decimal>("Balance");

                    b.Property<string>("Customer");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("AccountID");

                    b.HasIndex("AppUserId");

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Account");
                });

            modelBuilder.Entity("fa19projectgroup16.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("Is_Employed");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleInitial")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("fa19projectgroup16.Models.StockTransaction", b =>
                {
                    b.Property<int>("StockTransactionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfShares");

                    b.Property<decimal>("PurchasePrice");

                    b.Property<int?>("StockID");

                    b.Property<int?>("StockPortfolioAccountID");

                    b.HasKey("StockTransactionID");

                    b.HasIndex("StockID");

                    b.HasIndex("StockPortfolioAccountID");

                    b.ToTable("StockTransaction");
                });

            modelBuilder.Entity("fa19projectgroup16.Payee", b =>
                {
                    b.Property<int>("PayeeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("PayeeName");

                    b.Property<int>("PayeeType");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("Zip");

                    b.HasKey("PayeeID");

                    b.ToTable("Payees");
                });

            modelBuilder.Entity("fa19projectgroup16.Stock", b =>
                {
                    b.Property<int>("StockID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StockName");

                    b.Property<decimal>("StockPrice");

                    b.Property<string>("StockTicker");

                    b.Property<int>("StockType");

                    b.HasKey("StockID");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("fa19projectgroup16.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountID");

                    b.Property<decimal>("Amount");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("IRAAccountAccountID");

                    b.Property<int?>("PayeeID");

                    b.Property<int?>("StandardAccountAccountID");

                    b.Property<int?>("StockPortfolioAccountID");

                    b.Property<int>("TransactionType");

                    b.HasKey("TransactionID");

                    b.HasIndex("AccountID");

                    b.HasIndex("IRAAccountAccountID");

                    b.HasIndex("PayeeID");

                    b.HasIndex("StandardAccountAccountID");

                    b.HasIndex("StockPortfolioAccountID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("fa19projectgroup16.Models.IRAAccount", b =>
                {
                    b.HasBaseType("fa19projectgroup16.Models.Account");

                    b.HasDiscriminator().HasValue("IRAAccount");
                });

            modelBuilder.Entity("fa19projectgroup16.Models.StandardAccount", b =>
                {
                    b.HasBaseType("fa19projectgroup16.Models.Account");

                    b.HasDiscriminator().HasValue("StandardAccount");
                });

            modelBuilder.Entity("fa19projectgroup16.Models.StockPortfolio", b =>
                {
                    b.HasBaseType("fa19projectgroup16.Models.Account");

                    b.Property<bool>("BalancedStatus");

                    b.HasDiscriminator().HasValue("StockPortfolio");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("fa19projectgroup16.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("fa19projectgroup16.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("fa19projectgroup16.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("fa19projectgroup16.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("fa19projectgroup16.Dispute", b =>
                {
                    b.HasOne("fa19projectgroup16.Transaction")
                        .WithMany("Disputes")
                        .HasForeignKey("TransactionID");
                });

            modelBuilder.Entity("fa19projectgroup16.Models.Account", b =>
                {
                    b.HasOne("fa19projectgroup16.Models.AppUser", "AppUser")
                        .WithMany("Accounts")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("fa19projectgroup16.Models.StockTransaction", b =>
                {
                    b.HasOne("fa19projectgroup16.Stock", "Stock")
                        .WithMany("StockTransactions")
                        .HasForeignKey("StockID");

                    b.HasOne("fa19projectgroup16.Models.StockPortfolio", "StockPortfolio")
                        .WithMany("StockTransactions")
                        .HasForeignKey("StockPortfolioAccountID");
                });

            modelBuilder.Entity("fa19projectgroup16.Transaction", b =>
                {
                    b.HasOne("fa19projectgroup16.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("fa19projectgroup16.Models.IRAAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("IRAAccountAccountID");

                    b.HasOne("fa19projectgroup16.Payee", "Payee")
                        .WithMany()
                        .HasForeignKey("PayeeID");

                    b.HasOne("fa19projectgroup16.Models.StandardAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("StandardAccountAccountID");

                    b.HasOne("fa19projectgroup16.Models.StockPortfolio")
                        .WithMany("Transactions")
                        .HasForeignKey("StockPortfolioAccountID");
                });
#pragma warning restore 612, 618
        }
    }
}
