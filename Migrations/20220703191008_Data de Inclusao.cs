using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvangelionERP.Migrations
{
    public partial class DatadeInclusao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InclusionDate",
                table: "tab_financial",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InclusionDate",
                table: "tab_financial");
        }
    }
}
