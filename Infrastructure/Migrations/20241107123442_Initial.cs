using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OrderManagment");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "OrderManagment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IssuedToClient = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentConfirmation = table.Column<bool>(type: "boolean", nullable: false),
                    Cancellation = table.Column<bool>(type: "boolean", nullable: false),
                    TotalSum = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    AutomobilesId = table.Column<Guid[]>(type: "uuid[]", nullable: true),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders",
                schema: "OrderManagment");
        }
    }
}
