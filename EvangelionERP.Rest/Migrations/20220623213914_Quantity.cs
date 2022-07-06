using Microsoft.EntityFrameworkCore.Migrations;

namespace EvangelionERP.Migrations
{
    public partial class Quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "tab_products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "FlOutput",
                table: "tab_orders_itens",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "tab_products");

            migrationBuilder.DropColumn(
                name: "FlOutput",
                table: "tab_orders_itens");
        }
    }
}
