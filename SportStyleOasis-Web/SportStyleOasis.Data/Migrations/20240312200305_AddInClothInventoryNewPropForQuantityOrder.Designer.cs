﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportStyleOasis.Data;

#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    [DbContext(typeof(SportStyleOasisDbContext))]
    [Migration("20240312200305_AddInClothInventoryNewPropForQuantityOrder")]
    partial class AddInClothInventoryNewPropForQuantityOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClotheInventoryShoppingCart", b =>
                {
                    b.Property<int>("ClotheInventoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartsId")
                        .HasColumnType("int");

                    b.HasKey("ClotheInventoriesId", "ShoppingCartsId");

                    b.HasIndex("ShoppingCartsId");

                    b.ToTable("ClotheInventoryShoppingCart");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProteinFlavorShoppingCart", b =>
                {
                    b.Property<int>("ProteinFlavorsId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartsId")
                        .HasColumnType("int");

                    b.HasKey("ProteinFlavorsId", "ShoppingCartsId");

                    b.HasIndex("ShoppingCartsId");

                    b.ToTable("ProteinFlavorShoppingCart");
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ClotheInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ClothId")
                        .HasColumnType("int");

                    b.Property<int?>("ClotheOrderQuantityId")
                        .HasColumnType("int");

                    b.Property<int?>("ClothesSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClothId");

                    b.HasIndex("ClotheOrderQuantityId");

                    b.ToTable("ClotheInventories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableQuantity = 10,
                            ClothId = 1,
                            ClothesSize = 4
                        },
                        new
                        {
                            Id = 2,
                            AvailableQuantity = 10,
                            ClothId = 2,
                            ClothesSize = 3
                        },
                        new
                        {
                            Id = 3,
                            AvailableQuantity = 10,
                            ClothId = 3,
                            ClothesSize = 0
                        },
                        new
                        {
                            Id = 4,
                            AvailableQuantity = 10,
                            ClothId = 3,
                            ClothesSize = 1
                        },
                        new
                        {
                            Id = 5,
                            AvailableQuantity = 10,
                            ClothId = 2,
                            ClothesSize = 2
                        });
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ClotheOrderQuantity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClothId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClotheOrderQuantities");
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.Clothes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClothesBrands")
                        .HasColumnType("int");

                    b.Property<int?>("ClothesForGender")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TypeOfClothes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clothes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClothesBrands = 0,
                            ClothesForGender = 0,
                            Color = "Gray",
                            Description = "This is test description about this tshirt",
                            Image = "gray_tshirt.jpg",
                            Name = "T-shirt-Gray",
                            Price = 13.99m,
                            TypeOfClothes = 0
                        },
                        new
                        {
                            Id = 2,
                            ClothesBrands = 3,
                            ClothesForGender = 0,
                            Color = "Black",
                            Description = "This is test description about this tshirt",
                            Image = "black_tshirt.jpg",
                            Name = "T-shirt-Black",
                            Price = 9.99m,
                            TypeOfClothes = 0
                        },
                        new
                        {
                            Id = 3,
                            ClothesBrands = 1,
                            ClothesForGender = 1,
                            Color = "White",
                            Description = "This is test description about this tshirt",
                            Image = "white_tshirt.jpg",
                            Name = "T-shirt-White",
                            Price = 10.99m,
                            TypeOfClothes = 0
                        });
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ProteinFlavor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FlavorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProteinId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProteinId");

                    b.ToTable("ProteinFlavor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FlavorName = "Iced Late",
                            ProteinId = 2,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            FlavorName = "Salted Caramel",
                            ProteinId = 2,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 3,
                            FlavorName = "Pistachio Ice Cream",
                            ProteinId = 2,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 4,
                            FlavorName = "Banana",
                            ProteinId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 5,
                            FlavorName = "Cookies & Cream",
                            ProteinId = 3,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ProteinPowder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProteinPowderBrands")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeForAddFlavor")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TypeOfProtein")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProteinPowder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Test description about protein powder",
                            Image = "impact_whey_protein.jpg",
                            Name = "Impact Whey Protein",
                            Price = 33.99m,
                            ProteinPowderBrands = 3,
                            TimeForAddFlavor = new DateTime(2024, 3, 12, 20, 3, 3, 944, DateTimeKind.Utc).AddTicks(9122),
                            TypeOfProtein = 0,
                            Weight = 1000
                        },
                        new
                        {
                            Id = 2,
                            Description = "Test description about protein powder",
                            Image = "bulk_isolate_protein.jpg",
                            Name = "Pure Whey Protein Isolate",
                            Price = 54.99m,
                            ProteinPowderBrands = 0,
                            TimeForAddFlavor = new DateTime(2024, 3, 12, 20, 3, 3, 944, DateTimeKind.Utc).AddTicks(9144),
                            TypeOfProtein = 2,
                            Weight = 1000
                        },
                        new
                        {
                            Id = 3,
                            Description = "Test description about protein powder",
                            Image = "proteinWorks_vegan_protein.jpg",
                            Name = "Vegan Protein",
                            Price = 11.99m,
                            ProteinPowderBrands = 5,
                            TimeForAddFlavor = new DateTime(2024, 3, 12, 20, 3, 3, 944, DateTimeKind.Utc).AddTicks(9148),
                            TypeOfProtein = 1,
                            Weight = 1000
                        });
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClothesId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProteinPowderId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClothesId");

                    b.HasIndex("ProteinPowderId");

                    b.ToTable("Review");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClothesId = 1,
                            Comment = "I really like the design and comfort of this gray T-shirt. Perfect for casual wear.",
                            CreatedAt = new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4482),
                            Rating = 4.5,
                            UserName = "TestUserName"
                        },
                        new
                        {
                            Id = 2,
                            ClothesId = 2,
                            Comment = "The black T-shirt fits well and has a nice price. Great for everyday use.",
                            CreatedAt = new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4491),
                            Rating = 4.0,
                            UserName = "TestUserName"
                        },
                        new
                        {
                            Id = 3,
                            ClothesId = 3,
                            Comment = "Absolutely love the style and feel of this white T-shirt. It's a must-have for any wardrobe!",
                            CreatedAt = new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4494),
                            Rating = 5.0,
                            UserName = "TestUserName"
                        },
                        new
                        {
                            Id = 4,
                            Comment = "Great taste and mixes well. Impact Whey is my go-to protein for post-workout recovery.",
                            CreatedAt = new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4497),
                            ProteinPowderId = 1,
                            Rating = 5.0,
                            UserName = "TestUserName"
                        },
                        new
                        {
                            Id = 5,
                            Comment = "Bulk Isolate Protein delivers excellent results. It's a bit pricey, but the quality is worth it.",
                            CreatedAt = new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4504),
                            ProteinPowderId = 2,
                            Rating = 4.7999999999999998,
                            UserName = "TestUserName"
                        },
                        new
                        {
                            Id = 6,
                            Comment = "As a vegan, I love ProteinWorks' Vegan Protein. Tastes great and meets my nutritional needs perfectly.",
                            CreatedAt = new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4507),
                            ProteinPowderId = 3,
                            Rating = 4.9000000000000004,
                            UserName = "TestUserName"
                        });
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("ClotheInventoryShoppingCart", b =>
                {
                    b.HasOne("SportStyleOasis.Data.Models.ClotheInventory", null)
                        .WithMany()
                        .HasForeignKey("ClotheInventoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportStyleOasis.Data.Models.ShoppingCart", null)
                        .WithMany()
                        .HasForeignKey("ShoppingCartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SportStyleOasis.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SportStyleOasis.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportStyleOasis.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SportStyleOasis.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProteinFlavorShoppingCart", b =>
                {
                    b.HasOne("SportStyleOasis.Data.Models.ProteinFlavor", null)
                        .WithMany()
                        .HasForeignKey("ProteinFlavorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportStyleOasis.Data.Models.ShoppingCart", null)
                        .WithMany()
                        .HasForeignKey("ShoppingCartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ClotheInventory", b =>
                {
                    b.HasOne("SportStyleOasis.Data.Models.Clothes", "Clothe")
                        .WithMany("ClotheInventories")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportStyleOasis.Data.Models.ClotheOrderQuantity", "ClotheOrderQuantity")
                        .WithMany()
                        .HasForeignKey("ClotheOrderQuantityId");

                    b.Navigation("Clothe");

                    b.Navigation("ClotheOrderQuantity");
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ProteinFlavor", b =>
                {
                    b.HasOne("SportStyleOasis.Data.Models.ProteinPowder", "Protein")
                        .WithMany("ProteinFlavors")
                        .HasForeignKey("ProteinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Protein");
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.Review", b =>
                {
                    b.HasOne("SportStyleOasis.Data.Models.Clothes", "Clothes")
                        .WithMany("Reviews")
                        .HasForeignKey("ClothesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportStyleOasis.Data.Models.ProteinPowder", "ProteinPowder")
                        .WithMany("Reviews")
                        .HasForeignKey("ProteinPowderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Clothes");

                    b.Navigation("ProteinPowder");
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ShoppingCart", b =>
                {
                    b.HasOne("SportStyleOasis.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("SportStyleOasis.Data.Models.ShoppingCart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("ShoppingCart")
                        .IsRequired();
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.Clothes", b =>
                {
                    b.Navigation("ClotheInventories");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("SportStyleOasis.Data.Models.ProteinPowder", b =>
                {
                    b.Navigation("ProteinFlavors");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
