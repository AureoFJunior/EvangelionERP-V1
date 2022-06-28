using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UcsCrudV1.Migrations
{
    public partial class Dalee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_customer",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_customer", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "tab_employer",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_employer", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "tab_order",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductsQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_order", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "tab_products",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_products", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "tab_user",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicIdPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isLogged = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_user", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "tab_orders_itens",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCod = table.Column<int>(type: "int", nullable: false),
                    ProductCod = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_orders_itens", x => x.Cod);
                    table.ForeignKey(
                        name: "FK_tab_orders_itens_tab_order_OrderCod",
                        column: x => x.OrderCod,
                        principalTable: "tab_order",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_orders_itens_tab_products_ProductCod",
                        column: x => x.ProductCod,
                        principalTable: "tab_products",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_orders_itens_OrderCod",
                table: "tab_orders_itens",
                column: "OrderCod");

            migrationBuilder.CreateIndex(
                name: "IX_tab_orders_itens_ProductCod",
                table: "tab_orders_itens",
                column: "ProductCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_customer");

            migrationBuilder.DropTable(
                name: "tab_employer");

            migrationBuilder.DropTable(
                name: "tab_orders_itens");

            migrationBuilder.DropTable(
                name: "tab_user");

            migrationBuilder.DropTable(
                name: "tab_order");

            migrationBuilder.DropTable(
                name: "tab_products");
        }
    }
}
