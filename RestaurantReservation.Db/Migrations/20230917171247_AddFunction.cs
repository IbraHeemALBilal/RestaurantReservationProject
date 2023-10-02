﻿using Microsoft.EntityFrameworkCore.Migrations;


namespace RestaurantReservation.Db.Migrations
{
    public partial class AddFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                CREATE FUNCTION dbo.CalculateTotalRevenue(@restaurantId INT)
                RETURNS DECIMAL(18, 2)
                AS
                BEGIN
                    DECLARE @totalRevenue DECIMAL(18, 2);
                    SELECT @totalRevenue = SUM(o.TotalAmount)
                    FROM Orders o
                    JOIN Reservations r ON o.ReservationId = r.ReservationId
                    WHERE r.RestaurantId = @restaurantId;

                    RETURN @totalRevenue;
                END
                "
            );
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.CalculateTotalRevenue");
        }
    }
}
