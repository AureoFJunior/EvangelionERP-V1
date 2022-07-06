using Microsoft.EntityFrameworkCore.Migrations;

namespace EvangelionERP.Migrations
{
    public partial class Tomamadera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FlOutput",
                table: "tab_order",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlOutput",
                table: "tab_order");
        }
    }
}
