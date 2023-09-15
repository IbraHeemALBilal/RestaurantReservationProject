﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db.Entities;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    [Migration("20230914141625_SeedAllData")]
    partial class SeedAllData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "john@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "jane@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            PhoneNumber = "987-654-3210"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "alice@example.com",
                            FirstName = "Alice",
                            LastName = "Johnson",
                            PhoneNumber = "555-555-5555"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "bob@example.com",
                            FirstName = "Bob",
                            LastName = "Williams",
                            PhoneNumber = "777-777-7777"
                        },
                        new
                        {
                            CustomerId = 5,
                            Email = "eva@example.com",
                            FirstName = "Eva",
                            LastName = "Brown",
                            PhoneNumber = "888-888-8888"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            Position = "Server",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "Jane",
                            LastName = "Smith",
                            Position = "Chef",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstName = "Alice",
                            LastName = "Johnson",
                            Position = "Server",
                            RestaurantId = 2
                        },
                        new
                        {
                            EmployeeId = 4,
                            FirstName = "Bob",
                            LastName = "Williams",
                            Position = "Bartender",
                            RestaurantId = 2
                        },
                        new
                        {
                            EmployeeId = 5,
                            FirstName = "Eva",
                            LastName = "Brown",
                            Position = "Manager",
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            Description = "Delicious beef burger with lettuce, tomato, and cheese",
                            Name = "Burger",
                            Price = 9.99m,
                            RestaurantId = 1
                        },
                        new
                        {
                            MenuItemId = 2,
                            Description = "Margherita pizza with fresh mozzarella and basil",
                            Name = "Pizza",
                            Price = 12.99m,
                            RestaurantId = 1
                        },
                        new
                        {
                            MenuItemId = 3,
                            Description = "Spaghetti with homemade marinara sauce",
                            Name = "Pasta",
                            Price = 10.49m,
                            RestaurantId = 2
                        },
                        new
                        {
                            MenuItemId = 4,
                            Description = "Fresh garden salad with mixed greens and vinaigrette dressing",
                            Name = "Salad",
                            Price = 7.99m,
                            RestaurantId = 2
                        },
                        new
                        {
                            MenuItemId = 5,
                            Description = "Assorted sushi rolls with soy sauce and wasabi",
                            Name = "Sushi",
                            Price = 15.99m,
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2023, 9, 15, 17, 16, 24, 622, DateTimeKind.Local).AddTicks(7480),
                            ReservationId = 1,
                            TotalAmount = 45.99m
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2023, 9, 16, 17, 16, 24, 622, DateTimeKind.Local).AddTicks(7548),
                            ReservationId = 2,
                            TotalAmount = 62.50m
                        },
                        new
                        {
                            OrderId = 3,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2023, 9, 17, 17, 16, 24, 622, DateTimeKind.Local).AddTicks(7552),
                            ReservationId = 3,
                            TotalAmount = 37.25m
                        },
                        new
                        {
                            OrderId = 4,
                            EmployeeId = 4,
                            OrderDate = new DateTime(2023, 9, 18, 17, 16, 24, 622, DateTimeKind.Local).AddTicks(7555),
                            ReservationId = 4,
                            TotalAmount = 89.75m
                        },
                        new
                        {
                            OrderId = 5,
                            EmployeeId = 5,
                            OrderDate = new DateTime(2023, 9, 19, 17, 16, 24, 622, DateTimeKind.Local).AddTicks(7558),
                            ReservationId = 5,
                            TotalAmount = 55.00m
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("MenuitemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("MenuitemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            ItemId = 101,
                            MenuitemId = 1,
                            OrderId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 2,
                            ItemId = 102,
                            MenuitemId = 2,
                            OrderId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 3,
                            ItemId = 103,
                            MenuitemId = 3,
                            OrderId = 3,
                            Quantity = 3
                        },
                        new
                        {
                            OrderItemId = 4,
                            ItemId = 104,
                            MenuitemId = 4,
                            OrderId = 4,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 5,
                            ItemId = 105,
                            MenuitemId = 5,
                            OrderId = 5,
                            Quantity = 4
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerId = 1,
                            PartySize = 4,
                            ReservationDate = new DateTime(2023, 9, 15, 17, 16, 24, 623, DateTimeKind.Local).AddTicks(4826),
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            ReservationId = 2,
                            CustomerId = 2,
                            PartySize = 6,
                            ReservationDate = new DateTime(2023, 9, 16, 17, 16, 24, 623, DateTimeKind.Local).AddTicks(4847),
                            RestaurantId = 1,
                            TableId = 2
                        },
                        new
                        {
                            ReservationId = 3,
                            CustomerId = 3,
                            PartySize = 5,
                            ReservationDate = new DateTime(2023, 9, 17, 17, 16, 24, 623, DateTimeKind.Local).AddTicks(4851),
                            RestaurantId = 2,
                            TableId = 3
                        },
                        new
                        {
                            ReservationId = 4,
                            CustomerId = 4,
                            PartySize = 8,
                            ReservationDate = new DateTime(2023, 9, 18, 17, 16, 24, 623, DateTimeKind.Local).AddTicks(4854),
                            RestaurantId = 2,
                            TableId = 4
                        },
                        new
                        {
                            ReservationId = 5,
                            CustomerId = 5,
                            PartySize = 6,
                            ReservationDate = new DateTime(2023, 9, 19, 17, 16, 24, 623, DateTimeKind.Local).AddTicks(4858),
                            RestaurantId = 3,
                            TableId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1,
                            Address = "123 Main St",
                            Name = "Restaurant 1",
                            OpeningHours = "Mon-Sat: 8 AM - 10 PM",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            RestaurantId = 2,
                            Address = "456 Elm St",
                            Name = "Restaurant 2",
                            OpeningHours = "Mon-Fri: 9 AM - 9 PM",
                            PhoneNumber = "987-654-3210"
                        },
                        new
                        {
                            RestaurantId = 3,
                            Address = "789 Oak St",
                            Name = "Restaurant 3",
                            OpeningHours = "Tue-Sun: 7 AM - 11 PM",
                            PhoneNumber = "555-555-5555"
                        },
                        new
                        {
                            RestaurantId = 4,
                            Address = "101 Pine St",
                            Name = "Restaurant 4",
                            OpeningHours = "Wed-Mon: 10 AM - 8 PM",
                            PhoneNumber = "777-777-7777"
                        },
                        new
                        {
                            RestaurantId = 5,
                            Address = "222 Cedar St",
                            Name = "Restaurant 5",
                            OpeningHours = "Thu-Sun: 9 AM - 7 PM",
                            PhoneNumber = "888-888-8888"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Capacity = 4,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 2,
                            Capacity = 6,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 3,
                            Capacity = 5,
                            RestaurantId = 2
                        },
                        new
                        {
                            TableId = 4,
                            Capacity = 8,
                            RestaurantId = 2
                        },
                        new
                        {
                            TableId = 5,
                            Capacity = 6,
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Order", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Entities.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.MenuItem", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuitemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Entities.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Table", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
