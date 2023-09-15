using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Delicious beef burger with lettuce, tomato, and cheese", "Burger", 9.99m, 1 },
                    { 2, "Margherita pizza with fresh mozzarella and basil", "Pizza", 12.99m, 1 },
                    { 3, "Spaghetti with homemade marinara sauce", "Pasta", 10.49m, 2 },
                    { 4, "Fresh garden salad with mixed greens and vinaigrette dressing", "Salad", 7.99m, 2 },
                    { 5, "Assorted sushi rolls with soy sauce and wasabi", "Sushi", 15.99m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 6, 1 },
                    { 3, 5, 2 },
                    { 4, 8, 2 },
                    { 5, 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2023, 9, 15, 17, 16, 24, 623, DateTimeKind.Local).AddTicks(4826), 1, 1 },
                    { 2, 2, 6, new DateTime(2023, 9, 16, 17, 16, 24, 623, DateTimeKind.Local).AddTicks(4847), 1, 2 },
                    { 3, 3, 5, new DateTime(2023, 9, 17, 17, 16, 24, 623, DateTimeKind.Local).AddTicks(4851), 2, 3 },
                    { 4, 4, 8, new DateTime(2023, 9, 18, 17, 16, 24, 623, DateTimeKind.Local).AddTicks(4854), 2, 4 },
                    { 5, 5, 6, new DateTime(2023, 9, 19, 17, 16, 24, 623, DateTimeKind.Local).AddTicks(4858), 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 15, 17, 16, 24, 622, DateTimeKind.Local).AddTicks(7480), 1, 45.99m },
                    { 2, 2, new DateTime(2023, 9, 16, 17, 16, 24, 622, DateTimeKind.Local).AddTicks(7548), 2, 62.50m },
                    { 3, 3, new DateTime(2023, 9, 17, 17, 16, 24, 622, DateTimeKind.Local).AddTicks(7552), 3, 37.25m },
                    { 4, 4, new DateTime(2023, 9, 18, 17, 16, 24, 622, DateTimeKind.Local).AddTicks(7555), 4, 89.75m },
                    { 5, 5, new DateTime(2023, 9, 19, 17, 16, 24, 622, DateTimeKind.Local).AddTicks(7558), 5, 55.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "ItemId", "MenuitemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 101, 1, 1, 2 },
                    { 2, 102, 2, 2, 1 },
                    { 3, 103, 3, 3, 3 },
                    { 4, 104, 4, 4, 2 },
                    { 5, 105, 5, 5, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);
        }
    }
}
