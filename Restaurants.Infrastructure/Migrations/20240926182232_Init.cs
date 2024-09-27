using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "Restaurant",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                HasDelivery = table.Column<bool>(type: "bit", nullable: false),
                ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Address_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Address_CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table => _ = table.PrimaryKey("PK_Restaurant", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "Dish",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                RestaurantId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Dish", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Dish_Restaurant_RestaurantId",
                    column: x => x.RestaurantId,
                    principalTable: "Restaurant",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "IX_Dish_RestaurantId",
            table: "Dish",
            column: "RestaurantId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "Dish");

        _ = migrationBuilder.DropTable(
            name: "Restaurant");
    }
}
